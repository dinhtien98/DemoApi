using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApi.Services.UploadImage
{
    public interface IUploadImageService
    {
        Task<List<object>> UploadImagesAsync(List<IFormFile> files);
        public Task<bool> DeleteImageAsync(string imagePath, int id);
        public Task<int> GetIdImageAsync(string imagePath);
    }
}
