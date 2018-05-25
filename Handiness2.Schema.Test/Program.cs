using System;
using System.Linq;
namespace Handiness2.Schema.Test
{
    class Program
    {
        static void Main(String[] args)
        {
            ProviderFactory factory = new ProviderFactory();
            var provider=factory.LoadSchemProviders().First();
            provider.Open("Data Source=117.48.197.78;Uid=sa;Pwd=932444208wlj+;Initial Catalog=biobank;");

            foreach (var tableSchema in provider.LoadTableSchemaList())
            {
                Console.WriteLine("Table:"+tableSchema.Name+" Explain:"+tableSchema.Explain,ConsoleColor.Green);
                foreach (var columnSchema in provider.LoadColumnSchemaList(tableSchema.Name))
                {
                    Console.WriteLine("/t Column:" + columnSchema.Name + " Explain:" + tableSchema.Explain, ConsoleColor.Yellow);
                }
            }

            provider.Close();
        }
    }
}
