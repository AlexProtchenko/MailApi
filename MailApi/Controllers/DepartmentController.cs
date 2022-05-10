using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using MailApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("api/department")]
public class DepartmentController : Controller
{
    private readonly IContent _repo;
    public DepartmentController(IContent repo)
    {
        _repo = repo;
    }

    [HttpPut]
    public JsonResult UpdateDepartment([FromBody] Department value)
    {
        if (value is null | value?.Name is null | value?.DepartmentId == 0)
            throw new MailException.MailValidationException("Wrong json request");
        _repo.Update(value);
        return Json(value);
    }

    [HttpPost]
    public JsonResult AddDepartment([FromBody] Department value)
    {
        if (value is null | value?.Name is null)
            throw new MailException.MailValidationException("Wrong json request");
        _repo.Add(value);
        return Json(value);
    }

    [HttpDelete]
    public JsonResult DelDepartment([FromBody] Department value)
    {
        if (value is null | value?.DepartmentId == 0)
            throw new MailException.MailValidationException("Wrong json request");
        _repo.Delete(value);
        return Json(value);
    }
}