using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IAlbum2
    {
        string Id { get; }

        string Name { get; }

        string? Owner { get; }

        global::ImageRecognition.Web.IModelPhotoConnection1? Photos { get; }
    }
}
