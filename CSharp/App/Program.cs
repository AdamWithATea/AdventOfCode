using AdventOfCode;
using AOC2021;
using AOC2023;

int today = Settings.Today, year = Settings.YearInt;
bool runAllDays = Settings.RunAllDays, useExampleFiles = Settings.UseExampleFiles;

List<Day> days = Settings.YearString switch{
    "2021" => new Year2021().Days(),
    "2023" => new Year2023().Days(),
    _ => new Year2021().Days() //Default outcome if no value matches
};

for (int day = 1; day <= today; day++){
    if (runAllDays == false) {day = today;}
    days[day-1].Main(year, day, useExampleFiles);
    }