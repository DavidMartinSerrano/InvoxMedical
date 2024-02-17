using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoxMedicalService.Services
{
    public interface IAudioTranscriptionService
    {
        string TranscribeAudio(IFormFile file, string userProfile);
    }
}
