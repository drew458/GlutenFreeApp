import json
import random
import logging
import os
import sys

import pymysql
from pymysql.constants import CLIENT

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
URL = "URL"

logger = logging.getLogger()
logger.setLevel(logging.INFO)

# Configuration Values
endpoint = os.environ["ENDPOINT"]
username = os.environ["USERNAME"]
password = os.environ["PASSWORD"]
database_name = os.environ["DBNAME"]

# Connection to db
try:
    connection = pymysql.connect(host=endpoint, user=username, passwd=password, db=database_name, 
                            client_flag=CLIENT.MULTI_STATEMENTS, charset='utf8mb4', cursorclass=pymysql.cursors.DictCursor)
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

        if event['rawQueryString']:
            logger.info("Parameters found!")

            if RESTAURANT_ID in event['queryStringParameters']:
                
                # Get restaurant with specific ID
                restaurantId = event['queryStringParameters']['restaurantId']

                logger.info("Parameter restaurantId=" + restaurantId)

                cursor.execute('SELECT * FROM falesiedb.Ristoranti WHERE ID=' + restaurantId)

            elif CITY in event['queryStringParameters']:
                
                # Get restaurants in a city
                city = event['queryStringParameters']['city']

                try:
                    dishType = event['queryStringParameters']['dishType']
                    try:
                        specialMenu = event['queryStringParameters']['specialMenu']
                        logger.info("Parameters city=" + city + " and dishType=" + dishType + " and specialMenu" + specialMenu)

                        query = 'SELECT * FROM falesiedb.Ristoranti r join falesiedb.TipologieCucina tc on r.TipoCucina=tc.TipoCucina ' \
                                'WHERE Citta="' + city + '" AND Principale="' + dishType + '" AND MenuAParte="' + specialMenu + '"'
                    except KeyError:
                        logger.info("Parameters city=" + city + " and dishType=" + dishType)
                        query = 'SELECT * FROM falesiedb.Ristoranti r join falesiedb.TipologieCucina tc on r.TipoCucina=tc.TipoCucina ' \
                                'WHERE Citta="' + city + '" AND Principale="' + dishType + '"'

                except KeyError:
                    logger.info("Parameter city=" + city)
                    query = 'SELECT * FROM falesiedb.Ristoranti WHERE Citta="' + city + '"'

                print(query)
                cursor.execute(query)

            elif PROVINCE in event['queryStringParameters']:
                
                # Get restaurants in a province
                province = event['queryStringParameters']['province']

                try:
                    dishType = event['queryStringParameters']['dishType']
                    try:
                        specialMenu = event['queryStringParameters']['specialMenu']
                        logger.info("Parameters province=" + province + " and dishType=" + dishType + " and specialMenu" + specialMenu)

                        query = 'SELECT * FROM falesiedb.Ristoranti r join falesiedb.TipologieCucina tc on r.TipoCucina=tc.TipoCucina ' \
                                'WHERE Provincia="' + province + '" AND Principale="' + dishType + '" AND MenuAParte="' + specialMenu + '"'
                    except KeyError:
                        logger.info("Parameters province=" + province + " and dishType=" + dishType)
                        query = 'SELECT * FROM falesiedb.Ristoranti r join falesiedb.TipologieCucina tc on r.TipoCucina=tc.TipoCucina ' \
                                'WHERE Provincia="' + province + '" AND Principale="' + dishType + '"'

                except KeyError:
                    logger.info("Parameter province=" + province)
                    query = 'SELECT * FROM falesiedb.Ristoranti WHERE Provincia="' + province + '"'

                print(query)
                cursor.execute(query)

            elif REGION in event['queryStringParameters']:
                
                # Get restaurants in a region
                region = event['queryStringParameters']['region']

                try:
                    dishType = event['queryStringParameters']['dishType']
                    try:
                        specialMenu = event['queryStringParameters']['specialMenu']
                        logger.info("Parameters region=" + region + " and dishType=" + dishType + " and specialMenu" + specialMenu)

                        query = 'SELECT * FROM falesiedb.Ristoranti r join falesiedb.TipologieCucina tc on r.TipoCucina=tc.TipoCucina ' \
                                'WHERE Regione="' + region + '" AND Principale="' + dishType + '" AND MenuAParte="' + specialMenu + '"'
                    except KeyError:
                        logger.info("Parameters region=" + region + " and dishType=" + dishType)
                        query = 'SELECT * FROM falesiedb.Ristoranti r join falesiedb.TipologieCucina tc on r.TipoCucina=tc.TipoCucina' \
                                ' WHERE Regione="' + region + '" AND Principale="' + dishType + '"'

                except KeyError:
                    logger.info("Parameter region=" + region)
                    query = 'SELECT * FROM falesiedb.Ristoranti WHERE Regione="' + region + '"'

                print(query)
                cursor.execute(query)

            elif DISHTYPE in event['queryStringParameters']:
                
                # Get restaurants with a specific dish type
                dishType = event['queryStringParameters']['dishType']

                logger.info("Parameter dishType=" + dishType)

                query = 'SELECT * FROM falesiedb.Ristoranti WHERE Principale=%s'
                cursor.execute(query, (dishType,))

            elif SPECIALMENU in event['queryStringParameters']:
                
                # Get restaurants with a special menu
                specialMenu = event['queryStringParameters']['specialMenu']

                logger.info("Parameter specialMenu=" + specialMenu)

                query = 'SELECT * FROM falesiedb.Ristoranti WHERE MenuAParte=%s'
                cursor.execute(query, (specialMenu,))

            else:
                logger.error("ERROR! Wrong query parameters")
                sys.exit()

        else:
            # Get all restaurants
            logger.info("No parameters! Fetching all the db...")
            cursor.execute('SELECT * FROM falesiedb.Ristoranti')

        result = cursor.fetchall()
        logger.info(result)
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
        specialMenu = decodedBody['specialMenu']
        URL = decodedBody["URL"]

        print(decodedBody)

        randomNumber = random.randint(10, 9999999)

        restaurantId = str(randomNumber + 1)
        imageFKId = str(randomNumber + 2)
        imageId = str(randomNumber + 3)
        tipoCucinaFKId = str(randomNumber + 4)
        tipoCucinaId = str(randomNumber + 5)

        try:
            tertiaryDishType = decodedBody['tertiaryDishType']

            try:
                secondaryDishType = decodedBody['secondaryDishType']

                try:
                    primaryDishType = decodedBody['primaryDishType']
                    logger.info("All tertiaryDishType, secondaryDishType and primaryDishType found")

                    query = "INSERT INTO `falesiedb`.`Immagini`(`ID`, `ImageId`) VALUES ('" + imageId + "', '" + imageFKId + "'); " \
                            "INSERT INTO `falesiedb`.`TipologieCucina`(`ID`, `TipoCucina` , `Principale`, `Secondaria`, `Terziaria`) VALUES ('" + tipoCucinaId + "','" + tipoCucinaFKId + "','" + primaryDishType + "','" + secondaryDishType + "','" + tertiaryDishType + "'); " \
                            "INSERT INTO `falesiedb`.`Ristoranti` (`ID`, `Nome`, `Indirizzo`, `Citta`, `Provincia`, `Regione`, `Latitudine`, `Longitudine`, `TipoCucina`, `MenuAParte`, `ImageId`, `URL`) VALUES ('" + \
                            restaurantId + "', '" + name + "', '" + address + "', '" + city + "', '" + province + "', '" + region + "', '" + latitude + "', '" + longitude + "', '" + tipoCucinaFKId + "', '" + specialMenu + "', '" + imageFKId + URL + "');"
                except KeyError:
                    raise KeyError
            except KeyError:
                raise KeyError

        except KeyError:
            try:
                secondaryDishType = decodedBody['secondaryDishType']

                try:
                    primaryDishType = decodedBody['primaryDishType']
                    logger.info("Both secondaryDishType and primaryDishType found")

                    query = "INSERT INTO `falesiedb`.`Immagini`(`ID`, `ImageId`) VALUES ('" + imageId + "', '" + imageFKId + "'); " \
                            "INSERT INTO `falesiedb`.`TipologieCucina`(`ID`, `TipoCucina` , `Principale`, `Secondaria`) VALUES ('" + tipoCucinaId + "','" + tipoCucinaFKId + "','" + primaryDishType + "','" + secondaryDishType + "'); " \
                            "INSERT INTO `falesiedb`.`Ristoranti` (`ID`, `Nome`, `Indirizzo`, `Citta`, `Provincia`, `Regione`, `Latitudine`, `Longitudine`, `TipoCucina`, `MenuAParte`, `ImageId`, `URL`) VALUES ('" + \
                            restaurantId + "', '" + name + "', '" + address + "', '" + city + "', '" + province + "', '" + region + "', '" + latitude + "', '" + longitude + "', '" + tipoCucinaFKId + "', '" + specialMenu + "', '" + imageFKId + URL + "');"
                except KeyError:
                    raise KeyError

            except KeyError:
                try:
                    primaryDishType = decodedBody['primaryDishType']
                    logger.info("Only primaryDishType found")

                    query = "INSERT INTO `falesiedb`.`Immagini`(`ID`, `ImageId`) VALUES ('" + imageId + "', '" + imageFKId + "'); " \
                            "INSERT INTO `falesiedb`.`TipologieCucina`(`ID`, `TipoCucina` , `Principale`) VALUES ('" + tipoCucinaId + "', '" + tipoCucinaFKId + "' ,'" + primaryDishType + "'); " \
                            "INSERT INTO `falesiedb`.`Ristoranti` (`ID`, `Nome`, `Indirizzo`, `Citta`, `Provincia`, `Regione`, `Latitudine`, `Longitudine`, `TipoCucina`, `MenuAParte`, `ImageId`, `URL`) VALUES ('" + \
                            restaurantId + "', '" + name + "', '" + address + "', '" + city + "', '" + province + "', '" + region + "', '" + latitude + "', '" + longitude + "', '" + tipoCucinaFKId + "', '" + specialMenu + "', '" + imageFKId + URL + "');"
                except KeyError:
                    logger.info("No dishType inserted!")

        print(query)
        cursor = connection.cursor()
        cursor.execute(query)
        connection.commit()

        response = {
            "restaurantId": restaurantId,
            "imageId": imageId,
            "tipoCucinaId": tipoCucinaId
        }

        return {
            "statusCode": 200,
            "headers": {"Content-Type": "application/json"},
            "body": json.dumps(response)
        }

    # /deleteRestaurant
    elif event['rawPath'] == DELETE_RAW_PATH:
        print("Starting request for deleteRestaurant...")

        # Get restaurant with specific ID
        restaurantId = event['queryStringParameters']['restaurantId']
        logger.info("Parameter restaurantId=" + restaurantId)

        cursor = connection.cursor()
        cursor.execute('SELECT * FROM falesiedb.Ristoranti WHERE ID=' + restaurantId)
        result = cursor.fetchall()

        logger.info(result)

        resultList = result[0]

        imageId = resultList[8]
        dishTypeId = resultList[10]

        logger.info("ImageId:" + str(imageId))
        logger.info("TipoCucina:" + str(dishTypeId))

        query = ("DELETE FROM falesiedb.Ristoranti WHERE ID=" + str(restaurantId) + "; DELETE FROM falesiedb.Immagini WHERE ImageId=" + 
            str(imageId) + "; DELETE FROM falesiedb.TipologieCucina WHERE TipoCucina=" + str(dishTypeId))

        cursor.execute(query)
        connection.commit()
        
        response = {
            "Deleted restaurantId": restaurantId,
            "Deleted imageId": imageId,
            "Deleted tipoCucinaId": dishTypeId
        }

        return {
            'statusCode': 200,
            "body": json.dumps(response)
        }

    else:
        return
