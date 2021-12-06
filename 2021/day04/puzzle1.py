with open('/home/adam/Documents/Repos/adventofcode2021/day04/example.txt') as input:
    gameDetails = list(map(str, input.read().split('\n\n')))

#Turn the first line of the input into a list of all the numbers to be drawn
numbersDrawn = list(map(int, gameDetails[0].split(',')))
#The rest of gameDetails is already split into bingo cards ready to be separated into their own list
bingoCards = gameDetails[1:]