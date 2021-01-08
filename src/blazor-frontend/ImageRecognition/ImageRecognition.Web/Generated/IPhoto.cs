using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IPhoto
    {
        string Id { get; }

        string AlbumId { get; }

        string? Owner { get; }

        string Bucket { get; }

        string? Format { get; }

        string? ExifMake { get; }

        string? ExitModel { get; }

        string? SfnExecutionArn { get; }

        Status? ProcessingStatus { get; }

        IReadOnlyList<string?>? ObjectDetected { get; }
    }
}
