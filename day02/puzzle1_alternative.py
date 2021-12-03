horizontal = 0
depth = 0

def forward(int):
    global horizontal
    horizontal += int

def down(int):
    global depth
    depth += int

def up(int):
    global depth
    depth -= int

with open('/home/adam/Documents/Repos/adventofcode2021/day02/input.txt') as txtfile:
    input = list(map(str, txtfile.read().split('\n')))

for index in range(len(input)):
    splitList = input[index].split(' ')
    eval(splitList[0] + '(' + splitList[1] + ')')

answer = horizontal * depth

print(answer)