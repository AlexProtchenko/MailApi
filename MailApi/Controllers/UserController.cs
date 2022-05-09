using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/user")]
public class UserController : Controller
{
    private readonly IContent _repo;
    public UserController(IContent repo)
    {
        _repo = repo;
    }
    
    [HttpPost]
    public JsonResult AddUser([FromBody] User value) // ActionResult
    {
        _repo.Add(value);
        return Json(value);
    }
    
    [HttpDelete]
    public JsonResult DelUser([FromBody] User value) // controller 
    {
        _repo.Delete(value);
        return Json(value);
    }
    
    [HttpPut]
    public JsonResult UpdateUser([FromBody] User value)
    {
        _repo.Update(value);
        return Json(value);
    }
}