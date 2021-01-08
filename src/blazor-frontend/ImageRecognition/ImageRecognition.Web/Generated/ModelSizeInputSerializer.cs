using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelSizeInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer? _intSerializer;

        public string Name { get; } = "ModelSizeInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(ModelSizeInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.Get("Int");
            _needsInitialization = false;
        }

        public object? Serialize(object? value)
        {
            if (_needsInitialization)
            {
                throw new InvalidOperationException(
                    $"The serializer for type `{Name}` has not been initialized.");
            }

            if (value is null)
            {
                return null;
            }

            var input = (ModelSizeInput)value;
            var map = new Dictionary<string, object?>();

            if (input.Between.HasValue)
            {
                map.Add("between", SerializeNullableListOfNullableInt(input.Between.Value));
            }

            if (input.Eq.HasValue)
            {
                map.Add("eq", SerializeNullableInt(input.Eq.Value));
            }

            if (input.Ge.HasValue)
            {
                map.Add("ge", SerializeNullableInt(input.Ge.Value));
            }

            if (input.Gt.HasValue)
            {
                map.Add("gt", SerializeNullableInt(input.Gt.Value));
            }

            if (input.Le.HasValue)
            {
                map.Add("le", SerializeNullableInt(input.Le.Value));
            }

            if (input.Lt.HasValue)
            {
                map.Add("lt", SerializeNullableInt(input.Lt.Value));
            }

            if (input.Ne.HasValue)
            {
                map.Add("ne", SerializeNullableInt(input.Ne.Value));
            }

            return map;
        }

        private object? SerializeNullableInt(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _intSerializer!.Serialize(value);
        }

        private object? SerializeNullableListOfNullableInt(object? value)
        {
            if (value is null)
            {
                return null;
            }


            IList source = (IList)value;
            object?[] result = new object?[source.Count];
            for(int i = 0; i < source.Count; i++)
            {
                result[i] = SerializeNullableInt(source[i]);
            }
            return result;
        }

        public object? Deserialize(object? value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
