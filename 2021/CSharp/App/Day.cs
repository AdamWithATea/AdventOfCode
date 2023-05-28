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
        
        // Get the current platform and relevant filepath from appsettings.json, translating any environment variables (e.g. %UserProfile% and %HOME%)
        string rootPath = Environment.ExpandEnvironmentVariables(settings.GetValue<string>($"Environment:Root:{settings.GetValue<string>("Environment:Platform")}"));
        
        string slash = (settings.GetValue<string>("Environment:Platform") == "Windows") ? "\\" : "/";
        string exampleFolder = (useExampleFile == true) ? $"Examples{slash}" : "";
        string fileName = day < 10 ? $"Day0{day}" : $"Day{day}";
        
        string filepath = $"{rootPath}InputFiles{slash}{exampleFolder}{fileName}.txt";
        return filepath;
    }
    //Enforce existence of Part1() and Part2() in child classes so Main() can always call them:
    public abstract Int64 Part1(string filepath); 
    public abstract Int64 Part2(string filepath);
}