from ..inputs import build_filepath
from ..aoc2021 import day01, day02, day03

def test_day01():
    assert day01.part1(build_filepath(2021,1,True)) == 7
    assert day01.part1(build_filepath(2021,1,False)) == 1791
    assert day01.part2(build_filepath(2021,1,True)) == 5
    assert day01.part2(build_filepath(2021,1,False)) == 1822

def test_day02():
    assert day02.part1(build_filepath(2021,2,True)) == 150
    assert day02.part1(build_filepath(2021,2,False)) == 1989014
    assert day02.part2(build_filepath(2021,2,True)) == 900
    assert day02.part2(build_filepath(2021,2,False)) == 2006917119

def test_day03():
    assert day03.part1(build_filepath(2021,3,True)) == 198
    assert day03.part1(build_filepath(2021,3,False)) == 3912944
    assert day03.part2(build_filepath(2021,3,True)) == 230
    assert day03.part2(build_filepath(2021,3,False)) == 4996233