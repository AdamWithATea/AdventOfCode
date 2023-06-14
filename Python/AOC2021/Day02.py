import InputHandler

def Run(useExamples):
    filepath = InputHandler.BuildFilePath(2021, 2, useExamples)
    print('Day 2-1: ' + str(Part1(filepath)))
    print('Day 2-2: ' + str(Part2(filepath)))
    
def Part1(filepath):
    directions = InputHandler.FileToStringList(filepath, '\n')
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

    return answer

def Part2(filepath):
    directions = InputHandler.FileToStringList(filepath, '\n') 
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

    return answer