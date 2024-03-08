namespace DashArgsNet.Tests
{
    public class CompositeArgRuleUnitTests
    {
        [Fact]
        public void CompositeArgRuleTest()
        {
            List<string> args = new List<string>
            {
                "--test", "5", "--test2", "6", "--test3", "test"
            };

            CompositeArgRule compositeArgRule = new CompositeArgRule
            (
                new ArgRule<int>("test", ArgParser.IntParser),
                new ArgRule<int>("test2", ArgParser.IntParser)
            );

            compositeArgRule.AddRule(new ArgRule<string>("test3", ArgParser.StringParser, true));

            DashArgs dashArgs = new DashArgs(args, compositeArgRule);

            dashArgs.Parse();

            Assert.Equal(5, dashArgs.Get<int>("test"));
            Assert.Equal(6, dashArgs.Get<int>("test2"));
            Assert.Equal("test", dashArgs.Get<string>("test3"));
        }

        [Fact]
        public void CompositeArgRuleOneSpecifiedTest()
        {
            List<string> args = new List<string>
            {
                "--test", "5"
            };

            CompositeArgRule compositeArgRule = new CompositeArgRule
            (
                new ArgRule<int>("test", ArgParser.IntParser),
                new ArgRule<int>("test2", ArgParser.IntParser)
            );


            DashArgs dashArgs = new DashArgs(args, compositeArgRule);

            dashArgs.Parse();

            Assert.Equal(5, dashArgs.Get<int>("test"));
        }

        [Fact]
        public void CompositeArgRuleRequiredTest()
        {
            List<string> args = new List<string>();

            CompositeArgRule compositeArgRule = new CompositeArgRule
            (
                new ArgRule<int>("test", ArgParser.IntParser),
                new ArgRule<int>("test2", ArgParser.IntParser)
            );

            DashArgs dashArgs = new DashArgs(args, compositeArgRule);

            Assert.Throws<MissingAllCompositeArgumentsException>(() => dashArgs.Parse());
        }

        [Fact]
        public void CompositeArgRuleRequiredTest2()
        {
            List<string> args = new List<string>
            {
                "--test", "5"
            };

            CompositeArgRule compositeArgRule = new CompositeArgRule
            (
                new ArgRule<int>("test", ArgParser.IntParser),
                new ArgRule<int>("test2", ArgParser.IntParser)
            );

            DashArgs dashArgs = new DashArgs(args, compositeArgRule, new ArgRule<string>("test3", ArgParser.StringParser, true));

            Assert.Throws<MissingRequiredArgumentException>(() => dashArgs.Parse());
        }
    }
}
