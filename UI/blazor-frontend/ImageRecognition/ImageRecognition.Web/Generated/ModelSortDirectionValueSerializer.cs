using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelSortDirectionValueSerializer
        : IValueSerializer
    {
        public string Name => "ModelSortDirection";

        public ValueKind Kind => ValueKind.Enum;

        public Type ClrType => typeof(ModelSortDirection);

        public Type SerializationType => typeof(string);

        public object? Serialize(object? value)
        {
            if (value is null)
            {
                return null;
            }

            var enumValue = (ModelSortDirection)value;

            switch(enumValue)
            {
                case ModelSortDirection.Asc:
                    return "ASC";
                case ModelSortDirection.Desc:
                    return "DESC";
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
                case "ASC":
                    return ModelSortDirection.Asc;
                case "DESC":
                    return ModelSortDirection.Desc;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
