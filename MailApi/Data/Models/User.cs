namespace MailApi.Data.Models;

public class User
{
    public int UserId { get; set; }

    public string Name { get; set; }

    public string Desc { get; set; }
    
    public int DepartmentId { get; set; } 
    
    public Department Department { get; set; }
}