def BuildFilePath(day, exampleInputs):
    inputFolder = "AdventOfCode/2021/InputFiles/"
    filename = 'Day' + day + '.txt'
    if exampleInputs == True:
        filepath = inputFolder + 'Examples/' + filename
    else: filepath = inputFolder + filename
    return(filepath)

def ToStringList(filepath, separator):
    with open(filepath) as input:
        return list(map(str, input.read().split(separator)))
    
def ToIntList(filepath, separator):
    with open(filepath) as input:
        return list(map(int, input.read().split(separator)))