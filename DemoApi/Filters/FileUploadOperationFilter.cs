namespace DemoApi.Filters;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class FileUploadOperationFilter: IOperationFilter
{
    public void Apply(OpenApiOperation operation,OperationFilterContext context)
    {
        var fileParam = operation.Parameters.FirstOrDefault(p => p.Name == "image");
        if (fileParam != null)
        {
            operation.Parameters.Remove(fileParam);
            operation.RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string,OpenApiMediaType>
                {
                    ["multipart/form-data"] = new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties =
                            {
                                ["image"] = new OpenApiSchema
                                {
                                    Type = "string",
                                    Format = "binary"
                                }
                            },
                            Required = new HashSet<string> { "image" }
                        }
                    }
                }
            };
        }
    }
}

