using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GeoCoordinates
        : IGeoCoordinates
    {
        public GeoCoordinates(
            global::ImageRecognition.Web.ILatitude latitude, 
            global::ImageRecognition.Web.ILongtitude longtitude)
        {
            Latitude = latitude;
            Longtitude = longtitude;
        }

        public global::ImageRecognition.Web.ILatitude Latitude { get; }

        public global::ImageRecognition.Web.ILongtitude Longtitude { get; }
    }
}
