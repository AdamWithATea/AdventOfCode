import InputHandler

def Run(filepath):
    gameDetails = InputHandler.ToStringList(filepath, '\n\n')

    print('Day 4')
    Part1(gameDetails)
    Part2(gameDetails)

def Part1(gameDetails):    

    print('Part 1: ')
    #The result should be

def Part2(gameDetails):  

    print('Part 2: ')
    #The result should be

def SetupGame(gameDetails):
    #Turn the first line of the input into a list of all the numbers to be drawn
    numbersDrawn = list(map(int, gameDetails[0].split(',')))
    #The rest of gameDetails is already split into bingo cards ready to be separated into their own list
    bingoCards = gameDetails[1:]