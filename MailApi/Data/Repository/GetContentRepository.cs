using MailApi.Data.Interfaces;
using MailApi.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MailApi.Data.Repository;

public class GetContentRepository : IGetContent
{
    private readonly AppDbContent _appDbContent;

    public GetContentRepository(AppDbContent appDbContent)
    {
        _appDbContent = appDbContent;
    }

    public List<User> GetPageableContent(int page, int size)
    {
        int skip = (page - 1) * size;
        List<User> content = _appDbContent.Users.Select(x => x).Skip(skip).Take(size).ToList();
        return content;

    }

    public List<User> GetAllUsers { get; set; }

    public List<User> GetUserDepartment(User user)
    {
        List<User> content = _appDbContent.Users.Select(x => x).Where(o => o.DepartmentId == user.DepartmentId)
            .ToList();
        return content;
    }
}