using System.ComponentModel.DataAnnotations;
using System.Web;
using MailApi.Data.Interfaces;
using MailApi.Data.Models;
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

    [HttpGet("get/user")]
    public JsonResult GetUsersPageable()
    {
        int page = int.Parse(Request.Query["page"]);
        int size = int.Parse(Request.Query["size"]);
        
        List<User> content = _repo.GetPageableContent(page, size);
        return Json(content);
    }
    
    [HttpGet("get/department")]
    public JsonResult GetUsersDepartment([FromBody] User value)
    {
        List<User> content = _repo.GetUserDepartment(value);
        return Json(content);
    }
    
    [HttpGet("get/all")]
    public JsonResult GetAllUsers()
    {
        List<User> content = _repo.GetAllUsers();
        return Json(content);
    }
}