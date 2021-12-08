namespace AdventOfCode
{
    class Day03 : Day
    {
        public override void Part1(string[] diagnostics)
        {
            string gamma = "", epsilon = "";
            int position = 0;
            gamma = gamma.PadLeft(diagnostics[0].Length, '#');
            epsilon = epsilon.PadLeft(diagnostics[0].Length, '#');

            while (position < diagnostics[0].Length)
            {
                var (mostCommonBit, leastCommonBit) = BitFrequency(diagnostics, position);
                gamma = gamma.Substring(0,position) + mostCommonBit + gamma.Substring(position+1);
                epsilon = epsilon.Substring(0,position) + leastCommonBit + epsilon.Substring(position+1);
                position++;
            }

            int powerConsumption = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
            int answer = 3912944;
            string outcome = CheckAnswer(powerConsumption, answer);
            System.Console.WriteLine($"Day 3-1: {powerConsumption} {outcome}");
        }
        public override void Part2(string[] diagnostics)
        {
            
        }
        
        static (string most, string least) BitFrequency(string[] diagnostics, int position)
        {
            int count = 0, sum = 0;
            string mostCommonBit, leastCommonBit;

            foreach (string diagnostic in diagnostics)
            {                                
                int bit = int.Parse(diagnostic[position].ToString());
                sum += bit;
                count++;
            }
            if (sum < count-sum)
            {
                mostCommonBit = "0";
                leastCommonBit = "1";
            }
            else
            {
                mostCommonBit = "1";
                leastCommonBit = "0";
            }
            return (mostCommonBit, leastCommonBit);
        }
    }
}