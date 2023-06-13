import InputHandler

def Run(filepath):
    measurements = InputHandler.ToIntList(filepath, '\n')

    print('Day 1-1: ' + Part1(measurements)) #The result should be 1791
    print('Day 1-2: ' + Part2(measurements)) #The result should be 1822

def Part1(measurements):
    increases = 0
    previousDepth = None

    for depth in measurements:
        #Increment if this isn't the first measurement and the depth has increased
        if previousDepth != None and depth > previousDepth:
            increases += 1
        previousDepth = depth
    
    return str(increases)

def Part2(measurements):
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

    return str(increases)