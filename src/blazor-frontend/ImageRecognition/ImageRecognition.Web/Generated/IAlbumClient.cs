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
        Task<IOperationResult<global::ImageRecognition.Web.IGetAlbum>> GetAlbumAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::ImageRecognition.Web.IGetAlbum>> GetAlbumAsync(
            GetAlbumOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::ImageRecognition.Web.IListAlbums>> ListAlbumsAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::ImageRecognition.Web.IListAlbums>> ListAlbumsAsync(
            ListAlbumsOperation operation,
            CancellationToken cancellationToken = default);
    }
}
