with open('/home/adam/Documents/Repos/adventofcode/2021/day02/input.txt') as input:
    directions = list(map(str, input.read().split('\n')))
    
horizontal = 0
depth = 0

for instruction in directions:
    #Split the full instruction into direction and distance
    direction = instruction.split(' ')[0]
    distance = instruction.split(' ')[1]
    if direction == 'forward':
        horizontal += int(distance)
    elif direction == 'down':
        depth += int(distance)
    elif direction == 'up':
        depth -= int(distance)

answer = horizontal * depth

print(answer)
#The result should be 1989014