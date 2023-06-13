#Get local file paths from .env file
import os
from dotenv import load_dotenv
load_dotenv()
inputPath = os.getenv('INPUT_PATH')
slash = os.getenv('SLASH')

exampleInputs = False
runAllDays = True
day = 3
year = 2021