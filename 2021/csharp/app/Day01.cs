namespace AdventOfCode;
public class Day01 : Day{
    public override Int64 Part1(string filepath){
        string[] file = File.ReadAllLines(filepath);
        List<string> readings = new List<string>(file);

        int increases = CountDepthIncreases(readings, 1);
        int answer = 1791;
        string outcome = CheckAnswer(increases, answer);
        System.Console.WriteLine($"Day 1-1: {increases} {outcome}");
        return increases;
    }
    public override Int64 Part2(string filepath){
        string[] file = File.ReadAllLines(filepath);
        List<string> readings = new List<string>(file);
        
        int increases = CountDepthIncreases(readings, 3);
        int answer = 1822;
        string outcome = CheckAnswer(increases, answer);
        System.Console.WriteLine($"Day 1-2: {increases} {outcome}");
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