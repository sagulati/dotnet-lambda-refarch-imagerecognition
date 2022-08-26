using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ImageRecognition.Web.Models
{
    public partial class ListAlbumResponse
    {
        [JsonProperty("listAlbums")]
        public ListAlbums? ListAlbums { get; set; }
    }

    public partial class ListAlbums
    {
        [JsonProperty("items")]
        public Album[]? Albums { get; set; }
    }

    public partial class Album
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

}
