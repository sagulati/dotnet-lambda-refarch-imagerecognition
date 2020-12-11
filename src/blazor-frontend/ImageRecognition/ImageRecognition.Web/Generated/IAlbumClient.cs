using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IAlbumClient
    {
        Task<IOperationResult<global::ImageRecognition.Web.IMyQuery>> MyQueryAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::ImageRecognition.Web.IMyQuery>> MyQueryAsync(
            MyQueryOperation operation,
            CancellationToken cancellationToken = default);
    }
}
