namespace AdventOfCode.Helpers;

public static class TextFileReader
{
    public static string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public static string ReadFileAsPasteableString(string filePath)
    {
        return ReadFile(filePath).Replace(@"\r\n", @"\\r\\n");
    }
}