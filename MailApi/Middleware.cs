using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using MailApi.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace MailApi;

public class Middleware : IMiddleware
{
    private readonly IConfiguration _configuration;

    public Middleware(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var path = context.Request.Path.ToString();

            if (path == "/api/jwt")
            {
            }

            else if (token != null)
                Validate(token);

            else
                throw new MailException.MailUnauthorizedException();

            await next(context);
        }

        catch (MailException.MailUnauthorizedException e)
        {
            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync(e.Message);
        }

        catch (MailException.MailValidationException e)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(e.Message);
        }

        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(e.Message);
        }
    }

    private void Validate(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // min 16 characters
            var key = Encoding.ASCII.GetBytes(_configuration["Secret"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out _);

        }
        catch
        {
            throw new MailException.MailUnauthorizedException();
        }
    }
}