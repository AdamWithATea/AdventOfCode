import settings

def BuildFilePath(day):
    inputs = str(settings.inputPath)
    year = str(settings.year)
    slash = settings.slash
    file = 'Day' + day + '.txt'
    if settings.exampleInputs == True:
        filepath = inputs + year + slash + 'Examples' + slash + file
    else: filepath = inputs + year + slash + file
    return(filepath)

def ToStringList(filepath, separator):
    with open(filepath) as input:
        return list(map(str, input.read().split(separator)))
    
def ToIntList(filepath, separator):
    with open(filepath) as input:
        return list(map(int, input.read().split(separator)))