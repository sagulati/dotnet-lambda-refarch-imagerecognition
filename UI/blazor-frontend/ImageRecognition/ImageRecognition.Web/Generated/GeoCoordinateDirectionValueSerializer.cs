using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GeoCoordinateDirectionValueSerializer
        : IValueSerializer
    {
        public string Name => "GeoCoordinateDirection";

        public ValueKind Kind => ValueKind.Enum;

        public Type ClrType => typeof(GeoCoordinateDirection);

        public Type SerializationType => typeof(string);

        public object? Serialize(object? value)
        {
            if (value is null)
            {
                return null;
            }

            var enumValue = (GeoCoordinateDirection)value;

            switch(enumValue)
            {
                case GeoCoordinateDirection.E:
                    return "E";
                case GeoCoordinateDirection.N:
                    return "N";
                case GeoCoordinateDirection.S:
                    return "S";
                case GeoCoordinateDirection.W:
                    return "W";
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
                case "E":
                    return GeoCoordinateDirection.E;
                case "N":
                    return GeoCoordinateDirection.N;
                case "S":
                    return GeoCoordinateDirection.S;
                case "W":
                    return GeoCoordinateDirection.W;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
