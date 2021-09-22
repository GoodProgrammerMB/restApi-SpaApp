using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GP.API.Bootstrap
{
    public class DefaultHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //operation.Parameters.Add(new OpenApiParameter
            //{
            //    Name = "ApiVersion",
            //    In = ParameterLocation.Header,
            //    Required = false,
            //    Example = new OpenApiString(SmartShopingConstants.REQUEST_HEADER_API_VERSION)
            //});
        }
    }
}
