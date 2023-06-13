import InputHandler
import settings
import importlib

def TwoDigitDates(day):
    #Enforce leading zero on days 1-9 to match package and file names
    day = str(day)
    if len(day) == 1 and (int(day) > 0 and int(day) < 10):
        day = '0' + day
    return day

def GetAllDays(highestDay):
    for day in range(1, highestDay+1):
        GetOneDay(day)

def GetOneDay(day):
    day = TwoDigitDates(day)
    filepath = InputHandler.BuildFilePath(day)
    packageName = str(settings.year) + '.Day' + day
    imported = importlib.import_module(packageName)
    imported.Run(filepath)

if settings.runAllDays == True:
    GetAllDays(settings.day)
else: GetOneDay(settings.day)