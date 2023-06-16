from .. import inputs

def run(filepath):
    print('#-1: ' + str(part1(filepath)))
    print('#-2: ' + str(part2(filepath)))

def part1(filepath):
    game_details = inputs.list_strings(filepath, '\n\n')
    return 0

def part2(filepath):
    game_details = inputs.list_strings(filepath, '\n\n')
    return 0

def setup_game(game_details):
    #Turn the first input line into a list of numbers to be drawn
    numbers_drawn = list(map(int, game_details[0].split(',')))
    #Get the bingo cards from the rest of the input
    bingo_cards = game_details[1:]