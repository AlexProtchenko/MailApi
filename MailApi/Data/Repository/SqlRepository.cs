using MailApi.Data.Interfaces;
using MailApi.Data.Models;

namespace MailApi.Data.Repository;

public class SqlRepository : IMail
{
    private readonly AppDBContent appDbContent;

    public SqlRepository(AppDBContent appDbContent)
    {
        this.appDbContent = appDbContent;
    }
    
    public void Delete(User value)
    {
        User user = appDbContent.Users.Where(o => o.UserId == value.UserId).FirstOrDefault();

        appDbContent.Users.Remove(user);
        appDbContent.SaveChanges();
    }

    public void Delete(Department value)
    {
        Department department = appDbContent.Departments.Where(o => o.DepartmentId == value.DepartmentId).FirstOrDefault();

        appDbContent.Departments.Remove(department);
        appDbContent.SaveChanges();
    }

    public void Add(User value)
    {
        appDbContent.Users.Add(value);
        appDbContent.SaveChanges();
    }

    public void Add(Department value)
    {
        appDbContent.Departments.Add(value);
        appDbContent.SaveChanges();
    }
}