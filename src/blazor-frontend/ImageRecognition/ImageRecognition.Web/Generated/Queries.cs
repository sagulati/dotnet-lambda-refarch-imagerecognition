using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Queries
        : global::StrawberryShake.IDocument
    {
        private readonly byte[] _hashName = new byte[]
        {
            109,
            100,
            53,
            72,
            97,
            115,
            104
        };
        private readonly byte[] _hash = new byte[]
        {
            50,
            102,
            57,
            100,
            48,
            52,
            49,
            98,
            99,
            98,
            51,
            102,
            55,
            54,
            56,
            99,
            98,
            52,
            57,
            98,
            51,
            54,
            97,
            48,
            54,
            100,
            100,
            97,
            97,
            102,
            97,
            97
        };
        private readonly byte[] _content = new byte[]
        {
            113,
            117,
            101,
            114,
            121,
            32,
            77,
            121,
            81,
            117,
            101,
            114,
            121,
            32,
            123,
            32,
            108,
            105,
            115,
            116,
            65,
            108,
            98,
            117,
            109,
            115,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            105,
            116,
            101,
            109,
            115,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            105,
            100,
            32,
            110,
            97,
            109,
            101,
            32,
            111,
            119,
            110,
            101,
            114,
            32,
            125,
            32,
            125,
            32,
            125
        };

        public ReadOnlySpan<byte> HashName => _hashName;

        public ReadOnlySpan<byte> Hash => _hash;

        public ReadOnlySpan<byte> Content => _content;

        public static Queries Default { get; } = new Queries();

        public override string ToString() => 
            @"query MyQuery {
              listAlbums {
                items {
                  id
                  name
                  owner
                }
              }
            }";
    }
}
