using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Wizards.Configuration.Misc
{
    /// <summary>
    /// A dynamic dictionary-like class that supports property-based access
    /// and serialization using ISerializable and JSON.
    /// </summary>
    [Serializable] // Allows the class to be serialized using binary serialization.
    public class BaseConfig : DynamicObject, ISerializable
    {
        /// <summary>
        /// Stores dynamic data as key-value pairs.
        /// </summary>
        [JsonProperty("_Data")] // Ensures this property is serialized as "_Data" in JSON output.
        public virtual Dictionary<string, object> _Data { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the DictionaryWithMembers class.
        /// </summary>
        public BaseConfig() { }

        /// <summary>
        /// Initializes a new instance of the DictionaryWithMembers class from serialized data.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected BaseConfig(SerializationInfo info, StreamingContext context)
        {
            // Deserialize the "_Data" dictionary from the serialization stream
            _Data = (Dictionary<string, object>)info.GetValue("_Data", typeof(Dictionary<string, object>));
        }

        /// <summary>
        /// Serializes the object data.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Serialize the "_Data" dictionary
            info.AddValue("_Data", _Data);
        }

        /// <summary>
        /// Attempts to retrieve a member dynamically.
        /// </summary>
        /// <param name="binder">The binder containing member information.</param>
        /// <param name="result">The retrieved value.</param>
        /// <returns>True if the member was found; otherwise, false.</returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string propertyName = binder.Name;
            var property = GetType().GetProperty(propertyName);

            // Ensure the requested property exists in the class definition
            if (property == null)
                throw new InvalidOperationException($"Property '{propertyName}' does not exist on type '{GetType().Name}'.");

            // If the property type is another DictionaryWithMembers, initialize it lazily
            if (typeof(BaseConfig).IsAssignableFrom(property.PropertyType))
            {
                if (!_Data.ContainsKey(propertyName))
                {
                    var nestedObject = Activator.CreateInstance(property.PropertyType) as BaseConfig;
                    _Data[propertyName] = nestedObject;
                }
                result = _Data[propertyName];
                return true;
            }

            // Retrieve value if it exists in the dictionary
            if (_Data.TryGetValue(propertyName, out var value))
            {
                result = value;
                return true;
            }

            // If the key is missing, throw an exception to indicate an unresolved property
            throw new KeyNotFoundException($"Key '{propertyName}' not found in the dictionary.");
        }

        /// <summary>
        /// Attempts to set a member dynamically.
        /// </summary>
        /// <param name="binder">The binder containing member information.</param>
        /// <param name="value">The value to assign.</param>
        /// <returns>True if the value was set; otherwise, false.</returns>
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            string propertyName = binder.Name;
            var property = GetType().GetProperty(propertyName);

            // Ensure the property exists before setting its value
            if (property == null)
                throw new InvalidOperationException($"Property '{propertyName}' does not exist on type '{GetType().Name}'.");

            // If assigning a nested DictionaryWithMembers, enforce type safety
            if (typeof(BaseConfig).IsAssignableFrom(property.PropertyType))
            {
                if (value is BaseConfig nestedObject)
                {
                    _Data[propertyName] = nestedObject;
                    return true;
                }
                else
                {
                    throw new InvalidCastException($"Expected a DictionaryWithMembers type for property '{propertyName}'.");
                }
            }

            // Assign value normally for other types
            _Data[propertyName] = value;
            return true;
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>The value associated with the specified key.</returns>
        public object this[string key]
        {
            get => _Data.TryGetValue(key, out var value) ? value : throw new KeyNotFoundException($"Key '{key}' not found.");
            set => _Data[key] = value;
        }

        /// <summary>
        /// Converts the stored dictionary data to a formatted JSON string.
        /// </summary>
        /// <returns>A formatted JSON string representation of the data.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(_Data, Formatting.Indented);
        }
    }
}
