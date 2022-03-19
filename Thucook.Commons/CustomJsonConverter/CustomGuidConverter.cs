using Newtonsoft.Json;
using System;

namespace Thucook.Commons.CustomJsonConverter
{
    public class CustomGuidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Guid) == objectType
                || typeof(Guid?) == objectType;
        }
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Guid? defaultValue = objectType == typeof(Guid) ? Guid.Empty : (Guid?)null;
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return defaultValue;
                case JsonToken.String:
                    string str = reader.Value as string;
                    if (string.IsNullOrEmpty(str))
                    {
                        return defaultValue;
                    }
                    else
                    {
                        Guid guidValue;
                        if (Guid.TryParse(str, out guidValue))
                        {
                            return guidValue;
                        }
                        else
                        {
                            return defaultValue;
                        }
                    }
                default:
                    return defaultValue;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not custom implement for WriteJson Guid, use default instead");
        }
    }
}
