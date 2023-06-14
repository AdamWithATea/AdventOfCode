import settings

def BuildFilePath(year, day, useExamples):
    inputs = str(settings.inputPath)
    year = str(year)
    slash = settings.slash
    day = DoubleDigitDay(day)
    file = 'Day' + day + '.txt'
    if useExamples == True:
        filepath = inputs + year + slash + 'Examples' + slash + file
    else: filepath = inputs + year + slash + file
    return(filepath)

def DoubleDigitDay(day):
    #Enforce leading zero on days 1-9 to match package and file names
    day = str(day)
    if len(day) == 1 and (int(day) > 0 and int(day) < 10):
        day = '0' + day
    return day

def FileToStringList(filepath, separator):
    with open(filepath) as input:
        return list(map(str, input.read().split(separator)))
    
def FileToIntList(filepath, separator):
    with open(filepath) as input:
        return list(map(int, input.read().split(separator)))