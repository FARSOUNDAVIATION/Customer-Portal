using FARSOUND.Application.Context;
using FARSOUND.Application.Services;
using FARSOUND.Components;
using FARSOUND.Infrastructure;
using Microsoft.EntityFrameworkCore;
//using FARSOUND.Context;
//using FARSOUND.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<IFARSOUNDDbContext,FARSOUNDDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FARSOUNDDbContext"));
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<FARSOUNDDbContext>();

    if (!dbContext.Database.CanConnect())
    {
        throw new NotImplementedException("Can't connect to DB");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
