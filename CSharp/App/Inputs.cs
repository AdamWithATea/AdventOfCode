namespace AdventOfCode;
public static class Inputs{
    public static string BuildFilepath(int year, int day, bool useExampleFile){
        //Get the relevant filepath for the current platform from the configuration
        string platform = Settings.Platform;
        string path = Settings.Path;
        //Expand out any environment variables in the path (e.g. %UserProfile% and %HOME%)
        string expandedPath = Environment.ExpandEnvironmentVariables(path);
        string slash = (platform == "Windows") ? "\\" : "/";
        string exampleFolder = (useExampleFile == true) ? $"Examples{slash}" : "";
        string fileName = day < 10 ? $"Day0{day}.txt" : $"Day{day}.txt";

        return $"{expandedPath}Inputs{slash}{year}{slash}{exampleFolder}{fileName}";
    }
    public static List<string> ListLines(string filepath){
        return File.ReadAllLines(filepath).ToList();
    }
    public static List<string> ListStrings(string filepath, string separator){
        return File.ReadAllText(filepath).Split(separator).ToList();
    }
    public static List<int> ListInts(string filepath, string separator){
        return File.ReadAllText(filepath).Split(separator).Select(int.Parse).ToList();
    }
}