namespace AdventOfCode
{
    class Day02 : Day
    {
        public override void Part1(string[] directions)
        {
            int destination = PlotCourse(directions);
            int answer = 1989014;
            string outcome = CheckAnswer(destination, answer);
            System.Console.WriteLine($"Day 2-1: {destination} {outcome}");
        }

        public override void Part2(string[] directions)
        {
            int aim = 0;
            int destination = PlotCourse(directions, aim);
            int answer = 2006917119;
            string outcome = CheckAnswer(destination, answer);
            System.Console.WriteLine($"Day 2-2: {destination} {outcome}");
        }

        static int PlotCourse(string[] directions)
        {
            int horizontal = 0, depth = 0;
            foreach (string direction in directions)
            {
                var (heading, distance) = SplitInstruction(direction);                
                switch (heading)
                {
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

        static int PlotCourse(string[] directions, int aim)
        {
            int horizontal = 0, depth = 0;
            foreach (string direction in directions)
            {
                var (heading, distance) = SplitInstruction(direction);                
                switch (heading)
                {
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

        static (string heading, int distance) SplitInstruction(string direction)
        {
            string[] directionSplit = direction.Split(" ");
            (string, int) directionParts = (directionSplit[0], Convert.ToInt32(directionSplit[1]));

            return directionParts;            
        }
    }
}