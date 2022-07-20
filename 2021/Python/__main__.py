#Enter 1-25 for a specific day's answers (if they exist yet). Any other value gets answers from all days
day = '0' 
#Load the example input instead of the real one?
example = False
#Latest day that a module exists for
latestDay = 4
#Local path for the AdventOfCode repo directory
rootDir = "/home/deck/Code/AdventOfCode/"

import importlib

def TwoDigitDates(day):
    #Enforces the leading zero on days 1-9, as package and file names require it
    day = str(day)
    if len(day) == 1 and (int(day) > 0 and int(day) < 10):
        day = '0' + day
    return(day)

def BuildFilePath(example, day):
    #Builds the filepath based on the day being requested and whether the example or input file is required
    if example == True:
        filepath = rootDir + '2021/InputFiles/Examples/Day' + day + '.txt'
    else: filepath = rootDir + '2021/InputFiles/Day' + day + '.txt'
    return(filepath)

def GetAllDays(latestDay):
    for day in range(1, latestDay+1):
        GetOneDay(day)
        if day < latestDay:
            #Insert line break between days
            print()

def GetOneDay(day):
    day = TwoDigitDates(day)
    filepath = BuildFilePath(example, day)
    packageName = 'Day' + day
    imported = importlib.import_module(packageName)
    imported.Run(filepath)

#If a day that exists is selected, get that day's answers
if int(day) > 0 and int(day) < latestDay:
    GetOneDay(day)
#Otherwise, get the answers from all days that exist
else: GetAllDays(latestDay)
