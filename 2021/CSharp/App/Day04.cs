namespace AdventOfCode;
public class Day04 : Day{
    public override Int64 Part1(string filepath){
        var (numbersDrawn, bingoCards, scoreboard) = SetupGame(filepath);
        scoreboard = PlayBingo(numbersDrawn, bingoCards, scoreboard);        
        int lowestTurn = numbersDrawn.Count(), winningScore = 0;

        for (int index = 0; index < bingoCards.Count(); index++){
            if (scoreboard[2, index] < lowestTurn){
                winningScore = scoreboard[1, index];
                lowestTurn = scoreboard[2, index];
            }
        }
        return winningScore;
    }
    public override Int64 Part2(string filepath){
        var (numbersDrawn, bingoCards, scoreboard) = SetupGame(filepath);
        scoreboard = PlayBingo(numbersDrawn, bingoCards, scoreboard);
        int highestTurn = 0, losingScore = 0;
        
        for (int index = 0; index < bingoCards.Count(); index++){
            if (scoreboard[2, index] > highestTurn){
                losingScore = scoreboard[1, index];
                highestTurn = scoreboard[2, index];
            }
        }
        return losingScore;
    }
    static int[,] PlayBingo(List<int> numbersDrawn, List<int[,]> bingoCards, int[,] scoreboard){
        int cardNumber = 1;

        foreach (int[,] bingoCard in bingoCards){
            int index = cardNumber - 1;
            var (cardScore, winningTurn) = CalculateCardScore(numbersDrawn, bingoCard);
            scoreboard[0, index] = cardNumber;
            scoreboard[1, index] = cardScore;
            scoreboard[2, index] = winningTurn;
            cardNumber++;
        }
        return scoreboard;
    }
    static (List<int> numbersDrawn, List<int[,]> bingoCards, int[,] scoreboard) SetupGame(string filepath){
        string[] file = File.ReadAllText(filepath).Split(Environment.NewLine + Environment.NewLine);
        List<string> gameDetails = new List<string>(file);
        //Turn the first line of the input into a list of all the numbers to be drawn and convert them to int
        List<string> numbersDrawnStr = gameDetails[0].Split(',').ToList();
        List<int> numbersDrawn = new List<int>();
        foreach (string number in numbersDrawnStr)
            {numbersDrawn.Add(Convert.ToInt32(number));}

        //The rest of gameDetails is already split into bingo cards, so bingoCards is
        // populated by copying gameDetails then removing that first line of numbers
        List<string> bingoCardStrings = gameDetails.ToList();
        bingoCardStrings.RemoveAt(0);
        List<int[,]> bingoCards = new List<int[,]>();
        foreach (string bingoCardString in bingoCardStrings)
            {bingoCards.Add(ConvertCardToArray(bingoCardString));}

        //Create a scoreboard to keep track of the each card's number, final score when
        // it won and which turn it won on
        int[,] scoreboard = new int[3, bingoCardStrings.Count()];
        return (numbersDrawn, bingoCards, scoreboard);
    }
    static int[,] ConvertCardToArray(string bingoCardString){
        int[,] bingoCard = new int[5, 5];
        string[] cardLines = bingoCardString.Split(Environment.NewLine);

        for (int line = 0; line < cardLines.Count(); line++){
            string formattedLine = RemoveExtraSpaces(cardLines[line]);
            string[] lineValues = formattedLine.Split(" ");
            
            for (int value = 0; value < lineValues.Count(); value++)
                {bingoCard[value, line] = Convert.ToInt32(lineValues[value]);}
        }
        return bingoCard;
    }
    static (int cardScore, int winningTurn) CalculateCardScore(List<int> numbersDrawn, int[,] bingoCard){
        int turnNumber = 1, markedNumbersSum = 0, allNumbersSum = 0, lastNumberDrawn = 0;
        int[] rowTallies = new int[5], columnTallies = new int[5];
        bool hasWon;
        foreach (int i in bingoCard) {allNumbersSum += i;}

        foreach (int numberDrawn in numbersDrawn){
            for (int row = 0; row < 5; row++){
                var (lineTally, markedNumbersLineSum) = CheckLine("row", row, bingoCard, numberDrawn);
                rowTallies[row] += lineTally;
                markedNumbersSum += markedNumbersLineSum;
            }
            for (int column = 0; column < 5; column++){
                var (lineTally, markedNumbersLineSum) = CheckLine("column", column, bingoCard, numberDrawn);
                columnTallies[column] += lineTally;
                markedNumbersSum += markedNumbersLineSum;
            }

            hasWon = (rowTallies.Contains(5) || columnTallies.Contains(5));
            if (hasWon == true){
                lastNumberDrawn = numberDrawn;
                break;
            }
            turnNumber++;
        }
        int cardScore = (allNumbersSum - markedNumbersSum) * lastNumberDrawn;
        return (cardScore, turnNumber);
    }
    static (int lineTally, int markedNumbersLineSum) CheckLine(string lineType, int lineNumber, int[,] bingoCard, int numberDrawn){
        int lineTally = 0, markedNumbersLineSum = 0, columnIndex, rowIndex;

        for (int i = 0; i < 5; i++){
            if (lineType == "row"){
                rowIndex = lineNumber;
                columnIndex = i;
            }
            else {columnIndex = lineNumber;
                rowIndex = i;
            }

            if (Convert.ToInt32(bingoCard[columnIndex, rowIndex]) == numberDrawn){
                lineTally++;
                if (lineType == "row")
                //Only add to the marked numbers sum on rows, as columns cover the same squares
                // on the card from the other direction so it would count each one twice
                { markedNumbersLineSum += numberDrawn; }
            }
        }
        return (lineTally, markedNumbersLineSum);
    }
    static string RemoveExtraSpaces(string line){
        if (Convert.ToString(line[0]) == " ")
        { line = line.Substring(1); }
        line = line.Replace("  ", " ");
        return line;
    }
}