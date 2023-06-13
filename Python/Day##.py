import InputHandler

def Run(filepath):
    intInputList = InputHandler.ToIntList(filepath, '\n')
    strInputList = InputHandler.ToStringList(filepath, '\n')

    print('Day #-1: ' + Part1(intInputList)) #The result should be 
    print('Day #-2: ' + Part2(strInputList)) #The result should be

def Part1(inputList):    
    return inputList

def Part2(inputList):
    return inputList