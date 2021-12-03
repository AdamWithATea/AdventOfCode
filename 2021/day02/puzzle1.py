horizontal = 0
depth = 0

with open('/home/adam/Documents/Repos/adventofcode2021/day02/input.txt') as txtfile:
    input = list(map(str, txtfile.read().split('\n')))

for index in range(len(input)):
    splitList = input[index].split(' ')
    if splitList[0] == 'forward':
        horizontal += int(splitList[1])
    elif splitList[0] == 'down':
        depth += int(splitList[1])
    elif splitList[0] == 'up':
        depth -= int(splitList[1])

answer = horizontal * depth

print(answer)