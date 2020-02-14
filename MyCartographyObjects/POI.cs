using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class POI : Coordonnees
    {
        #region VARIABLES MEMBRES
        private string _description;
        #endregion

        #region PROPRIETES
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public POI() : this(50.652, 5.045, "Rue Peetermans, Seraing") { } //Constructeur par defaut

        public POI(double newlongitude, double newlatitude, string newdescription) : base(newlongitude, newlatitude)
        {
            Longitude = newlongitude;
            Latitude = newlatitude;
            Description = newdescription;
        }
        #endregion

        #region CODE
        public override string ToString()
        {
            return string.Format("Id : " + Id + " > " + "({0:0.###}, ", Latitude) + string.Format("{0:0.###})", Longitude) + " => " + Description + "    ";
        }
        #endregion
    }
}
