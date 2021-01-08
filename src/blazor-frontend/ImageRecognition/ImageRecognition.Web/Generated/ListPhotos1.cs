using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ListPhotos1
        : IListPhotos
    {
        public ListPhotos1(
            global::ImageRecognition.Web.IModelPhotoConnection2? listPhotos)
        {
            ListPhotos = listPhotos;
        }

        public global::ImageRecognition.Web.IModelPhotoConnection2? ListPhotos { get; }
    }
}
