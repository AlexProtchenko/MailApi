using System.Text.Json.Serialization;


namespace MailApi.Data.Models;

public class Department
{
    [JsonPropertyName("department_id")]
    public int DepartmentId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    public List<User> Users { get; set; }
}