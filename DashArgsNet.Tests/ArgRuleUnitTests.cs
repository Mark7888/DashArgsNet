namespace DashArgsNet.Tests
{
    public class ArgRuleUnitTests
    {
        [Fact]
        public void ArgRuleTest()
        {
            ArgRule<int> rule = new ArgRule<int>("test", ArgParser.IntParser);
            Assert.Equal("test", rule.GetName());
            Assert.False(rule.isRequired);
            Assert.Single(rule.GetAliases());
            Assert.Equal("--test", rule.GetAliases()[0]);

            ArgRule<int> rule2 = new ArgRule<int>("test", new List<string> { "t", "t2" }, ArgParser.IntParser);
            Assert.Equal("test", rule2.GetName());
            Assert.False(rule2.isRequired);
            Assert.Equal(3, rule2.GetAliases().Count);
            Assert.Equal("-t", rule2.GetAliases()[0]);
            Assert.Equal("-t2", rule2.GetAliases()[1]);
            Assert.Equal("--test", rule2.GetAliases()[2]);

            ArgRule<int> rule3 = new ArgRule<int>("test", new string[] { "t", "t2" }, ArgParser.IntParser);
            Assert.Equal("test", rule3.GetName());
            Assert.False(rule3.isRequired);
            Assert.Equal(3, rule3.GetAliases().Count);
            Assert.Equal("-t", rule3.GetAliases()[0]);
            Assert.Equal("-t2", rule3.GetAliases()[1]);
            Assert.Equal("--test", rule3.GetAliases()[2]);

            ArgRule<int> rule4 = new ArgRule<int>("test", ArgParser.IntParser, true);
            Assert.Equal("test", rule4.GetName());
            Assert.True(rule4.isRequired);
            Assert.Single(rule4.GetAliases());
            Assert.Equal("--test", rule4.GetAliases()[0]);

            ArgRule<int> rule5 = new ArgRule<int>("test", new List<string> { "t", "t2" }, ArgParser.IntParser, true);
            Assert.Equal("test", rule5.GetName());
            Assert.True(rule5.isRequired);
            Assert.Equal(3, rule5.GetAliases().Count);
            Assert.Equal("-t", rule5.GetAliases()[0]);
            Assert.Equal("-t2", rule5.GetAliases()[1]);
            Assert.Equal("--test", rule5.GetAliases()[2]);
        }

        [Fact]
        public void ArgRuleDoParseTest()
        {
            ArgRule<int> rule = new ArgRule<int>("test", ArgParser.IntParser);
            Assert.Equal(5, (int)rule.DoParse("5"));

            ArgRule<Int16> argRule = new ArgRule<Int16>("test", ArgParser.Int16Parser);
            Assert.Equal(5, (Int16)argRule.DoParse("5"));

            ArgRule<Int32> argRule2 = new ArgRule<Int32>("test", ArgParser.Int32Parser);
            Assert.Equal(5, (Int32)argRule2.DoParse("5"));

            ArgRule<Int64> argRule3 = new ArgRule<Int64>("test", ArgParser.Int64Parser);
            Assert.Equal(5, (Int64)argRule3.DoParse("5"));

            ArgRule<uint> argRule4 = new ArgRule<uint>("test", ArgParser.UIntParser);
            Assert.True(5 == (uint)argRule4.DoParse("5"));

            ArgRule<UInt16> argRule5 = new ArgRule<UInt16>("test", ArgParser.UInt16Parser);
            Assert.True(5 == (UInt16)argRule5.DoParse("5"));

            ArgRule<UInt32> argRule6 = new ArgRule<UInt32>("test", ArgParser.UInt32Parser);
            Assert.True(5 == (UInt32)argRule6.DoParse("5"));

            ArgRule<UInt64> argRule7 = new ArgRule<UInt64>("test", ArgParser.UInt64Parser);
            Assert.True(5 == (UInt64)argRule7.DoParse("5"));

            ArgRule<float> argRule8 = new ArgRule<float>("test", ArgParser.FloatParser);
            Assert.Equal(5, (float)argRule8.DoParse("5"));

            ArgRule<double> argRule9 = new ArgRule<double>("test", ArgParser.DoubleParser);
            Assert.Equal(5, (double)argRule9.DoParse("5"));

            ArgRule<decimal> argRule10 = new ArgRule<decimal>("test", ArgParser.DecimalParser);
            Assert.Equal(5, (decimal)argRule10.DoParse("5"));

            ArgRule<byte> argRule11 = new ArgRule<byte>("test", ArgParser.ByteParser);
            Assert.Equal(5, (byte)argRule11.DoParse("5"));

            ArgRule<sbyte> argRule12 = new ArgRule<sbyte>("test", ArgParser.SByteParser);
            Assert.Equal(5, (sbyte)argRule12.DoParse("5"));

            ArgRule<long> argRule13 = new ArgRule<long>("test", ArgParser.LongParser);
            Assert.Equal(5, (long)argRule13.DoParse("5"));

            ArgRule<ulong> argRule14 = new ArgRule<ulong>("test", ArgParser.ULongParser);
            Assert.True(5 == (ulong)argRule14.DoParse("5"));

            ArgRule<short> argRule15 = new ArgRule<short>("test", ArgParser.ShortParser);
            Assert.Equal(5, (short)argRule15.DoParse("5"));

            ArgRule<ushort> argRule16 = new ArgRule<ushort>("test", ArgParser.UShortParser);
            Assert.True(5 == (ushort)argRule16.DoParse("5"));

            ArgRule<bool> argRule17 = new ArgRule<bool>("test", ArgParser.BoolParser);
            Assert.True((bool)argRule17.DoParse("true"));

            ArgRule<string> argRule18 = new ArgRule<string>("test", ArgParser.StringParser);
            Assert.Equal("test", (string)argRule18.DoParse("test"));

            ArgRule<byte> argRule19 = new ArgRule<byte>("test", ArgParser.hexToByte);
            Assert.Equal(0x2a, (byte)argRule19.DoParse("2a"));

            ArgRule<byte[]> argRule20 = new ArgRule<byte[]>("test", ArgParser.hexToByteArray);
            Assert.Equal(new byte[] { 0x2a }, (byte[])argRule20.DoParse("2a"));

        }
    }
}
