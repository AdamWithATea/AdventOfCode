using System.Text.RegularExpressions;
using AdventOfCode;

namespace AOC2023;
public class Day02 : Day{
    public override long Part1(string filepath){
        List<string> games = Inputs.ListLines(filepath);
        int sumPossibleGames = 0;
        foreach (string game in games){
            var(reds, greens, blues) = CubesNeeded(game);
            if (reds <= 12 && greens <= 13 && blues <= 14){
                string gameTitle = game.Split(':')[0];
                _ = int.TryParse(Regex.Replace(gameTitle, "[^0-9]", ""), out int gameId);
                sumPossibleGames += gameId;
            }
        }
        return sumPossibleGames;
    }
    public override long Part2(string filepath){
        List<string> games = Inputs.ListLines(filepath);
        int totalPower = 0;
        foreach (string game in games){
            var(reds, greens, blues) = CubesNeeded(game);
            int gamePower = reds * greens * blues;
            totalPower += gamePower;
        }
        return totalPower;
    }
    private static (int red, int green, int blue) CubesNeeded(string game){
        int redsNeeded = 0, greensNeeded = 0, bluesNeeded = 0;
        string[] rounds = game.Split(": ")[1].Split("; ");
        foreach (var round in rounds){
            int reds = 0, greens = 0, blues = 0;
            string[] cubes = round.Split(", ");
            foreach (string cube in cubes){
                _ = int.TryParse(cube.Split(' ')[0], out int count);
                string colour = cube.Split(' ')[1];
                switch (colour){
                    case "red":
                        if (count > reds){
                            reds = count;
                        }
                        break;
                    case "green":
                        if (count > greens){
                            greens = count;
                        }
                        break;
                    case "blue":
                        if (count > blues){
                            blues = count;
                        }
                        break;
                    default:
                        break;
                }
            }
            redsNeeded = reds > redsNeeded ? reds : redsNeeded;
            greensNeeded = greens > greensNeeded ? greens : greensNeeded;
            bluesNeeded = blues > bluesNeeded ? blues : bluesNeeded;
        }
        return (redsNeeded, greensNeeded, bluesNeeded);
    }
}