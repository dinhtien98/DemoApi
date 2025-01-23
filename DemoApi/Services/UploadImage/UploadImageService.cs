using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoApi.Services.UploadImage
{
    public class UploadImageService: IUploadImageService
    {
        private readonly IWebHostEnvironment _env;

        public UploadImageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<List<object>> UploadImagesAsync(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                throw new ArgumentException("No files to upload.");
            }

            var permittedExtensions = new[] { ".jpg",".jpeg",".png",".gif" };
            var uploadPath = Path.Combine(_env.WebRootPath,"Uploads","images");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var imageUrl = new List<object>();

            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (!permittedExtensions.Contains(extension))
                {
                    throw new ArgumentException("Invalid file type. Only .jpg, .jpeg, .png, and .gif are allowed.");
                }

                string fileName = $"{Guid.NewGuid()}{extension}";
                string filePath = Path.Combine(uploadPath,fileName);

                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                imageUrl.Add(new
                {
                    code = $"/uploads/images/{fileName}"
                });
            }

            return imageUrl;
        }
        public bool DeleteImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                throw new ArgumentException("Image path cannot be null or empty.");
            }

            if (imagePath.StartsWith("/"))
            {
                imagePath = imagePath.Substring(1);
            }

            var fullPath = Path.Combine(_env.WebRootPath,imagePath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true; 
            }

            return false; 
        }
    }
}
