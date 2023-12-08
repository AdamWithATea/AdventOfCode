using Xunit;
using AdventOfCode;
using AOC2023;

namespace Tests;
public class Tests2023{
    [Fact]
    public void Day01Test(){
        Day01 day01 = new();
        Assert.Equal(0, day01.Part1(Inputs.BuildFilepath(2023, 01, true)));
        Assert.Equal(0, day01.Part1(Inputs.BuildFilepath(2023, 01, false)));
        Assert.Equal(0, day01.Part2(Inputs.BuildFilepath(2023, 01, true)));
        Assert.Equal(0, day01.Part2(Inputs.BuildFilepath(2023, 01, false)));
    }
}