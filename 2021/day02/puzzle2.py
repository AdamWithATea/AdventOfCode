with open('/home/adam/Documents/Repos/adventofcode/2021/day02/input.txt') as input:
    directions = list(map(str, input.read().split('\n')))

horizontal = 0
depth = 0
aim = 0

for instruction in directions:
    #Split the full instruction into direction and distance
    direction = instruction.split(' ')[0]
    distance = instruction.split(' ')[1]
    if direction == 'forward':
        horizontal += int(distance)
        depth += aim * int(distance)
    elif direction == 'down':
        aim += int(distance)
    elif direction == 'up':
        aim -= int(distance)

answer = horizontal * depth

print(answer)
#Result should be 2006917119