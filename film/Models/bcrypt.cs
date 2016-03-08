using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chess.Models
{
    public class bcrypt
    {
        public static string encrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashString(password);
        }

        public static bool test_password(string password, string hashedpassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedpassword);
        }
    }
}