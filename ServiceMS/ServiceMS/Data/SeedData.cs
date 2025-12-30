using ServiceMS.Helpers;
using ServiceMS.Models;

namespace ServiceMS.Data;

public static class SeedData
{
    public static void EnsureAdmin(AppDbContext db)
    {
        if (db.Users.Any(x => x.Role == "Admin"))
            return;

        var admin = new AppUser
        {
            Username = "admin",
            PasswordHash = PasswordHasher.Hash("admin"),
            Role = "Admin",
            CreatedAt = DateTime.UtcNow
        };
        
        db.Users.Add(admin);
        db.SaveChanges();
    }
}