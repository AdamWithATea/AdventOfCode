using AdventOfCode;

namespace AOC2021;
public class Day01 : Day{
    public override long Part1(string filepath){
        return CountDepthIncreases(Inputs.ListInts(filepath, Environment.NewLine), 1);
    }
    public override long Part2(string filepath){
        return CountDepthIncreases(Inputs.ListInts(filepath, Environment.NewLine), 3);
    }
    static int CountDepthIncreases(List<int> measurements, int groupSize){
        int previousGroup = 0, increases = 0;
        for (int index = 0; index <= measurements.Count - groupSize; index++){
            int currentGroup = 0;
            for (int i = index; i < index + groupSize; i++)
                { currentGroup += measurements[i]; }
            if (index > 0 && currentGroup > previousGroup) {increases++;}
            previousGroup = currentGroup;
        }
        return increases;
    }
}