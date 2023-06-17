using AdventOfCode;
using System;

namespace AOC2021;
public class Day03 : Day{
    public override long Part1(string filepath){
        return RunDiagnostics("PowerConsumption", Inputs.ListLines(filepath));
    }
    public override long Part2(string filepath){
        return RunDiagnostics("LifeSupport", Inputs.ListLines(filepath));
    }
    static int RunDiagnostics (string task, List<string> report){
        int mostCommon = DiagnosticResults(report, task, "Most");
        int leastCommon = DiagnosticResults(report, task, "Least");
        return mostCommon*leastCommon;
    }
    static int DiagnosticResults (List<string> report, string task, string mostOrLeast){
        //Pad out the initial string with 0s up to the required length
        string bitString = "";
        bitString = bitString.PadLeft(report[0].Length, '0');
        for (int position = 0; position < report[0].Length && report.Count > 1; position++){
            int ones = 0;
            string bitValue;
            foreach (var entry in report){ ones += int.Parse(entry[position].ToString()); }
            if ((ones >= report.Count-ones && mostOrLeast == "Most")
                ||(ones < report.Count-ones && mostOrLeast == "Least")){
                bitValue = "1";
            }
            else{ bitValue = "0"; }
            switch (task){
                case "PowerConsumption":
                    //Insert the bit into position while keeping the rest of the string intact
                    bitString = string.Concat(bitString.AsSpan(0, position), bitValue, bitString.AsSpan(position + 1));
                    break;
                case "LifeSupport":
                    //Only keep entries with the same bit as the bitString in the current position
                    report = report.Where(x => Convert.ToString(x[position]) == bitValue).ToList();
                    if (report.Count <= 1){ bitString = report[0];}
                    break;
            }
        }
        return Convert.ToInt32(bitString, 2); //Convert string of 1s & 0s to a base-2 int before returning it
    }
}