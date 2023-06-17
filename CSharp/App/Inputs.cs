using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdventOfCode;
public static class Inputs{
    public static string BuildFilepath(int year, int day, bool useExampleFile){
        using IHost host = Host.CreateDefaultBuilder().Build();
        IConfiguration settings = host.Services.GetRequiredService<IConfiguration>();

        // Get the relevant filepath for the current platform from appsettings.json
        string platform = settings.GetValue<string>("Environment:Platform");
        string platformPath = settings.GetValue<string>($"Environment:Root:{platform}");
        //Expand out any environment variables in the path (e.g. %UserProfile% and %HOME%)
        string basePath = Environment.ExpandEnvironmentVariables(platformPath);
        string slash = (platform == "Windows") ? "\\" : "/";
        string exampleFolder = (useExampleFile == true) ? $"Examples{slash}" : "";
        string fileName = day < 10 ? $"Day0{day}.txt" : $"Day{day}.txt";

        return $"{basePath}Inputs{slash}{year}{slash}{exampleFolder}{fileName}";        
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