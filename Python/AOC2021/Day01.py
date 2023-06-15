import InputHandler

def Run(useExamples):
    filepath = InputHandler.BuildFilePath(2021, 1, useExamples)
    print('Day 1-1: ' + str(Part1(filepath)))
    print('Day 1-2: ' + str(Part2(filepath)))

def Part1(filepath):
    return CountDepthIncreases(InputHandler.FileToIntList(filepath, '\n'), 1)

def Part2(filepath):
    return CountDepthIncreases(InputHandler.FileToIntList(filepath, '\n'), 3)

def CountDepthIncreases(measurements, groupSize):
    increases = index = previousGroup = 0
    lastGroupStartingIndex = len(measurements)-groupSize
    #Emulate a do...while loop using "while True" and "if (end of loop): break"
    while True:
        currentGroup = 0
        for i in range(index, index+groupSize):
            currentGroup += measurements[i]
        if index > 0 and currentGroup > previousGroup:
            increases += 1
        previousGroup = currentGroup
        index += 1
        if index > lastGroupStartingIndex:
            break
    return increases