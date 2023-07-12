import inputs

def run(use_examples):
    print('2-1: ' + str(part1(use_examples)))
    print('2-2: ' + str(part2(use_examples)))
    
def part1(use_examples):
    filepath = inputs.build_filepath(2021, 2, use_examples)
    return plot_course(inputs.list_strings(filepath, '\n'), False)

def part2(use_examples):
    filepath = inputs.build_filepath(2021, 2, use_examples)
    return plot_course(inputs.list_strings(filepath, '\n'), True)

def plot_course (directions, use_aim):
    horizontal = depth = aim = 0
    for direction in directions:
        heading = direction.split(' ')[0]
        distance = int(direction.split(' ')[1])
        match heading:
            case "forward":
                horizontal += distance
                if use_aim:
                    depth += aim * distance
            case "down":
                if use_aim:
                    aim += distance
                else:
                    depth += distance
            case "up":
                if use_aim:
                    aim -= distance
                else:
                    depth -= distance
    return horizontal * depth