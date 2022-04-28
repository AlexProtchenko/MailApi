using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/")]
public class DepartmentController : Controller
{
    private readonly IMail _repo;
    public DepartmentController(IMail repo)
    {
        _repo = repo;
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