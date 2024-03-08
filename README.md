# DashArgsNet - Command-Line Argument Parsing Library for .NET

DashArgsNet is a lightweight and flexible command-line argument parsing library for .NET, compatible with .NET Standard 2.0. With DashArgsNet, you can easily handle command-line arguments and retrieve values based on specified rules. This documentation provides a quick guide on how to install and use DashArgsNet, along with details on available default parsers and instructions on creating custom parsers.

## Installation

You can install DashArgsNet using the following [NuGet](https://www.nuget.org/packages/DashArgsNet) command:

```bash
dotnet add package DashArgsNet
```

## Usage

Here is a basic example of using DashArgsNet to parse command-line arguments:

```csharp
using DashArgsNet;

// Instantiate DashArgs with command-line arguments
DashArgs dashArgs = new DashArgs(args);

// Add a rule for parsing an integer argument
dashArgs.AddRule(new ArgRule<int>("value1", ArgParser.IntParser));

// Alternatively, use short arguments (aliases)
dashArgs.AddRule(new ArgRule<string>("value2", new string[] { "v2", "2v" }, ArgParser.StringParser));

// Parse the arguments
dashArgs.Parse();

// Retrieve values
int value1 = dashArgs.Get<int>("value1");
string value2 = dashArgs.Get<string>("value2");

// You can also check if the variable is set
bool isValue1Set = dashArgs.IsSet("value1");
```

## Default Parsers

DashArgsNet includes a set of default parsers for common types. You can use these parsers when adding rules for your command-line arguments:

| Type      | Parser                   |
|-----------|--------------------------|
| int       | ArgParser.IntParser      |
| int16     | ArgParser.Int16Parser    |
| int32     | ArgParser.Int32Parser    |
| int64     | ArgParser.Int64Parser    |
| uint      | ArgParser.UIntParser     |
| uint16    | ArgParser.UInt16Parser   |
| uint32    | ArgParser.UInt32Parser   |
| uint64    | ArgParser.UInt64Parser   |
| float     | ArgParser.FloatParser    |
| double    | ArgParser.DoubleParser   |
| decimal   | ArgParser.DecimalParser  |
| byte      | ArgParser.ByteParser     |
| sbyte     | ArgParser.SByteParser    |
| short     | ArgParser.ShortParser    |
| ushort    | ArgParser.UShortParser   |
| long      | ArgParser.LongParser     |
| ulong     | ArgParser.ULongParser    |
| string    | ArgParser.StringParser   |
| bool      | ArgParser.BoolParser     |
| char      | ArgParser.CharParser     |
| hex       | ArgParser.hexToByte      |
| hex-array | ArgParser.hexToByteArray |

## Creating Custom Parsers

You can easily create your own parsers for custom types. Here's an example:

```csharp
public static MyObject CustomParser(string data)
{
    // Implement custom parsing logic here
    return myParsedObject;
}

// Usage
DashArgs dashArgs = new DashArgs(args);

// Add a rule with a custom parser
dashArgs.AddRule(new ArgRule<MyObject>("my-value", CustomParser));

// Parse the arguments
dashArgs.Parse();

// Retrieve the custom value
MyObject myValue = dashArgs.Get<MyObject>("my-value");
```

Feel free to experiment with custom parsers to handle unique data types in your applications.

## Required Arguments

DashArgsNet supports specifying required arguments for your command-line application. If an argument is marked as required but not found during parsing, DashArgsNet will throw a `MissingRequiredArgumentException`. To declare an argument as required, use the `required` parameter when adding a rule, as demonstrated in the example below:

```csharp
// Usage with a required argument
DashArgs dashArgs = new DashArgs(args);

// Add a rule for parsing a required integer argument
dashArgs.AddRule(new ArgRule<int>("value1", ArgParser.IntParser, required: true));

// Parse the arguments
dashArgs.Parse();

// Retrieve the required value
int value1 = dashArgs.Get<int>("value1");
```

By setting `required: true`, you ensure that the specified argument must be present in the command-line input. If the required argument is not found, a `MissingRequiredArgumentException` will be thrown, allowing you to handle missing required arguments in your application.

## CompositeArgRule - Handling Multiple Rules

DashArgsNet introduces the `CompositeArgRule` to handle scenarios where you want to specify multiple rules and ensure that at least one of them is fulfilled during parsing. This is particularly useful when you have different valid ways of providing an argument.

### Adding Rules to a `CompositeArgRule`

You can add rules to a `CompositeArgRule` either within the constructor or using a separate method. The rules should be instances of `ArgRule`. The `isRequired` field in individual `ArgRule` instances is ignored when used within a `CompositeArgRule`.

#### Example 1: Adding Rules within the Constructor

```csharp
// Creating a CompositeArgRule with rules added in the constructor
CompositeArgRule compositeArgRule = new CompositeArgRule(
    new ArgRule<int>("test1", ArgParser.IntParser),
    new ArgRule<int>("test2", ArgParser.IntParser)
);
```

#### Example 2: Adding Rules with a Separate Method

```csharp
// Creating a CompositeArgRule and adding rules using a separate method
CompositeArgRule compositeArgRule = new CompositeArgRule();
compositeArgRule.AddRule(new ArgRule<int>("test1", ArgParser.IntParser));
compositeArgRule.AddRule(new ArgRule<int>("test2", ArgParser.IntParser));
```

### Usage of `CompositeArgRule`

When using a `CompositeArgRule`, at least one of the contained rules must be fulfilled during parsing; otherwise, a `MissingAllCompositeArgumentsException` will be thrown.

```csharp
// Instantiate DashArgs with command-line arguments
DashArgs dashArgs = new DashArgs(args);

// Create a CompositeArgRule with multiple rules
CompositeArgRule compositeArgRule = new CompositeArgRule(
    new ArgRule<int>("test1", ArgParser.IntParser),
    new ArgRule<int>("test2", ArgParser.IntParser)
);

// Add the CompositeArgRule to DashArgs
dashArgs.AddRule(compositeArgRule);

// Parse the arguments
dashArgs.Parse();

// Retrieve values based on fulfilled rules
if (dashArgs.IsSet("test1")) {
    int test1Value = dashArgs.Get<int>("test1");
    // Do something with the value
}
if (dashArgs.IsSet("test2"))
{
    int test2Value = dashArgs.Get<int>("test2");
    // Do something with the value
}
```

## Exceptions

### When Using `dashArgs.Parse()`

- **MissingRequiredArgumentException:**
  - Description: Thrown when one or more required arguments are missing in the command-line input.
  - Example:
    ```csharp
    try
    {
        dashArgs.Parse();
    }
    catch (MissingRequiredArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        // Handle missing required arguments
    }
    ```

- **MissingAllCompositeArgumentsException:**
   - Description: Thrown when using a `CompositeArgRule`, and all of its contained rules are missing in the command-line input.
   - Example Usage:
     ```csharp
    try
    {
        dashArgs.Parse();
    }
    catch (MissingAllCompositeArgumentsException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        // Handle missing required arguments
    }
     ```

### When Using `dashArgs.Get<T>("value1")`

- **TypeMismatchException:**
  - Description: Thrown when the type `T` requested in `dashArgs.Get<T>("value1")` does not match the value returned by the parser specified in the corresponding `ArgRule`.
  - Example:
    ```csharp
    try
    {
        int value1 = dashArgs.Get<int>("value1");
    }
    catch (TypeMismatchException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        // Handle type mismatch
    }
    ```

- **ArgumentException:**
  - Description: Thrown when the specified argument name (e.g., "value1") in `dashArgs.Get<T>("value1")` is not found in the parsed command-line arguments.
  - Example:
    ```csharp
    try
    {
        int value1 = dashArgs.Get<int>("value1");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        // Handle missing argument
    }
    ```

### Enjoy using DashArgsNet for easy and efficient command-line argument parsing in your .NET projects!
