using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Interfaces
{
    public interface IUploadService
    {
        Task<string> Upload(IFormFile file, string Directory, string Id);
        void Remove(string Directory);
    }
}
