import InputHandler

def Run(useExamples):
    filepath = InputHandler.BuildFilePath(2000,0,useExamples)
    print('Day #-1: ' + Part1(filepath))
    print('Day #-2: ' + Part2(filepath))

def Part1(filepath):
    intInputList = InputHandler.ToIntList(filepath, '\n')
    return 0

def Part2(filepath):
    strInputList = InputHandler.ToStringList(filepath, '\n')
    return 0