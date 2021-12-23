import DeleteRestaurants
import GetRestaurants
import PostRestaurants
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

RESTAURANT_ID = "restaurantId"
NAME = "name"
CITY = "city"
PROVINCE = "province"
REGION = "region"
LATITUDE = "latitude"
LONGITUDE = "longitude"
DISHTYPE = "dishType"

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
                return GetRestaurants.getRestaurantWithId(event, cursor, logger)
            elif CITY in event['queryStringParameters']:
                # Get restaurants in a city
                return GetRestaurants.getRestaurantWithCity(event, cursor, logger)
            elif PROVINCE in event['queryStringParameters']:
                # Get restaurants in a province
                return GetRestaurants.getRestaurantWithProvince(event, cursor, logger)
            elif REGION in event['queryStringParameters']:
                # Get restaurants in a region
                return GetRestaurants.getRestaurantWithRegion(event, cursor, logger)
            elif DISHTYPE in event['queryStringParameters']:
                # Get restaurants with a specific dish type
                return GetRestaurants.getRestaurantWithDishType(event, cursor, logger)
            else:
                logger.error("ERROR! Wrong query parameters")
                sys.exit()

        except KeyError:
            # Get all restaurants
            logger.info("No parameters! Fetching all the db...")
            return GetRestaurants.getAllRestaurants(cursor, logger)

    # /createRestaurant
    elif event['rawPath'] == POST_RAW_PATH:
        print("Starting request for createRestaurant...")

        return PostRestaurants.postRestaurant(event, connection, logger)

    # /createRestaurant
    elif event['rawPath'] == DELETE_RAW_PATH:
        print("Starting request for deleteRestaurant...")

        cursor = connection.cursor()

        return DeleteRestaurants.deleteRestaurant(event, connection, logger)

    else:
        return
