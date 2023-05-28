namespace AdventOfCode;
public class Day02 : Day{
    public override Int64 Part1(string filepath){
        string[] file = File.ReadAllLines(filepath);
        List<string> directions = new List<string>(file);
        int destination = PlotCourse(directions);
        return destination;
    }
    public override Int64 Part2(string filepath){
        string[] file = File.ReadAllLines(filepath);
        List<string> directions = new List<string>(file);
        int destination = PlotCourse(directions, 0);
        return destination;
    }
    static int PlotCourse(List<string> directions){
        //For part 1, where the course just follows the directions
        int horizontal = 0, depth = 0;
        foreach (string direction in directions){
            var (heading, distance) = SplitInstruction(direction);
            switch (heading){
                case "forward":
                    horizontal += distance;
                    break;
                case "down":
                    depth += distance;
                    break;
                case "up":
                    depth -= distance;
                    break;
            }
        }
        int destination = horizontal * depth;
        return destination;
    }
    static int PlotCourse(List<string> directions, int aim){
        //For part 2, where aim affects how directions are followed
        int horizontal = 0, depth = 0;
        foreach (string direction in directions){
            var (heading, distance) = SplitInstruction(direction);
            switch (heading){
                case "forward":
                    horizontal += distance;
                    depth += aim * distance;
                    break;
                case "down":
                    aim += distance;
                    break;
                case "up":
                    aim -= distance;
                    break;
            }
        }
        int destination = horizontal * depth;
        return destination;
    }
    static (string heading, int distance) SplitInstruction(string direction){
        //Split the full instruction into a tuple containing direction and distance
        string[] directionSplit = direction.Split(" ");
        (string, int) directionParts = (directionSplit[0], Convert.ToInt32(directionSplit[1]));
        return directionParts;
    }
}