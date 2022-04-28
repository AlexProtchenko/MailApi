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
    public ActionResult GetUsersPageable()
    {
        int page = int.Parse(Request.Query["page"]);
        int size = int.Parse(Request.Query["size"]);
        
        var content = _repo.GetPageableContent(page, size);
        return Json(content);
    }
}