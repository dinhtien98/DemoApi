using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApi.Services.UploadImage
{
    public interface IUploadImageService
    {
        Task<List<object>> UploadImagesAsync(List<IFormFile> files);
        bool DeleteImage(string imagePath);
    }
}
