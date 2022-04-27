namespace MailApi.Data.Models;

public class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; }
    
    public List<User> Users { get; set; } = new List<User>();
}