using System;

namespace DashArgsNet
{
    public static class ArgParser
    {
        public static int IntParser(string data) => int.Parse(data);
        public static Int16 Int16Parser(string data) => Int16.Parse(data);
        public static Int32 Int32Parser(string data) => Int32.Parse(data);
        public static Int64 Int64Parser(string data) => Int64.Parse(data);
        public static uint UIntParser(string data) => uint.Parse(data);
        public static UInt16 UInt16Parser(string data) => UInt16.Parse(data);
        public static UInt32 UInt32Parser(string data) => UInt32.Parse(data);
        public static UInt64 UInt64Parser(string data) => UInt64.Parse(data);
        public static float FloatParser(string data) => float.Parse(data);
        public static double DoubleParser(string data) => double.Parse(data);
        public static decimal DecimalParser(string data) => decimal.Parse(data);
        public static bool BoolParser(string data) => bool.Parse(data);
        public static string StringParser(string data) => data;
        public static byte ByteParser(string data) => byte.Parse(data);
        public static sbyte SByteParser(string data) => sbyte.Parse(data);
        public static char CharParser(string data) => char.Parse(data);
        public static long LongParser(string data) => long.Parse(data);
        public static ulong ULongParser(string data) => ulong.Parse(data);
        public static short ShortParser(string data) => short.Parse(data);
        public static ushort UShortParser(string data) => ushort.Parse(data);


        public static byte[] hexToByteArray(string hex)
        {
            if (hex.StartsWith("0x"))
            {
                hex = hex.Substring(2);
            }

            hex = hex.Replace("-", "").Replace(" ", "").Replace(":", "");

            if (hex.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid length");
            }

            byte[] ret = new byte[hex.Length / 2];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return ret;
        }

        public static byte hexToByte(string hex)
        {
            if (hex.StartsWith("0x"))
            {
                hex = hex.Substring(2);
            }

            if (hex.Length != 2)
            {
                throw new ArgumentException("Invalid length");
            }

            return Convert.ToByte(hex, 16);
        }
    }
}
