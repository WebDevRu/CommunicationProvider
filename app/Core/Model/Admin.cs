namespace app.Core.Model;
using Microsoft.EntityFrameworkCore;

public partial class Admin
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public DateTime RegisteredAt { get; set; }

    public DateTime LastLoginAt { get; set; }

    public string Email { get; set; } = null!;
    
    protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>().HasData(new Admin
        {
            Password = "QWERTY123qwe",
            Email = "nikrainev@gmail.com"
        });
    }
}