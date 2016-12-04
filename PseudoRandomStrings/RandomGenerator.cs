using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRandomStrings
{
    public class RandomGenerator
    {
        public string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder();
            var rnd = new Random();

            for(int i=0; i<length; i++)
            {
                result.Append(chars[rnd.Next(chars.Length)]);
            }

            return result.ToString();
        }

        public string GenerateRandomEmail(int beforeAtLength = 8)
        {
            return GenerateRandomString(beforeAtLength) + "@mvrht.com";
        }
    }
}
