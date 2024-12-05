using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FARSOUND.Application.Services;
using FARSOUND.Application.Models;

namespace FARSOUND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private object id;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(
            InsertUpdateUser insertUser
            )
        {
            var userId = await _userService.InsertAsync(insertUser);

            return Created(string.Empty, new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,
               InsertUpdateUser updateUser
                )
        {
            await _userService.UpdateAsync(id, updateUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
