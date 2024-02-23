using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmailNotificationFeature.Models;
using EmailNotificationFeature.Services.EmailNotificationService;
using EmailNotificationFeature.Services;

namespace EmailNotificationFeature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController : ControllerBase
    {
        private readonly IPasswordResetService _passwordResetService;

        public PasswordResetController(IPasswordResetService passwordResetService)
        {
            _passwordResetService = passwordResetService;
        }

        [HttpPost]
        public IActionResult SendPasswordResetEmail([FromBody] PasswordResetDto data)
        {
            _passwordResetService.SendPasswordResetEmail(data);
            return Ok();
        }
    }
}
