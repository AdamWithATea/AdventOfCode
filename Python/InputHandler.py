import settings

def BuildFilePath(year, day, useExamples):
    exampleFolder = 'Examples' + settings.slash if useExamples == True else ''
    filename = 'Day' + DoubleDigitDay(day) + '.txt'
    return(settings.inputPath + str(year) + settings.slash + exampleFolder + filename)

def DoubleDigitDay(day): #Enforce leading zero on days 1-9 to match package and file names
    return '0' + str(day) if len(str(day)) == 1 else str(day)

def FileToStringList(filepath, separator):
    with open(filepath) as input:
        return list(map(str, input.read().split(separator)))
    
def FileToIntList(filepath, separator):
    with open(filepath) as input:
        return list(map(int, input.read().split(separator)))