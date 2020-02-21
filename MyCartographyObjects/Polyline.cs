using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyCartographyObjects
{
    public class Polyline : CartoObj, IIsPointClose, IPointy
    {
        #region VARIABLES MEMBRES
        private Coordonnees[] _collection;
        private int _epaisseur;
        private Color _couleur;
        #endregion

        #region PROPRIETES
        public Coordonnees[] Collection
        {
            set { _collection = value; }
            get { return _collection; }
        }
        public Color Couleur
        {
            set { _couleur = value; }
            get { return _couleur; }
        }
        public int Epaisseur
        {
            set { _epaisseur = value; }
            get { return _epaisseur; }
        }
        #endregion

        #region CONSTRUCTEUR
        public Polyline()
        {
            this.Collection = null;
            this.Couleur = Colors.White;
            this.Epaisseur = 0;
        }

        public Polyline(Coordonnees[] newCoordonees,Color newCouleur, int newEpaisseur) : base()
        {
            this.Collection = newCoordonees;
            this.Couleur = newCouleur;
            this.Epaisseur = newEpaisseur;
        }
        #endregion

        #region Draw
        public override string ToString()
        {
            return string.Format(base.ToString() + " > Couleur : " + Couleur + " / Epaisseur : " + Epaisseur);
        }

        public override void Draw()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine("\nCollection Polyline :");

            if (Collection != null)
            {
                foreach (Coordonnees c in Collection)
                {
                    Console.WriteLine(c);
                }
            }
            else
                Console.WriteLine("NULL");
        }

        public bool IsPointClose(Coordonnees c2, double precision)
        {
            int i = 1;
            bool ret_val;
            bool PointClose = false;

            foreach (Coordonnees c in Collection)
            {
                Coordonnees coord1 = Collection[i];
                Coordonnees coord2 = Collection[i - 1];

                ret_val = MathUtile.PointLineDistance(coord1, coord2,c2, precision);

                if (ret_val == true)
                    PointClose = true;
            }

            return PointClose;
        }

        public byte GetNumberOfPoint()
        {
            byte NbrPoint=0;

            foreach(Coordonnees c in Collection)
            {
                NbrPoint++;
            }
            return NbrPoint;
        }
        #endregion
    }
}
