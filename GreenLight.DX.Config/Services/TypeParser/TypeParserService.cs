﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenLight.DX.Config.Services.TypeParser
{
    public interface ITypeParserService
    {
        List<Type> GetSupportedTypes();
        void RegisterParser(ITypeParser parser);
        bool TryParse<T>(string value, out T result);
        T Parse<T>(string value);
        bool TryParse(string value, Type type, out object result);
        object Parse(string value, Type type);
        string Serialize<T>(T value);
    }
    public class TypeParserService : ITypeParserService
    {
        private readonly List<ITypeParser> _primitiveParsers = new List<ITypeParser>();
        private readonly List<ITypeParser> _collectionParsers = new List<ITypeParser>();

        public TypeParserService()
        {
            RegisterParser(new BoolPrimitiveParser());
            RegisterParser(new IntPrimitiveParser());
            RegisterParser(new StringPrimitiveParser());
            RegisterParser(new DoublePrimitiveParser());
            RegisterParser(new DateTimePrimitiveParser());
            RegisterParser(new ListCollectionParser<int>());
            RegisterParser(new ListCollectionParser<bool>());
            RegisterParser(new ListCollectionParser<string>());
            RegisterParser(new ListCollectionParser<double>());
            RegisterParser(new ListCollectionParser<DateTime>());
            RegisterParser(new ArrayCollectionParser<int>());
            RegisterParser(new ArrayCollectionParser<bool>());
            RegisterParser(new ArrayCollectionParser<string>());
            RegisterParser(new ArrayCollectionParser<double>());
            RegisterParser(new ArrayCollectionParser<DateTime>());

        }

        public List<Type> GetSupportedTypes()
        {
            var types = new List<Type>();

            // Add primitive types directly
            types.AddRange(_primitiveParsers.Select(p => p.Type));
            types.AddRange(_collectionParsers.Select(p => p.Type));


            return types.Distinct().ToList(); // Ensure no duplicates
        }

        public void RegisterParser(ITypeParser parser)
        {
            if (parser is ICollectionParser p)
            {
                _collectionParsers.Add(p);
            }
            else if (parser is IPrimitiveParser p2)
            {
                _primitiveParsers.Add(p2);
            }
            else
            {
                throw new InvalidOperationException($"Unknown parser type for type {parser.Type.Name}");
            }
        }

        public bool TryParse(string value, Type type, out object result)
        {
            try
            {
                result = Parse(value, type);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
        public object Parse(string value, Type type)
        {
            var parser = _collectionParsers.FirstOrDefault(p => p.Type == type) ?? _primitiveParsers.FirstOrDefault(p => p.Type == type);
            if (value == "null")
            {
                return null;
            }
            if (parser == null)
            {
                throw new InvalidOperationException($"No parser registered for type {type.Name}");
            }
            if (parser is ICollectionParser collectionParser)
            {
                return collectionParser.Parse(value, _primitiveParsers);
            }
            else if (parser is IPrimitiveParser primitiveParser)
            {
                return primitiveParser.Parse(value);
            }
            else
            {
                throw new InvalidOperationException($"Unknown parser type for type {type.Name}");
            }
        }
        public bool TryParse<T>(string value, out T result)
        {
            try
            {
                result = Parse<T>(value);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
        public T Parse<T>(string value)
        {
            var parser = _collectionParsers.FirstOrDefault(p => p.Type == typeof(T)) ?? _primitiveParsers.FirstOrDefault(p => p.Type == typeof(T));
            if (value == "null")
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
            if (value == null)
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