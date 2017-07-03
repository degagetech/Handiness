using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ConsoleTestUnit
{
    class Test
    {
         static Test()
        {
            Console.WriteLine("Static Ctro Called");
        }
      internal   static void Write()
        {
            Console.WriteLine("Static Write Called");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
