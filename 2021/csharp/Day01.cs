namespace AdventOfCode;
class Day01 : Day{
    public override void Part1(List<string> readings){
        int increases = CountDepthIncreases(readings, 1);
        int answer = 1791;
        string outcome = CheckAnswer(increases, answer);
        System.Console.WriteLine($"Day 1-1: {increases} {outcome}");
    }
    public override void Part2(List<string> readings){
        int increases = CountDepthIncreases(readings, 3);
        int answer = 1822;
        string outcome = CheckAnswer(increases, answer);
        System.Console.WriteLine($"Day 1-2: {increases} {outcome}");
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