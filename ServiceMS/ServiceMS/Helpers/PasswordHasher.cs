using System.Security.Cryptography;
using System.Text;

namespace ServiceMS.Helpers;

public class PasswordHasher
{
    private const string Salt = "service-ms-salt";
    public static string Hash(string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password + Salt);
        return Convert.ToHexString(sha.ComputeHash(bytes));
    }
}