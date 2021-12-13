namespace AdventOfCode;
class Day06 : Day{
    public override void Main(string filepath){
        //Main is overriden today because this input file is divided by commas,
        // meaning this Split() works better than the usual ReadAllLines()
        string[] file = File.ReadAllText(filepath).Split(',');
        List<string> input = new List<string>(file);
        Part1(input);
        Part2(input);
    }
    public override void Part1(List<string> fishAges){
        Int64[] populationByAge = GroupFishByAge(fishAges);
        for (int day = 1; day <= 80; day++)
            {populationByAge = AddOneDay(populationByAge);}

        Int64 population = populationByAge.Sum();
        Int64 answer = 385391;
        string outcome = CheckAnswer(population, answer);
        System.Console.WriteLine($"Day 6-1: {population} {outcome}");
    }
    public override void Part2(List<string> fishAges){
        Int64[] populationByAge = GroupFishByAge(fishAges);
        for (int day = 1; day <= 256; day++)
            {populationByAge = AddOneDay(populationByAge);}

        Int64 population = populationByAge.Sum();
        Int64 answer = 1728611055389;
        string outcome = CheckAnswer(population, answer);
        System.Console.WriteLine($"Day 6-2: {population} {outcome}");
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