namespace MailApi.Data.Models;

public class Department
{
    public int DepartmentId;

    public string Name;
    
    public List<User> Users { get; set; } = new List<User>();
}