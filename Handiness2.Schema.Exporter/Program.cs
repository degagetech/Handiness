using System;
using System.IO;
using System.Linq;
namespace Handiness2.Schema.Exporter
{
    class Program
    {
        static void Main(String[] args)
        {
            //Data Source=117.48.197.78;Uid=sa;Pwd=932444208wlj+;Initial Catalog=biobank;
            if (args.Length >= 2)
            {
                String connectionString = args[0];
                String outputPath = args[1];
                ProviderFactory factory = new ProviderFactory();
                var providers = factory.LoadSchemProviders();
                if (providers.Count > 0)
                {
                    var provider = providers[0];
                    try
                    {
                        provider.Open(connectionString);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Successfully use {connectionString} to open the database!");
                        OfficeExporter exporter = new OfficeExporter();
                        OfficeExportCommand command = new OfficeExportCommand();
                        command.Output = outputPath;
                        command.Type = OfficeExportCommand.ExportTypeExcel;
                        exporter.ExportSchema(provider, command, (e, t) =>
                        {
                            Console.WriteLine($"  Writing schema information for table [{t.Name}] , progress has been completed {e.ToString()}% !");
                        });

                    }
                    catch (ProviderConnectException exc)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Failed to connect to the database instance:" + exc.ErrorExplain);
                    }
                    catch (Exception exc)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Operation abnormal:" + exc.ToString());
                    }
                    finally
                    {
                        provider.Close();
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Failed to find schema provider!");
                }
            }

            //ProviderFactory factory = new ProviderFactory();
            //var provider = factory.LoadSchemProviders().First();
            //if (providers.Count > 0)
            //{
            //    var provider = providers[0];

            //}
            //provider.Open("Data Source=117.48.197.78;Uid=sa;Pwd=932444208wlj+;Initial Catalog=biobank;");
            //try
            //{
            //    OfficeExporter exporter = new OfficeExporter();
            //    OfficeExportCommand command = new OfficeExportCommand();
            //    command.Output = Path.Combine(@"C:\Users\93244\Desktop", "tableSchema.xlsx");
            //    command.Type = OfficeExportCommand.ExportTypeExcel;
            //    exporter.ExportSchema(provider, command, (e, t) =>
            //    {
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        Console.WriteLine($"Writing structure information for table [{t.Name}] , progress has been completed {e.ToString()}% !");
            //    });
            //}
            //finally
            //{
            //    provider.Close();
            //}

        }
    }
}
