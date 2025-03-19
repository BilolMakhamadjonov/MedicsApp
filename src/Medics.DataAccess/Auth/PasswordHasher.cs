using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace Medics.DataAccess.Auth;


public sealed class PasswordHasher : IPasswordHasher
{
    private const int KeySize = 32;
    private const int IterationCount = 1000;

    public string Encrypt(string password, string salt)
    {
        using var algorithm = new Rfc2898DeriveBytes(
            password,
            Encoding.UTF8.GetBytes(salt),
            IterationCount,
            HashAlgorithmName.SHA256);

        return Convert.ToBase64String(algorithm.GetBytes(KeySize));
    }

    public bool Verify(string hash, string password, string salt)
    {
        return Encrypt(password, salt) == hash;
    }
}