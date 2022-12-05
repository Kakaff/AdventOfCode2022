namespace AoCHelpers
{
    public static class InputHelper
    {
        public static string ReadInputFromFile(string path)
        {
            string inputText;

            using (var file = File.OpenRead(path))
            using (var streamReader = new StreamReader(file))
                inputText = streamReader.ReadToEnd();

            return inputText;
        }

        public static string[] ReadInputLinesFromFile(string path)
        {
            return ReadInputFromFile(path).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
