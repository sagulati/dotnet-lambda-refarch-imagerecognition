using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetAlbumResultParser
        : JsonResultParserBase<IGetAlbum>
    {
        private readonly IValueSerializer _iDSerializer;
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _statusSerializer;

        public GetAlbumResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _iDSerializer = serializerResolver.Get("ID");
            _stringSerializer = serializerResolver.Get("String");
            _statusSerializer = serializerResolver.Get("Status");
        }

        protected override IGetAlbum ParserData(JsonElement data)
        {
            return new GetAlbum1
            (
                ParseGetAlbumGetAlbum(data, "getAlbum")
            );

        }

        private global::ImageRecognition.Web.IAlbum? ParseGetAlbumGetAlbum(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new Album
            (
                DeserializeID(obj, "id"),
                DeserializeString(obj, "name"),
                DeserializeNullableString(obj, "owner"),
                ParseGetAlbumGetAlbumPhotos(obj, "photos")
            );
        }

        private global::ImageRecognition.Web.IModelPhotoConnection? ParseGetAlbumGetAlbumPhotos(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new ModelPhotoConnection
            (
                ParseGetAlbumGetAlbumPhotosItems(obj, "items"),
                DeserializeNullableString(obj, "nextToken")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto>? ParseGetAlbumGetAlbumPhotosItems(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            int objLength = obj.GetArrayLength();
            var list = new global::ImageRecognition.Web.IPhoto[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Photo
                (
                    DeserializeID(element, "id"),
                    DeserializeID(element, "albumId"),
                    DeserializeNullableString(element, "owner"),
                    DeserializeString(element, "bucket"),
                    DeserializeNullableString(element, "format"),
                    DeserializeNullableString(element, "exifMake"),
                    DeserializeNullableString(element, "exitModel"),
                    DeserializeNullableString(element, "SfnExecutionArn"),
                    DeserializeNullableStatus(element, "ProcessingStatus"),
                    DeserializeNullableListOfNullableString(element, "objectDetected")
                );

            }

            return list;
        }

        private string DeserializeID(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_iDSerializer.Deserialize(value.GetString())!;
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString())!;
        }

        private string? DeserializeNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string?)_stringSerializer.Deserialize(value.GetString())!;
        }
        private Status? DeserializeNullableStatus(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (Status?)_statusSerializer.Deserialize(value.GetString())!;
        }

        private IReadOnlyList<string?>? DeserializeNullableListOfNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement list))
            {
                return null;
            }

            if (list.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            int listLength = list.GetArrayLength();
            var listList = new string?[listLength];

            for (int i = 0; i < listLength; i++)
            {
                JsonElement element = list[i];
                if (element.ValueKind == JsonValueKind.Null)
                {
                    listList[i] = null;
                }
                else
                {
                    listList[i] = (string?)_stringSerializer.Deserialize(element.GetString())!;
                }
            }
            return listList;
        }
    }
}
