using AdventOfCode;
using AOC2021;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IHost host = Host.CreateDefaultBuilder().Build();

IConfiguration settings = host.Services.GetRequiredService<IConfiguration>();

int today = settings.GetValue<int>("Today"), year = settings.GetValue<int>("Year");
bool runAllDays = settings.GetValue<bool>("RunAllDays"), useExampleFiles = settings.GetValue<bool>("UseExampleFiles");

List<Day> days = settings.GetValue<string>("Year") switch{
    "2021" => new Year2021().Days(),
    _ => new Year2021().Days() //Default outcome if no value matches
};

for (int day = 1; day <= today; day++){
    if (runAllDays == false) {day = today;}
    days[day-1].Main(year, day, useExampleFiles);
    }