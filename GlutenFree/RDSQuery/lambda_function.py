import json
import random

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

GET_RAW_PATH = "/getRestaurant"
POST_RAW_PATH = "/createRestaurant"
DELETE_RAW_PATH = "/deleteRestaurant"

RESTAURANT_ID = "restaurantId"
NAME = "name"
CITY = "city"
PROVINCE = "province"
REGION = "region"
LATITUDE = "latitude"
LONGITUDE = "longitude"
DISHTYPE = "dishType"
SPECIALMENU = "specialMenu"

logger = logging.getLogger()
logger.setLevel(logging.INFO)

# Configuration Values
endpoint = os.environ["ENDPOINT"]
username = os.environ["USERNAME"]
password = os.environ["PASSWORD"]
database_name = os.environ["DBNAME"]

# Connection to db
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

    # /getRestaurant
    if event['rawPath'] == GET_RAW_PATH:
        logger.info("Starting request for getRestaurant...")

        cursor = connection.cursor()

        try:
            event['queryStringParameters']
            logger.info("Parameters found!")

            if RESTAURANT_ID in event['queryStringParameters']:
                # Get restaurant with specific ID
                restaurantId = event['queryStringParameters']['restaurantId']

                logger.info("Parameter restaurantId=" + restaurantId)

                cursor.execute('SELECT * FROM falesiedb.Ristoranti WHERE ID=' + restaurantId)
                result = cursor.fetchall()

                logger.info(result)

                return {
                    'statusCode': 200,
                    "headers": {"Content-Type": "application/json"},
                    'body': json.dumps(result)
                }

            elif CITY in event['queryStringParameters']:
                # Get restaurants in a city
                city = event['queryStringParameters']['city']

                try:
                    dishType = event['queryStringParameters']['dishType']
                    try:
                        specialMenu = event['queryStringParameters']['specialMenu']
                        logger.info(
                            "Parameters city=" + city + " and dishType=" + dishType + " and specialMenu" + specialMenu)

                        query = 'SELECT * FROM falesiedb.Ristoranti WHERE Citta="' + city + '" AND TipoCucina="' + dishType + \
                                '" AND MenuAParte="' + specialMenu + '"'
                    except KeyError:
                        logger.info("Parameters city=" + city + " and dishType=" + dishType)
                        query = 'SELECT * FROM falesiedb.Ristoranti WHERE Citta="' + city + '" AND TipoCucina="' + dishType + '"'

                except KeyError:
                    logger.info("Parameter city=" + city)
                    query = 'SELECT * FROM falesiedb.Ristoranti WHERE Citta="' + city + '"'

                print(query)
                cursor.execute(query)
                result = cursor.fetchall()

                logger.info(result)

                return {
                    'statusCode': 200,
                    "headers": {"Content-Type": "application/json"},
                    'body': json.dumps(result)
                }

            elif PROVINCE in event['queryStringParameters']:
                # Get restaurants in a province
                province = event['queryStringParameters']['province']

                try:
                    dishType = event['queryStringParameters']['dishType']
                    try:
                        specialMenu = event['queryStringParameters']['specialMenu']
                        logger.info(
                            "Parameters province=" + province + " and dishType=" + dishType + " and specialMenu" + specialMenu)

                        query = 'SELECT * FROM falesiedb.Ristoranti WHERE Provincia="' + province + '" AND TipoCucina="' + dishType + \
                                '" AND MenuAParte="' + specialMenu + '"'
                    except KeyError:
                        logger.info("Parameters province=" + province + " and dishType=" + dishType)
                        query = 'SELECT * FROM falesiedb.Ristoranti WHERE Provincia="' + province + '" AND TipoCucina="' + dishType + '"'

                except KeyError:
                    logger.info("Parameter province=" + province)
                    query = 'SELECT * FROM falesiedb.Ristoranti WHERE Provincia="' + province + '"'

                print(query)
                cursor.execute(query)
                result = cursor.fetchall()

                logger.info(result)

                return {
                    'statusCode': 200,
                    "headers": {"Content-Type": "application/json"},
                    'body': json.dumps(result)
                }

            elif REGION in event['queryStringParameters']:
                # Get restaurants in a region
                region = event['queryStringParameters']['region']

                try:
                    dishType = event['queryStringParameters']['dishType']
                    try:
                        specialMenu = event['queryStringParameters']['specialMenu']
                        logger.info(
                            "Parameters region=" + region + " and dishType=" + dishType + " and specialMenu" + specialMenu)

                        query = 'SELECT * FROM falesiedb.Ristoranti WHERE Regione="' + region + '" AND TipoCucina="' + dishType + \
                                '" AND MenuAParte="' + specialMenu + '"'
                    except KeyError:
                        logger.info("Parameters region=" + region + " and dishType=" + dishType)
                        query = 'SELECT * FROM falesiedb.Ristoranti WHERE Regione="' + region + '" AND TipoCucina="' + dishType + '"'

                except KeyError:
                    logger.info("Parameter region=" + region)
                    query = 'SELECT * FROM falesiedb.Ristoranti WHERE Regione="' + region + '"'

                print(query)
                cursor.execute(query)
                result = cursor.fetchall()

                logger.info(result)

                return {
                    'statusCode': 200,
                    "headers": {"Content-Type": "application/json"},
                    'body': json.dumps(result)
                }

            elif DISHTYPE in event['queryStringParameters']:
                # Get restaurants with a specific dish type
                dishType = event['queryStringParameters']['dishType']

                logger.info("Parameter dishType=" + dishType)

                query = 'SELECT * FROM falesiedb.Ristoranti WHERE TipoCucina=%s'
                cursor.execute(query, (dishType,))
                result = cursor.fetchall()

                return {
                    'statusCode': 200,
                    "headers": {"Content-Type": "application/json"},
                    'body': json.dumps(result)
                }

            elif SPECIALMENU in event['queryStringParameters']:
                # Get restaurants with a special menu
                specialMenu = event['queryStringParameters']['specialMenu']

                logger.info("Parameter specialMenu=" + specialMenu)

                query = 'SELECT * FROM falesiedb.Ristoranti WHERE MenuAParte=%s'
                cursor.execute(query, (specialMenu,))
                result = cursor.fetchall()

                return {
                    'statusCode': 200,
                    "headers": {"Content-Type": "application/json"},
                    'body': json.dumps(result)
                }

            else:
                logger.error("ERROR! Wrong query parameters")
                sys.exit()

        except KeyError:
            # Get all restaurants
            logger.info("No parameters! Fetching all the db...")

            cursor.execute('SELECT * FROM falesiedb.Ristoranti')
            result = cursor.fetchall()

            return {
                'statusCode': 200,
                "headers": {"Content-Type": "application/json"},
                'body': json.dumps(result)
            }

    # /createRestaurant
    elif event['rawPath'] == POST_RAW_PATH:
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
        command = "INSERT INTO `falesiedb`.`Ristoranti` (`ID`, `Nome`, `Indirizzo`, `Citta`, `Provincia`, `Regione`, `Latitudine`, `Longitudine`, `TipoCucina`, `MenuAParte`) VALUES ('" + str(
            restaurantId) + "', '" + name + "', '" + address + "', '" + city + "', '" + province + "', '" + region + "', '" + latitude + "', '" + longitude + "', '" + dishType + "', '" + specialMenu + "');"
        print(command)

        cursor = connection.cursor()
        cursor.execute(command)
        connection.commit()

        return {
            "statusCode": 200,
        }

    # /deleteRestaurant
    elif event['rawPath'] == DELETE_RAW_PATH:
        print("Starting request for deleteRestaurant...")

        restaurantId = event['queryStringParameters']['restaurantId']

        logger.info("Parameter restaurantId=" + restaurantId)

        query = ('DELETE FROM falesiedb.Ristoranti WHERE ID=' + restaurantId)

        cursor = connection.cursor()
        cursor.execute(query)
        connection.commit()

        return {
            'statusCode': 200,
        }

    else:
        return
