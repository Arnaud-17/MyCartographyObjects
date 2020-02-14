using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCartographyObjects;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            float xxx = 0;
            string xxxstring = Console.ReadLine();
            if (float.TryParse(xxxstring, out xxx))
            {
                Console.WriteLine("xxx = {0}", xxx);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Console.ReadKey();
        }
    }
}
