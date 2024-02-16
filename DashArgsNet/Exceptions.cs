using System;
using System.Collections.Generic;

namespace DashArgsNet
{
    public class MissingRequiredArgumentException : Exception
    {
        public MissingRequiredArgumentException(string[] missing) : base($"Missing required arguments: '{string.Join(", ", missing)}'")
        { }

        public MissingRequiredArgumentException(List<string> missing) : base($"Missing required arguments: '{string.Join(", ", missing)}'")
        { }
    }

    public class ArgumentNotFoundException : Exception
    {
        public ArgumentNotFoundException(string name) : base($"No argument with name '{name}' found")
        { }
    }

    public class TypeMismatchException : Exception
    {
        public TypeMismatchException(string name, string expectedType, string actualType) : base($"Type mismatch for argument '{name}': Expected '{expectedType}', got '{actualType}'")
        { }
    }
}
