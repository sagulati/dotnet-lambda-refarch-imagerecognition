using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelPhotoConnection3
        : IModelPhotoConnection3
    {
        public ModelPhotoConnection3(
            global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto3>? items, 
            string? nextToken)
        {
            Items = items;
            NextToken = nextToken;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto3>? Items { get; }

        public string? NextToken { get; }
    }
}
