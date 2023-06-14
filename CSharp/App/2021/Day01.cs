using AdventOfCode;

namespace AOC2021;
public class Day01 : Day{
    public override long Part1(string filepath){
        List<string> readings = InputHandler.LinesToStringList(filepath);
        int increases = CountDepthIncreases(readings, 1);
        return increases;
    }
    public override long Part2(string filepath){
        List<string> readings = InputHandler.LinesToStringList(filepath);
        int increases = CountDepthIncreases(readings, 3);
        return increases;
    }
    static int CountDepthIncreases(List<string> readings, int groupSize){
        int currentSum = 0, previousSum = 0, increases = 0, depth, index = 0, indexDiff = groupSize - 1;
        
        //This loop uses indexDiff to run until there are no more full-sized groups to
        /// add together, e.g. a group of 3 items will start 2 indexes before the end 
        while (index < readings.Count - indexDiff){
            int i = 0;
            
            do{ ///Add at least the first depth reading to the sum, then loop if more depths exist
                depth = Convert.ToInt32(readings[index + i]);
                currentSum += depth;
                i++;
            } while (i < groupSize);
            
            //Increment if this isn't the first measurement and the depth has increased
            if (previousSum != 0 && currentSum > previousSum) {increases++;}
            previousSum = currentSum;
            currentSum = 0;
            index++;
        }
        return increases;
    }
}