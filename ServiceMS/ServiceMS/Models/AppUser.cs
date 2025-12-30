using System.ComponentModel.DataAnnotations;

namespace ServiceMS.Models;

public class AppUser
{
    public long Id { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    [Required, MaxLength(20)]
    public string Role { get; set; } = "Clerk"; // Admin / Clerk / Technician

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}