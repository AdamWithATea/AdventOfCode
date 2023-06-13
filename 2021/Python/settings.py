#Get local file paths from .env file
import os
from dotenv import load_dotenv
load_dotenv()
inputFolder = os.getenv('INPUT_FOLDER')
exampleFolder = os.getenv('EXAMPLE_FOLDER')

#1-25 gets that day's answers, any other value gives all answers
currentDay = 0

#Highest day that an answer exists for
highestDay = 3

#Use the examples instead of the actual inputs?
exampleInputs = True