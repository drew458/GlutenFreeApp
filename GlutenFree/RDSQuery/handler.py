import pymysql
import logging
import os
import sys
 
# 1. Install pymysql to local directory
# pip install -t $PWD pymysql
 
# 2. (If Using Lambda) Write your code, then zip it all up 
# a) Mac/Linux --> zip -r9 ${PWD}/function.zip 
# b) Windows --> Via Windows Explorer
 
# Lambda Permissions:
# AWSLambdaVPCAccessExecutionRole

logger = logging.getLogger()
logger.setLevel(logging.INFO)
 
#Configuration Values
endpoint = os.environ["ENDPOINT"]
username = os.environ["USERNAME"]
password = os.environ["PASSWORD"]
database_name = os.environ["DBNAME"]
 
#Connection
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

	item_count = 0

	cursor = connection.cursor()
	cursor.execute('SELECT * FROM falesiedb.Ristoranti')

	for row in cursor:
            item_count += 1
            logger.info(row)
            #print(row)

	connection.commit();

	return {
		'statusCode': 200,
		}
 
	for row in rows:
		print("{0} {1} {2}".format(row[0], row[1], row[2]))