using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelIDInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer? _booleanSerializer;
        private IValueSerializer? _modelAttributeTypesSerializer;
        private IValueSerializer? _iDSerializer;
        private IValueSerializer? _modelSizeInputSerializer;

        public string Name { get; } = "ModelIDInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(ModelIDInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _booleanSerializer = serializerResolver.Get("Boolean");
            _modelAttributeTypesSerializer = serializerResolver.Get("ModelAttributeTypes");
            _iDSerializer = serializerResolver.Get("ID");
            _modelSizeInputSerializer = serializerResolver.Get("ModelSizeInput");
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

            var input = (ModelIDInput)value;
            var map = new Dictionary<string, object?>();

            if (input.AttributeExists.HasValue)
            {
                map.Add("attributeExists", SerializeNullableBoolean(input.AttributeExists.Value));
            }

            if (input.AttributeType.HasValue)
            {
                map.Add("attributeType", SerializeNullableModelAttributeTypes(input.AttributeType.Value));
            }

            if (input.BeginsWith.HasValue)
            {
                map.Add("beginsWith", SerializeNullableID(input.BeginsWith.Value));
            }

            if (input.Between.HasValue)
            {
                map.Add("between", SerializeNullableListOfNullableID(input.Between.Value));
            }

            if (input.Contains.HasValue)
            {
                map.Add("contains", SerializeNullableID(input.Contains.Value));
            }

            if (input.Eq.HasValue)
            {
                map.Add("eq", SerializeNullableID(input.Eq.Value));
            }

            if (input.Ge.HasValue)
            {
                map.Add("ge", SerializeNullableID(input.Ge.Value));
            }

            if (input.Gt.HasValue)
            {
                map.Add("gt", SerializeNullableID(input.Gt.Value));
            }

            if (input.Le.HasValue)
            {
                map.Add("le", SerializeNullableID(input.Le.Value));
            }

            if (input.Lt.HasValue)
            {
                map.Add("lt", SerializeNullableID(input.Lt.Value));
            }

            if (input.Ne.HasValue)
            {
                map.Add("ne", SerializeNullableID(input.Ne.Value));
            }

            if (input.NotContains.HasValue)
            {
                map.Add("notContains", SerializeNullableID(input.NotContains.Value));
            }

            if (input.Size.HasValue)
            {
                map.Add("size", SerializeNullableModelSizeInput(input.Size.Value));
            }

            return map;
        }

        private object? SerializeNullableBoolean(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _booleanSerializer!.Serialize(value);
        }
        private object? SerializeNullableModelAttributeTypes(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _modelAttributeTypesSerializer!.Serialize(value);
        }
        private object? SerializeNullableID(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _iDSerializer!.Serialize(value);
        }

        private object? SerializeNullableListOfNullableID(object? value)
        {
            if (value is null)
            {
                return null;
            }


            IList source = (IList)value;
            object?[] result = new object?[source.Count];
            for(int i = 0; i < source.Count; i++)
            {
                result[i] = SerializeNullableID(source[i]);
            }
            return result;
        }
        private object? SerializeNullableModelSizeInput(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _modelSizeInputSerializer!.Serialize(value);
        }

        public object? Deserialize(object? value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
