using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoxMedicalService.Services
{
    public class AudioTranscriptionService : IAudioTranscriptionService
    {
        public string TranscribeAudio(IFormFile file, string userProfile)
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
