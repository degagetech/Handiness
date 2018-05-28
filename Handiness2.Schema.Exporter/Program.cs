using System;
using System.Linq;
namespace Handiness2.Schema.Exporter
{
    class Program
    {
        static void Main(String[] args)
        {
            ProviderFactory factory = new ProviderFactory();
            var provider = factory.LoadSchemProviders().First();
            provider.Open("Data Source=117.48.197.78;Uid=sa;Pwd=932444208wlj+;Initial Catalog=biobank_report;");

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

            provider.Close();
        }
    }
}
