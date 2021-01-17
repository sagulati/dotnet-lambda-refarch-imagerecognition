using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Photo3
        : IPhoto3
    {
        public Photo3(
            string id, 
            string albumId, 
            string? owner, 
            string bucket, 
            global::ImageRecognition.Web.IPhotoS3Info4? fullsize, 
            global::ImageRecognition.Web.IPhotoS3Info5? thumbnail, 
            string? format, 
            string? exifMake, 
            string? exitModel, 
            string? sfnExecutionArn, 
            Status? processingStatus, 
            IReadOnlyList<string?>? objectDetected, 
            global::ImageRecognition.Web.IGeoCoordinates1? geoLocation)
        {
            Id = id;
            AlbumId = albumId;
            Owner = owner;
            Bucket = bucket;
            Fullsize = fullsize;
            Thumbnail = thumbnail;
            Format = format;
            ExifMake = exifMake;
            ExitModel = exitModel;
            SfnExecutionArn = sfnExecutionArn;
            ProcessingStatus = processingStatus;
            ObjectDetected = objectDetected;
            GeoLocation = geoLocation;
        }

        public string Id { get; }

        public string AlbumId { get; }

        public string? Owner { get; }

        public string Bucket { get; }

        public global::ImageRecognition.Web.IPhotoS3Info4? Fullsize { get; }

        public global::ImageRecognition.Web.IPhotoS3Info5? Thumbnail { get; }

        public string? Format { get; }

        public string? ExifMake { get; }

        public string? ExitModel { get; }

        public string? SfnExecutionArn { get; }

        public Status? ProcessingStatus { get; }

        public IReadOnlyList<string?>? ObjectDetected { get; }

        public global::ImageRecognition.Web.IGeoCoordinates1? GeoLocation { get; }
    }
}
