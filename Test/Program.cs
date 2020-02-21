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
            Coordonnees c2 = new Coordonnees(2,2) ;
            Coordonnees c3 = new Coordonnees(4,-2);
            Coordonnees c4 = new Coordonnees(1, -5);
            Coordonnees c5 = new Coordonnees(-3,0);
            Coordonnees c6 = new Coordonnees(5, 5);

            POI poi1 = new POI();
            POI poi2 = new POI("Magnée",c3);

            Polyline PolyL1 = new Polyline();
            Polygon PolyG1 = new Polygon();

            Coordonnees[] tab1 = { new Coordonnees(0,0), new Coordonnees(-2,0), new Coordonnees(-2,-2)};
            Coordonnees[] tab2 = { c3, c2 ,c4,c5,c6};

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
            Console.WriteLine(PolyL2.IsPointClose(new Coordonnees(-3,-3),2));

            Console.WriteLine("\n-------PolyG1 IsPointClose c6 ---------");
            Console.WriteLine(PolyG2.IsPointClose(new Coordonnees(-3, 3),0));

            Console.WriteLine("\n--------NbrPoint PolyL2-------------");
            Console.WriteLine(PolyL2.GetNumberOfPoint());

            Console.ReadKey();
        }
    }
}
