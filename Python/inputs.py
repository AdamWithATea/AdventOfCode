import settings

def build_filepath(year, day, use_examples):
    root_path = settings.input_path + str(year) + settings.slash
    example_folder = settings.example_folder if use_examples == True else ''
    filename = 'Day' + two_digit_day(day) + '.txt'
    return(root_path + example_folder + filename)

def two_digit_day(day):
    #Enforce leading zero on days 1-9 for package and file names
    return '0' + str(day) if len(str(day)) == 1 else str(day)

def list_strings(filepath, separator):
    with open(filepath) as input:
        return list(map(str, input.read().split(separator)))
    
def list_ints(filepath, separator):
    with open(filepath) as input:
        return list(map(int, input.read().split(separator)))