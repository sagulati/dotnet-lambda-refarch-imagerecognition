using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Longtitude
        : ILongtitude
    {
        public Longtitude(
            double d, 
            double m, 
            double s, 
            GeoCoordinateDirection direction)
        {
            D = d;
            M = m;
            S = s;
            Direction = direction;
        }

        public double D { get; }

        public double M { get; }

        public double S { get; }

        public GeoCoordinateDirection Direction { get; }
    }
}
