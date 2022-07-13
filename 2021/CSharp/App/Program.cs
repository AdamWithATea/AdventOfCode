using AdventOfCode;

int today = 9;
Boolean onlyRunToday = true, useExampleFiles = true;
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
    if (onlyRunToday == true) {day = today;}
    days[day-1].Main(day, useExampleFiles);
    }