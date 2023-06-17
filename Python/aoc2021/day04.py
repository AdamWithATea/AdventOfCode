import inputs
import numpy as np

def run(use_examples):
    print('4-1: ' + str(part1(use_examples)))
    print('4-2: ' + str(part2(use_examples)))

def part1(use_examples):
    filepath = inputs.build_filepath(2021, 4, use_examples)
    return play(filepath)[0]

def part2(use_examples):
    filepath = inputs.build_filepath(2021, 4, use_examples)
    return play(filepath)[1]

def play(filepath):
    game_details = inputs.list_strings(filepath, '\n\n')
    numbers = list(map(int, game_details[0].split(',')))
    return winners(numbers, bingo_cards(game_details[1:]))

def bingo_cards(card_strings):
    cards = list()
    for card_string in card_strings:
        card = list()
        for row in list(card_string.split('\n')):
            row = row + ' 0' #To store the row's score
            card.append(list(map(int, row.split())))
        card.append([0,0,0,0,0,0]) #To store the column scores
        cards.append(card)
    return cards

def winners(numbers, cards):
    first = (len(numbers)+1, 0)
    last = (-1, 0)
    for c in range(len(cards)):
        score = card_score(numbers, cards[c])
        first = score if first[0] > score[0] else first
        last = score if last[0] < score[0] else last
    return (first[1], last[1])

def card_score(numbers, card):
    score = (0,0)
    marked_sum = 0
    card_sum = np.sum(card)
    for n in range (len(numbers)):
        for x in range (5):
            for y in range (5):
                if numbers[n] == card[x][y]:
                    card[x][5] += 1
                    card[5][y] += 1
                    marked_sum += card[x][y]
                card[5][5] = (card_sum - marked_sum) * numbers[n]
        if card_won(card):
            score = (n, card[5][5]) #(Winning turn & score)
            break
    return score

def card_won(card):
    won = False
    for i in range(5):
        if card[i][5] == 5 or card[5][i] == 5:
            won = True
    return won