import inputs
import settings
import importlib

def run_day(day):
    day = inputs.two_digit_day(day)
    package_name = 'aoc' + str(settings.year) + '.day' + day
    importlib.import_module(package_name).run(settings.use_examples)

def run_all(highest_day):
    for day in range(1, highest_day+1):
        run_day(day)

if __name__ == "__main__":
    if settings.run_all == True:
        run_all(settings.day)
    else: run_day(settings.day)