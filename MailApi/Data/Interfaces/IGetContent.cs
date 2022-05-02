using MailApi.Data.Models;

namespace MailApi.Data.Interfaces;

public interface IGetContent
{
    public List<User> GetPageableContent(int page, int size);

    public List<User> GetAllUsers();

    public List<Department> GetAllDepartments();

    public List<User> GetUserDepartment(User user);
}