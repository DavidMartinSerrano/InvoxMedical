using InvoxMedicalService.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace InvoxMedicalService.Controllers
{
    // Controller
    [ApiController]
    [Route("api/transcribe")]
    public class TranscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TranscriptionController> _logger;

        public TranscriptionController(IMediator mediator, ILogger<TranscriptionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromForm] string userProfile)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("File not selected or empty.");

                var transcription = await _mediator.Send(new UploadAudioCommand { File = file, UserProfile = userProfile });
                return Ok(new { Transcription = transcription });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Error processing file: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing file.");
                return StatusCode(500, "An error occurred while processing the file.");
            }
        }
    }

}
