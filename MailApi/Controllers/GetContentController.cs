using System.ComponentModel.DataAnnotations;
using System.Web;
using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/get")]
public class GetContentController : Controller
{
    private readonly IGetContent _repo;
    public GetContentController(IGetContent repo)
    {
        _repo = repo;
    }

    [HttpGet("user")]
    public JsonResult GetUsersPageable()
    {
        var page = int.Parse(Request.Query["page"]);
        var size = int.Parse(Request.Query["size"]);
        
        var content = _repo.GetPageableContent(page, size);
        return Json(content);
    }
    
    [HttpGet("department")]
    public JsonResult GetUsersDepartment([FromBody] User value)
    {
        var content = _repo.GetUserDepartment(value);
        return Json(content);
    }
    
    [HttpGet("all")]
    public JsonResult GetAllUsers()
    {
        var content = _repo.GetAllUsers();
        return Json(content);
    }
}