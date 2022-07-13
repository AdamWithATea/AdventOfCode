using AdventOfCode;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IHost host = Host.CreateDefaultBuilder().Build();

IConfiguration settings = host.Services.GetRequiredService<IConfiguration>();

int today = settings.GetValue<int>("Today");
bool runAllDays = settings.GetValue<bool>("RunAllDays"), useExampleFiles = settings.GetValue<bool>("UseExampleFiles");
var days = new List<Day>{
    new Day01(),
    new Day02(),
    new Day03(),
    new Day04(),
    new Day05(),
    new Day06(),
    new Day07(),
    new Day08(),
    new Day09()
    };

for (int day = 1; day <= today; day++){
    if (runAllDays == false) {day = today;}
    days[day-1].Main(day, useExampleFiles);
    }