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

        Task<IOperationResult<global::ImageRecognition.Web.IGetPhoto>> GetPhotoAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::ImageRecognition.Web.IGetPhoto>> GetPhotoAsync(
            GetPhotoOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::ImageRecognition.Web.IListPhotos>> ListPhotosAsync(
            Optional<global::ImageRecognition.Web.ModelPhotoFilterInput?> filter = default,
            Optional<int?> limit = default,
            Optional<string?> nextToken = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::ImageRecognition.Web.IListPhotos>> ListPhotosAsync(
            ListPhotosOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::ImageRecognition.Web.IListPhotosByAlbumUploadTime>> ListPhotosByAlbumUploadTimeAsync(
            Optional<string?> albumId = default,
            Optional<ModelSortDirection?> sortDirection = default,
            Optional<global::ImageRecognition.Web.ModelPhotoFilterInput?> filter = default,
            Optional<int?> limit = default,
            Optional<string?> nextToken = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::ImageRecognition.Web.IListPhotosByAlbumUploadTime>> ListPhotosByAlbumUploadTimeAsync(
            ListPhotosByAlbumUploadTimeOperation operation,
            CancellationToken cancellationToken = default);
    }
}
