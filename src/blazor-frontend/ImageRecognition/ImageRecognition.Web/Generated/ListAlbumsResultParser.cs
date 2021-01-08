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
    public partial class ListAlbumsResultParser
        : JsonResultParserBase<IListAlbums>
    {
        private readonly IValueSerializer _iDSerializer;
        private readonly IValueSerializer _stringSerializer;

        public ListAlbumsResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _iDSerializer = serializerResolver.Get("ID");
            _stringSerializer = serializerResolver.Get("String");
        }

        protected override IListAlbums ParserData(JsonElement data)
        {
            return new ListAlbums1
            (
                ParseListAlbumsListAlbums(data, "listAlbums")
            );

        }

        private global::ImageRecognition.Web.IModelAlbumConnection? ParseListAlbumsListAlbums(
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

            return new ModelAlbumConnection
            (
                ParseListAlbumsListAlbumsItems(obj, "items")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::ImageRecognition.Web.IAlbum1>? ParseListAlbumsListAlbumsItems(
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
            var list = new global::ImageRecognition.Web.IAlbum1[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Album1
                (
                    DeserializeID(element, "id"),
                    DeserializeString(element, "name")
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
    }
}
