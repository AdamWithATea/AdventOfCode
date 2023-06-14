namespace AdventOfCode;

public abstract class Day{
    public virtual void Main(int year, int day, bool useExampleFile){
        long output1 = Part1(InputHandler.BuildFilePath(year, day, useExampleFile));
        Console.WriteLine($"Day {day}-1: {output1}");

        long output2 = Part2(InputHandler.BuildFilePath(year, day, useExampleFile));
        Console.WriteLine($"Day {day}-2: {output2}");
    }
    //Enforce existence of Part1() and Part2() in child classes so Main() can always call them:
    public abstract long Part1(string filepath);
    public abstract long Part2(string filepath);
}