using AdventOfCode;

int latestDay = 9;
Boolean onlyRunLatestDay = false, exampleForLatestDay = true;
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

string inputFolder = "inputs";
string fileName = "";
for (int day = 1; day <= latestDay; day++){
    if (onlyRunLatestDay == true) {day = latestDay;}
    if (exampleForLatestDay == true && day == latestDay) {inputFolder = "examples";}
    if (day < 10) {fileName = $"day0{day}";}
    else {fileName = $"day{day}";}
    string filepath = $"../{inputFolder}/{fileName}.txt";
    days[day-1].Main(filepath);
    }