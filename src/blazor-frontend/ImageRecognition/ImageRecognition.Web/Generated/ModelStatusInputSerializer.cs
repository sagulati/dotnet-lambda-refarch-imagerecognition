using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelStatusInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer? _statusSerializer;

        public string Name { get; } = "ModelStatusInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(ModelStatusInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _statusSerializer = serializerResolver.Get("Status");
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

            var input = (ModelStatusInput)value;
            var map = new Dictionary<string, object?>();

            if (input.Eq.HasValue)
            {
                map.Add("eq", SerializeNullableStatus(input.Eq.Value));
            }

            if (input.Ne.HasValue)
            {
                map.Add("ne", SerializeNullableStatus(input.Ne.Value));
            }

            return map;
        }

        private object? SerializeNullableStatus(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _statusSerializer!.Serialize(value);
        }

        public object? Deserialize(object? value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
