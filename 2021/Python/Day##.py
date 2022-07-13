def Part1(inputList):
    
    print('Part 1: ')
    #The result should be 

def Part2(inputList):    

    print('Part 2: ')
    #The result should be 

def Run(filepath):
    with open(filepath) as input:
        inputList = list(map(int, input.read().split('\n')))

    print('Day ##')
    Part1(inputList)
    Part2(inputList)