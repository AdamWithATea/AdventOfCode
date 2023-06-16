import inputs

def run(use_examples):
    print('3-1: ' + str(part1(use_examples)))
    print('3-2: ' + str(part2(use_examples)))

def part1(use_examples):
    filepath = inputs.build_filepath(2021, 3, use_examples)
    return run_diagnostics('power', inputs.list_strings(filepath, '\n'))

def part2(use_examples):
    filepath = inputs.build_filepath(2021, 3, use_examples)
    return run_diagnostics('life', inputs.list_strings(filepath, '\n'))

def run_diagnostics (task, report):
    most_common = diagnostic_results(report, task, 'most')
    least_common = diagnostic_results(report, task, 'least')
    return most_common * least_common

def diagnostic_results(report, task, target):
    #Fill initial string with 0s up to the required length
    output = '0' * len(report[0])
    for index in range(len(report[0])):
        ones = 0
        for entry in report:
            ones += int(entry[index])
        zeroes = len(report) - ones
        if ((ones >= zeroes and target == 'most')
                or (ones < zeroes and target == 'least')):
            bit = '1'
        else:
            bit = '0'
        match task:
            case "power": #Power Consumption
                #Replace current position in the string with target bit
                output = output[:index] + bit + output[index+1:]
            case "life": #Life Support
                #Only keep entries with target bit in this position
                report = [entry for entry in report if entry[index] == bit]
        if len(report) <= 1:
            #When one value remains, return it for the Life Support task
            output = report[0]
            break
    #Convert string of 1s & 0s to an int using base-2
    return int(output,2)