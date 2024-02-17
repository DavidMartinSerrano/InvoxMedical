using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InvoxMedicalService.Commands
{
    public class UploadAudioCommand : IRequest<string>
    {
        public IFormFile File { get; set; }
        public string UserProfile { get; set; }
    }

    
}
