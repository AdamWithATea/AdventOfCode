using System.Text.RegularExpressions;
using AdventOfCode;

namespace AOC2023;
public class Day01 : Day{
    public override long Part1(string filepath){
        if (filepath.Contains("Examples")){
            filepath = filepath[..^4] + "-Part1.txt";
        }
        List<string> inputs = Inputs.ListLines(filepath);
        int calibrationSum = CalibrationSum(inputs, false);
        return calibrationSum;
    }
    public override long Part2(string filepath){
        if (filepath.Contains("Examples")){
            filepath = filepath[..^4] + "-Part2.txt";
        }
        List<string> inputs = Inputs.ListLines(filepath);
        int calibrationSum = CalibrationSum(inputs, true);
        return calibrationSum;
    }
    private static int CalibrationSum(List<string> inputs, bool includeWords){
        int calibrationSum = 0;
        foreach (string line in inputs){
            string firstNumber = CalibrationDigit(line, false, includeWords);
            string lastNumber = CalibrationDigit(line, true, includeWords);
            _ = int.TryParse(firstNumber + lastNumber, out int calibrationValue);
            calibrationSum += calibrationValue;
        }
        return calibrationSum;
    }
    private static string CalibrationDigit(string input, bool rightToLeft, bool includeWords){
        string pattern = includeWords ? 
            @"[1-9]|one|two|three|four|five|six|seven|eight|nine" : @"[1-9]";
        RegexOptions options = rightToLeft ? RegexOptions.RightToLeft : RegexOptions.None;        
        string number = Regex.Matches(input, pattern, options)[0].Value;
        return NumericDigit(number);
    }
    private static string NumericDigit(string input){
        return input switch{
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => input,
        };
    }
}