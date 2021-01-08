using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Photo
        : IPhoto
    {
        public Photo(
            string id, 
            string albumId, 
            string? owner, 
            string bucket, 
            string? format, 
            string? exifMake, 
            string? exitModel, 
            string? sfnExecutionArn, 
            Status? processingStatus, 
            IReadOnlyList<string?>? objectDetected)
        {
            Id = id;
            AlbumId = albumId;
            Owner = owner;
            Bucket = bucket;
            Format = format;
            ExifMake = exifMake;
            ExitModel = exitModel;
            SfnExecutionArn = sfnExecutionArn;
            ProcessingStatus = processingStatus;
            ObjectDetected = objectDetected;
        }

        public string Id { get; }

        public string AlbumId { get; }

        public string? Owner { get; }

        public string Bucket { get; }

        public string? Format { get; }

        public string? ExifMake { get; }

        public string? ExitModel { get; }

        public string? SfnExecutionArn { get; }

        public Status? ProcessingStatus { get; }

        public IReadOnlyList<string?>? ObjectDetected { get; }
    }
}
