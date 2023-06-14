import InputHandler
from AOC2021 import Day01, Day02, Day03

def test_Day01():
    assert Day01.Part1(InputHandler.BuildFilePath(2021,1,True)) == 7
    assert Day01.Part1(InputHandler.BuildFilePath(2021,1,False)) == 1791
    assert Day01.Part2(InputHandler.BuildFilePath(2021,1,True)) == 5
    assert Day01.Part2(InputHandler.BuildFilePath(2021,1,False)) == 1822

def test_Day02():
    assert Day02.Part1(InputHandler.BuildFilePath(2021,2,True)) == 150
    assert Day02.Part1(InputHandler.BuildFilePath(2021,2,False)) == 1989014
    assert Day02.Part2(InputHandler.BuildFilePath(2021,2,True)) == 900
    assert Day02.Part2(InputHandler.BuildFilePath(2021,2,False)) == 2006917119

def test_Day03():
    assert Day03.Part1(InputHandler.BuildFilePath(2021,3,True)) == 198
    assert Day03.Part1(InputHandler.BuildFilePath(2021,3,False)) == 3912944
    assert Day03.Part2(InputHandler.BuildFilePath(2021,3,True)) == 230
    assert Day03.Part2(InputHandler.BuildFilePath(2021,3,False)) == 4996233