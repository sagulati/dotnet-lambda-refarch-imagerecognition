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
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.Formats;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

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
        /// A simple function that takes a string and returns both the upper and lower case version of the string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<State> FunctionHandler(State state, ILambdaContext context)
        {
            var tmpPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(state.SourceKey));
            try
            {
                context.Logger.LogLine("Saving image to tmp");
                using (var response = await S3Client.GetObjectAsync(state.Bucket, state.SourceKey))
                {
                    IImageFormat format;
                    //context.Logger.LogLine($"Loading image {tmpPath}. File size {new FileInfo(tmpPath).Length}");
                    using (var sourceImage = Image.Load(response.ResponseStream, out format))
                    {
                        state.ImageMetadata = sourceImage.Metadata;

                        state.OrignalImagePixelCount = sourceImage.Width * sourceImage.Height;

                        state.FullSize = new ImageSize()
                        {
                            Height = sourceImage.Height,
                            Width = sourceImage.Width,
                            Size = state.Size,
                            Key = state.SourceKey
                        };
                        state.Format = format.Name;
                    }
                }

                return state;
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
