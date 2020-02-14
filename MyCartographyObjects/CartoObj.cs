using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyCartographyObjects
{
    public abstract class CartoObj
    {
        #region VARIABLES MEMBRES
        private static long _idcpt = 0;
        private long _id;
        #endregion

        #region PROPRIETES
        public static long Idcpt
        {
            get { return _idcpt; }
            set { _idcpt = value; }
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public CartoObj()
        {
            Id = Idcpt++;
        }
        #endregion

        #region CODE

        public virtual string Draw()
        {
            return "Id > " + Id;
        }
        #endregion 
    }
}
