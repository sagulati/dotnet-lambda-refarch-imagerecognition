﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ListAlbums1
        : IListAlbums
    {
        public ListAlbums1(
            global::ImageRecognition.Web.IModelAlbumConnection? listAlbums)
        {
            ListAlbums = listAlbums;
        }

        public global::ImageRecognition.Web.IModelAlbumConnection? ListAlbums { get; }
    }
}
