using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace ImageRecognition.Web
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class StatusValueSerializer
        : IValueSerializer
    {
        public string Name => "Status";

        public ValueKind Kind => ValueKind.Enum;

        public Type ClrType => typeof(Status);

        public Type SerializationType => typeof(string);

        public object? Serialize(object? value)
        {
            if (value is null)
            {
                return null;
            }

            var enumValue = (Status)value;

            switch(enumValue)
            {
                case Status.Aborted:
                    return "ABORTED";
                case Status.Failed:
                    return "FAILED";
                case Status.Pending:
                    return "PENDING";
                case Status.Running:
                    return "RUNNING";
                case Status.Succeeded:
                    return "SUCCEEDED";
                case Status.TimedOut:
                    return "TIMED_OUT";
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
                case "ABORTED":
                    return Status.Aborted;
                case "FAILED":
                    return Status.Failed;
                case "PENDING":
                    return Status.Pending;
                case "RUNNING":
                    return Status.Running;
                case "SUCCEEDED":
                    return Status.Succeeded;
                case "TIMED_OUT":
                    return Status.TimedOut;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
