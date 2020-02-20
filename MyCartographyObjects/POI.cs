using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class POI : Coordonnees, IIsPointClose
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
        public POI() : base(0,0)//Constructeur par defaut
        {
            this.Description = "Rue peetermans, Seraing";
        }

        public POI(string newDescription, Coordonnees newCoordonnees) : base(newCoordonnees.Latitude,newCoordonnees.Longitude)
        {
            this.Description = newDescription;
        }
        #endregion

        #region CODE
        public override string ToString()
        {
            return string.Format(base.ToString() + " => " + Description);
        }
        #endregion
    }
}
