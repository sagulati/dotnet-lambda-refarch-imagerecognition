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
    public partial class GetPhotoResultParser
        : JsonResultParserBase<IGetPhoto>
    {
        private readonly IValueSerializer _iDSerializer;
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _statusSerializer;
        private readonly IValueSerializer _intSerializer;
        private readonly IValueSerializer _floatSerializer;
        private readonly IValueSerializer _geoCoordinateDirectionSerializer;

        public GetPhotoResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _iDSerializer = serializerResolver.Get("ID");
            _stringSerializer = serializerResolver.Get("String");
            _statusSerializer = serializerResolver.Get("Status");
            _intSerializer = serializerResolver.Get("Int");
            _floatSerializer = serializerResolver.Get("Float");
            _geoCoordinateDirectionSerializer = serializerResolver.Get("GeoCoordinateDirection");
        }

        protected override IGetPhoto ParserData(JsonElement data)
        {
            return new GetPhoto1
            (
                ParseGetPhotoGetPhoto(data, "getPhoto")
            );

        }

        private global::ImageRecognition.Web.IPhoto1? ParseGetPhotoGetPhoto(
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

            return new Photo1
            (
                DeserializeID(obj, "id"),
                DeserializeID(obj, "albumId"),
                DeserializeNullableString(obj, "owner"),
                DeserializeString(obj, "bucket"),
                ParseGetPhotoGetPhotoFullsize(obj, "fullsize"),
                ParseGetPhotoGetPhotoThumbnail(obj, "thumbnail"),
                DeserializeNullableString(obj, "format"),
                DeserializeNullableString(obj, "exifMake"),
                DeserializeNullableString(obj, "exitModel"),
                DeserializeNullableString(obj, "SfnExecutionArn"),
                DeserializeNullableStatus(obj, "ProcessingStatus"),
                DeserializeNullableListOfNullableString(obj, "objectDetected"),
                ParseGetPhotoGetPhotoGeoLocation(obj, "geoLocation"),
                ParseGetPhotoGetPhotoAlbum(obj, "album")
            );
        }

        private global::ImageRecognition.Web.IAlbum2? ParseGetPhotoGetPhotoAlbum(
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

            return new Album2
            (
                DeserializeID(obj, "id"),
                DeserializeString(obj, "name"),
                DeserializeNullableString(obj, "owner"),
                ParseGetPhotoGetPhotoAlbumPhotos(obj, "photos")
            );
        }

        private global::ImageRecognition.Web.IPhotoS3Info? ParseGetPhotoGetPhotoFullsize(
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

            return new PhotoS3Info
            (
                DeserializeString(obj, "key"),
                DeserializeNullableInt(obj, "width"),
                DeserializeNullableInt(obj, "height")
            );
        }

        private global::ImageRecognition.Web.IGeoCoordinates? ParseGetPhotoGetPhotoGeoLocation(
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

            return new GeoCoordinates
            (
                ParseGetPhotoGetPhotoGeoLocationLatitude(obj, "Latitude"),
                ParseGetPhotoGetPhotoGeoLocationLongtitude(obj, "Longtitude")
            );
        }

        private global::ImageRecognition.Web.IPhotoS3Info1? ParseGetPhotoGetPhotoThumbnail(
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

            return new PhotoS3Info1
            (
                DeserializeString(obj, "key"),
                DeserializeNullableInt(obj, "width"),
                DeserializeNullableInt(obj, "height")
            );
        }

        private global::ImageRecognition.Web.IModelPhotoConnection1? ParseGetPhotoGetPhotoAlbumPhotos(
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

            return new ModelPhotoConnection1
            (
                DeserializeNullableString(obj, "nextToken")
            );
        }

        private global::ImageRecognition.Web.ILatitude ParseGetPhotoGetPhotoGeoLocationLatitude(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Latitude
            (
                DeserializeFloat(obj, "D"),
                DeserializeFloat(obj, "M"),
                DeserializeFloat(obj, "S"),
                DeserializeGeoCoordinateDirection(obj, "Direction")
            );
        }

        private global::ImageRecognition.Web.ILongtitude ParseGetPhotoGetPhotoGeoLocationLongtitude(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Longtitude
            (
                DeserializeFloat(obj, "D"),
                DeserializeFloat(obj, "M"),
                DeserializeFloat(obj, "S"),
                DeserializeGeoCoordinateDirection(obj, "Direction")
            );
        }

        private string DeserializeID(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_iDSerializer.Deserialize(value.GetString())!;
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
