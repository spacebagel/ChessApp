using System.Security.Cryptography;
using System.Text;

namespace ChessApp.Methods;

public class CryptoLogic
{
    public static bool CheckUser(string login, string password)
        => App.Context.Users.FirstOrDefault(x => x.Login == login && x.Password == HashPassword(login, password)) != null;


    public static string HashPassword(string login, string password)
    {
        using SHA256 hash = SHA256.Create();
        return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(login + password)));
    }
}