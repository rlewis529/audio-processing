using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

public class SwaggerFileOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var fileParameters = context.ApiDescription.ParameterDescriptions
            .Where(p => p.ModelMetadata.ModelType == typeof(IFormFile))
            .ToList();

        if (!fileParameters.Any())
            return;

        foreach (var parameter in fileParameters)
        {
            operation.Parameters.Remove(operation.Parameters.First(p => p.Name == parameter.Name));
        }

        operation.RequestBody = new OpenApiRequestBody
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["multipart/form-data"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "object",
                        Properties = fileParameters.ToDictionary(p => p.Name, p => new OpenApiSchema
                        {
                            Type = "string",
                            Format = "binary"
                        }),
                        Required = fileParameters.Select(p => p.Name).ToHashSet()
                    }
                }
            }
        };
    }
}
