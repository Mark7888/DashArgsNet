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

Enjoy using DashArgsNet for easy and efficient command-line argument parsing in your .NET projects!
