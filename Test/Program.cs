using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MyCartographyObjects;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordonnees c1 = new Coordonnees();
            Coordonnees c2 = new Coordonnees(0,5) ;
            Coordonnees c3 = new Coordonnees(5,0);

            POI poi1 = new POI();
            POI poi2 = new POI("Magnée",c3);

            Polyline PolyL1 = new Polyline();
            Polygon PolyG1 = new Polygon();

            Coordonnees[] tab1 = { new Coordonnees(0,0), new Coordonnees(-2,0) };
            Coordonnees[] tab2 = { c3, c1, c2 };

            Polyline PolyL2 = new Polyline(tab1, Colors.Blue, 10);
            Polygon PolyG2 = new Polygon(tab2, Colors.Lime, Colors.Aqua,1);

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("------ c1 (Cpd) ---------");
            Console.WriteLine(c1);
            Console.WriteLine("------ poi1 (Cpd) -------");
            Console.WriteLine(poi1);

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("------ c2 (Cinit) -------");
            Console.WriteLine(c2);
            Console.WriteLine("------ poi2 (Cinit) -----");
            Console.WriteLine(poi2);

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("------ PolyL1 (Cpd) -----");
            PolyL1.Draw();
            Console.WriteLine("\n------ PolyG1 (Cpd) -----");
            PolyG1.Draw();

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("------ PolyL2 (Cinit) -----");
            PolyL2.Draw();
            Console.WriteLine("\n------ PolyG2 (Cinit) -----");
            PolyG2.Draw();

            Console.WriteLine("\n------ c1 IsPointClose c2 -------");
            Console.WriteLine(c1.IsPointClose(new Coordonnees(0, 5), 4.9));

            Console.WriteLine("\n------ poi1 IsPointClose poi2 -------");
            Console.WriteLine(poi1.IsPointClose(poi2, 4.9));

            Console.WriteLine("\n------ Polyl1 IsPointClose c5 -------");
            Console.WriteLine(PolyL2.IsPointClose(new Coordonnees(-4.1,0),2));

            Console.ReadKey();
        }
    }
}
