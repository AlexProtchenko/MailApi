using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using MailApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/[controller]")]
public class MailController : Controller
{
    private IMail _repo;
    public MailController(IMail repo)
    {
        _repo = repo;
    }

    [HttpPost("add/user")]
    public JsonResult AddUser([FromBody]User value)
    {
        _repo.Add(value);
        return Json(value);
    }

    [HttpPost("add/department")]
    public JsonResult AddDepartmen([FromBody]Department value)
    {
        _repo.Add(value);
        return Json(value);
    }
}