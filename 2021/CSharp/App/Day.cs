namespace AdventOfCode;
public abstract class Day{
    public virtual void Main(int day, Boolean useExampleFile){
        Part1(BuildFilePath(day, useExampleFile));
        Part2(BuildFilePath(day, useExampleFile));
    }
    public string BuildFilePath(int day, Boolean useExampleFile){
        string exampleFolder = "", fileName = "";
        if (useExampleFile == true) { exampleFolder = "Examples/"; }
        if (day < 10) { fileName = $"Day0{day}"; }
        else { fileName = $"Day{day}"; }

        //Windows:
        string filepath = $"C:/Users/Public/Repos/AdventOfCode/2021/InputFiles/{exampleFolder}{fileName}.txt";
        //Linux:
        //string filepath = $"/home/user/Documents/Repos/AdventOfCode/2021/InputFiles/{exampleFolder}{fileName}.txt";
        return filepath;
    }
    //Enforce existence of Part1() and Part2() in child classes so Main() can always call them:
    public abstract Int64 Part1(string filepath); 
    public abstract Int64 Part2(string filepath);
}