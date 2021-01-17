using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GeoCoordinates1
        : IGeoCoordinates1
    {
        public GeoCoordinates1(
            global::ImageRecognition.Web.ILatitude1 latitude, 
            global::ImageRecognition.Web.ILongtitude1 longtitude)
        {
            Latitude = latitude;
            Longtitude = longtitude;
        }

        public global::ImageRecognition.Web.ILatitude1 Latitude { get; }

        public global::ImageRecognition.Web.ILongtitude1 Longtitude { get; }
    }
}
