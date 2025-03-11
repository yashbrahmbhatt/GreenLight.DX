using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenLight.DX.Config.Studio.Misc
{
    public class TypeParsingService
    {
        private List<ITypeParser> _primitiveParsers { get; } = new List<ITypeParser>();
        private List<ITypeParser> _collectionParsers { get; } = new List<ITypeParser>();

        public void RegisterParser(ITypeParser parser)
        {
            if (parser is ICollectionParser)
            {
                _collectionParsers.Add(parser);
            }
            else
            {
                _primitiveParsers.Add(parser);
            }
        }

        public T Parse<T>(string value)
        {
            var parser = _collectionParsers.FirstOrDefault(p => p.Type == typeof(T)) ?? _primitiveParsers.FirstOrDefault(p => p.Type == typeof(T));
            if(value == "null")
            {
                return default;
            }
            if (parser == null)
            {
                throw new InvalidOperationException($"No parser registered for type {typeof(T).Name}");
            }

            if (parser is ICollectionParser collectionParser)
            {
                return (T)collectionParser.Parse(value, _primitiveParsers);
            }
            else if (parser is IPrimitiveParser primitiveParser)
            {
                return (T)primitiveParser.Parse(value);
            }
            else
            {
                throw new InvalidOperationException($"Unknown parser type for type {typeof(T).Name}");
            }
        }

        public string Serialize<T>(T value)
        {
            var parser = _collectionParsers.FirstOrDefault(p => p.Type == typeof(T)) ?? _primitiveParsers.FirstOrDefault(p => p.Type == typeof(T));
            if(value == null)
            {
                return "null";
            }
            if (parser == null)
            {
                throw new InvalidOperationException($"No parser registered for type {typeof(T).Name}");
            }

            if (parser is ICollectionParser collectionParser)
            {
                return collectionParser.Serialize(value, _primitiveParsers);
            }
            else if (parser is IPrimitiveParser primitiveParser)
            {
                return primitiveParser.Serialize(value);
            }
            else
            {
                throw new InvalidOperationException($"Unknown parser type for type {typeof(T).Name}");
            }
        }
    }
}