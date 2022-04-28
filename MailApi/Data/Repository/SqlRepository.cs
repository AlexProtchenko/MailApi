using MailApi.Data.Interfaces;
using MailApi.Data.Models;

namespace MailApi.Data.Repository;

public class SqlRepository : IMail
{
    private readonly AppDbContent _appDbContent;

    public SqlRepository(AppDbContent appDbContent)
    {
        _appDbContent = appDbContent;
    }
    
    public void Delete(User value)
    {
        User user = _appDbContent.Users.Where(o => o.UserId == value.UserId).FirstOrDefault();

        _appDbContent.Users.Remove(user);
        _appDbContent.SaveChanges();
    }

    public void Delete(Department value)
    {
        Department department = _appDbContent.Departments.Where(o => o.DepartmentId == value.DepartmentId).FirstOrDefault();

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
}