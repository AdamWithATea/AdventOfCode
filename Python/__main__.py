import InputHandler
import settings
import importlib

def GetOneDay(day):
    day = InputHandler.DoubleDigitDay(day)
    packageName = 'AOC' + str(settings.year) + '.Day' + day
    imported = importlib.import_module(packageName)
    imported.Run(settings.useExamples)

def GetAllDays(highestDay):
    for day in range(1, highestDay+1):
        GetOneDay(day)

if settings.runAllDays == True:
    GetAllDays(settings.day)
else: GetOneDay(settings.day)