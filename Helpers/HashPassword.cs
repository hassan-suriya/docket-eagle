using System.Security.Cryptography;
using System.Text;

public static class HashPassword
{
    public static string GetHashPassword(string password)
    {
        var hashedPassword = "";
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            hashedPassword = Convert.ToBase64String(hashBytes);
        }
        return hashedPassword;
    }
}