using AdventOfCode;
using System;

namespace AOC2021;
public class Day03 : Day{
    public override long Part1(string filepath){
        List<string> diagnostics = InputHandler.LinesToStringList(filepath);
        string gamma = "", epsilon = "";
        int position = 0;
        //Fill strings with the right number of characters, to be replaced as the bits are calculated below
        gamma = gamma.PadLeft(diagnostics[0].Length, '#');
        epsilon = epsilon.PadLeft(diagnostics[0].Length, '#');
        
        while (position < diagnostics[0].Length){
            var (mostCommonBit, leastCommonBit) = BitFrequency(diagnostics, position);
            gamma = string.Concat(gamma.AsSpan(0, position), mostCommonBit, gamma.AsSpan(position + 1));
            epsilon = string.Concat(epsilon.AsSpan(0, position), leastCommonBit, epsilon.AsSpan(position + 1));
            position++;
        }
        return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);        
    }
    public override long Part2(string filepath){
        List<string> diagnostics = InputHandler.LinesToStringList(filepath);
        int o2 = CalculateLifeSupport(diagnostics, "o2");
        int co2 = CalculateLifeSupport(diagnostics, "co2");
        return  o2 * co2;        
    }
    static int CalculateLifeSupport(List<string> diagnostics, string task){
        string comparisonBit;

        for (int position = 0; position < diagnostics[0].Length && diagnostics.Count > 1; position++){
            var (mostCommonBit, leastCommonBit) = BitFrequency(diagnostics, position);
            comparisonBit = task switch{
                "co2" => leastCommonBit,
                _ => mostCommonBit,
            };
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