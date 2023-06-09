using Xunit;
using AdventOfCode;

namespace tests;
public class Tests{
    [Fact]
    public void Day01Test(){
        Day01 day01 = new();
        Assert.Equal(7, day01.Part1(day01.BuildFilePath(01, true)));
        Assert.Equal(1791, day01.Part1(day01.BuildFilePath(01, false)));
        Assert.Equal(5, day01.Part2(day01.BuildFilePath(01, true)));
        Assert.Equal(1822, day01.Part2(day01.BuildFilePath(01, false)));
    }
    [Fact]
    public void Day02Test(){
        Day02 day02 = new();
        Assert.Equal(150, day02.Part1(day02.BuildFilePath(02, true)));
        Assert.Equal(1989014, day02.Part1(day02.BuildFilePath(02, false)));
        Assert.Equal(900, day02.Part2(day02.BuildFilePath(02, true)));
        Assert.Equal(2006917119, day02.Part2(day02.BuildFilePath(02, false)));
    }
    [Fact]
    public void Day03Test(){
        Day03 day03 = new();
        Assert.Equal(198, day03.Part1(day03.BuildFilePath(03, true)));
        Assert.Equal(3912944, day03.Part1(day03.BuildFilePath(03, false)));
        Assert.Equal(230, day03.Part2(day03.BuildFilePath(03, true)));
        Assert.Equal(4996233, day03.Part2(day03.BuildFilePath(03, false)));
    }
    [Fact]
    public void Day04Test(){
        Day04 day04 = new();
        Assert.Equal(4512, day04.Part1(day04.BuildFilePath(04, true)));
        Assert.Equal(33462, day04.Part1(day04.BuildFilePath(04, false)));
        Assert.Equal(1924, day04.Part2(day04.BuildFilePath(04, true)));
        Assert.Equal(30070, day04.Part2(day04.BuildFilePath(04, false)));
    }
    [Fact]
    public void Day05Test(){
        Day05 day05 = new();
        Assert.Equal(5, day05.Part1(day05.BuildFilePath(05, true)));
        Assert.Equal(6841, day05.Part1(day05.BuildFilePath(05, false)));
        Assert.Equal(12, day05.Part2(day05.BuildFilePath(05, true)));
        Assert.Equal(19258, day05.Part2(day05.BuildFilePath(05, false)));
    }
    [Fact]
    public void Day06Test(){
        Day06 day06 = new();
        Assert.Equal(5934, day06.Part1(day06.BuildFilePath(06, true)));
        Assert.Equal(385391, day06.Part1(day06.BuildFilePath(06, false)));
        Assert.Equal(26984457539, day06.Part2(day06.BuildFilePath(06, true)));
        Assert.Equal(1728611055389, day06.Part2(day06.BuildFilePath(06, false)));
    }
    [Fact]
    public void Day07Test(){
        Day07 day07 = new();
        Assert.Equal(37, day07.Part1(day07.BuildFilePath(07, true)));
        Assert.Equal(336120, day07.Part1(day07.BuildFilePath(07, false)));
        Assert.Equal(168, day07.Part2(day07.BuildFilePath(07, true)));
        Assert.Equal(96864235, day07.Part2(day07.BuildFilePath(07, false)));
    }
    [Fact]
    public void Day08Test(){
        Day08 day08 = new();
        Assert.Equal(26, day08.Part1(day08.BuildFilePath(08, true)));        
        Assert.Equal(321, day08.Part1(day08.BuildFilePath(08, false)));
        Assert.Equal(61229, day08.Part2(day08.BuildFilePath(08, true)));
        Assert.Equal(1028926, day08.Part2(day08.BuildFilePath(08, false)));
    }
    [Fact]
    public void Day09Test(){
        Day09 day09 = new();
        Assert.Equal(15, day09.Part1(day09.BuildFilePath(09, true)));
        Assert.Equal(522, day09.Part1(day09.BuildFilePath(09, false)));
    }
}