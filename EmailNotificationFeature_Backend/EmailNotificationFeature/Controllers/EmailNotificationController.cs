using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EmailNotificationFeature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailNotificationController : ControllerBase
    {

        private readonly IEmailNotificationService _emailNotificationService;


        public EmailNotificationController(IEmailNotificationService emailNotificationService)
        {
            _emailNotificationService = emailNotificationService;
        }
        [HttpPost]
        public IActionResult SendEmail([FromBody] EmailDto request) 
        {
            _emailNotificationService.SendEmail(request);
            return Ok();
        }
    }
}
