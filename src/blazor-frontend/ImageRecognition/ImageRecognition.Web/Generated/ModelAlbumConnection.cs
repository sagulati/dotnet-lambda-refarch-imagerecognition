using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelAlbumConnection
        : IModelAlbumConnection
    {
        public ModelAlbumConnection(
            global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IAlbum1>? items)
        {
            Items = items;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IAlbum1>? Items { get; }
    }
}
