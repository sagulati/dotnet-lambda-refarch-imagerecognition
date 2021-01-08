using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelPhotoConnection2
        : IModelPhotoConnection2
    {
        public ModelPhotoConnection2(
            global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto2>? items, 
            string? nextToken)
        {
            Items = items;
            NextToken = nextToken;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto2>? Items { get; }

        public string? NextToken { get; }
    }
}
