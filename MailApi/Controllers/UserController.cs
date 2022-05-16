using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using MailApi.Exceptions;
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
    public JsonResult AddUser([FromBody] User value) 
    {
        if (value is null | value?.Name is null | value?.DepartmentId == 0)
            throw new MailException.MailValidationException();
        value.Desc ??= "";
        _repo.Add(value);
        return Json(value);
    }
    
    [HttpDelete]
    public JsonResult DelUser([FromBody] User value) 
    {
        if (value is null | value?.UserId == 0)
            throw new MailException.MailValidationException();
        _repo.Delete(value);
        return Json(value);
    }
    
    [HttpPut]
    public JsonResult UpdateUser([FromBody] User value)
    {
        if (value is null | value?.UserId == 0)
            throw new MailException.MailValidationException();
        _repo.Update(value);
        return Json(value);
    }
}