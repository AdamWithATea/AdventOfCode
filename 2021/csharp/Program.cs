using AdventOfCode;

int latestDay = 7;
Boolean exampleForLatestDay = false;
var days = new List<Day>{
    new Day01(),
    new Day02(),
    new Day03(),
    new Day04(),
    new Day05(),
    new Day06(),
    new Day07(),
    };

string inputFolder = "inputs";
string fileName = "";
for (int day = 1; day <= latestDay; day++){
    if (day < 10) {fileName = $"day0{day}";}
    else {fileName = $"day{day}";}
    if (exampleForLatestDay == true && day == latestDay) {inputFolder = "examples";}
    string filepath = $"../{inputFolder}/{fileName}.txt";
    days[day-1].Main(filepath);
    }