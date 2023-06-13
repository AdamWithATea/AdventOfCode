import InputHandler
import importlib

#1-25 gets that day's answers, any other value gives all answers
currentDay = 0
#Highest day that an answer exists for
highestDay = 3
#Use the examples instead of the actual inputs?
exampleInputs = False

def TwoDigitDates(day):
    #Enforce leading zero on days 1-9 to match package and file names
    day = str(day)
    if len(day) == 1 and (int(day) > 0 and int(day) < 10):
        day = '0' + day
    return day

def GetAllDays(highestDay):
    for day in range(1, highestDay+1):
        GetOneDay(day)
        if day < highestDay:
            #Insert line break between days
            print()

def GetOneDay(day):
    day = TwoDigitDates(day)
    filepath = InputHandler.BuildFilePath(day, exampleInputs)
    packageName = 'Day' + day
    imported = importlib.import_module(packageName)
    imported.Run(filepath)

#If a day that exists is selected, get that day's answers
if int(currentDay) > 0 and int(currentDay) < highestDay:
    GetOneDay(currentDay)
#Otherwise, get the answers from all days that exist
else: GetAllDays(highestDay)