using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelIDInput
    {
        public Optional<bool?> AttributeExists { get; set; }

        public Optional<ModelAttributeTypes?> AttributeType { get; set; }

        public Optional<string?> BeginsWith { get; set; }

        public Optional<IReadOnlyList<string?>?> Between { get; set; }

        public Optional<string?> Contains { get; set; }

        public Optional<string?> Eq { get; set; }

        public Optional<string?> Ge { get; set; }

        public Optional<string?> Gt { get; set; }

        public Optional<string?> Le { get; set; }

        public Optional<string?> Lt { get; set; }

        public Optional<string?> Ne { get; set; }

        public Optional<string?> NotContains { get; set; }

        public Optional<global::ImageRecognition.Web.ModelSizeInput?> Size { get; set; }
    }
}
