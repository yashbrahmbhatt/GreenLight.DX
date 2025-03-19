using System;
using System.Collections.Generic;
using GreenLight.DX.Config.Studio.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GreenLight.DX.Config.Studio.Test.Services
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void TestBoolPrimitiveParser()
        {
            var parser = new BoolPrimitiveParser();
            Assert.AreEqual(true, parser.Parse("true"));
            Assert.AreEqual("true", parser.Serialize(true));
            Assert.AreEqual(false, parser.Parse("false"));
            Assert.AreEqual("false", parser.Serialize(false));
        }

        [TestMethod]
        public void TestStringPrimitiveParser()
        {
            var parser = new StringPrimitiveParser();
            Assert.AreEqual("test", parser.Parse("test"));
            Assert.AreEqual("test", parser.Serialize("test"));
            Assert.AreEqual("", parser.Serialize(null)); // Test null serialization
        }

        [TestMethod]
        public void TestIntPrimitiveParser()
        {
            var parser = new IntPrimitiveParser();
            Assert.AreEqual(123, parser.Parse("123"));
            Assert.AreEqual("123", parser.Serialize(123));
        }

        [TestMethod]
        public void TestDoublePrimitiveParser()
        {
            var parser = new DoublePrimitiveParser();
            Assert.AreEqual(12.34, parser.Parse("12.34"));
            Assert.AreEqual("12.34", parser.Serialize(12.34));
        }

        [TestMethod]
        public void TestObjectPrimitiveParser()
        {
            var parser = new ObjectPrimitiveParser();
            var obj = new { Name = "Test", Value = 42 };
            string json = JsonConvert.SerializeObject(obj);
            Assert.AreEqual(json, JsonConvert.SerializeObject(parser.Parse(json)));
            Assert.AreEqual(json, parser.Serialize(obj));

            string jsonArray = "[1,2,3]";
            Assert.AreEqual(jsonArray, JsonConvert.SerializeObject(parser.Parse(jsonArray)));

            string jsonString = "\"test\"";
            Assert.AreEqual(jsonString, parser.Serialize("test"));
        }

        [TestMethod]
        public void TestDateTimePrimitiveParser()
        {
            var parser = new DateTimePrimitiveParser();
            DateTime expected = new DateTime(2023, 10, 27);
            Assert.AreEqual(expected, parser.Parse("2023-10-27"));
            Assert.AreEqual("2023-10-27T00:00:00", parser.Serialize(expected));
        }

        [TestMethod]
        public void TestTimeStampPrimitiveParser()
        {
            var parser = new TimeStampPrimitiveParser();
            TimeSpan expected = TimeSpan.FromHours(1);
            Assert.AreEqual(expected, parser.Parse("01:00:00"));
            Assert.AreEqual("\"01:00:00\"", parser.Serialize(expected));
        }

        [TestMethod]
        public void TestListCollectionParser()
        {
            var primitiveParsers = new List<ITypeParser>
            {
                new StringPrimitiveParser(),
                new IntPrimitiveParser(),
                new DateTimePrimitiveParser()
            };

            var stringListParser = new ListCollectionParser<string>();
            List<string> expectedStringList = new List<string> { "a", "b", "c" };
            CollectionAssert.AreEqual(expectedStringList, (List<string>)stringListParser.Parse("a,b,c", primitiveParsers));
            Assert.AreEqual("a,b,c", stringListParser.Serialize(expectedStringList, primitiveParsers));

            var intListParser = new ListCollectionParser<int>();
            List<int> expectedIntList = new List<int> { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedIntList, (List<int>)intListParser.Parse(@"1,2,3", primitiveParsers));
            Assert.AreEqual(@"1,2,3", intListParser.Serialize(expectedIntList, primitiveParsers));

            var dateTimeListParser = new ListCollectionParser<DateTime>();
            List<DateTime> expectedDateTimeList = new List<DateTime> { new DateTime(2023, 10, 27), new DateTime(2023, 10, 28) };
            CollectionAssert.AreEqual(expectedDateTimeList, (List<DateTime>)dateTimeListParser.Parse("2023-10-27,2023-10-28", primitiveParsers));
            Assert.AreEqual("2023-10-27T00:00:00,2023-10-28T00:00:00", dateTimeListParser.Serialize(expectedDateTimeList, primitiveParsers));
        }

        [TestMethod]
        public void TestArrayCollectionParser()
        {
            var primitiveParsers = new List<ITypeParser>
            {
                new StringPrimitiveParser(),
                new DoublePrimitiveParser(),
                new DateTimePrimitiveParser()
            };

            var stringArrayParser = new ArrayCollectionParser<string>();
            string[] expectedStringArray = new string[] { "a", "b", "c" };
            CollectionAssert.AreEqual(expectedStringArray, (string[])stringArrayParser.Parse("a,b,c", primitiveParsers));
            Assert.AreEqual("a,b,c", stringArrayParser.Serialize(expectedStringArray, primitiveParsers));

            var doubleArrayParser = new ArrayCollectionParser<double>();
            double[] expectedDoubleArray = new double[] { 1.1, 2.2, 3.3 };
            CollectionAssert.AreEqual(expectedDoubleArray, (double[])doubleArrayParser.Parse("1.1,2.2,3.3", primitiveParsers));
            Assert.AreEqual("1.1,2.2,3.3", doubleArrayParser.Serialize(expectedDoubleArray, primitiveParsers));

            var dateTimeArrayParser = new ArrayCollectionParser<DateTime>();
            DateTime[] expectedDateTimeArray = new DateTime[] { new DateTime(2023, 10, 27), new DateTime(2023, 10, 28) };
            CollectionAssert.AreEqual(expectedDateTimeArray, (DateTime[])dateTimeArrayParser.Parse("2023-10-27, 2023-10-28", primitiveParsers));
            Assert.AreEqual("2023-10-27T00:00:00,2023-10-28T00:00:00", dateTimeArrayParser.Serialize(expectedDateTimeArray, primitiveParsers));
        }
    }
}