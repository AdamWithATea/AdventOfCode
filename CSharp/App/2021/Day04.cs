using AdventOfCode;

namespace AOC2021;
public class Day04 : Day{
    public override long Part1(string filepath){
        return Play(filepath).Item1;
    }
    public override long Part2(string filepath){
        return Play(filepath).Item2;
    }
    static (int, int) Play(string filepath){
        List<string> input = Inputs.ListStrings(filepath, Environment.NewLine + Environment.NewLine);
        List<int> numbers = input[0].Split(',').ToList().Select(s => int.Parse(s)).ToList();
        List<int[,]> cards = BingoCards(input.GetRange(1,input.Count()-1));
        return Winners(numbers, cards);
    }
    static List<int[,]> BingoCards(List<string> cardsAsStrings){
        List<int[,]> cards = new();
        foreach (string cardString in cardsAsStrings){
            int[,] card = new int[6,6];
            for (int x = 0; x < 5; x++){
                string row = cardString.Split(Environment.NewLine)[x];
                for (int y = 0; y < 5; y++){
                    string value = row.Split(' ', StringSplitOptions.RemoveEmptyEntries)[y];
                    card[x,y] = Convert.ToInt32(value);
                }
            }
            cards.Add(card);
        }
        return cards;
    }
    static (int, int) Winners(List<int> numbers, List<int[,]> cards){
        var first = (numbers.Count + 1, 0);
        var last = (-1, 0);
        for (int i = 0; i < cards.Count; i++){
            var score = CardScore(numbers, cards[i]);
            first = first.Item1 > score.Item1 ? score : first;
            last = last.Item1 < score.Item1 ? score : last;
        }
        return (first.Item2, last.Item2);
    }
    static (int, int) CardScore(List<int> numbers, int[,] card){
        var score = (0,0);
        int markedSum = 0, cardSum = 0;
        for (int x = 0; x < 5; x++)
            { for(int y = 0; y < 5; y++) { cardSum += card[x,y]; } }
        for (int n = 0; n < numbers.Count; n++){
            for (int x = 0; x < 5; x++){
                for(int y = 0; y < 5; y++){
                    if (numbers[n] == card[x,y]){
                        card[x,5] += 1;
                        card[5,y] += 1;
                        markedSum += card[x,y];
                    }
                }
            }
            if (CardWon(card)){
                card[5,5] = (cardSum - markedSum) * numbers[n];
                score = (n, card[5,5]); //(Winning turn, Final score)
                break;
            }
        }
        return(score);
    }
    static bool CardWon(int[,] card){
        bool won = false;
        for (int i = 0; i < 5; i++)
            { if (card[i,5]==5 | card[5,i]==5) { won = true; } }
        return won;
    }
}