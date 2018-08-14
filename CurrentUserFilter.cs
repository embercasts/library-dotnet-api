using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using JsonApiDotNetCore.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LibraryApi
{
    public class CurrentUserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var authHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault(a => a.Contains("Bearer "));

            if (authHeader == null)
            {
                throw new JsonApiException(401, "Unauthorized");
            }

            var token = authHeader.Replace("Bearer ", "");

            var securityKey = httpContext.RequestServices.GetRequiredService<SymmetricSecurityKey>();

            try
            {
                var userClaim = new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey
                }, out var validatedToken);

                httpContext.User = userClaim;
            }
            catch (SecurityTokenException)
            {
                throw new JsonApiException(401, "Unauthorized");
            }
        }
    }
}
