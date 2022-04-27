using MailApi.Data.Models;
using MailApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/[controller]")]
public class MailController : Controller
{
    private SqlRepository _repo;
    public MailController(SqlRepository repo)
    {
        _repo = repo;
    }
    
    [HttpPost("add")]
    public JsonResult AddUser([FromBody]User value)
    {
        _repo.Add(value);
        return Json(value);
    }
}