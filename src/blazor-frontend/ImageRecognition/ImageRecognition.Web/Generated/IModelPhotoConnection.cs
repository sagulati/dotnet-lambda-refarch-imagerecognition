using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IModelPhotoConnection
    {
        global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto>? Items { get; }

        string? NextToken { get; }
    }
}
