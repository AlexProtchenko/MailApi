using MailApi.Data.Models;

namespace MailApi.Data.Interfaces;

public interface IGetContent
{
    public List<User> GetPageableContent(int page, int size);
    
    public List<User> GetAllUsers { get; set; }

    public List<User> GetUserDepartment(User user);
}