def Run(filepath):
    with open(filepath) as input:
        directions = list(map(str, input.read().split('\n')))

    print('Day 2')
    Part1(directions)
    Part2(directions)
    
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

    print('Part 1: ' + str(answer))
    #The result should be 1989014

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

    print('Part 2: ' + str(answer))
    #Result should be 2006917119