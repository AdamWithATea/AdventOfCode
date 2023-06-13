using AdventOfCode;

namespace AOC2021;
public class Day07 : Day{
    public override long Part1(string filepath){
        List<int> crabs = ConvertValuesToIntList(filepath, ",");
        return MedianFuelUsage(crabs);
    }
    public override long Part2(string filepath){
        List<int> crabs = ConvertValuesToIntList(filepath, ",");
        return LeastFuelUsage(crabs, 1);
    }
    private static int MedianFuelUsage(List<int> crabs){
        int fuelUsage = 0, medianPosition;
        crabs.Sort();
        if (crabs.Count % 2 == 0){ //If the list contains an even number of values
            int valueBelowMiddle = crabs[(crabs.Count/2)-1];
            int valueAboveMiddle = crabs[crabs.Count/2];
            medianPosition = (valueBelowMiddle + valueAboveMiddle)/2;
        }
        else{ //If the list contains an odd number of values
            medianPosition = crabs[((crabs.Count+1)/2)-1];
        }
        foreach (int crab in crabs){
            int distanceMoved = medianPosition-crab;
            distanceMoved = distanceMoved < 0 ? -distanceMoved : distanceMoved;
            fuelUsage += distanceMoved;
        }        
        return fuelUsage;
    }
    private static int LeastFuelUsage(List<int> crabs, int costIncrement){
        List<int> fuelUsage = new();
        //Group all crabs in the same position together as their fuel usage will be the same
        var crabGroups = crabs.GroupBy(i => i);
        for (int position = crabs.Min(); position <= crabs.Max(); position++){
            int totalFuelUsed = 0;
            foreach (var crabGroup in crabGroups){
                int distanceMoved = 0, fuelPerMove = 1, crabsInGroup = crabGroup.Count();
                if (crabGroup.Key > position) {distanceMoved += crabGroup.Key - position;}
                else { distanceMoved += position - crabGroup.Key; }
                for (int move = 1; move <= distanceMoved; move++){
                    totalFuelUsed += fuelPerMove * crabsInGroup;
                    fuelPerMove += costIncrement;
                }
            }
            fuelUsage.Add(totalFuelUsed);
        }
        return fuelUsage.Min();
    }
}