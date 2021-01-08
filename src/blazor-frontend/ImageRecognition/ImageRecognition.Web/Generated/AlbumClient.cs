using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AlbumClient
        : IAlbumClient
    {
        private const string _clientName = "AlbumClient";

        private readonly global::StrawberryShake.IOperationExecutor _executor;

        public AlbumClient(global::StrawberryShake.IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IGetAlbum>> GetAlbumAsync(
            global::StrawberryShake.Optional<string> id = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (id.HasValue && id.Value is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _executor.ExecuteAsync(
                new GetAlbumOperation { Id = id },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IGetAlbum>> GetAlbumAsync(
            GetAlbumOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IListAlbums>> ListAlbumsAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new ListAlbumsOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IListAlbums>> ListAlbumsAsync(
            ListAlbumsOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
