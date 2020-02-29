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
            //Constructeur par defaut
            Coordonnees c1 = new Coordonnees();
            POI poi1 = new POI();
            Polyline PolyL1 = new Polyline();
            Polygon PolyG1 = new Polygon();
            
            //Constructeur d'initialisation
            Coordonnees c2 = new Coordonnees(2, 2);
            Coordonnees c3 = new Coordonnees(4, -2);
            Coordonnees c4 = new Coordonnees(1, -5);
            Coordonnees c5 = new Coordonnees(-3, 0);
            Coordonnees c6 = new Coordonnees(5, 5);

            POI poi2 = new POI("Magnée", c3);

            Coordonnees[] tab1 = { new Coordonnees(0, 0), new Coordonnees(-2, 0), new Coordonnees(-2, -2) };
            Coordonnees[] tab2 = { c3, c2, c4, c5, c6 };
            Coordonnees[] tab3 = { new Coordonnees(0, 0), new Coordonnees(2, 2), new Coordonnees(2, -2) };
            Coordonnees[] tab4 = { new Coordonnees(-3, 3), new Coordonnees(0, 5), new Coordonnees(5, 2), new Coordonnees(2, -4), new Coordonnees(-2, -3) };

            Polyline PolyL2 = new Polyline(tab1, Colors.Blue, 10);
            Polygon PolyG2 = new Polygon(tab2, Colors.Lime, Colors.Aqua, 1);

            Polyline pol1 = new Polyline(tab1, Colors.Azure, 5);
            Polyline pol2 = new Polyline(tab2, Colors.CornflowerBlue, 2);
            Polyline pol3 = new Polyline(tab3, Colors.Coral, 7);
            Polyline pol4 = new Polyline(tab4, Colors.DarkRed, 9);

            //Liste générique
            List<CartoObj> cartoObj = new List<CartoObj>()
            {
                c1,
                c2,
                poi1,
                poi2,
                PolyL1,
                PolyL2,
                PolyG1,
                PolyG2
            };

            List<Polyline> poly = new List<Polyline>()
            {
                pol1,
                pol2,
                pol3,
                pol4
            };

            Console.WriteLine("==============================================");
            Console.WriteLine("------ c1 (Cpd) ---------");
            Console.WriteLine(c1);
            Console.WriteLine("------ poi1 (Cpd) -------");
            Console.WriteLine(poi1);

            Console.WriteLine("\n==============================================");
            Console.WriteLine("------ c2 (Cinit) -------");
            Console.WriteLine(c2);
            Console.WriteLine("------ poi2 (Cinit) -----");
            Console.WriteLine(poi2);

            Console.WriteLine("\n==============================================");
            Console.WriteLine("------ PolyL1 (Cpd) -----");
            PolyL1.Draw();
            Console.WriteLine("\n------ PolyG1 (Cpd) -----");
            PolyG1.Draw();

            Console.WriteLine("\n==============================================");
            Console.WriteLine("------ PolyL2 (Cinit) -----");
            PolyL2.Draw();
            Console.WriteLine("\n------ PolyG2 (Cinit) -----");
            PolyG2.Draw();

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nc1 IsPointClose c2");
            Console.WriteLine("---> " + c1.IsPointClose(new Coordonnees(0, 5), 4.9));

            Console.WriteLine("\npoi1 IsPointClose poi2");
            Console.WriteLine("---> " + poi1.IsPointClose(poi2, 4.9));

            Console.WriteLine("\nPolyline IsPointClose c");
            Console.WriteLine("---> " + PolyL2.IsPointClose(new Coordonnees(-3,-3),2));

            Console.WriteLine("\nPolygon IsPointClose c");
            Console.WriteLine("---> " + PolyG2.IsPointClose(new Coordonnees(-3, 3),0));

            Console.WriteLine("\nNbrPoint PolyLline");
            Console.WriteLine("---> " + PolyL2.GetNumberOfPoint());

            Console.WriteLine("\nNbrPoint Polygon");
            Console.WriteLine("---> " + PolyG2.GetNumberOfPoint());

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage de la liste générique de CartoObj");
            foreach(CartoObj c in cartoObj)
            {
                c.Draw();
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage des CartoObj IPointy");
            foreach (CartoObj c in cartoObj)
            {
                if (c is IPointy)
                {
                    c.Draw();
                    Console.WriteLine("-----> is Ipointy\n");
                }
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage des CartoObj qui ne sont pas IPointy");
            foreach (CartoObj c in cartoObj)
            {
                if (!(c is IPointy))
                    Console.WriteLine(c + " is not Ipointy");
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage de la liste générique de polyline");
            foreach (Polyline pol in poly)
            {
                Console.WriteLine(pol);
                Console.WriteLine("Distance = " + MathUtile.Longueur(pol.Collection, pol.GetNumberOfPoint()));
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage des polyline trier par ordre de longueur");
            poly.Sort();
            foreach (Polyline pol in poly)
            {
                Console.WriteLine(pol);
                Console.WriteLine("Distance = " + MathUtile.Longueur(pol.Collection, pol.GetNumberOfPoint()));
            }

           /* Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage des polyline trier par ordre de surface de BoundingBox");
            poly.Sort();
            foreach (MyPolylineBoundingBoxComparer pol in poly)
            {
                Console.WriteLine(pol);
            }*/

            Console.ReadKey();
        }
    }
}
