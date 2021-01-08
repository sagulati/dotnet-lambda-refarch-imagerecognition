using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelPhotoFilterInput
    {
        public Optional<global::ImageRecognition.Web.ModelIDInput?> AlbumId { get; set; }

        public Optional<global::System.Collections.Generic.List<global::ImageRecognition.Web.ModelPhotoFilterInput>?> And { get; set; }

        public Optional<global::ImageRecognition.Web.ModelStringInput?> Bucket { get; set; }

        public Optional<global::ImageRecognition.Web.ModelStringInput?> ExifMake { get; set; }

        public Optional<global::ImageRecognition.Web.ModelStringInput?> ExitModel { get; set; }

        public Optional<global::ImageRecognition.Web.ModelStringInput?> Format { get; set; }

        public Optional<global::ImageRecognition.Web.ModelIDInput?> Id { get; set; }

        public Optional<global::ImageRecognition.Web.ModelPhotoFilterInput?> Not { get; set; }

        public Optional<global::ImageRecognition.Web.ModelStringInput?> ObjectDetected { get; set; }

        public Optional<global::System.Collections.Generic.List<global::ImageRecognition.Web.ModelPhotoFilterInput>?> Or { get; set; }

        public Optional<global::ImageRecognition.Web.ModelStringInput?> Owner { get; set; }

        public Optional<global::ImageRecognition.Web.ModelStatusInput?> ProcessingStatus { get; set; }

        public Optional<global::ImageRecognition.Web.ModelStringInput?> SfnExecutionArn { get; set; }

        public Optional<global::ImageRecognition.Web.ModelStringInput?> UploadTime { get; set; }
    }
}
