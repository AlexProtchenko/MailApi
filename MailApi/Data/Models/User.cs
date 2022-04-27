namespace MailApi.Data.Models;

public class User
{
    public int UserId;

    public string Name;

    public string Desc;
    
    public List<Department> Departments { get; set; } = new List<Department>();
}