namespace AdventOfCode
{
    class Day04 : Day
    {
        public override void Main(string filepath)
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
            List<string> numbersDrawn = gameDetails[0].Split(',').ToList();
            List<string> bingoCards = gameDetails.ToList();
            bingoCards.RemoveAt(0);

            return (numbersDrawn, bingoCards);
        }
    }
}