import settings

def BuildFilePath(day):
    filename = 'Day' + day + '.txt'
    if settings.exampleInputs == True:
        filepath = settings.exampleFolder + filename
    else: filepath = settings.inputFolder + filename
    return(filepath)

def ToStringList(filepath, separator):
    with open(filepath) as input:
        return list(map(str, input.read().split(separator)))
    
def ToIntList(filepath, separator):
    with open(filepath) as input:
        return list(map(int, input.read().split(separator)))