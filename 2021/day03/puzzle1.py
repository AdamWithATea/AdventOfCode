binString = ''
gamma = bin(0)
epsilon = bin(0)

with open('/home/adam/Documents/Repos/adventofcode/2021/day03/example.txt') as txtfile:
    input = list(map(str, txtfile.read().split('\n')))

for i in range(len(input[0])):
    