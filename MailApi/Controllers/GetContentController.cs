using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using MailApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/")]
public class GetContentController : Controller
{
    private readonly IGetContent _repo;
    public GetContentController(IGetContent repo)
    {
        _repo = repo;
    }

    [HttpGet("pageable_users")]
    public JsonResult GetUsersPageable()
    {
        var page = int.Parse(Request.Query["page"]);
        var size = int.Parse(Request.Query["size"]);
        
        var content = _repo.GetPageableContent(page, size);
        return Json(content);
    }
    
    [HttpGet("users/department")]
    public JsonResult GetUsersDepartment([FromBody] User value)
    {
        if (value is null | value?.DepartmentId == 0 )
            throw new MailException.MailValidationException();
        var content = _repo.GetUserDepartment(value);
        return Json(content);
    }
    
    [HttpGet("users")]
    public JsonResult GetAllUsers()
    {
        var content = _repo.GetAllUsers();
        return Json(content);
    }
    
    [HttpGet("departments")]
    public JsonResult GetAllDepartment()
    {
        var content = _repo.GetAllDepartments();
        return Json(content);
    }
}