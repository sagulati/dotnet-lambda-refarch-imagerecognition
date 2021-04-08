using SixLabors.ImageSharp.Metadata;
using System;

namespace Common
{
    public class State : ExecutionInput
    {
        public long Id { get; set; }

        public string Format { get; set; }

        public decimal OrignalImagePixelCount { get; set; }

        public long Size { get; set; }

        public ImageMetadata ImageMetadata { get; set; }

        public ImageSize FullSize { get; set; }

        public ImageSize ThumbnailSize { get; set; }

        public string ProcessingStatus { get; set; }

        public string ExifMake { get; set; }
        
        public string ExifModel { get; set; }

        public GeoLocation Geo { get; set; }

        /// <summary>
        /// Objects detected by AWS Rekognition API
        /// </summary>
        public string[] ObjectDetected { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
