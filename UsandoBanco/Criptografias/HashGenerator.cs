using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsandoBanco.Criptografias
{
    internal enum HashType
    {
        MD5,
    }

    internal class HashGenerator
    {
        public static string GenerateHash(string value, HashType type)
        {
            var result = string.Empty;

            switch (type)
            {
                case HashType.MD5:
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] input = Encoding.ASCII.GetBytes(value);
                        byte[] hash = md5.ComputeHash(input);

                        var sb = new StringBuilder();
                        foreach(var element in hash)
                        {
                            sb.Append(element.ToString("X2"));
                        }
                        result = sb.ToString();
                    }
                    break;
            }

            return result;
        }
    }
}
