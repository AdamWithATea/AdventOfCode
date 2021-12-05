with open('/home/adam/Documents/Repos/adventofcode2021/day04/example.txt') as txtfile:
    input = list(map(str, txtfile.read().split('\n\n')))

numbersDrawn = list(map(int, input[0].split(',')))
bingoCards = input[1:]