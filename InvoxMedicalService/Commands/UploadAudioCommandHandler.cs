using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace InvoxMedicalService.Commands
{
    public class UploadAudioCommandHandler : IRequestHandler<UploadAudioCommand, string>
    {
        private readonly ILogger<UploadAudioCommandHandler> _logger;

        public UploadAudioCommandHandler(ILogger<UploadAudioCommandHandler> logger)
        {
            _logger = logger;
        }

        public Task<string> Handle(UploadAudioCommand request, CancellationToken cancellationToken)
        {
            if (request.File == null || request.File.Length == 0)
                throw new ArgumentException("File not selected or empty.");

            // Retrieve user profile from command
            string userProfile = request.UserProfile;

            try
            {
                return Task.FromResult(TranscribeAudio(request.File, userProfile));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing file.");
                throw; // Rethrow the exception for global exception handling
            }
        }

        private string TranscribeAudio(IFormFile file, string userProfile)
        {
            // This is a mock implementation to select a predefined text
            var predefinedTexts = new[] { "Text 1", "Text 2", "Text 3", "Text 4" };
            var random = new Random();
            var selectedIndex = random.Next(0, predefinedTexts.Length);
            var selectedText = predefinedTexts[selectedIndex];

            // Include user profile in the transcription
            return $"{selectedText} - Transcribed by: {userProfile}";
        }
    }
}
