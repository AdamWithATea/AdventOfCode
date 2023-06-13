using AdventOfCode;

namespace AOC2021;
public class Year2021 : Year{
    public override List<Day> Days(){
        return new List<Day>{
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
            new Day06(),
            new Day07(),
            new Day08(),
            new Day09()
        };
    }
}