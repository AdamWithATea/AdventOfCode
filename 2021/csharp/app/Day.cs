namespace AdventOfCode;
public abstract class Day{
    public virtual void Main(int day, Boolean useExampleFile){
        Part1(BuildFilePath(day, useExampleFile));
        Part2(BuildFilePath(day, useExampleFile));
    }
    public string BuildFilePath(int day, Boolean useExampleFile){
        string inputFolder = "inputs", fileName = "";
        if (useExampleFile == true) { inputFolder = "examples"; }
        if (day < 10) { fileName = $"day0{day}"; }
        else { fileName = $"day{day}"; }

        //Windows:
        string filepath = $"C:/Users/Public/Repos/adventofcode/2021/{inputFolder}/{fileName}.txt";
        //Linux:
        //string filepath = $"/home/adam/Documents/Repos/adventofcode/2021/{inputFolder}/{fileName}.txt";
        return filepath;
    }
    //Enforce existence of Part1() and Part2() in child classes so Main() can always call it:
    public abstract Int64 Part1(string filepath); 
    public abstract Int64 Part2(string filepath);
}