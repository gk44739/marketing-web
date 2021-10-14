using marketing_web.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Services
{
    public class UploadService : IUploadService
    {
        private readonly IWebHostEnvironment _env;

        public UploadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void Remove(string Directory)
        {
            var path = _env.WebRootPath + Directory.Replace("/", @"\");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task<string> Upload(IFormFile file, string DirectoryOne, string Id)
        {
            var filePath = Path.Combine(_env.WebRootPath, "Upload", DirectoryOne, Id);

            Directory.CreateDirectory(filePath);

            var fullPath = Path.Combine(filePath, file.FileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var result = "/Upload/" + DirectoryOne + "/" + Id + "/" + file.FileName;

            return result;
        }

    }
}
