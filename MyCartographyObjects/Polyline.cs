using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    class Polyline : CartoObj
    {
        #region VARIABLES MEMBRES
        private int _epaisseur;
        public static System.Windows.Media.Color Lime { get; }
        #endregion

        public int Epaisseur
        {
            get { return _epaisseur; }
            set { _epaisseur = value; }
        }

        public Polyline()
        {
            
        }
    }
}
