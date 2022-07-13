namespace AdventOfCode;
public class Day07 : Day{
    public override Int64 Part1(string filepath){
        string[] file = File.ReadAllText(filepath).Split(',');
        List<string> crabStrings = new List<string>(file);
        List<int> crabs = ConvertPositionsToInt(crabStrings);
        int leastFuel = LeastFuelUsage(crabs, 0);

        System.Console.WriteLine($"Day 7-1: {leastFuel}");
        return leastFuel;
    }
    public override Int64 Part2(string filepath){
        string[] file = File.ReadAllText(filepath).Split(',');
        List<string> crabStrings = new List<string>(file);
        List<int> crabs = ConvertPositionsToInt(crabStrings);
        int leastFuel = LeastFuelUsage(crabs, 1);
        
        System.Console.WriteLine($"Day 7-2: {leastFuel}");
        return leastFuel;
    }
    private static List<int> ConvertPositionsToInt(List<string> crabStrings){
        List<int> crabs = new List<int>();
        foreach (string crab in crabStrings) {crabs.Add(Convert.ToInt32(crab));}
        return crabs;
    }
    private static int LeastFuelUsage(List<int> crabs, int costIncrement){
        List<int> fuelUsage = new List<int>();
        crabs.Sort();
        int highestCrab = crabs[crabs.Count - 1], lowestCrab = crabs[0];
        for (int position = lowestCrab; position <= highestCrab; position++){
            int totalFuelUsed = 0;
            foreach (int crab in crabs){
                int distanceMoved = 0, fuelPerMove = 1;
                if (crab > position) {distanceMoved += crab - position;}
                else { distanceMoved += position - crab; }
                for (int move = 1; move <= distanceMoved; move++){
                    totalFuelUsed += fuelPerMove;
                    fuelPerMove += costIncrement;
                }
            }
            fuelUsage.Add(totalFuelUsed);
        }
        fuelUsage.Sort();
        return fuelUsage[0];
    }
}