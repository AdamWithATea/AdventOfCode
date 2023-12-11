using AdventOfCode;

namespace AOC2023;
public class Year2023 : Year{
    public override List<Day> Days(){
        return new List<Day>{
            new Day01(),
            new Day02()
        };
    }
}