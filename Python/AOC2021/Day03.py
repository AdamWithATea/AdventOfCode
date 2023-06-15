import InputHandler

def Run(useExamples):
    filepath = InputHandler.BuildFilePath(2021, 3, useExamples)
    print('Day 3-1: ' + str(Part1(filepath)))
    print('Day 3-2: ' + str(Part2(filepath)))

def Part1(filepath):
    return RunDiagnostics('PowerConsumption', InputHandler.FileToStringList(filepath, '\n'))

def Part2(filepath):
    return RunDiagnostics('LifeSupport', InputHandler.FileToStringList(filepath, '\n'))

def RunDiagnostics (task, report):
    mostCommon = int(DiagnosticResults(report, task, 'Most'),2)
    leastCommon = int(DiagnosticResults(report, task, 'Least'),2)
    return mostCommon*leastCommon

def DiagnosticResults(report, task, mostOrLeast):
    bitString = '0' * len(report[0])
    for position in range(len(report[0])):
        ones = 0
        for entry in report:
            ones += int(entry[position])
            if ((ones >= len(report)-ones and mostOrLeast == 'Most')
                or (ones < len(report)-ones and mostOrLeast == 'Least')):
                bitValue = '1'
            else:
                bitValue = '0'
        match task:
            case "PowerConsumption":
                #Insert the bit into position while keeping the rest of the string intact
                bitString = bitString[:position] + bitValue + bitString[position+1:]
            case "LifeSupport":
                #Only keep entries with the same bit as the bitString in the current position
                report = [entry for entry in report if entry[position] == bitValue]
        if len(report) <= 1:
            #If the Life Support task removes all but other values, stop and return the last one
            bitString = report[0]
            break
    return bitString