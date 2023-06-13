import InputHandler

def Run(filepath):
    directions = InputHandler.ToStringList(filepath, '\n')

    print('Day 2-1: ' + Part1(directions)) #The result should be 1989014
    print('Day 2-2: ' + Part2(directions)) #The result should be 2006917119
    
def Part1(directions):
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

    return str(answer)

def Part2(directions):    
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

    return str(answer)