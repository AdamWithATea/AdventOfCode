import InputHandler

def Run(filepath):
    gameDetails = InputHandler.ToStringList(filepath, '\n\n')

    print('Day #-1: ' + Part1(gameDetails)) #The result should be 
    print('Day #-2: ' + Part2(gameDetails)) #The result should be

def Part1(gameDetails):    
    return gameDetails

def Part2(gameDetails):  
    return gameDetails

def SetupGame(gameDetails):
    #Turn the first line of the input into a list of all the numbers to be drawn
    numbersDrawn = list(map(int, gameDetails[0].split(',')))
    #The rest of gameDetails is already split into bingo cards ready to be separated into their own list
    bingoCards = gameDetails[1:]