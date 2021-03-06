﻿using System;
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

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IGetPhoto>> GetPhotoAsync(
            global::StrawberryShake.Optional<string> id = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (id.HasValue && id.Value is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _executor.ExecuteAsync(
                new GetPhotoOperation { Id = id },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IGetPhoto>> GetPhotoAsync(
            GetPhotoOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IListPhotos>> ListPhotosAsync(
            global::StrawberryShake.Optional<global::ImageRecognition.Web.ModelPhotoFilterInput?> filter = default,
            global::StrawberryShake.Optional<int?> limit = default,
            global::StrawberryShake.Optional<string?> nextToken = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new ListPhotosOperation
                {
                    Filter = filter, 
                    Limit = limit, 
                    NextToken = nextToken
                },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IListPhotos>> ListPhotosAsync(
            ListPhotosOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IListPhotosByAlbumUploadTime>> ListPhotosByAlbumUploadTimeAsync(
            global::StrawberryShake.Optional<string?> albumId = default,
            global::StrawberryShake.Optional<ModelSortDirection?> sortDirection = default,
            global::StrawberryShake.Optional<global::ImageRecognition.Web.ModelPhotoFilterInput?> filter = default,
            global::StrawberryShake.Optional<int?> limit = default,
            global::StrawberryShake.Optional<string?> nextToken = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new ListPhotosByAlbumUploadTimeOperation
                {
                    AlbumId = albumId, 
                    SortDirection = sortDirection, 
                    Filter = filter, 
                    Limit = limit, 
                    NextToken = nextToken
                },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::ImageRecognition.Web.IListPhotosByAlbumUploadTime>> ListPhotosByAlbumUploadTimeAsync(
            ListPhotosByAlbumUploadTimeOperation operation,
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
