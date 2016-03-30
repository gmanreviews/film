using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace film.Models
{
    public class bcrypt
    {
        public static string encrypt(string password)
        {
            return password;
            //return BCrypt.Net.BCrypt.HashString(password);
        }

        public static bool test_password(string password, string hashedpassword)
        {
            return password == hashedpassword;
            /*
            try {
                return BCrypt.Net.BCrypt.Verify(password, hashedpassword);
            }
            catch
            {
                return false;
            }
            */
        }
    }
}