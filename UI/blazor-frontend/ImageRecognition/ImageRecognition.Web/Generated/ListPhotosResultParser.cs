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
    public partial class ListPhotosResultParser
        : JsonResultParserBase<IListPhotos>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _iDSerializer;
        private readonly IValueSerializer _statusSerializer;
        private readonly IValueSerializer _intSerializer;

        public ListPhotosResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _iDSerializer = serializerResolver.Get("ID");
            _statusSerializer = serializerResolver.Get("Status");
            _intSerializer = serializerResolver.Get("Int");
        }

        protected override IListPhotos ParserData(JsonElement data)
        {
            return new ListPhotos1
            (
                ParseListPhotosListPhotos(data, "listPhotos")
            );

        }

        private global::ImageRecognition.Web.IModelPhotoConnection2? ParseListPhotosListPhotos(
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

            return new ModelPhotoConnection2
            (
                ParseListPhotosListPhotosItems(obj, "items"),
                DeserializeNullableString(obj, "nextToken")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto2>? ParseListPhotosListPhotosItems(
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
            var list = new global::ImageRecognition.Web.IPhoto2[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Photo2
                (
                    DeserializeID(element, "id"),
                    DeserializeID(element, "albumId"),
                    DeserializeNullableString(element, "owner"),
                    DeserializeString(element, "bucket"),
                    ParseListPhotosListPhotosItemsFullsize(element, "fullsize"),
                    ParseListPhotosListPhotosItemsThumbnail(element, "thumbnail"),
                    DeserializeNullableString(element, "format"),
                    DeserializeNullableString(element, "exifMake"),
                    DeserializeNullableString(element, "exitModel"),
                    DeserializeNullableString(element, "SfnExecutionArn"),
                    DeserializeNullableStatus(element, "ProcessingStatus"),
                    DeserializeNullableListOfNullableString(element, "objectDetected"),
                    ParseListPhotosListPhotosItemsAlbum(element, "album")
                );

            }

            return list;
        }

        private global::ImageRecognition.Web.IAlbum3? ParseListPhotosListPhotosItemsAlbum(
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

            return new Album3
            (
                DeserializeID(obj, "id"),
                DeserializeString(obj, "name"),
                DeserializeNullableString(obj, "owner")
            );
        }

        private global::ImageRecognition.Web.IPhotoS3Info2? ParseListPhotosListPhotosItemsFullsize(
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

            return new PhotoS3Info2
            (
                DeserializeString(obj, "key"),
                DeserializeNullableInt(obj, "width"),
                DeserializeNullableInt(obj, "height")
            );
        }

        private global::ImageRecognition.Web.IPhotoS3Info3? ParseListPhotosListPhotosItemsThumbnail(
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

            return new PhotoS3Info3
            (
                DeserializeString(obj, "key"),
                DeserializeNullableInt(obj, "width"),
                DeserializeNullableInt(obj, "height")
            );
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
        private int? DeserializeNullableInt(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (int?)_intSerializer.Deserialize(value.GetInt32())!;
        }
    }
}
