import InputHandler

def Run(useExamples):
    filepath = InputHandler.BuildFilePath(2021, 1, useExamples)
    print('Day 1-1: ' + str(Part1(filepath)))
    print('Day 1-2: ' + str(Part2(filepath)))

def Part1(filepath):
    measurements = InputHandler.FileToIntList(filepath, '\n')
    increases = 0
    previousDepth = None

    for depth in measurements:
        #Increment if this isn't the first measurement and the depth has increased
        if previousDepth != None and depth > previousDepth:
            increases += 1
        previousDepth = depth
    
    return increases

def Part2(filepath):
    measurements = InputHandler.FileToIntList(filepath, '\n')
    increases = 0
    previousSum = None

    #Run as long as there are complete sets of 3 measurements to add together
    for index in range(len(measurements)-2):
        measurement1 = measurements[index]
        measurement2 = measurements[index+1]
        measurement3 = measurements[index+2]
        currentSum = measurement1 + measurement2 + measurement3
        
        #Increment if this isn't the first set of measurements and the sum has increased
        if previousSum != None and currentSum > previousSum:
            increases += 1
        previousSum = currentSum

    return increases