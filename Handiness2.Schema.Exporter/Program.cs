using System;
using System.IO;
using System.Linq;
namespace Handiness2.Schema.Exporter
{
    class Program
    {
        static void Main(String[] args)
        {
            ProviderFactory factory = new ProviderFactory();
            var provider = factory.LoadSchemProviders().First();
            provider.Open("Data Source=117.48.197.78;Uid=sa;Pwd=932444208wlj+;Initial Catalog=biobank;");
            try
            {
                OfficeExporter exporter = new OfficeExporter();
                OfficeExportCommand command = new OfficeExportCommand();
                command.Output = Path.Combine(@"C:\Users\93244\Desktop", "tableSchema.xlsx");
                command.Type = OfficeExportCommand.ExportTypeExcel;
                exporter.ExportSchema(provider, command, (e,i)=>
                {
                    Console.WriteLine($"{e.ToString()}%"+i);
                });
            }
            finally
            {
                provider.Close();
            }
      
        }
    }
}
