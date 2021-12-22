import pymysql
import logging
import os
import sys
import json
import uuid
import random

# 1. Install pymysql to local directory
# pip install -t $PWD pymysql

# 2. (If Using Lambda) Write your code, then zip it all up 
# a) Mac/Linux --> zip -r9 ${PWD}/function.zip 
# b) Windows --> Via Windows Explorer

# Lambda Permissions:
# AWSLambdaVPCAccessExecutionRole

GET_RAW_PATH = "/getRestaurant"
POST_RAW_PATH = "/createRestaurant"
DELETE_RAW_PATH = "/deleteRestaurant"

logger = logging.getLogger()
logger.setLevel(logging.INFO)

# Configuration Values
endpoint = os.environ["ENDPOINT"]
username = os.environ["USERNAME"]
password = os.environ["PASSWORD"]
database_name = os.environ["DBNAME"]

# Connection
try:
	connection = pymysql.connect(host=endpoint, user=username,
								 passwd=password, db=database_name)
except pymysql.MySQLError as e:
	logger.error("ERROR: Unexpected error: Could not connect to MySQL instance.")
	logger.error(e)
	sys.exit()

logger.info("SUCCESS: Connection to RDS MySQL instance succeeded")


def lambda_handler(event, context):
	"""
	This function fetches content from MySQL RDS instance
	"""
	
	print(event)

	if event['rawPath'] == GET_RAW_PATH:
		# getRestaurant
		print("Starting request for getRestaurant...")

		cursor = connection.cursor()
		
		try:
			restaurantId = event['queryStringParameters']['restaurantId']
			print("param restaurantId=" + restaurantId)
			cursor.execute('SELECT * FROM falesiedb.Ristoranti WHERE ID=' +restaurantId)
			
			item_count = 0
			for row in cursor:
				item_count += 1
				logger.info(row)
				# print(row)
	
			connection.commit();
			return {
				'statusCode': 200,
				'restaurantId': restaurantId
			}
			
		except KeyError:
			logger.info("No query string parameter 'restaurantId', fetching all the db...")
			cursor.execute('SELECT * FROM falesiedb.Ristoranti')
			
			item_count = 0
			for row in cursor:
				item_count += 1
				logger.info(row)
				# print(row)
			
			connection.commit();
			return {
				'statusCode': 200,
			}

	elif event['rawPath'] == POST_RAW_PATH:
		# createRestaurant
		print("Starting request for createRestaurant...")

		decodedBody = json.loads(event['body'])
		name = decodedBody['name']
		address = decodedBody['address']
		city = decodedBody['city']
		province = decodedBody['province']
		region = decodedBody['region']
		latitude = decodedBody['latitude']
		longitude = decodedBody['longitude']
		dishType = decodedBody['dishType']
		specialMenu = decodedBody['specialMenu']

		restaurantId = random.randint(10, 100000000)
		command = "INSERT INTO `falesiedb`.`Ristoranti` (`ID`, `Nome`, `Indirizzo`, `Citta`, `Provincia`, `Regione`, `Latitudine`, `Longitudine`, `TipoCucina`, `MenuAParte`) VALUES ('" + restaurantId + "', '" + name + "', '" + address + "', '" + city + "', '" + province + "', '" + region + "', '" + latitude + "', '" + longitude + "', '" + dishType + "', '" + specialMenu + "');"
		print(command)

		cursor = connection.cursor()
		cursor.execute(command)

		return {
			"statusCode": 200,
			"restaurantId": restaurantId}

	elif event['rawPath'] == DELETE_RAW_PATH:
		# createRestaurant
		print("Starting request for deleteRestaurant...")

	else:
		return
