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

            Coordonnees[] tab1 = { new Coordonnees(-3, 3), new Coordonnees(6, -1), new Coordonnees(-2, -2) };
            Coordonnees[] tab2 = { c3, c2, c4, c5, c6 };
            Coordonnees[] tab3 = { new Coordonnees(3, 3), new Coordonnees(3, 8), new Coordonnees(2, 8) };
            Coordonnees[] tab4 = { new Coordonnees(-3, 3), new Coordonnees(0, 5), new Coordonnees(5, 2), new Coordonnees(2, -4), new Coordonnees(-2, -3) };
            Coordonnees[] tabref = { new Coordonnees(0, 0), new Coordonnees(6, 0)};

            Polyline PolyL2 = new Polyline(tab1, Colors.Blue, 10);
            Polygon PolyG2 = new Polygon(tab2, Colors.Lime, Colors.Aqua, 1);

            Polyline pol1 = new Polyline(tab1, Colors.Azure, 5);
            Polyline pol2 = new Polyline(tab2, Colors.CornflowerBlue, 2);
            Polyline pol3 = new Polyline(tab3, Colors.Coral, 7);
            Polyline pol4 = new Polyline(tab4, Colors.DarkRed, 9);
            Polyline Reference = new Polyline(tabref, Colors.DarkBlue, 2);

            MyPolylineBoundingBoxComparer pcomp = new MyPolylineBoundingBoxComparer();

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

            List<Polyline> polyline = new List<Polyline>()
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
            Console.WriteLine("---> " + c1.IsPointClose(new Coordonnees(1, 6), 6));

            Console.WriteLine("\npoi1 IsPointClose poi2");
            Console.WriteLine("---> " + poi1.IsPointClose(poi2, 4.9));

            Console.WriteLine("\nPolyline IsPointClose c");
            Console.WriteLine("---> " + PolyL2.IsPointClose(new Coordonnees(2,2),2));

            Console.WriteLine("\nPolygon IsPointClose c");
            Console.WriteLine("---> " + PolyG2.IsPointClose(new Coordonnees(-3, 3),0));

            Console.WriteLine("\nNbrPoint PolyLline");
            Console.WriteLine("---> " + PolyL2.GetNumberOfPoint());

            Console.WriteLine("\nNbrPoint Polygon");
            Console.WriteLine("---> " + PolyG2.GetNumberOfPoint());

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage de la liste générique de CartoObj\n");
            foreach(CartoObj c in cartoObj)
            {
                c.Draw();
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage des CartoObj IPointy\n");
            foreach (CartoObj c in cartoObj)
            {
                if (c is IPointy)
                {
                    c.Draw();
                    Console.WriteLine("-----> is Ipointy\n");
                }
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage des CartoObj qui ne sont pas IPointy\n");
            foreach (CartoObj c in cartoObj)
            {
                if (!(c is IPointy))
                    Console.WriteLine(c + " is not Ipointy");
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage de la liste générique de polyline\n");
            foreach (Polyline p in polyline)
            {
                p.Draw();
                Console.WriteLine("Longueur du Polyline = " + MathUtile.Longueur(p.Collection)+ "\n");
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage des polyline trier par ordre de longueur\n");
            polyline.Sort();
            foreach (Polyline p in polyline)
            {
                p.Draw();
                Console.WriteLine("Longueur du Polyline = " + MathUtile.Longueur(p.Collection) + "\n");
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage des polyline trier par ordre de surface de BoundingBox\n");
            polyline.Sort(pcomp);
            foreach (Polyline p in polyline)
            {
                p.Draw();
                Console.WriteLine("Surface de la BoundingBox = " + p.PolylineBoundingBox() + "\n");
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nRecherche si une liste de Polyline contient un polyline de même longueur qu'un polyline de reference\n");
            double longueur = MathUtile.Longueur(Reference.Collection);
            
            Polyline res = polyline.Find(x => MathUtile.Longueur(x.Collection) == longueur);
            if (res == null)
                Console.WriteLine("Aucune Polyline trouver");
            else
            {
                Console.WriteLine("Longueur polyline de reference = " + longueur);
                Console.WriteLine("Longueur polyline trouver = " + MathUtile.Longueur(res.Collection) + "\n");
                res.Draw();
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage d'une liste de CartoObj trier par nombre de point\n");
            foreach (CartoObj c in cartoObj)
            {
                c.Draw();
            }

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\nAffichage des polyline qui sont proche d'un point\n");
            int cpt = 0;
            foreach (Polyline p in polyline)
            {
                if ((p.IsPointClose(new Coordonnees(5, 3),  1.1)) == true)
                {
                    Console.WriteLine("Ce polyline est proche du point");
                    p.Draw();
                    cpt++;
                }
            }
            if (cpt == 0)
                Console.WriteLine("Aucun Polyline n'est proche du point...");

            Console.ReadKey();
        }
    }
}
