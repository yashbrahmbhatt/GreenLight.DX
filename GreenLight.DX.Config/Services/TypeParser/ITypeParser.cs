using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Services.TypeParser
{
    public interface ITypeParser
    {
        TypeParserType ParserType { get; }
        Type Type { get; }
    }
    public interface IPrimitiveParser : ITypeParser
    {
        object Parse(string value);
        string Serialize(object value);
    }

    public interface ICollectionParser : ITypeParser
    {
        object Parse(string value, List<ITypeParser> primitiveParsers);
        string Serialize(object value, List<ITypeParser> primitiveParsers);
    }

    public abstract class BasePrimitiveParser<T> : IPrimitiveParser
    {
        public abstract object Parse(string value);
        public abstract string Serialize(object value);
        public Type Type => typeof(T);
        public TypeParserType ParserType { get; } = TypeParserType.Primitive;
        public BasePrimitiveParser() { }
    }

    public abstract class BaseCollectionParser<T> : ICollectionParser
    {
        public abstract Type Type { get; }
        public TypeParserType ParserType { get; } = TypeParserType.Collection;
        public abstract object Parse(string value, List<ITypeParser> primitiveParsers);
        public abstract string Serialize(object value, List<ITypeParser> primitiveParsers);
        public BaseCollectionParser() { }
    }

    public enum TypeParserType
    {
        Primitive,
        Collection
    }

    public class BoolPrimitiveParser : BasePrimitiveParser<bool>
    {
        public override object Parse(string value)
        {
            return bool.Parse(value);
        }

        public override string Serialize(object value)
        {
            return value.ToString().ToLower(); // Ensure consistent lowercase "true" or "false"
        }
    }

    public class StringPrimitiveParser : BasePrimitiveParser<string>
    {
        public override object Parse(string value)
        {
            return value;
        }

        public override string Serialize(object value)
        {
            return value?.ToString() ?? string.Empty; // Handle null values
        }
    }

    public class IntPrimitiveParser : BasePrimitiveParser<int>
    {
        public override object Parse(string value)
        {
            return int.Parse(value);
        }

        public override string Serialize(object value)
        {
            return value.ToString();
        }
    }

    public class DoublePrimitiveParser : BasePrimitiveParser<double>
    {
        public override object Parse(string value)
        {
            return double.Parse(value);
        }

        public override string Serialize(object value)
        {
            return value.ToString();
        }
    }

    public class ObjectPrimitiveParser : BasePrimitiveParser<object>
    {
        public override object Parse(string value)
        {
            return JsonConvert.DeserializeObject<object>(value);
        }

        public override string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }

    public class DateTimePrimitiveParser : BasePrimitiveParser<DateTime>
    {
        public override object Parse(string value)
        {
            return DateTime.Parse(value);
        }
        public override string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value).TrimStart('"').TrimEnd('"');
        }
    }

    public class TimeStampPrimitiveParser : BasePrimitiveParser<TimeSpan>
    {
        public override object Parse(string value)
        {
            return TimeSpan.Parse(value);
        }
        public override string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }

    public class ListCollectionParser<T> : BaseCollectionParser<List<T>>
    {
        public override Type Type => typeof(List<T>);
        public override object Parse(string value, List<ITypeParser> primitiveParsers)
        {
            if (string.IsNullOrWhiteSpace(value)) return new List<T>();
            var values = value.Split(",");
            if (values == null) return new List<T>();

            var result = new List<T>();
            var elementType = typeof(T);
            var parser = primitiveParsers.FirstOrDefault(p => p.Type == elementType);

            if (parser != null && parser is IPrimitiveParser p)
            {
                foreach (var item in values)
                {
                    result.Add((T)p.Parse(item));
                }
            }
            else
            {
                // Fallback to JsonConvert if no specific parser is found
                result = JsonConvert.DeserializeObject<List<T>>(value);
            }

            return result ?? new List<T>();
        }

        public override string Serialize(object value, List<ITypeParser> primitiveParsers)
        {
            if (value == null) return "[]";
            var list = (List<T>)value;
            var elementType = typeof(T);
            var parser = primitiveParsers.FirstOrDefault(p => p.Type == elementType);

            if (parser != null && parser is IPrimitiveParser p)
            {
                var serializedValues = list.Select(item => p.Serialize(item)).ToList();
                return string.Join(",", serializedValues);
            }
            else
            {
                // Fallback to JsonConvert if no specific parser is found
                return JsonConvert.SerializeObject(value);
            }
        }
    }

    public class ArrayCollectionParser<T> : BaseCollectionParser<T[]>
    {
        public override Type Type => typeof(T[]);

        public override object Parse(string value, List<ITypeParser> primitiveParsers)
        {
            if (string.IsNullOrWhiteSpace(value)) return Array.Empty<T>();
            var values = value.Split(",");
            if (values == null) return Array.Empty<T>();

            var result = new List<T>();
            var elementType = typeof(T);
            var parser = primitiveParsers.FirstOrDefault(p => p.Type == elementType);

            if (parser != null && parser is IPrimitiveParser p)
            {
                foreach (var item in values)
                {
                    result.Add((T)p.Parse(item));
                }
            }
            else
            {
                // Fallback to JsonConvert if no specific parser is found
                return JsonConvert.DeserializeObject<T[]>(value);
            }
            return result.ToArray() ?? Array.Empty<T>();
        }

        public override string Serialize(object value, List<ITypeParser> primitiveParsers)
        {
            if (value == null) return "[]";
            var array = (T[])value;
            var elementType = typeof(T);
            var parser = primitiveParsers.FirstOrDefault(p => p.Type == elementType);

            if (parser != null && parser is IPrimitiveParser p)
            {
                var serializedValues = array.Select(item => p.Serialize(item)).ToList();
                return string.Join(",", serializedValues);
            }
            else
            {
                // Fallback to JsonConvert if no specific parser is found
                return JsonConvert.SerializeObject(value);
            }
        }
    }
}