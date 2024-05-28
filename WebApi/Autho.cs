using System.Text;
using System.Security.Cryptography;
using WebApi.Model;
using System.Diagnostics.Eventing.Reader;
namespace WebApi
{
    
    public class Autho
    {
        public string Authorization(string login, string password)
        {
            User user = new User();
            string Pass = HashPassword(password);
            user = MyBaseContext.GetContext().Users.Where(p => p.Login == login && p.Parol == Pass).FirstOrDefault();
            if (user != null)
            {
                Sotrudniki sotr = new Sotrudniki();
                sotr = MyBaseContext.GetContext().Sotrudnikis.Where(p => p.IdUser == user.IdUser).FirstOrDefault();

                Console.WriteLine("***************************************************************************");
                Console.WriteLine("Добро пожаловать, "+user.Login+"!");
                Console.WriteLine(sotr.Imea+" "+sotr.Familia+" "+sotr.Otchestvo);
                Console.WriteLine("***************************************************************************");
                return "Вы успешно авторизовались! Вас зовут "+sotr.Imea+" "+sotr.Familia+" "+sotr.Otchestvo+", ваш номер телефона "+sotr.Telephon;
            }
            else
            {
                Console.WriteLine("Не получилось войти в аккаунт!");
                return null;
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
