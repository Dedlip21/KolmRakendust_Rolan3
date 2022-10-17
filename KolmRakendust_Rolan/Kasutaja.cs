using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolmRakendust_Rolan
{
    public class Kasutaja
    {
        public int Id { get; set; }
        public static string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password { get; set; }
        /*public string Email { get; set; }
        public string Sugu { get; set; }
        public int Vanus { get; set; }*/
    }
}
