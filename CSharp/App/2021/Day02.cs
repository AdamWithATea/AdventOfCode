using AdventOfCode;

namespace AOC2021;
public class Day02 : Day{
    public override long Part1(string filepath){
        return PlotCourse(Inputs.ListLines(filepath), false);
    }
    public override long Part2(string filepath){
        return PlotCourse(Inputs.ListLines(filepath), true);
    }
    static int PlotCourse(List<string> directions, bool useAim){
        int horizontal = 0, depth = 0, aim = 0;
        foreach (string direction in directions){
            //Split the full instruction into a tuple containing direction and distance
            string[] directionSplit = direction.Split(" ");
            var (heading, distance) = (directionSplit[0], Convert.ToInt32(directionSplit[1]));
            switch (heading){
                case "forward":
                    horizontal += distance;
                    if (useAim){ depth += aim * distance; }
                    break;
                case "down":
                    if (useAim){ aim += distance; }
                    else { depth += distance; }
                    break;
                case "up":
                    if (useAim){ aim -= distance; }
                    else { depth -= distance; }
                    break;
            }
        }
        return horizontal * depth;
    }
}