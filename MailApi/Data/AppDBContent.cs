using MailApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MailApi.Data;


public class AppDBContent : DbContext
{
    public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
    {
        
    }
    public DbSet<User> User { get; set; }
    public DbSet<Department> Department { get; set; }
}