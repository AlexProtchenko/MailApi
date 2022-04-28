using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using MailApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/")]
public class MailController : Controller
{
    private readonly IMail _repo;
    public MailController(IMail repo)
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
    
    [HttpPut("update/department")]
    public JsonResult UpdateDepartment([FromBody] Department value)
    {
        _repo.Update(value);
        return Json(value);
    }

    [HttpPost("add/department")]
    public JsonResult AddDepartment([FromBody] Department value)
    {
        _repo.Add(value);
        return Json(value);
    }

    [HttpDelete("del/department")]
    public JsonResult DelDepartment([FromBody] Department value)
    {
        _repo.Delete(value);
        return Json(value);
    }
}