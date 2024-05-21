using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class User
    {
        [Key]
        public int ID_User { get; set; }
        public string Login { get; set; }
        public string Parol { get; set; }
    }
}
