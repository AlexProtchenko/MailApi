using MailApi.Data.Interfaces;
using MailApi.Data.Models;

namespace MailApi.Data.Repository;

public class ContentRepository : IContent
{
    private readonly AppDbContent _appDbContent;

    public ContentRepository(AppDbContent appDbContent)
    {
        _appDbContent = appDbContent;
    }
    
    public void Delete(User value)
    {
        var user = _appDbContent.Users.FirstOrDefault(o => o.UserId == value.UserId);

        _appDbContent.Users.Remove(user);
        _appDbContent.SaveChanges();
    }

    public void Delete(Department value)
    {
        var department = _appDbContent.Departments.FirstOrDefault(o => o.DepartmentId == value.DepartmentId);

        _appDbContent.Departments.Remove(department);
        _appDbContent.SaveChanges();
    }

    public void Add(User value)
    {
        _appDbContent.Users.Add(value);
        _appDbContent.SaveChanges();
    }

    public void Add(Department value)
    {
        _appDbContent.Departments.Add(value);
        _appDbContent.SaveChanges();
    }

    public void Update(User value)
    {
        var user = _appDbContent.Users.FirstOrDefault(c => c.UserId == value.UserId);

        if (value.Name != null)
            user.Name = value.Name;

        if (value.DepartmentId != null)
            user.DepartmentId = value.DepartmentId;
        

        if (value.Desc != null)
            user.Desc = value.Desc;

        _appDbContent.SaveChanges();
    }

    public void Update(Department value)
    {
        var department = _appDbContent.Departments.FirstOrDefault(c => c.DepartmentId == value.DepartmentId);

        if (value.Name != null)
            department.Name = value.Name;


            _appDbContent.SaveChanges();
    }
}