using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdventOfCode;

public abstract class Day{
    public virtual void Main(int day, bool useExampleFile){
        Int64 output1 = Part1(BuildFilePath(day, useExampleFile));
        System.Console.WriteLine($"Day {day}-1: {output1}");

        Int64 output2 = Part2(BuildFilePath(day, useExampleFile));
        System.Console.WriteLine($"Day {day}-2: {output2}");
    }
    public string BuildFilePath(int day, bool useExampleFile){
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

        string filepath = $"{basePath}InputFiles{slash}{exampleFolder}{fileName}.txt";
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
    public abstract Int64 Part1(string filepath);
    public abstract Int64 Part2(string filepath);
}