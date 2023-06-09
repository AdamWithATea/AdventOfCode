namespace AdventOfCode;
public class Day07 : Day{
    public override Int64 Part1(string filepath){
        List<int> crabs = ConvertValuesToIntList(filepath, ",");
        int leastFuel = LeastFuelUsage(crabs, 0);
        return leastFuel;
    }
    public override Int64 Part2(string filepath){
        List<int> crabs = ConvertValuesToIntList(filepath, ",");
        int leastFuel = LeastFuelUsage(crabs, 1);
        return leastFuel;
    }
    private static int LeastFuelUsage(List<int> crabs, int costIncrement){
        List<int> fuelUsage = new();
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