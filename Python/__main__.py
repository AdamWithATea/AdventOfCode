import inputs
import settings
import importlib

def run_day(day):
    year = str(settings.year)
    day = inputs.two_digit_day(day)
    filepath = inputs.build_filepath(year, day, settings.use_examples)
    package_name = 'aoc' + year + '.day' + day
    importlib.import_module(package_name).run(filepath)

def run_all(highest_day):
    for day in range(1, highest_day+1):
        run_day(day)

if __name__ == "__main__":
    if settings.run_all == True:
        run_all(settings.day)
    else: run_day(settings.day)