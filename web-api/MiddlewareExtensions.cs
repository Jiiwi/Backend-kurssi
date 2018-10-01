using Microsoft.AspNetCore.Builder;

namespace web_api
{
    public static class MiddlewareExtensions
    {
            public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<AuthMiddleware>();
            }
        }
    }
