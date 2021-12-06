with open('/home/adam/Documents/Repos/adventofcode/2021/day01/input.txt') as input:
    measurements = list(map(int, input.read().split('\n')))

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

print(increases)
#The result should be 1822