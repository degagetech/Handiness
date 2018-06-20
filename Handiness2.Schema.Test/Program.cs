using System;
using System.Linq;
namespace Handiness2.Schema.Test
{
    class Program
    {
        static void Main(String[] args)
        {
            ProviderFactory factory = new ProviderFactory();
            var provider = factory.LoadSchemProviders().First();
            provider.Open("Data Source=117.48.197.78;Uid=sa;Pwd=932444208wlj+;Initial Catalog=biobank_report;");

            Console.WriteLine("Table Schema Info:");
            foreach (var tableSchema in provider.LoadTableSchemaList())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Table:" + tableSchema.Name + " Explain:" + tableSchema.Explain);
                foreach (var columnSchema in provider.LoadColumnSchemaList(tableSchema.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t Column:" + columnSchema.Name + " Explain:" + columnSchema.Explain);
                }
            }
            Console.WriteLine("View Schema Info:");
            foreach (var viewSchema in provider.LoadViewSchemaList())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("View:" + viewSchema.Name + " Explain:" + viewSchema.Explain);
                foreach (var columnSchema in provider.LoadViewColumnSchemaList(viewSchema.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t Column:" + columnSchema.Name + " Explain:" + columnSchema.Explain);
                }
            }
            provider.Close();
        }
    }
}
