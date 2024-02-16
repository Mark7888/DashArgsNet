using System;
using System.Collections.Generic;
using System.Linq;

namespace DashArgsNet
{
    public interface IArgRule
    {
        bool isRequired { get; }
        string GetName();
        List<string> GetAliases();
        object DoParse(string data);
    }

    public class ArgRule<TResult> : IArgRule
    {
        private string Name;
        private List<string> Aliases = new List<string>();
        private readonly Func<string, TResult> parserFunction;
        public bool isRequired { get; }

        bool IArgRule.isRequired => isRequired;

        public ArgRule(string name, Func<string, TResult> handler, bool required = false)
        {
            Name = name;
            parserFunction = handler ?? throw new ArgumentNullException(nameof(handler));
            isRequired = required;
        }

        public ArgRule(string name, List<string> aliases, Func<string, TResult> handler, bool required = false)
        {
            Name = name;
            Aliases = aliases;
            parserFunction = handler ?? throw new ArgumentNullException(nameof(handler));
            isRequired = required;
        }

        public ArgRule(string name, string[] aliases, Func<string, TResult> handler, bool required = false)
        {
            Name = name;
            Aliases = aliases.ToList();
            parserFunction = handler ?? throw new ArgumentNullException(nameof(handler));
            isRequired = required;
        }

        public object DoParse(string data) => parserFunction(data);

        public string GetName() => Name;

        public List<string> GetAliases()
        {
            List<string> result = Aliases.Select(a => $"-{a}").ToList();
            result.Add($"--{Name}");
            return result;
        }
    }
}
