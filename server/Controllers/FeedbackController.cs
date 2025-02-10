using Server.DTOs;
using Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/feedback")]
    public class FeedbackController : ControllerBase
    {
        private readonly EmailService _emailService;

        public FeedbackController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SubmitFeedback([FromBody] FeedbackRequest feedback)
        {
            if (string.IsNullOrEmpty(feedback.Email) || string.IsNullOrEmpty(feedback.Rating))
            {
                return BadRequest("Email y valoración son obligatorios.");
            }

            _emailService.SendFeedbackEmail(feedback.Email, feedback.Rating);
            return Ok("Feedback enviado con éxito.");
        }
    }
}