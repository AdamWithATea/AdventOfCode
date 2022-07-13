using AdventOfCode;

int latestDay = 9;
Boolean onlyRunLatestDay = true, exampleForLatestDay = true;
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


for (int day = 1; day <= latestDay; day++){
    if (onlyRunLatestDay == true) {day = latestDay;}
    if (exampleForLatestDay == true && day == latestDay)
        { days[day-1].Main(day, exampleForLatestDay); }
    else { days[day-1].Main(day, false); }
    }