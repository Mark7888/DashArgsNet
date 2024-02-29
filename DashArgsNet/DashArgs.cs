using System;
using System.Collections.Generic;
using System.Linq;

namespace DashArgsNet
{
    public class DashArgs
    {
        private List<string> argsList = new List<string>();
        List<IArgRule> argRules = new List<IArgRule>();
        public bool warnDuplicates = true;
        Dictionary<string, object> parsedArgs = new Dictionary<string, object>();


        public DashArgs(List<string> args)
        {
            argsList = args;
        }

        public DashArgs(string[] args)
        {
            argsList = args.ToList();
        }

        public DashArgs(params IArgRule[] rules)
        {
            argRules.AddRange(rules);
        }

        public void AddRule(IArgRule rule)
        {
            argRules.Add(rule);
        }

        public void Parse()
        {
            for (int i = 0; i < argsList.Count; i++)
            {
                foreach (var rule in argRules)
                {
                    if (rule.GetAliases().Contains(argsList[i]))
                    {
                        if (parsedArgs.ContainsKey(rule.GetName()) && warnDuplicates)
                        {
                            Console.WriteLine($"WARN - Duplicate argument: {argsList[i]}");
                        }

                        if (i + 1 < argsList.Count)
                        {
                            parsedArgs[rule.GetName()] = rule.DoParse(argsList[i + 1]);
                        }
                        else
                        {
                            parsedArgs[rule.GetName()] = true;
                        }
                    }
                }
            }


            List<string> missingRequired = new List<string>();
            foreach (var rule in argRules)
            {
                if (rule.isRequired && !parsedArgs.ContainsKey(rule.GetName()))
                {
                    missingRequired.Add(rule.GetName());
                }
            }

            if (missingRequired.Count != 0)
            {
                throw new MissingRequiredArgumentException(missingRequired);
            }
        }

        public bool IsSet(string name)
        {
            return parsedArgs.ContainsKey(name);
        }

        public T Get<T>(string name)
        {
            if (parsedArgs.ContainsKey(name))
            {
                if (parsedArgs[name] is T t)
                {
                    return t;
                }
                throw new TypeMismatchException(name, typeof(T).Name, parsedArgs[name].GetType().Name);
            }
            else
            {
                throw new ArgumentException($"No argument with name '{name}' found");
            }
        }

        public object this[string name]
        {
            get
            {
                if (parsedArgs.ContainsKey(name.ToString()))
                {
                    return parsedArgs[name.ToString()];
                }
                else
                {
                    throw new ArgumentNotFoundException(name);
                }
            }
        }
    }
}
