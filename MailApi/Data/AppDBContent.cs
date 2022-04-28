using MailApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MailApi.Data;


public class AppDbContent : DbContext
{
    public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
}