import InputHandler

def Run(useExamples):
    filepath = InputHandler.BuildFilePath(2021, 2, useExamples)
    print('Day 2-1: ' + str(Part1(filepath)))
    print('Day 2-2: ' + str(Part2(filepath)))
    
def Part1(filepath):
    return PlotCourse(InputHandler.FileToStringList(filepath, '\n'), False)

def Part2(filepath):
    return PlotCourse(InputHandler.FileToStringList(filepath, '\n'), True)

def PlotCourse (directions, useAim):
    horizontal = depth = aim = 0    
    for direction in directions:
        heading = direction.split(' ')[0]
        distance = int(direction.split(' ')[1])
        match heading:
            case "forward":
                horizontal += distance
                if (useAim):
                    depth += aim * distance
            case "down":
                if (useAim):
                    aim += distance
                else:
                    depth += distance
            case "up":
                if(useAim):
                    aim -= distance
                else:
                    depth -= distance
    return horizontal * depth