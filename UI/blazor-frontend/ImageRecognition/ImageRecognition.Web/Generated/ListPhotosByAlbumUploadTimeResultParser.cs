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
    public partial class ListPhotosByAlbumUploadTimeResultParser
        : JsonResultParserBase<IListPhotosByAlbumUploadTime>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _iDSerializer;
        private readonly IValueSerializer _statusSerializer;
        private readonly IValueSerializer _intSerializer;
        private readonly IValueSerializer _floatSerializer;
        private readonly IValueSerializer _geoCoordinateDirectionSerializer;

        public ListPhotosByAlbumUploadTimeResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _iDSerializer = serializerResolver.Get("ID");
            _statusSerializer = serializerResolver.Get("Status");
            _intSerializer = serializerResolver.Get("Int");
            _floatSerializer = serializerResolver.Get("Float");
            _geoCoordinateDirectionSerializer = serializerResolver.Get("GeoCoordinateDirection");
        }

        protected override IListPhotosByAlbumUploadTime ParserData(JsonElement data)
        {
            return new ListPhotosByAlbumUploadTime1
            (
                ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTime(data, "listPhotosByAlbumUploadTime")
            );

        }

        private global::ImageRecognition.Web.IModelPhotoConnection3? ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTime(
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

            return new ModelPhotoConnection3
            (
                ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItems(obj, "items"),
                DeserializeNullableString(obj, "nextToken")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IPhoto3>? ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItems(
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
            var list = new global::ImageRecognition.Web.IPhoto3[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Photo3
                (
                    DeserializeID(element, "id"),
                    DeserializeID(element, "albumId"),
                    DeserializeNullableString(element, "owner"),
                    DeserializeString(element, "bucket"),
                    ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsFullsize(element, "fullsize"),
                    ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsThumbnail(element, "thumbnail"),
                    DeserializeNullableString(element, "format"),
                    DeserializeNullableString(element, "exifMake"),
                    DeserializeNullableString(element, "exitModel"),
                    DeserializeNullableString(element, "SfnExecutionArn"),
                    DeserializeNullableStatus(element, "ProcessingStatus"),
                    DeserializeNullableListOfNullableString(element, "objectDetected"),
                    ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsGeoLocation(element, "geoLocation")
                );

            }

            return list;
        }

        private global::ImageRecognition.Web.IPhotoS3Info4? ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsFullsize(
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

            return new PhotoS3Info4
            (
                DeserializeString(obj, "key"),
                DeserializeNullableInt(obj, "width"),
                DeserializeNullableInt(obj, "height")
            );
        }

        private global::ImageRecognition.Web.IGeoCoordinates1? ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsGeoLocation(
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

            return new GeoCoordinates1
            (
                ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsGeoLocationLatitude(obj, "Latitude"),
                ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsGeoLocationLongtitude(obj, "Longtitude")
            );
        }

        private global::ImageRecognition.Web.IPhotoS3Info5? ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsThumbnail(
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

            return new PhotoS3Info5
            (
                DeserializeString(obj, "key"),
                DeserializeNullableInt(obj, "width"),
                DeserializeNullableInt(obj, "height")
            );
        }

        private global::ImageRecognition.Web.ILatitude1 ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsGeoLocationLatitude(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Latitude1
            (
                DeserializeFloat(obj, "D"),
                DeserializeFloat(obj, "M"),
                DeserializeFloat(obj, "S"),
                DeserializeGeoCoordinateDirection(obj, "Direction")
            );
        }

        private global::ImageRecognition.Web.ILongtitude1 ParseListPhotosByAlbumUploadTimeListPhotosByAlbumUploadTimeItemsGeoLocationLongtitude(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Longtitude1
            (
                DeserializeFloat(obj, "D"),
                DeserializeFloat(obj, "M"),
                DeserializeFloat(obj, "S"),
                DeserializeGeoCoordinateDirection(obj, "Direction")
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
        private double DeserializeFloat(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (double)_floatSerializer.Deserialize(value.GetDouble())!;
        }

        private GeoCoordinateDirection DeserializeGeoCoordinateDirection(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (GeoCoordinateDirection)_geoCoordinateDirectionSerializer.Deserialize(value.GetString())!;
        }
    }
}
