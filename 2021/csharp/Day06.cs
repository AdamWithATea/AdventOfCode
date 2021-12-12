namespace AdventOfCode
{
    class Day06 : Day
    {
        //Main is overriden today because this input file is divided by commas,
        // meaning this Split() works better than the usual ReadAllLines()
        public override void Main(string filepath){
            string[] file = File.ReadAllText(filepath).Split(',');
            List<string> input = new List<string>(file);

            Part1(input);
            Part2(input);
            
        }
        
        public override void Part1(List<string> fishAges)
        {
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
                {populationByAge = AddOneDay(populationByAge);
                //System.Console.WriteLine($"{day}: 0={populationByAge[0]} 1={populationByAge[1]} 2={populationByAge[2]} 3={populationByAge[3]} 4={populationByAge[4]} 5={populationByAge[5]} 6={populationByAge[6]} 7={populationByAge[7]} 8={populationByAge[8]}");
                
                }

            Int64 population = populationByAge.Sum();
            Int64 answer = 1728611055389;
            string outcome = CheckAnswer(population, answer);
            System.Console.WriteLine($"Day 6-2: {population} {outcome}");
        }

        private static Int64[] AddOneDay(Int64[] existingPopulation)
        {
            Int64[] newPopulation = new Int64[9];
            for(int age=0; age<=8; age++) {newPopulation[age] = 0;}

            for (int age=0; age<=8; age++){
                switch (age){
                    case 0:
                        newPopulation[6] += existingPopulation[0];
                        newPopulation[8] += existingPopulation[0];
                        break;
                    default:
                        newPopulation[age-1] += existingPopulation[age];
                        break;
                }                
            }

            // for (int age=0; age<=8; age++){
            //     //System.Console.WriteLine($"Age = {age}, Old Population = {existingPopulation[age]}");
            //     System.Console.WriteLine($"Age = {age}, New Population = {newPopulation[age]}");
            // }
            // System.Console.WriteLine();

            return newPopulation;
        }

        private static Int64[] GroupFishByAge(List<string> input){
            List<Int64> fishAges = new List<Int64>();
            Int64[] populationByAge = new Int64[9];

            foreach (string item in input)
                {fishAges.Add(Convert.ToInt64(item));}            
            foreach (Int64 fishAge in fishAges)
                {populationByAge[fishAge]++;}

            return populationByAge;
        }
    }
}