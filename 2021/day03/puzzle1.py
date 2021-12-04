with open('/home/adam/Documents/Repos/adventofcode/2021/day03/input.txt') as txtfile:
    input = list(map(str, txtfile.read().split('\n')))

gamma = '#' * len(input[0])
epsilon = '#' * len(input[0])

for bit in range(len(input[0])):
    ones = zeroes = count = leastCommon = mostCommon = 0

    for line in input:
        ones += int(line[bit])
        count += 1
    
    zeroes = count - ones

    if ones > zeroes:
        mostCommon = 1
    elif zeroes > ones:        
        leastCommon = 1

    gamma = gamma[:bit] + str(mostCommon) + gamma[bit+1:]
    epsilon = epsilon[:bit] + str(leastCommon) + epsilon[bit+1:]

gamma = int(gamma,2)
epsilon = int(epsilon,2)

print(gamma*epsilon)