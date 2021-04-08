using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Common;
using SixLabors.ImageSharp.Metadata;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace trasnform_metadata
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and returns both the upper and lower case version of the string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<State> FunctionHandler(State state, ILambdaContext context)
        {
            // extract geo location from Metadata.

            // extract exifMake from Metadata

            // remove existing metadata.
            state.ImageMetadata = null;

            return state;
        }
    }

    public record Casing(string Lower, string Upper);
}
