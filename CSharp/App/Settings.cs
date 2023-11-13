using Microsoft.Extensions.Configuration;

namespace AdventOfCode;

public class Settings{
    private static IConfiguration GetConfig(){
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<AdventOfCode.Settings>();
        return builder.Build();
    }
    public static int Today = GetConfig().GetValue<int>("Today");
    public static int YearInt = GetConfig().GetValue<int>("Year");
    public static string YearString = GetConfig().GetValue<string>("Year")!;
    public static string Platform = GetConfig().GetValue<string>("Environment:Platform")!;
    public static string Path = GetConfig().GetValue<string>($"Environment:Root:{Platform}")!;
    public static bool UseExampleFiles = GetConfig().GetValue<bool>("UseExampleFiles");
    public static bool RunAllDays = GetConfig().GetValue<bool>("RunAllDays");
}