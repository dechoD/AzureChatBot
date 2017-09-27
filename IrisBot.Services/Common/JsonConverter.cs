using System;
using IrisBot.Services.Interfaces.Common;
using Newtonsoft.Json;

namespace IrisBot.Services.Common
{
    [Serializable]
    public class JsonConverter : IJsonConverter
    {
        /// <summary>
        /// Deserialize JSON to a given type.
        /// </summary>
        /// <typeparam name="TDestinationType">The type to which the JSON will be deserialized.</typeparam>
        /// <param name="json">JSON that will be deserialized.</param>
        /// <returns>The result object of the deserialization.</returns>
        public TDestinationType DeserializeObject<TDestinationType>(string json)
        {
            var obj = JsonConvert.DeserializeObject<TDestinationType>(json);
            return obj;
        }
    }
}
