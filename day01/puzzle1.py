increases = 0
previous = None

with open('/home/adam/Documents/Repos/adventofcode2021/day01/input.txt') as txtfile:
    input = list(map(int, txtfile.read().split('\n')))

for i in input:
    i = int(i)
    
    if previous != None and i > previous:
       increases += 1

    previous = i

print(increases)