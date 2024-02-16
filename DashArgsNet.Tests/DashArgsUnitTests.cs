using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DashArgsNet.Tests
{
    public class DashArgsUnitTests
    {
        [Fact]
        public void FunctionalTest()
        {
            List<string> types = new List<string> { "int", "int16", "int32", "int64", "uint", "uint16", "uint32", "uint64", "float", "double", "decimal", "string", "byte", "sbyte", "long", "ulong", "short", "ushort", "string" };
            List<string> args = new List<string>();

            foreach (string type in types)
            {
                args.Add("--" + type);
                args.Add("24");
            }

            args.Add("--bool");
            args.Add("true");
            args.Add("--char");
            args.Add("a");

            args.Add("--hex");
            args.Add("0x22");

            args.Add("--hex-array");
            args.Add("0xA0220A");

            DashArgs dashArgs = new DashArgs(args);

            dashArgs.AddRule(new ArgRule<int>("int", ArgParser.IntParser));
            dashArgs.AddRule(new ArgRule<Int16>("int16", ArgParser.Int16Parser));
            dashArgs.AddRule(new ArgRule<Int32>("int32", ArgParser.Int32Parser));
            dashArgs.AddRule(new ArgRule<Int64>("int64", ArgParser.Int64Parser));
            dashArgs.AddRule(new ArgRule<uint>("uint", ArgParser.UIntParser));
            dashArgs.AddRule(new ArgRule<UInt16>("uint16", ArgParser.UInt16Parser));
            dashArgs.AddRule(new ArgRule<UInt32>("uint32", ArgParser.UInt32Parser));
            dashArgs.AddRule(new ArgRule<UInt64>("uint64", ArgParser.UInt64Parser));
            dashArgs.AddRule(new ArgRule<float>("float", ArgParser.FloatParser));
            dashArgs.AddRule(new ArgRule<double>("double", ArgParser.DoubleParser));
            dashArgs.AddRule(new ArgRule<decimal>("decimal", ArgParser.DecimalParser));
            dashArgs.AddRule(new ArgRule<byte>("byte", ArgParser.ByteParser));
            dashArgs.AddRule(new ArgRule<sbyte>("sbyte", ArgParser.SByteParser));
            dashArgs.AddRule(new ArgRule<short>("short", ArgParser.ShortParser));
            dashArgs.AddRule(new ArgRule<ushort>("ushort", ArgParser.UShortParser));
            dashArgs.AddRule(new ArgRule<long>("long", ArgParser.LongParser));
            dashArgs.AddRule(new ArgRule<ulong>("ulong", ArgParser.ULongParser));
            dashArgs.AddRule(new ArgRule<string>("string", ArgParser.StringParser));
            dashArgs.AddRule(new ArgRule<bool>("bool", ArgParser.BoolParser));
            dashArgs.AddRule(new ArgRule<char>("char", ArgParser.CharParser));
            dashArgs.AddRule(new ArgRule<byte>("hex", ArgParser.hexToByte));
            dashArgs.AddRule(new ArgRule<byte[]>("hex-array", ArgParser.hexToByteArray));

            dashArgs.Parse();

            int value = dashArgs.Get<int>("int");
            Assert.Equal(24, value);

            Int16 value16 = dashArgs.Get<Int16>("int16");
            Assert.Equal(24, value16);

            Int32 value32 = dashArgs.Get<Int32>("int32");
            Assert.Equal(24, value32);

            Int64 value64 = dashArgs.Get<Int64>("int64");
            Assert.Equal(24, value64);

            uint uValue = dashArgs.Get<uint>("uint");
            Assert.True(24 == uValue);

            UInt16 uValue16 = dashArgs.Get<UInt16>("uint16");
            Assert.True(24 == uValue16);

            UInt32 uValue32 = dashArgs.Get<UInt32>("uint32");
            Assert.True(24 == uValue32);

            UInt64 uValue64 = dashArgs.Get<UInt64>("uint64");
            Assert.True(24 == uValue64);

            float fValue = dashArgs.Get<float>("float");
            Assert.Equal(24, fValue);

            double dValue = dashArgs.Get<double>("double");
            Assert.Equal(24, dValue);

            decimal decValue = dashArgs.Get<decimal>("decimal");
            Assert.Equal(24, decValue);

            byte bValue = dashArgs.Get<byte>("byte");
            Assert.Equal(24, bValue);

            sbyte sbValue = dashArgs.Get<sbyte>("sbyte");
            Assert.Equal(24, sbValue);

            short sValue = dashArgs.Get<short>("short");
            Assert.Equal(24, sValue);

            ushort usValue = dashArgs.Get<ushort>("ushort");
            Assert.Equal(24, usValue);

            long lValue = dashArgs.Get<long>("long");
            Assert.Equal(24, lValue);

            ulong ulValue = dashArgs.Get<ulong>("ulong");
            Assert.True(24 == ulValue);

            string strValue = dashArgs.Get<string>("string");
            Assert.Equal("24", strValue);

            bool boolValue = dashArgs.Get<bool>("bool");
            Assert.True(boolValue);

            char charValue = dashArgs.Get<char>("char");
            Assert.Equal('a', charValue);

            byte hexValue = dashArgs.Get<byte>("hex");
            Assert.Equal(0x22, hexValue);

            byte[] hexArrayValue = dashArgs.Get<byte[]>("hex-array");
            Assert.Equal(3, hexArrayValue.Length);
            Assert.Equal(0xA0, hexArrayValue[0]);
            Assert.Equal(0x22, hexArrayValue[1]);
            Assert.Equal(0x0A, hexArrayValue[2]);
        }

        [Fact]
        public void AliasTest()
        {
            List<string> args = new List<string> { "-i", "24", "-ui", "24", "-d", "24", "-s", "24", "-bo", "true", "-ha", "0xA0220A" };

            DashArgs dashArgs = new DashArgs(args);

            dashArgs.AddRule(new ArgRule<int>("int", new string[] { "i", "in" }, ArgParser.IntParser));
            dashArgs.AddRule(new ArgRule<uint>("uint", new string[] { "ui", "uin" }, ArgParser.UIntParser));
            dashArgs.AddRule(new ArgRule<double>("double", new string[] { "d", "do" }, ArgParser.DoubleParser));
            dashArgs.AddRule(new ArgRule<string>("string", new string[] { "s", "st" }, ArgParser.StringParser));
                
            dashArgs.AddRule(new ArgRule<bool>("bool", new string[] { "bo", "boo" }, ArgParser.BoolParser));
            dashArgs.AddRule(new ArgRule<byte[]>("hex-array", new string[] { "ha", "hexa" }, ArgParser.hexToByteArray));

            dashArgs.Parse();

            int value = dashArgs.Get<int>("int");
            Assert.Equal(24, value);

            uint uValue = dashArgs.Get<uint>("uint");
            Assert.True(24 == uValue);

            double dValue = dashArgs.Get<double>("double");
            Assert.Equal(24, dValue);

            string strValue = dashArgs.Get<string>("string");
            Assert.Equal("24", strValue);

            bool boolValue = dashArgs.Get<bool>("bool");
            Assert.True(boolValue);

            byte[] hexArrayValue = dashArgs.Get<byte[]>("hex-array");
            Assert.Equal(3, hexArrayValue.Length);
            Assert.Equal(0xA0, hexArrayValue[0]);
            Assert.Equal(0x22, hexArrayValue[1]);
            Assert.Equal(0x0A, hexArrayValue[2]);
        }
    }
}
