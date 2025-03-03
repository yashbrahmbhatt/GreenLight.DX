using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Studio.Converters
{
    public class TypeSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType) => typeof(Type).IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string typeName = (string)reader.Value;
            return Type.GetType(typeName); // Or a more robust lookup
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type type = (Type)value;
            writer.WriteValue(type.AssemblyQualifiedName); // Or a custom representation
        }
    }
}
