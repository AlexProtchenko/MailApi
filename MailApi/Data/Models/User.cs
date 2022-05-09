using System.Text.Json.Serialization;


namespace MailApi.Data.Models;

public class User
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Desc { get; set; }
    
    [JsonPropertyName("department_id")]
    public int DepartmentId { get; set; } 
    
    public Department Department { get; set; }
}