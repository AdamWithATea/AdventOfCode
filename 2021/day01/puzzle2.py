increases = 0
previousSum = None

with open('/home/adam/Documents/Repos/adventofcode2021/day01/input.txt') as txtfile:
    input = list(map(int, txtfile.read().split('\n')))

for index in range(len(input)-2):
    int1 = input[index]
    int2 = input[index+1]
    int3 = input[index+2]
    currentSum = int1+int2+int3
    
    if previousSum != None and currentSum > previousSum:
        increases += 1

    previousSum = currentSum

print(increases)