with open('/home/adam/Documents/Repos/adventofcode/2021/day03/input.txt') as input:
    diagnostics = list(map(str, input.read().split('\n')))

#Fill strings with the right number of characters, to be replaced as the bits are calculated below
gamma = '#' * len(diagnostics[0])
epsilon = '#' * len(diagnostics[0])

for bit in range(len(diagnostics[0])):
    ones = zeroes = count = leastCommonBit = mostCommonBit = 0

    for line in diagnostics:
        #Just add the value in the 'bit' position. If it's 1 it will increment 'ones', if it's 0 it won't
        ones += int(line[bit])
        count += 1

    #Because there are only ones and zeroes: 
    zeroes = count - ones

    if ones > zeroes:
        mostCommonBit = 1
    elif zeroes > ones:        
        leastCommonBit = 1

    #Insert results into the relevant spot while keeping the rest of the string intact
    gamma = gamma[:bit] + str(mostCommonBit) + gamma[bit+1:]
    epsilon = epsilon[:bit] + str(leastCommonBit) + epsilon[bit+1:]

#Convert strings into binary numbers, i.e base-2 integers
gamma = int(gamma,2)
epsilon = int(epsilon,2)
powerConsumption = (gamma*epsilon)

print(powerConsumption)
#Result should be 3912944