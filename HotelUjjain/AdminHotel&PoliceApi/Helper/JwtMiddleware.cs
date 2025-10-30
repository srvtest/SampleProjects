using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdminHotel_PoliceApi.Helper
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly IMemoryCache _memoryCache;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, IMemoryCache memoryCache)
        {
            _next = next;
            _appSettings = appSettings.Value;
            _memoryCache = memoryCache;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var endpoint = context.GetEndpoint();
            //if ((endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() is object && context.Request.Path.ToString().Contains("UpgradeLevel")))
            //{
            //    await _next(context);
            //}
            //else
            //{
                string userToken = null;
                if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() is object)
                {
                    userToken = null;
                }
                else
                {
                    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                    //if (token != null)
                    //    //Validate the token
                    //    attachUserToContext(context, userService, token);
                    //await _next(context);

                    if (!string.IsNullOrEmpty(token))
                    {
                        attachUserToContext(context, userService, token);
                    }
                    else
                        throw new UnauthorizedAccessException("Invalid User Token");
                }
            await _next(context);
            //}
        }
        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            JwtSecurityToken jwtToken = null;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = key,
                    ValidIssuer = _appSettings.Issuer,
                    ValidAudience = _appSettings.Issuer,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                 jwtToken = (JwtSecurityToken)validatedToken;                
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("Your session has timed out. Please login again.");
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
            if (_memoryCache.TryGetValue(token, out _))
            {
                throw new UnauthorizedAccessException("Your session has timed out. Please login again.");
            }
            var idHotelMaster = int.Parse(jwtToken.Claims.First(x => x.Type == "idHotelMaster").Value);
            var HotelName = Convert.ToString(jwtToken.Claims.First(x => x.Type == "HotelName").Value);
            // attach user to context on successful jwt validation
            context.Items["idHotelMaster"] = idHotelMaster;
            context.Items["HotelName"] = HotelName;
        }
    }
}
