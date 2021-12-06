#Completely unnecessary alternative solution to Day 2 Puzzle 1 just to play around with functions

with open('/home/adam/Documents/Repos/adventofcode/2021/day02/input.txt') as input:
    directions = list(map(str, input.read().split('\n')))
    
horizontal = 0
depth = 0

def forward(distance):
    global horizontal
    horizontal += distance

def down(distance):
    global depth
    depth += distance

def up(distance):
    global depth
    depth -= distance

for instruction in directions:
    #Split the full instruction into direction and distance
    direction = instruction.split(' ')[0]
    distance = instruction.split(' ')[1]
    #Turn string values into a working command in order to call a different function depending on the direction
    eval(direction + '(' + distance + ')')

answer = horizontal * depth

print(answer)
#The result should be 1989014