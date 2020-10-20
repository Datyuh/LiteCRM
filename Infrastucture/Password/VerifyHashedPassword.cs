using System;
using System.Security.Cryptography;

namespace LiteCRM.Infrastucture.Password
{
    public class VerifyHashedPassword
    {
        public static bool VerifyHashedPasswords(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }

            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }

            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] buffer3, byte[] buffer4)
        {
            if (buffer3 == buffer4) return true;
            if (buffer3 == null || buffer4 == null) return false;
            if (buffer3.Length != buffer4.Length) return false;
            for (int i = 0; i < buffer3.Length; i++)
            {
                if (buffer3[i] != buffer4[i]) return false;
            }

            return true;
        }
    }
}