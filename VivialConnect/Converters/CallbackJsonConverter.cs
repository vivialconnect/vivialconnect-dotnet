using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VivialConnect.Extensions;
using VivialConnect.Resources.Connector;

namespace VivialConnect.Converters
{
    /// <summary>
    /// Custom JsonConverter that implements deserializing
    /// Callback JSON to it's specific event type instance.
    /// </summary>
    internal class CallbackJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if(objectType == typeof(ICallback))
            {
                return true;
            }

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            string eventType = jObject["event_type"].ToString();
            JsonReader jsonReader = jObject.CreateReader();

            if (eventType == EventTypeEnum.Incoming.JsonAttribute())
            {
                return serializer.Deserialize<CallbackIncoming>(jsonReader);
            }
            else if (eventType == EventTypeEnum.IncomingFallback.JsonAttribute())
            {
                return serializer.Deserialize<CallbackIncomingFallback>(jsonReader);
            }
            
            return serializer.Deserialize<CallbackStatus>(jsonReader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
