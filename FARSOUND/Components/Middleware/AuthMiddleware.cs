using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace FARSOUND.Components.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate next; // Delegate to the next middleware in the pipeline

        // Static dictionary to store logins with a unique Guid as the key and ClaimsPrincipal as the value
        public static IDictionary<Guid, ClaimsPrincipal> Logins { get; private set; }
            = new ConcurrentDictionary<Guid, ClaimsPrincipal>();

        // Constructor to initialize the middleware with the next delegate
        public AuthMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next)); // Ensure 'next' is not null
        }

        // Method to handle the HTTP request
        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the request path is "/login" and contains a "key" query parameter
            if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
            {
                var key = Guid.Parse(context.Request.Query["key"]); // Parse the key from the query parameter
                var claim = Logins[key]; // Retrieve the ClaimsPrincipal associated with the key
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claim); // Sign in the user
                context.Response.Redirect("/"); // Redirect to the home page
            }
            else
            {
                await next(context); // Call the next middleware in the pipeline
            }
        }
    }
}
