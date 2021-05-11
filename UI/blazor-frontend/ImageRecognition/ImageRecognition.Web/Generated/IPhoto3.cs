using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IPhoto3
    {
        string Id { get; }

        string AlbumId { get; }

        string? Owner { get; }

        string Bucket { get; }

        global::ImageRecognition.Web.IPhotoS3Info4? Fullsize { get; }

        global::ImageRecognition.Web.IPhotoS3Info5? Thumbnail { get; }

        string? Format { get; }

        string? ExifMake { get; }

        string? ExitModel { get; }

        string? SfnExecutionArn { get; }

        Status? ProcessingStatus { get; }

        IReadOnlyList<string?>? ObjectDetected { get; }

        global::ImageRecognition.Web.IGeoCoordinates1? GeoLocation { get; }
    }
}
