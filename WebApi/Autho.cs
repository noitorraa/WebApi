using System.Text;
using System.Security.Cryptography;
using WebApi.Model;
using System.Diagnostics.Eventing.Reader;
namespace WebApi
{
    
    public class Autho
    {
        public User user = new User();
        public void Authorization(string login, string password)
        {
            //Scaffold-DbContext "data source=DESKTOP-TEQ035O;initial catalog=MyBase;persist security info=True;user id=Noitorra;password=Passw0rd;trustservercertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
            //User user = new User();
            string Pass = HashPassword(password);
            Console.WriteLine(Pass);
            user = MyBaseContext.GetContext().Users.Where(p => p.Login == login && p.Parol == Pass).FirstOrDefault();
            if (user != null)
            {
                Console.WriteLine("Доброо пожаловать "+user.Login+"!");
            }
            else
            {
                Console.WriteLine("Не получилось войти в аккаунт!");
            }
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] SoursebytePass = Encoding.UTF8.GetBytes(password);
                byte[] HashSourceBytePass = sha256hash.ComputeHash(SoursebytePass);
                string hashpass = BitConverter.ToString(HashSourceBytePass).Replace("-", string.Empty);
                return hashpass;
            }
        }
        
    }
}
