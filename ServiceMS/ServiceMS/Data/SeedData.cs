using ServiceMS.Helpers;
using ServiceMS.Models.Db;

namespace ServiceMS.Data;

public static class SeedData
{
    public static void EnsureAdmin(AppDbContext db)
    {
        if (db.users.Any(x => x.role == "Admin"))
            return;

        var admin = new user()
        {
            username = "admin",
            password_hash = PasswordHasher.Hash("admin"),
            role = "Admin",
            created_at = DateTime.UtcNow
        };
        
        db.users.Add(admin);
        db.SaveChanges();
    }
}