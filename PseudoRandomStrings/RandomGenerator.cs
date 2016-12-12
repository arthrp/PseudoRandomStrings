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

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[rnd.Next(chars.Length)]);
            }

            return result.ToString();
        }

        public string GenerateRandomEmail(int beforeAtLength = 8)
        {
            return GenerateRandomString(beforeAtLength) + "@mvrht.com";
        }

        public string GenerateRandomName(NameType nameType = NameType.All)
        {
            List<string> maleNames = new List<string>() { "Lukas", "Maximilian", "Jakob", "David", "Tobias", "Paul", "Jonas", "Felix", "Alexander", "Elias",
                "Lucas","Louis","Noah","Nathan","Adam","Arthur","Mohamed","Victor","Mathis","Liam" };
            List<string> femaleNames = new List<string>() { "Anna", "Hannah", "Sophia", "Emma", "Marie", "Lena", "Sarah", "Sophie", "Laura", "Mia",
                "Emma","Louise","Elise","Léa","Marie","Julie","Lina","Nina","Olivia","Camille","Juliette"};

            var rnd = new Random();

            if (nameType == NameType.Male)
                return maleNames.ElementAt(rnd.Next(0, maleNames.Count - 1));
            if(nameType == NameType.Female)
                return femaleNames.ElementAt(rnd.Next(0, femaleNames.Count - 1));

            var allNames = new List<string>();
            allNames.AddRange(maleNames);
            allNames.AddRange(femaleNames);

            return allNames.ElementAt(rnd.Next(0, allNames.Count - 1));
        }
    }
}
