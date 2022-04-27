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
    
    public void Delete(User id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Department id)
    {
        throw new NotImplementedException();
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