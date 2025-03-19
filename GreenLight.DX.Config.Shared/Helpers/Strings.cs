using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GreenLight.DX.Config.Shared.Helpers
{
    public static class Strings
    {
        public static string ToValidIdentifier(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "_"; // Or any other default value
            }

            // 1. Remove invalid characters (anything not alphanumeric or underscore)
            string validChars = Regex.Replace(input, @"[^a-zA-Z0-9_]", "");

            // 2. Ensure the string starts with a letter or underscore
            if (validChars.Length > 0 && !char.IsLetter(validChars[0]) && validChars[0] != '_')
            {
                validChars = "_" + validChars;
            }

            // 3. Handle empty string after invalid character removal
            if (string.IsNullOrEmpty(validChars))
            {
                return "_"; // Or any other default value
            }

            // 4. Handle C# keyword collisions (optional, but recommended)
            string keywordSafe = AvoidCSharpKeywords(validChars);

            return keywordSafe;
        }

        private static string AvoidCSharpKeywords(string input)
        {
            string[] keywords = {
            "abstract", "as", "base", "bool", "break", "byte", "case", "catch",
            "char", "checked", "class", "const", "continue", "decimal", "default",
            "delegate", "do", "double", "else", "enum", "event", "explicit",
            "extern", "false", "finally", "fixed", "float", "for", "foreach",
            "goto", "if", "implicit", "in", "int", "interface", "internal", "is",
            "lock", "long", "namespace", "new", "null", "object", "operator",
            "out", "override", "params", "private", "protected", "public",
            "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof",
            "stackalloc", "static", "string", "struct", "switch", "this", "throw",
            "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe",
            "ushort", "using", "virtual", "void", "volatile", "while", "partial",
            "yield", "dynamic", "await", "async", "var"
        };

            if (keywords.Contains(input))
            {
                return "_" + input; // Prepend an underscore to avoid collision
            }

            return input;
        }
    }
}
