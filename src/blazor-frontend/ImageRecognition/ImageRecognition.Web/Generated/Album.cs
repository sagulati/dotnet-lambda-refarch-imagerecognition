using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Album
        : IAlbum
    {
        public Album(
            string id, 
            string name, 
            string? owner, 
            global::ImageRecognition.Web.IModelPhotoConnection? photos)
        {
            Id = id;
            Name = name;
            Owner = owner;
            Photos = photos;
        }

        public string Id { get; }

        public string Name { get; }

        public string? Owner { get; }

        public global::ImageRecognition.Web.IModelPhotoConnection? Photos { get; }
    }
}
