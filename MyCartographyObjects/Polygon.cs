using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyCartographyObjects
{
    public class Polygon : CartoObj, IIsPointClose
    {
        #region VARIABLES MEMBRES
        private Coordonnees[] _collection;
        private Color _remplissage;
        private Color _contour;
        private double _opacité;
        #endregion

        #region PROPRIETES
        public Coordonnees[] Collection
        {
            set { _collection = value; }
            get { return _collection; }
        }
        public Color Remplissage
        {
            set { _remplissage = value; }
            get { return _remplissage; }
        }

        public Color Contour
        {
            set { _contour = value; }
            get { return _contour; }
        }

        public double Opacité
        {
            set { _opacité = value; }
            get { return _opacité; }
        }
        #endregion

        #region CONSTRUCTEUR 
        public Polygon()
        {
            this.Collection = null;
            this.Remplissage = Colors.White;
            this.Contour = Colors.White;
            this.Opacité = 0;
        }

        public Polygon(Coordonnees[] newCoordonnees, Color newRemplissage, Color NewContour, Double newOpacité) :base()
        {
            this.Collection = newCoordonnees;
            this.Remplissage = newRemplissage;
            this.Contour = NewContour;
            this.Opacité = newOpacité;
        }
        #endregion

        #region Draw
        public override string ToString()
        {
            return string.Format(base.ToString() + " > Remplissage : " + Remplissage + " / Contour : " + Contour + " / Opacité : " + Opacité);
        }

        public override void Draw()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine("\nCollection Polygon :");

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

        public bool IsPointClose(Coordonnees c2, double presision)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
