using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdventOfCode;
public static class InputHandler{
    public static string BuildFilePath(int year, int day, bool useExampleFile){
        using IHost host = Host.CreateDefaultBuilder().Build();
        IConfiguration settings = host.Services.GetRequiredService<IConfiguration>();

        // Get the relevant filepath for the current platform from appsettings.json
        string platform = settings.GetValue<string>("Environment:Platform");
        string platformPath = settings.GetValue<string>($"Environment:Root:{platform}");
        //Expand out any environment variables in the path (e.g. %UserProfile% and %HOME%)
        string basePath = Environment.ExpandEnvironmentVariables(platformPath);

        string slash = (settings.GetValue<string>("Environment:Platform") == "Windows") ? "\\" : "/";
        string exampleFolder = (useExampleFile == true) ? $"Examples{slash}" : "";
        string fileName = day < 10 ? $"Day0{day}" : $"Day{day}";

        string filepath = $"{basePath}Inputs{slash}{year}{slash}{exampleFolder}{fileName}.txt";
        return filepath;
    }
    public static List<string> LinesToStringList(string filepath){
        List<string> inputs = File.ReadAllLines(filepath).ToList();
        return inputs;
    }
    public static List<string> ValuesToStringList(string filepath, string separator){
        List<string> inputs = File.ReadAllText(filepath).Split(separator).ToList();
        return inputs;
    }
    public static List<int> ValuesToIntList(string filepath, string separator){
        List<int> inputs = File.ReadAllText(filepath).Split(separator).Select(int.Parse).ToList();
        return inputs;
    }
}