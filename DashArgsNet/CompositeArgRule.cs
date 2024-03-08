using System;
using System.Collections.Generic;
using System.Text;

namespace DashArgsNet
{
    public class CompositeArgRule : IRule
    {
        private List<IArgRule> argRules = new List<IArgRule>();
        public bool warnDuplicates = true;

        public CompositeArgRule(params IArgRule[] rules)
        {
            argRules.AddRange(rules);
        }

        public void AddRule(IArgRule rule)
        {
            argRules.Add(rule);
        }

        public List<IRule> GetRules() => new List<IRule> (argRules);

        public List<string> CheckRequired(List<string> parsedList)
        {
            foreach (var rule in argRules)
            {
                if (parsedList.Contains(rule.GetName()))
                {
                    return new List<string>();
                }
            }

            throw new MissingAllCompositeArgumentsException(argRules.ConvertAll(r => r.GetName()));
        }
    }
}
