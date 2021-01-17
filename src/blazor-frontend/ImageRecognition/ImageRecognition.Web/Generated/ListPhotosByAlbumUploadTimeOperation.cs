using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ListPhotosByAlbumUploadTimeOperation
        : IOperation<IListPhotosByAlbumUploadTime>
    {
        public string Name => "ListPhotosByAlbumUploadTime";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IListPhotosByAlbumUploadTime);

        public Optional<string?> AlbumId { get; set; }

        public Optional<ModelSortDirection?> SortDirection { get; set; }

        public Optional<global::ImageRecognition.Web.ModelPhotoFilterInput?> Filter { get; set; }

        public Optional<int?> Limit { get; set; }

        public Optional<string?> NextToken { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (AlbumId.HasValue)
            {
                variables.Add(new VariableValue("albumId", "ID", AlbumId.Value));
            }

            if (SortDirection.HasValue)
            {
                variables.Add(new VariableValue("sortDirection", "ModelSortDirection", SortDirection.Value));
            }

            if (Filter.HasValue)
            {
                variables.Add(new VariableValue("filter", "ModelPhotoFilterInput", Filter.Value));
            }

            if (Limit.HasValue)
            {
                variables.Add(new VariableValue("limit", "Int", Limit.Value));
            }

            if (NextToken.HasValue)
            {
                variables.Add(new VariableValue("nextToken", "String", NextToken.Value));
            }

            return variables;
        }
    }
}
