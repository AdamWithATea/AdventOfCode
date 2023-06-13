using AdventOfCode;

namespace AOC2021;
public class Day06 : Day{
    public override long Part1(string filepath){
        List<string>  fishAges = ConvertValuesToStringList(filepath, ",");
        long[] populationByAge = GroupFishByAge(fishAges);
        for (int day = 1; day <= 80; day++)
            {populationByAge = AddOneDay(populationByAge);}
        long population = populationByAge.Sum();
        return population;
    }
    public override long Part2(string filepath){
        List<string>  fishAges = ConvertValuesToStringList(filepath, ",");
        long[] populationByAge = GroupFishByAge(fishAges);
        for (int day = 1; day <= 256; day++)
            {populationByAge = AddOneDay(populationByAge);}
        long population = populationByAge.Sum();
        return population;
    }
    private static long[] AddOneDay(long[] existingPopulation){
        long[] newPopulation = new long[9];
        for (int age = 0; age <= 8; age++) {newPopulation[age] = 0;}
        for (int age = 0; age <= 8; age++){
            switch (age){
                case 0:
                    newPopulation[6] += existingPopulation[0];
                    newPopulation[8] += existingPopulation[0];
                    break;
                default:
                    newPopulation[age - 1] += existingPopulation[age];
                    break;
            }
        }
        return newPopulation;
    }
    private static long[] GroupFishByAge(List<string> input){
        List<long> fishAges = new();
        long[] populationByAge = new long[9];

        foreach (string item in input) {fishAges.Add(Convert.ToInt64(item));}
        foreach (long fishAge in fishAges) {populationByAge[fishAge]++;}

        return populationByAge;
    }
}