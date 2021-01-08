using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PhotoS3Info
        : IPhotoS3Info
    {
        public PhotoS3Info(
            string key, 
            int? width, 
            int? height)
        {
            Key = key;
            Width = width;
            Height = height;
        }

        public string Key { get; }

        public int? Width { get; }

        public int? Height { get; }
    }
}
