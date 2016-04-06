namespace Common
{
    using System;
    using System.Security.Cryptography;

    public class Md5HashComputer
    {
        public static string CreateMd5HashString(byte[] data)
        {
            string resultingHash = string.Empty;

            using (var md5 = MD5.Create())
            {
                resultingHash = Convert.ToBase64String(md5.ComputeHash(data));
            }

            return resultingHash;
        }
    }
}