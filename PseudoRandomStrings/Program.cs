using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if !__MonoCS__
using System.Windows.Forms;
#endif

namespace PseudoRandomStrings
{   
    class Program
    {
        private const int TYPE_VAL_IDX = 1;

        [STAThread]
        static void Main(string[] args)
        {
            var randGenerator = new RandomGenerator();

            if (args.Length == 0)
            {
                GenerateOnce(8, randGenerator);
                return;
            }

            var entityType = GeneratedEntity.String;

            bool hasValidType = Enum.TryParse<GeneratedEntity>(args[TYPE_VAL_IDX], out entityType);
            if (!hasValidType)
            {
                Console.WriteLine("Must have a valid type specified");
                return;
            }

            int stringLength;
            bool hasValidLength = Int32.TryParse(args[3], out stringLength);

            if (args[0] != "-l" && args[TYPE_VAL_IDX] != "Name" && !hasValidLength)
            {
                Console.WriteLine("Must have a valid length specified, unless generating name!"+Environment.NewLine);
                PrintUsage();
                return;
            }

            bool isLoop = args.Contains("-loop");

            if (isLoop)
                GenerateInLoop(stringLength, randGenerator, entityType);
            else
                GenerateOnce(stringLength, randGenerator, entityType);
        }

        private static void GenerateInLoop(int length, RandomGenerator randGenerator, GeneratedEntity type = GeneratedEntity.String)
        {
            string input = "";
            while(input.ToLowerInvariant() != "q")
            {
                input = GenerateOnce(length, randGenerator, type);
            }
        }

        private static string GenerateOnce(int length, RandomGenerator randGenerator, GeneratedEntity type = GeneratedEntity.String)
        {
            string result = "";

            if (type == GeneratedEntity.String)
                result = randGenerator.GenerateRandomString(length);
            else if (type == GeneratedEntity.Email)
                result = randGenerator.GenerateRandomEmail(length);
            else if (type == GeneratedEntity.Name)
                result = randGenerator.GenerateRandomName(NameType.All);


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
            Console.WriteLine("PseudoRandomStrings -type [Email|String] -l [string_length] [-loop] or");
            Console.WriteLine("PseudoRandomStrings -type [Name] [-loop]");
        }
    }
}
