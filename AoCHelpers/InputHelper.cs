namespace AoCHelpers
{
    public static class InputHelper
    {
        public static string ReadInputFromFile(string path) => File.ReadAllText(path);
        public static string[] ReadInputLinesFromFile(string path) => File.ReadAllLines(path);
    }
}
