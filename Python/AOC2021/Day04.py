import InputHandler

def Run(useExamples):
    filepath = InputHandler.BuildFilePath(2021, 4, useExamples)
    print('Day #-1: ' + str(Part1(filepath)))
    print('Day #-2: ' + str(Part2(filepath)))

def Part1(filepath):
    gameDetails = InputHandler.FileToStringList(filepath, '\n\n')
    return 0

def Part2(filepath):
    gameDetails = InputHandler.FileToStringList(filepath, '\n\n')
    return 0

def SetupGame(gameDetails):
    #Turn the first line of the input into a list of all the numbers to be drawn
    numbersDrawn = list(map(int, gameDetails[0].split(',')))
    #The rest of gameDetails is already split into bingo cards ready to be separated into their own list
    bingoCards = gameDetails[1:]