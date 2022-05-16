using MailApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/")]
public class AuthenticationController : Controller
{
    private readonly IConfiguration _configuration;

    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("jwt")]
    public JsonResult GetJwt()
    {

        var token = _configuration.GenerateJwtToken();
        var jsonToken = new Dictionary<string, string>() {{"token", token }};
        return Json(jsonToken);
    }
}