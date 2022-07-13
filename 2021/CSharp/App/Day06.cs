namespace AdventOfCode;
public class Day06 : Day{
    public override Int64 Part1(string filepath){
        string[] file = File.ReadAllText(filepath).Split(',');
        List<string>  fishAges = new List<string>(file);
        Int64[] populationByAge = GroupFishByAge(fishAges);
        for (int day = 1; day <= 80; day++)
            {populationByAge = AddOneDay(populationByAge);}
        Int64 population = populationByAge.Sum();
        
        System.Console.WriteLine($"Day 6-1: {population}");
        return population;
    }
    public override Int64 Part2(string filepath){
        string[] file = File.ReadAllText(filepath).Split(',');
        List<string>  fishAges = new List<string>(file);
        Int64[] populationByAge = GroupFishByAge(fishAges);
        for (int day = 1; day <= 256; day++)
            {populationByAge = AddOneDay(populationByAge);}
        Int64 population = populationByAge.Sum();
        
        System.Console.WriteLine($"Day 6-2: {population}");
        return population;
    }
    private static Int64[] AddOneDay(Int64[] existingPopulation){
        Int64[] newPopulation = new Int64[9];
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
    private static Int64[] GroupFishByAge(List<string> input){
        List<Int64> fishAges = new List<Int64>();
        Int64[] populationByAge = new Int64[9];

        foreach (string item in input) {fishAges.Add(Convert.ToInt64(item));}
        foreach (Int64 fishAge in fishAges) {populationByAge[fishAge]++;}

        return populationByAge;
    }
}