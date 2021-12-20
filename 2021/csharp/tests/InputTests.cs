using Xunit;
using AdventOfCode;

namespace tests;
public class InputTests
{
    [Fact]
    public void Day01Test(){
        Day01 day01 = new Day01();
        Assert.Equal(1791, day01.Part1("../../../../../inputs/day01.txt"));
        Assert.Equal(1822, day01.Part2("../../../../../inputs/day01.txt"));
    }
    [Fact]
    public void Day02Test(){
        Day02 day02 = new Day02();
        Assert.Equal(1989014, day02.Part1("../../../../../inputs/day02.txt"));
        Assert.Equal(2006917119, day02.Part2("../../../../../inputs/day02.txt"));
    }
    [Fact]
    public void Day03Test(){
        Day03 day03 = new Day03();
        Assert.Equal(3912944, day03.Part1("../../../../../inputs/day03.txt"));
        Assert.Equal(4996233, day03.Part2("../../../../../inputs/day03.txt"));
    }
    [Fact]
    public void Day04Test(){
        Day04 day04 = new Day04();
        Assert.Equal(33462, day04.Part1("../../../../../inputs/day04.txt"));
        Assert.Equal(30070, day04.Part2("../../../../../inputs/day04.txt"));
    }
    [Fact]
    public void Day05Test(){
        Day05 day05 = new Day05();
        Assert.Equal(6841, day05.Part1("../../../../../inputs/day05.txt"));
        Assert.Equal(19258, day05.Part2("../../../../../inputs/day05.txt"));
    }
    [Fact]
    public void Day06Test(){
        Day06 day06 = new Day06();
        Assert.Equal(385391, day06.Part1("../../../../../inputs/day06.txt"));
        Assert.Equal(1728611055389, day06.Part2("../../../../../inputs/day06.txt"));
    }
    [Fact]
    public void Day07Test(){
        Day07 day07 = new Day07();
        Assert.Equal(336120, day07.Part1("../../../../../inputs/day07.txt"));
        Assert.Equal(96864235, day07.Part2("../../../../../inputs/day07.txt"));
    }
    [Fact]
    public void Day08Test(){
        Day08 day08 = new Day08();
        Assert.Equal(321, day08.Part1("../../../../../inputs/day08.txt"));
        Assert.Equal(1028926, day08.Part2("../../../../../inputs/day08.txt"));
    }
}