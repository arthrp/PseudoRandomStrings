using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoRandomStrings
{   
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var randGenerator = new RandomGenerator();

            if(args.Length == 0)
            {
                GenerateOnce(8, randGenerator);
                return;
            }

            bool isLoop = args.Contains("-loop");
            int typeArgIndex = args.ToList().IndexOf("-type");

            var entityType = GeneratedEntity.String;

            if (typeArgIndex >= 0)
            {
                var stringType = args[typeArgIndex + 1];
                if(!Enum.TryParse<GeneratedEntity>(stringType, out entityType))
                {
                    PrintUsage();
                    return;
                }
            }

            if (isLoop)
                GenerateInLoop(Int32.Parse(args[0]), randGenerator, entityType);
            else
                GenerateOnce(Int32.Parse(args[0]), randGenerator, entityType);
        }

        private static void GenerateInLoop(int length, RandomGenerator randGenerator, GeneratedEntity type = GeneratedEntity.String)
        {
            string input = "";
            while(input.ToLowerInvariant() != "q")
            {
                input = GenerateOnce(length, randGenerator);
            }
        }

        private static string GenerateOnce(int length, RandomGenerator randGenerator, GeneratedEntity type = GeneratedEntity.String)
        {
            string result = "";

            if (type == GeneratedEntity.String)
                result = randGenerator.GenerateRandomString(length);
            else if (type == GeneratedEntity.Email)
                result = randGenerator.GenerateRandomEmail(length);


            Console.WriteLine(result);
            #if !__MonoCS__
            Clipboard.SetText(result);
            #endif

            string input = Console.ReadLine();

            return input;
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("PseudoRandomStrings [string length] [-type Email|String] [-loop]");
        }
    }
}
