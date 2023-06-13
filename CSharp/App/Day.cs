using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdventOfCode;

public abstract class Day{
    public virtual void Main(int year, int day, bool useExampleFile){
        long output1 = Part1(BuildFilePath(year, day, useExampleFile));
        Console.WriteLine($"Day {day}-1: {output1}");

        long output2 = Part2(BuildFilePath(year, day, useExampleFile));
        Console.WriteLine($"Day {day}-2: {output2}");
    }
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
    public static List<string> ConvertLinesToStringList(string filepath){
        List<string> inputs = File.ReadAllLines(filepath).ToList();
        return inputs;
    }
    public static List<string> ConvertValuesToStringList(string filepath, string separator){
        List<string> inputs = File.ReadAllText(filepath).Split(separator).ToList();
        return inputs;
    }
    public static List<int> ConvertValuesToIntList(string filepath, string separator){
        List<int> inputs = File.ReadAllText(filepath).Split(separator).Select(int.Parse).ToList();
        return inputs;
    }
    //Enforce existence of Part1() and Part2() in child classes so Main() can always call them:
    public abstract long Part1(string filepath);
    public abstract long Part2(string filepath);
}