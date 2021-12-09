namespace AdventOfCode
{
    class Day04 : Day
    {
        public override void Main(string filepath)
        //Main is overriden today because this input file is divided by double line
        // breaks, meaning this Split() works better than the usual ReadAllLines()
        {
            string[] file = File.ReadAllText(filepath).Split(Environment.NewLine + Environment.NewLine);
            List<string> input = new List<string>(file);

            Part1(input);
            Part2(input);
            
        }
        public override void Part1(List<string> gameDetails)
        {
            var (numbersDrawn, bingoCards) = SetupGame(gameDetails);
        }
        public override void Part2(List<string> gameDetails)
        {
            var (numbersDrawn, bingoCards) = SetupGame(gameDetails);
        }

        static (List<string> numbersDrawn, List<string> bingoCards) SetupGame(List<string> gameDetails)
        {
            //Turn the first line of the input into a list of all the numbers to be drawn
            List<string> numbersDrawn = gameDetails[0].Split(',').ToList();
            //The rest of gameDetails is already split into bingo cards, so bingoCards is
            // populated by copying gameDetails then removing that first line of numbers
            List<string> bingoCards = gameDetails.ToList();
            bingoCards.RemoveAt(0);

            return (numbersDrawn, bingoCards);
        }
    }
}