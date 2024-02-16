namespace DashArgsNet.Tests
{
    public class ParserUnitTests
    {
        [Fact]
        public void ParserTest()
        {
            string data = "42";
            string boolData = "true";
            string charData = "a";

            int intValue = ArgParser.IntParser(data);
            Assert.Equal(42, intValue);

            Int16 int16Value = ArgParser.Int16Parser(data);
            Assert.Equal(42, int16Value);

            Int32 int32Value = ArgParser.Int32Parser(data);
            Assert.Equal(42, int32Value);

            Int64 int64Value = ArgParser.Int64Parser(data);
            Assert.Equal(42, int64Value);

            uint uintValue = ArgParser.UIntParser(data);
            Assert.True(42 == uintValue);

            UInt16 uInt16Value = ArgParser.UInt16Parser(data);
            Assert.True(42 == uInt16Value);

            UInt32 uInt32Value = ArgParser.UInt32Parser(data);
            Assert.True(42 == uInt32Value);

            UInt64 uInt64Value = ArgParser.UInt64Parser(data);
            Assert.True(42 == uInt64Value);

            float floatValue = ArgParser.FloatParser(data);
            Assert.Equal(42, floatValue);

            double doubleValue = ArgParser.DoubleParser(data);
            Assert.Equal(42, doubleValue);

            decimal decimalValue = ArgParser.DecimalParser(data);
            Assert.Equal(42, decimalValue);

            byte byteValue = ArgParser.ByteParser(data);
            Assert.Equal(42, byteValue);

            sbyte sbyteValue = ArgParser.SByteParser(data);
            Assert.Equal(42, sbyteValue);

            long longValue = ArgParser.LongParser(data);
            Assert.Equal(42, longValue);

            ulong ulongValue = ArgParser.ULongParser(data);
            Assert.True(42 == ulongValue);

            short shortValue = ArgParser.ShortParser(data);
            Assert.Equal(42, shortValue);

            ushort ushortValue = ArgParser.UShortParser(data);
            Assert.True(42 == ushortValue);

            string stringValue = ArgParser.StringParser(data);
            Assert.Equal("42", stringValue);

            char charValue = ArgParser.CharParser(charData);
            Assert.Equal('a', charValue);

            bool boolValue = ArgParser.BoolParser(boolData);
            Assert.True(boolValue);
        }

        [Fact]
        public void ParserExceptionTest()
        {
            string data = "42m";

            Assert.Throws<FormatException>(() => ArgParser.IntParser(data));
            Assert.Throws<FormatException>(() => ArgParser.Int16Parser(data));
            Assert.Throws<FormatException>(() => ArgParser.Int32Parser(data));
            Assert.Throws<FormatException>(() => ArgParser.Int64Parser(data));
            Assert.Throws<FormatException>(() => ArgParser.UIntParser(data));
            Assert.Throws<FormatException>(() => ArgParser.UInt16Parser(data));
            Assert.Throws<FormatException>(() => ArgParser.UInt32Parser(data));
            Assert.Throws<FormatException>(() => ArgParser.UInt64Parser(data));
            Assert.Throws<FormatException>(() => ArgParser.FloatParser(data));
            Assert.Throws<FormatException>(() => ArgParser.DoubleParser(data));
            Assert.Throws<FormatException>(() => ArgParser.DecimalParser(data));
            Assert.Throws<FormatException>(() => ArgParser.LongParser(data));
            Assert.Throws<FormatException>(() => ArgParser.ULongParser(data));
            Assert.Throws<FormatException>(() => ArgParser.ShortParser(data));
            Assert.Throws<FormatException>(() => ArgParser.UShortParser(data));
            Assert.Throws<FormatException>(() => ArgParser.ByteParser(data));
            Assert.Throws<FormatException>(() => ArgParser.SByteParser(data));
            Assert.Throws<FormatException>(() => ArgParser.CharParser(data));
            Assert.Throws<FormatException>(() => ArgParser.BoolParser(data));
        }

        [Fact]
        public void HexParserTest()
        {
            string hexData = "0x2A";
            byte byteValue = ArgParser.hexToByte(hexData);
            Assert.Equal(42, byteValue);

            string hexData2 = "2A";
            byte byteValue2 = ArgParser.hexToByte(hexData2);
            Assert.Equal(42, byteValue2);

            string hexData3 = "0x2A";
            byte[] byteArray = ArgParser.hexToByteArray(hexData3);
            Assert.Equal(42, byteArray[0]);
        }

        [Fact]
        public void HexByteArrayParserTest()
        {
            string hexData = "0x2A";
            byte[] byteArray = ArgParser.hexToByteArray(hexData);
            Assert.Equal(42, byteArray[0]);

            string hexData2 = "0x2A2B";
            byte[] byteArray2 = ArgParser.hexToByteArray(hexData2);
            Assert.Equal(42, byteArray2[0]);
            Assert.Equal(43, byteArray2[1]);
            
            string hexData3 = "0x2A2B2C";
            byte[] byteArray3 = ArgParser.hexToByteArray(hexData3);
            Assert.Equal(42, byteArray3[0]);
            Assert.Equal(43, byteArray3[1]);
            Assert.Equal(44, byteArray3[2]);

            string hexData4 = "0x2A2B2C2D";
            byte[] byteArray4 = ArgParser.hexToByteArray(hexData4);
            Assert.Equal(42, byteArray4[0]);
            Assert.Equal(43, byteArray4[1]);
            Assert.Equal(44, byteArray4[2]);
            Assert.Equal(45, byteArray4[3]);
        }

        [Fact]
        public void HexParserExceptionTest()
        {
            string hexData = "0x2";
            Assert.Throws<ArgumentException>(() => ArgParser.hexToByte(hexData));

            string hexData2 = "0x2";
            Assert.Throws<ArgumentException>(() => ArgParser.hexToByteArray(hexData2));
        }
    }
}