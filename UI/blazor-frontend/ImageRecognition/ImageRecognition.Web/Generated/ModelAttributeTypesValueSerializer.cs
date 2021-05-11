using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelAttributeTypesValueSerializer
        : IValueSerializer
    {
        public string Name => "ModelAttributeTypes";

        public ValueKind Kind => ValueKind.Enum;

        public Type ClrType => typeof(ModelAttributeTypes);

        public Type SerializationType => typeof(string);

        public object? Serialize(object? value)
        {
            if (value is null)
            {
                return null;
            }

            var enumValue = (ModelAttributeTypes)value;

            switch(enumValue)
            {
                case ModelAttributeTypes.Null:
                    return "_NULL";
                case ModelAttributeTypes.Binary:
                    return "BINARY";
                case ModelAttributeTypes.Binaryset:
                    return "BINARYSET";
                case ModelAttributeTypes.Bool:
                    return "BOOL";
                case ModelAttributeTypes.List:
                    return "LIST";
                case ModelAttributeTypes.Map:
                    return "MAP";
                case ModelAttributeTypes.Number:
                    return "NUMBER";
                case ModelAttributeTypes.Numberset:
                    return "NUMBERSET";
                case ModelAttributeTypes.String:
                    return "STRING";
                case ModelAttributeTypes.Stringset:
                    return "STRINGSET";
                default:
                    throw new NotSupportedException();
            }
        }

        public object? Deserialize(object? serialized)
        {
            if (serialized is null)
            {
                return null;
            }

            var stringValue = (string)serialized;

            switch(stringValue)
            {
                case "_NULL":
                    return ModelAttributeTypes.Null;
                case "BINARY":
                    return ModelAttributeTypes.Binary;
                case "BINARYSET":
                    return ModelAttributeTypes.Binaryset;
                case "BOOL":
                    return ModelAttributeTypes.Bool;
                case "LIST":
                    return ModelAttributeTypes.List;
                case "MAP":
                    return ModelAttributeTypes.Map;
                case "NUMBER":
                    return ModelAttributeTypes.Number;
                case "NUMBERSET":
                    return ModelAttributeTypes.Numberset;
                case "STRING":
                    return ModelAttributeTypes.String;
                case "STRINGSET":
                    return ModelAttributeTypes.Stringset;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
