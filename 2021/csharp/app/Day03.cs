namespace AdventOfCode;
public class Day03 : Day{
    public override Int64 Part1(string filepath){
        string[] file = File.ReadAllLines(filepath);
        List<string> diagnostics = new List<string>(file);
        string gamma = "", epsilon = "";
        int position = 0;
        //Fill strings with the right number of characters, to be replaced as the bits are calculated below
        gamma = gamma.PadLeft(diagnostics[0].Length, '#');
        epsilon = epsilon.PadLeft(diagnostics[0].Length, '#');

        while (position < diagnostics[0].Length){
            var (mostCommonBit, leastCommonBit) = BitFrequency(diagnostics, position);
            gamma = gamma.Substring(0, position) + mostCommonBit + gamma.Substring(position + 1);
            epsilon = epsilon.Substring(0, position) + leastCommonBit + epsilon.Substring(position + 1);
            position++;
        }
        int powerConsumption = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        
        System.Console.WriteLine($"Day 3-1: {powerConsumption}");
        return powerConsumption;
    }
    public override Int64 Part2(string filepath){
        string[] file = File.ReadAllLines(filepath);
        List<string> diagnostics = new List<string>(file);
        int o2 = CalculateLifeSupport(diagnostics, "o2");
        int co2 = CalculateLifeSupport(diagnostics, "co2");
        int lifeSupport = o2 * co2;
        
        System.Console.WriteLine($"Day 3-2: {lifeSupport}");
        return lifeSupport;
    }
    static int CalculateLifeSupport(List<string> diagnostics, string task){
        string comparisonBit;

        for (int position = 0; position < diagnostics[0].Length && diagnostics.Count > 1; position++){
            var (mostCommonBit, leastCommonBit) = BitFrequency(diagnostics, position);
            switch (task){
                case "co2":
                    comparisonBit = leastCommonBit;
                    break;
                default:
                    comparisonBit = mostCommonBit;
                    break;
            }
            diagnostics = diagnostics.Where(x => Convert.ToString(x[position]) == comparisonBit).ToList();
        }
        int rating = Convert.ToInt32(diagnostics[0], 2);
        return rating;
    }
    static (string most, string least) BitFrequency(List<string> diagnostics, int position){
        //Calculate the most and least common bit in the current postion in all strings
        int count = 0, ones = 0;
        string mostCommonBit, leastCommonBit;

        foreach (string diagnostic in diagnostics){
            int bit = int.Parse(diagnostic[position].ToString());
            //Just adds the bit rather than checking if it's a 1
            // because if it's a 0 that won't affect the value
            ones += bit;
            count++;
        }
        if (ones < count - ones){ //count-ones = the number of 0s in the string
            mostCommonBit = "0";
            leastCommonBit = "1";
        }
        else{mostCommonBit = "1";
            leastCommonBit = "0";
        }
        return (mostCommonBit, leastCommonBit);
    }
}