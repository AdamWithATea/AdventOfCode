namespace AdventOfCode
{
    class Day01 : Day
  {
    public override void Part1(string[] readings)
    {       
      int increases = CountDepthIncreases(readings, 1);

      int answer = 1791;
      string outcome = CheckAnswer(increases, answer);
      System.Console.WriteLine($"Day 1-1: {increases} {outcome}");
    }

    public override void Part2(string[] readings)
    {
      int increases = CountDepthIncreases(readings, 3);

      int answer = 1822;
      string outcome = CheckAnswer(increases, answer);
      System.Console.WriteLine($"Day 1-2: {increases} {outcome}");
    }

    static int CountDepthIncreases(string[] readings, int groupSize)
    {
      int currentSum = 0, previousSum = 0, increases = 0, depth, index = 0, indexDiff = groupSize - 1;

      while (index < readings.Length - indexDiff)
      {
        int i=0; 
        do{
          depth = Convert.ToInt32(readings[index+i]);
          currentSum += depth;
          i++;
          }        
        while (i < groupSize);
        
        if(previousSum != 0 && currentSum > previousSum)
            {increases++;}

        previousSum = currentSum;
        currentSum = 0;
        index++;
      }
      return increases;
    }
  }
}