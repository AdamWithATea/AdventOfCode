with open('/home/adam/Documents/Repos/adventofcode/2021/day03/input.txt') as txtfile:
    input = list(map(str, txtfile.read().split('\n')))

def BitFrequency(inputList, position, task):
    ones = zeroes = count = mostCommonBit = 0
    for item in inputList:
        ones += int(item[position])
        count +=1
    zeroes = count - ones
    if zeroes > ones:
        mostCommonBit = 0
    else: mostCommonBit = 1
    if task == 'o2':
        return mostCommonBit
    elif task == 'co2':
        return (1 - mostCommonBit)

def Highlander(inputList, task):
    for i in range(len(inputList[0])):
        comparisonBit = BitFrequency(inputList, i, task)
        inputList = [x for x in inputList if int(x[i]) == comparisonBit]
        if len(inputList) <= 1:
            break
    return inputList[0]

o2 = int(Highlander(input,'o2'),2)
co2 = int(Highlander(input,'co2'),2)
lifeSupport = o2 * co2
print('O2 = ' + str(o2))
print('CO2 = ' + str(co2))
print('Life Support = ' + str(lifeSupport))
