with open('/home/adam/Documents/Repos/adventofcode/2021/day03/input.txt') as txtfile:
    input = list(map(str, txtfile.read().split('\n')))

gammaString = '#' * len(input[0])
epsilonString = '#' * len(input[0])

for bit in range(len(input[0])):
    ones = zeroes = count = 0

    for line in input:
        ones += int(line[bit])
        count += 1
    
    zeroes = count-ones

    if ones > zeroes:
        mostCommon = 1
        leastCommon = 0
    elif zeroes > ones:
        mostCommon = 0
        leastCommon = 1

    gammaString = gammaString[:bit] + str(mostCommon) + gammaString[bit+1:]
    epsilonString = epsilonString[:bit] + str(leastCommon) + epsilonString[bit+1:]

gamma = int(gammaString,2)
epsilon = int(epsilonString,2)

print(gamma*epsilon)