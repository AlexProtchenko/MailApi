using MailApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/[controller]")]
public class MailController : Controller
{
    [HttpPost("add")]
    public JsonResult AddUser([FromBody]User value)
    {
        Console.WriteLine("OK");
        return Json(value);
    }
}