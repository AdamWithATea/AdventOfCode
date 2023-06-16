#Get local file paths from .env file
import os
from dotenv import load_dotenv
load_dotenv()
input_path = os.getenv('INPUT_PATH')
example_folder = os.getenv('EXAMPLE_FOLDER')
slash = os.getenv('SLASH')
use_examples = False
run_all = True
day = 3
year = 2021