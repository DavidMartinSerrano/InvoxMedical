using InvoxMedicalService.Services;
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
        private readonly IAudioTranscriptionService _audioTranscriptionService;

        public UploadAudioCommandHandler(ILogger<UploadAudioCommandHandler> logger, IAudioTranscriptionService audioTranscriptionService)
        {
            _logger = logger;
            _audioTranscriptionService = audioTranscriptionService;
        }

        public Task<string> Handle(UploadAudioCommand request, CancellationToken cancellationToken)
        {
            if (request.File == null || request.File.Length == 0)
                throw new ArgumentException("File not selected or empty.");

            // Retrieve user profile from command
            string userProfile = request.UserProfile;

            try
            {
                return Task.FromResult(_audioTranscriptionService.TranscribeAudio(request.File, userProfile));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing file.");
                throw; // Rethrow the exception for global exception handling
            }
        }

       
    }
}
