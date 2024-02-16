namespace DashArgsNet
{
    public class ArgParser
    {
        public static int IntParser(string data)
        {
            return int.Parse(data);
        }

        public static string StringParser(string data)
        {
            return data;
        }
    }
}
