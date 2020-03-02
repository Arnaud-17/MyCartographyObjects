using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class Coordonnees : CartoObj, IIsPointClose
    {
        #region VARIABLES MEMBRES
        private double _latitude;
        private double _longitude;
        #endregion

        #region PROPRIETES
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Coordonnees() //Constructeur par defaut
        {
            this.Latitude = 0.0;
            this.Longitude = 0.0;
        }

        public Coordonnees(double newlatitude,double newlongitude) //Constructeur D'init
        {
            this.Latitude = newlatitude;
            this.Longitude = newlongitude;
        }

        public Coordonnees(Coordonnees previousCoordonnees)
        {
            Latitude = previousCoordonnees.Latitude;
            Longitude = previousCoordonnees.Longitude;
        }
        #endregion

        #region CODE
        public override string ToString()
        {
            return string.Format(base.ToString() + " > ({0:0.###}, ", Latitude) + string.Format("{0:0.###})", Longitude);
        }
        public override void Draw()
        {
            Console.WriteLine(ToString());
        }

        public bool IsPointClose(Coordonnees c2, double precision)
        {
            bool ret_val;
            ret_val = MathUtile.Pythagore(Latitude, Longitude, c2, precision);
            //Console.WriteLine(ret_val);
            return ret_val;
        }
        #endregion
    }
}
