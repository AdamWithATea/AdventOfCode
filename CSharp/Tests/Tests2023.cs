using Xunit;
using AdventOfCode;
using AOC2023;

namespace Tests;
public class Tests2023{
    [Fact]
    public void Day01Test(){
        Day01 day01 = new();
        Assert.Equal(142, day01.Part1(Inputs.BuildFilepath(2023, 01, true)));
        Assert.Equal(54968, day01.Part1(Inputs.BuildFilepath(2023, 01, false)));
        Assert.Equal(281, day01.Part2(Inputs.BuildFilepath(2023, 01, true)));
        Assert.Equal(54094, day01.Part2(Inputs.BuildFilepath(2023, 01, false)));
    }
    [Fact]
    public void Day02Test(){
        Day02 day02 = new();
        Assert.Equal(8, day02.Part1(Inputs.BuildFilepath(2023, 02, true)));
        Assert.Equal(2771, day02.Part1(Inputs.BuildFilepath(2023, 02, false)));
        Assert.Equal(2286, day02.Part2(Inputs.BuildFilepath(2023, 02, true)));
        Assert.Equal(70924, day02.Part2(Inputs.BuildFilepath(2023, 02, false)));
    }
}