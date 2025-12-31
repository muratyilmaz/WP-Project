using System.Security.Cryptography;
using System.Text;

namespace ServiceMS.Helpers;

public static class TrackingCodeGenerator
{
    private const string Alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

    public static string Generate()
    {
        var bytes = RandomNumberGenerator.GetBytes(12);
        var sb = new StringBuilder(12);

        foreach (var b in bytes)
            sb.Append(Alphabet[b % Alphabet.Length]);
        
        return $"TS-{sb.ToString()[..4]}-{sb.ToString()[4..8]}-{sb.ToString()[8..12]}";
    }
}