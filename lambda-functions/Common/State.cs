using System;

namespace Common
{
    public class State : ExecutionInput
    {
        public long Id { get; set; }

        public string ImageFormat { get; set; }

        public ImageSize FullSize { get; set; }

        public ImageSize ThumbnailSize { get; set; }

        public string ProcessingStatus { get; set; }

        /// <summary>
        /// Objects detected by AWS Rekognition API
        /// </summary>
        public string[] ObjectDetected { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
