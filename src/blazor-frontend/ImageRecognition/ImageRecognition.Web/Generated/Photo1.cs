using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Photo1
        : IPhoto1
    {
        public Photo1(
            string id, 
            string albumId, 
            string? owner, 
            string bucket, 
            global::ImageRecognition.Web.IPhotoS3Info? fullsize, 
            global::ImageRecognition.Web.IPhotoS3Info1? thumbnail, 
            string? format, 
            string? exifMake, 
            string? exitModel, 
            string? sfnExecutionArn, 
            Status? processingStatus, 
            IReadOnlyList<string?>? objectDetected, 
            global::ImageRecognition.Web.IGeoCoordinates? geoLocation, 
            global::ImageRecognition.Web.IAlbum2? album)
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
            Album = album;
        }

        public string Id { get; }

        public string AlbumId { get; }

        public string? Owner { get; }

        public string Bucket { get; }

        public global::ImageRecognition.Web.IPhotoS3Info? Fullsize { get; }

        public global::ImageRecognition.Web.IPhotoS3Info1? Thumbnail { get; }

        public string? Format { get; }

        public string? ExifMake { get; }

        public string? ExitModel { get; }

        public string? SfnExecutionArn { get; }

        public Status? ProcessingStatus { get; }

        public IReadOnlyList<string?>? ObjectDetected { get; }

        public global::ImageRecognition.Web.IGeoCoordinates? GeoLocation { get; }

        public global::ImageRecognition.Web.IAlbum2? Album { get; }
    }
}
