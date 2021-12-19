import pymysql
import os
import json
 
# 1. Install pymysql to local directory
# pip install -t $PWD pymysql
 
# 2. (If Using Lambda) Write your code, then zip it all up 
# a) Mac/Linux --> zip -r9 ${PWD}/function.zip 
# b) Windows --> Via Windows Explorer
 
# Lambda Permissions:
# AWSLambdaVPCAccessExecutionRole
 
#Configuration Values
endpoint = os.environ["ENDPOINT"]
username = os.environ["USERNAME"]
password = os.environ["PASSWORD"]
database_name = os.environ["DBNAME"]
 
#Connection
connection = pymysql.connect(host=endpoint, user=username,
	passwd=password, db=database_name)
 
def lambda_handler(event, context):
	cursor = connection.cursor()
	cursor.execute('SELECT * from Falesie')
	rows = cursor.fetchall()
	return {
		'statusCode': 200,
		'body': json.dumps(rows)
		}
 
	for row in rows:
		print("{0} {1} {2}".format(row[0], row[1], row[2]))