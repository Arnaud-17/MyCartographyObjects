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
        public long Id
        {
            get { return _id; }
        }
        #endregion

        #region CONSTRUCTEURS
        public CartoObj()
        {
            _id = _idcpt++;
        }
        #endregion

        #region CODE
        public virtual void Draw()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return string.Format("Id : " + Id);
        }
        #endregion
    }
}
