with open('/home/adam/Documents/Repos/adventofcode/2021/day03/input.txt') as input:
    diagnostics = list(map(str, input.read().split('\n')))

def BitFrequency(diagnostics, position, task):
    ones = zeroes = count = mostCommonBit = 0
    for entry in diagnostics:
        #Just add the value in the relevant position. If it's 1 it will increment 'ones', if it's 0 it won't
        ones += int(entry[position])
        count +=1
    #Because there are only ones and zeroes: 
    zeroes = count - ones
    if zeroes > ones:
        mostCommonBit = 0
    #Because in a draw, 1 wins:
    else: mostCommonBit = 1
    if task == 'o2':
        return mostCommonBit
    elif task == 'co2':
        #Because in both possible cases, this will result in the least common bit:
        return (1 - mostCommonBit)

def Highlander(diagnostics, task):
#There can be only one... (item left in the list)
    for position in range(len(diagnostics[0])):
        #Get either the most or least common bit for the o2 and co2 tasks respectively
        comparisonBit = BitFrequency(diagnostics, position, task)
        #Keep only the entries which have comparisonBit in the current position:
        diagnostics = [entry for entry in diagnostics if int(entry[position]) == comparisonBit]
        #Stop when there's only one left
        if len(diagnostics) <= 1:
            break
    return diagnostics[0]

#Get binary numbers made up of most (o2) and least (co2) common bits
o2 = int(Highlander(diagnostics,'o2'),2)
co2 = int(Highlander(diagnostics,'co2'),2)
lifeSupport = o2 * co2

print(lifeSupport)
#Result should be 4996233