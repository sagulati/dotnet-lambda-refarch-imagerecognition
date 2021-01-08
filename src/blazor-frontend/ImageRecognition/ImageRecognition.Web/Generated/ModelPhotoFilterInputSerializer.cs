using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ModelPhotoFilterInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer? _modelIDInputSerializer;
        private IValueSerializer? _modelPhotoFilterInputSerializer;
        private IValueSerializer? _modelStringInputSerializer;
        private IValueSerializer? _modelStatusInputSerializer;

        public string Name { get; } = "ModelPhotoFilterInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(ModelPhotoFilterInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _modelIDInputSerializer = serializerResolver.Get("ModelIDInput");
            _modelPhotoFilterInputSerializer = serializerResolver.Get("ModelPhotoFilterInput");
            _modelStringInputSerializer = serializerResolver.Get("ModelStringInput");
            _modelStatusInputSerializer = serializerResolver.Get("ModelStatusInput");
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

            var input = (ModelPhotoFilterInput)value;
            var map = new Dictionary<string, object?>();

            if (input.AlbumId.HasValue)
            {
                map.Add("albumId", SerializeNullableModelIDInput(input.AlbumId.Value));
            }

            if (input.And.HasValue)
            {
                map.Add("and", SerializeNullableListOfNullableModelPhotoFilterInput(input.And.Value));
            }

            if (input.Bucket.HasValue)
            {
                map.Add("bucket", SerializeNullableModelStringInput(input.Bucket.Value));
            }

            if (input.ExifMake.HasValue)
            {
                map.Add("exifMake", SerializeNullableModelStringInput(input.ExifMake.Value));
            }

            if (input.ExitModel.HasValue)
            {
                map.Add("exitModel", SerializeNullableModelStringInput(input.ExitModel.Value));
            }

            if (input.Format.HasValue)
            {
                map.Add("format", SerializeNullableModelStringInput(input.Format.Value));
            }

            if (input.Id.HasValue)
            {
                map.Add("id", SerializeNullableModelIDInput(input.Id.Value));
            }

            if (input.Not.HasValue)
            {
                map.Add("not", SerializeNullableModelPhotoFilterInput(input.Not.Value));
            }

            if (input.ObjectDetected.HasValue)
            {
                map.Add("objectDetected", SerializeNullableModelStringInput(input.ObjectDetected.Value));
            }

            if (input.Or.HasValue)
            {
                map.Add("or", SerializeNullableListOfNullableModelPhotoFilterInput(input.Or.Value));
            }

            if (input.Owner.HasValue)
            {
                map.Add("owner", SerializeNullableModelStringInput(input.Owner.Value));
            }

            if (input.ProcessingStatus.HasValue)
            {
                map.Add("ProcessingStatus", SerializeNullableModelStatusInput(input.ProcessingStatus.Value));
            }

            if (input.SfnExecutionArn.HasValue)
            {
                map.Add("SfnExecutionArn", SerializeNullableModelStringInput(input.SfnExecutionArn.Value));
            }

            if (input.UploadTime.HasValue)
            {
                map.Add("uploadTime", SerializeNullableModelStringInput(input.UploadTime.Value));
            }

            return map;
        }

        private object? SerializeNullableModelIDInput(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _modelIDInputSerializer!.Serialize(value);
        }
        private object? SerializeNullableModelPhotoFilterInput(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _modelPhotoFilterInputSerializer!.Serialize(value);
        }

        private object? SerializeNullableListOfNullableModelPhotoFilterInput(object? value)
        {
            if (value is null)
            {
                return null;
            }


            IList source = (IList)value;
            object?[] result = new object?[source.Count];
            for(int i = 0; i < source.Count; i++)
            {
                result[i] = SerializeNullableModelPhotoFilterInput(source[i]);
            }
            return result;
        }
        private object? SerializeNullableModelStringInput(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _modelStringInputSerializer!.Serialize(value);
        }
        private object? SerializeNullableModelStatusInput(object? value)
        {
            if (value is null)
            {
                return null;
            }


            return _modelStatusInputSerializer!.Serialize(value);
        }

        public object? Deserialize(object? value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
