with open('/home/adam/Documents/Repos/adventofcode/2021/day01/input.txt') as input:
    measurements = list(map(int, input.read().split('\n')))
    
increases = 0
previousDepth = None

for depth in measurements:
    #Increment if this isn't the first measurement and the depth has increased
    if previousDepth != None and depth > previousDepth:
       increases += 1

    previousDepth = depth

print(increases)
#The result should be 1791