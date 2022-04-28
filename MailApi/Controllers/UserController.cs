using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/")]
public class UserController : Controller
{
    private readonly IContent _repo;
    public UserController(IContent repo)
    {
        _repo = repo;
    }
    
    [HttpPost("add/user")]
    public JsonResult AddUser([FromBody] User value) // ActionResult
    {
        _repo.Add(value);
        return Json(value);
    }
    
    [HttpDelete("del/user")]
    public JsonResult DelUser([FromBody] User value) // controller 
    {
        _repo.Delete(value);
        return Json(value);
    }
    
    [HttpPut("update/user")]
    public JsonResult UpdateUser([FromBody] User value)
    {
        _repo.Update(value);
        return Json(value);
    }
}