using System;
using System.Threading.Tasks;

namespace GenerateRadomKeys
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            int op;
            byte len;

            string key = "";

            RandonGenerateKey generateKey = new RandonGenerateKey();

            do
            {
                Console.WriteLine("1-PADRAO, 2-NUMERICO, 3 - CARACTERE,  4-SIMBOLO, 5-BINARIO");
                op = int.Parse(Console.ReadLine());

                Console.WriteLine("Tamanho: ");
                len = byte.Parse(Console.ReadLine());

                switch (op) 
                {
                    case 1: key = await generateKey.Generate(GenerationType.pattern, len); break;

                    case 2: key = await generateKey.Generate(GenerationType.numeric, len); break;

                    case 3: key = await generateKey.Generate(GenerationType.character, len); break;

                    case 4: key = await generateKey.Generate(GenerationType.symbol, len); break;
                }

                Console.WriteLine($"key gerada: {key}");

            }while (true);
        }
    }
}
