using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace InsecTimeLine.Services
{
    public class UploadService
    {
        public string Upload(IFormFile file)
        {
            if (file != null && file.Length <= 0) return "";

            var path = "Uploads/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fullPath = "wwwroot/" + path;
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
                stream.Flush();
                return "/" + path;
            }
        }
    }
}