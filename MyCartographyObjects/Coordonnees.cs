using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class Coordonnees : CartoObj
    {
        #region VARIABLES MEMBRES
        private double _longitude;
        private double _latitude;
        #endregion

        #region PROPRIETES
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Coordonnees() : this(0.0, 0.0) { } //Constructeur par defaut

        public Coordonnees(double newlongitude, double newlatitude) : base() //Constructeur D'init
        {
            Longitude = newlongitude;
            Latitude = newlatitude;
        }
        #endregion

        #region CODE
        public override string ToString()
        {
            return "Id : " + Id + " > " + "(" + Longitude + ";" + Latitude + ")";
        }
        #endregion
    }
}
