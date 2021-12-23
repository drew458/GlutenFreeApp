import json


def getAllRestaurants(cursor, logger):
    cursor.execute('SELECT * FROM falesiedb.Ristoranti')
    result = cursor.fetchall()

    item_count = 0
    for row in cursor:
        item_count += 1
        logger.info(row)

    return {
        'statusCode': 200,
        'body': json.dumps(result)
    }


def getRestaurantWithId(event, cursor, logger):
    restaurantId = event['queryStringParameters']['restaurantId']

    logger.info("Parameter restaurantId=" + restaurantId)
    cursor.execute('SELECT * FROM falesiedb.Ristoranti WHERE ID=' + restaurantId)
    result = cursor.fetchall()

    item_count = 0
    for row in cursor:
        item_count += 1
        logger.info(row)

    return {
        'statusCode': 200,
        'restaurantId': restaurantId,
        'body': json.dumps(result)
    }
