import InputHandler

def Run(useExamples):
    filepath = InputHandler.BuildFilePath(2021, 1, useExamples)
    print('Day 1-1: ' + str(Part1(filepath)))
    print('Day 1-2: ' + str(Part2(filepath)))

def Part1(filepath):
    return MeasureDepthIncreases(InputHandler.FileToIntList(filepath, '\n'), 1)

def Part2(filepath):
    return MeasureDepthIncreases(InputHandler.FileToIntList(filepath, '\n'), 3)

def MeasureDepthIncreases(measurements, groupSize):
    increases = 0
    index = 0
    previousGroup = 0
    lastGroupStartingIndex = len(measurements)-groupSize

    #Emulate a do...while loop using "while True" and "break"
    while True:
        currentGroup = 0
        #Add every value in the group to the current group's sum
        for i in range(index, index+groupSize):
            currentGroup += measurements[i]
        #Increment if this isn't the first set of measurements and the sum has increased
        if index > 0 and currentGroup > previousGroup:
            increases += 1
        previousGroup = currentGroup
        index += 1
        if index > lastGroupStartingIndex:
            break
    return increases