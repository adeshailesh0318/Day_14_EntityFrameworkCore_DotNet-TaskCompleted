using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Authen.API.Handlers
{
    public class TokenValidationHandler : DelegatingHandler
    {
        private const string SecretKey = "ADSFDSKLJKLK7498S8493843759874383758798437D5FLJKDSLKJF998098996JLAKAKJDSKJF2343530899";
        private const string Issuer = "https://localhost:44395";
        private const string Audience = "https://localhost:44395";

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authHeader = request.Headers.Authorization;

            if (authHeader == null || authHeader.Scheme != "Bearer" || string.IsNullOrWhiteSpace(authHeader.Parameter))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var token = authHeader.Parameter;

            try
            {
                var principal = ValidateToken(token);

                if (principal != null)
                {
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }

                    Thread.CurrentPrincipal = principal;
                }
            }
            catch (SecurityTokenExpiredException)
            {
                return CreateUnauthorizedResponse("Token has expired. Please login again.");
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                return CreateUnauthorizedResponse("Token signature is invalid.");
            }
            catch (SecurityTokenException ex)
            {
                return CreateUnauthorizedResponse("Token validation failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                return CreateUnauthorizedResponse("Unexpected error: " + ex.Message);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(SecretKey);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = Issuer,
                ValidateAudience = true,
                ValidAudience = Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            // ✅ IMPORTANT FIX: AuthenticationType set karein warna IsAuthenticated false rahega
            var identity = principal.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var newIdentity = new ClaimsIdentity(identity.Claims, "JWT", identity.NameClaimType, identity.RoleClaimType);
                return new ClaimsPrincipal(newIdentity);
            }

            return principal;
        }

        private HttpResponseMessage CreateUnauthorizedResponse(string message)
        {
            return new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent(
                    "{\"Message\":\"" + message + "\"}",
                    Encoding.UTF8,
                    "application/json")
            };
        }
    }
}