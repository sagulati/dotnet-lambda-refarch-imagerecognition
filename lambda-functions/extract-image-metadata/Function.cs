using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.S3;
using Common;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
[assembly: LambdaSerializer(typeof(NewtonJsonSerializer))]
namespace extract_image_metadata
{
    public class Function
    {
        IAmazonS3 S3Client { get; set; }

        public Function()
        {
            this.S3Client = new AmazonS3Client();
        }

        /// <summary>
        /// A simple function that takes a s3 bucket input and extract metadata of Image.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<ImageMetadata> FunctionHandler(ExecutionInput state, ILambdaContext context)
        {
            var tmpPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(state.SourceKey));
            try
            {
                ImageMetadata metadata = new ImageMetadata(); 
                using (var response = await S3Client.GetObjectAsync(state.Bucket, state.SourceKey))
                {
                    IImageFormat format;
                    
                    using (var sourceImage = Image.Load(response.ResponseStream, out format))
                    {
                        metadata.OrignalImagePixelCount = sourceImage.Width * sourceImage.Height;

                        metadata.Width = sourceImage.Width;

                        metadata.Height = sourceImage.Height;

                        metadata.ExifProfile = sourceImage.Metadata.ExifProfile;

                        metadata.Format = format.Name;
                    }
                }

                return metadata;
            }
            finally
            {
                if (File.Exists(tmpPath))
                {
                    File.Delete(tmpPath);
                }
            }
        }
    }
}
