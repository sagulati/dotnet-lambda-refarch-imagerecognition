﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Album3
        : IAlbum3
    {
        public Album3(
            string id, 
            string name, 
            string? owner)
        {
            Id = id;
            Name = name;
            Owner = owner;
        }

        public string Id { get; }

        public string Name { get; }

        public string? Owner { get; }
    }
}
