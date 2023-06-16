from .. import inputs

def run(filepath):
    print('1-1: ' + str(part1(filepath)))
    print('1-2: ' + str(part2(filepath)))

def part1(filepath):
    return count_increases(inputs.list_ints(filepath, '\n'), 1)

def part2(filepath):
    return count_increases(inputs.list_ints(filepath, '\n'), 3)

def count_increases(measurements, group_size):
    increases = index = previous_group = 0
    #Get the starting index of the last complete group in the list
    last_group_index = len(measurements)-group_size
    #Emulate "do...while" using "while True" and "if (condition): break"
    while True:
        current_group = 0
        for i in range(index, index+group_size):
            current_group += measurements[i]
        if index > 0 and current_group > previous_group:
            increases += 1
        previous_group = current_group
        index += 1
        if index > last_group_index:
            break
    return increases