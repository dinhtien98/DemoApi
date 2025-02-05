using Dapper;
using DemoApi.Context;
using DemoApi.Models.Dtos.UserDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DemoApi.Services.UploadImage
{
    public class UploadImageService: IUploadImageService
    {
        private readonly IWebHostEnvironment _env;
        private readonly DapperConnection _dapperConnection;

        public UploadImageService(DapperConnection dapperConnection,IWebHostEnvironment env)
        {
            _dapperConnection = dapperConnection;
            _env = env ?? throw new ArgumentNullException(nameof(env));
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
        public async Task<bool> DeleteImageAsync(string imagePath, int idImage)
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
                var deleteImage = "sp_productimage_delete";

                using (var connection = _dapperConnection.GetConnection())
                {
                    await connection.OpenAsync();

                    try
                    {
                        var Parameters = new DynamicParameters(new
                        {
                            p_ID = idImage
                        });

                        var rowsAffected = await connection.ExecuteAsync(
                            deleteImage,
                            Parameters,
                            commandType: CommandType.StoredProcedure
                        );

                        if (rowsAffected > 0)
                        {
                            File.Delete(fullPath);
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to execute AddUser stored procedure: {ex.Message}");
                        return false;
                    }
                }

            }

            return false; 
        }

        public async Task<int> GetIdImageAsync(string imagePath)
        {
            var queryGetId = "sp_productimage_getid";

            using (var connection = _dapperConnection.GetConnection())
            {
                await connection.OpenAsync();

                try
                {
                    
                    var parametersGetId = new DynamicParameters();
                    parametersGetId.Add("p_imageUrl",imagePath,DbType.String,ParameterDirection.Input);

                    var idImage = await connection.QueryFirstOrDefaultAsync<int?>(queryGetId,parametersGetId,commandType: CommandType.StoredProcedure);

                    if (idImage == null)
                    {
                        Console.WriteLine("Image ID not found in database.");
                        return 0;
                    }
                    return (int)idImage;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to execute AddUser stored procedure: {ex.Message}");
                    return 0;
                }
            }
        }
    }
}
