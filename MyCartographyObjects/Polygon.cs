﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyCartographyObjects
{
    public class Polygon : CartoObj, IIsPointClose, IPointy
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
            Console.WriteLine("-----Collection Polygon-----");

            if (Collection != null)
            {
                foreach (Coordonnees c in Collection)
                {
                    Console.WriteLine("     " + c);
                }
            }
            else
                Console.WriteLine("NULL");
        }

        public bool IsPointClose(Coordonnees c2, double presision)
        {
            double LatMax=0, LongMax=0, LatMin=0, LongMin=0;

            foreach (Coordonnees c in Collection)
            {
                if (c.Latitude < LatMin)
                {
                    LatMin = c.Latitude;
                }
                else
                {
                    if (c.Latitude > LatMax)
                    {
                        LatMax = c.Latitude;
                    }
                }

                if (c.Longitude < LongMin)
                {
                    LongMin = c.Longitude;
                }
                else
                {
                    if (c.Longitude > LongMax)
                    {
                        LongMax = c.Longitude;
                    }
                }
                
            }
            //Console.WriteLine("latMax = " + LatMax + " longmax = " + LongMax + " latmin = " + LatMin + " longmin = " + LongMin);
            //Console.WriteLine("c2.lat = " + c2.Latitude + " c2.long = " + c2.Longitude);
            if (c2.Latitude >= LatMin && c2.Latitude <= LatMax && c2.Longitude >= LongMin && c2.Longitude <= LongMax)
                return true;
            else
                return false;
        }
        public byte GetNumberOfPoint()
        {
            byte NbrPoint = 0;

            foreach (Coordonnees c in Collection)
            {
                NbrPoint++;
            }
            return NbrPoint;
        }
        public override int NbrPointCarto()
        {
            if (this.Collection == null)
                return 0;
            else
                return GetNumberOfPoint();
        }
        #endregion
    }
}
