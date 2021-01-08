using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelPhotoConnection
        : IModelPhotoConnection
    {
        public ModelPhotoConnection(
            global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto>? items, 
            string? nextToken)
        {
            Items = items;
            NextToken = nextToken;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto>? Items { get; }

        public string? NextToken { get; }
    }
}
