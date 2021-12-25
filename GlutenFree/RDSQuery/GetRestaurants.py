import json


def getAllRestaurants(cursor, logger):
    cursor.execute('SELECT * FROM falesiedb.Ristoranti')
    result = cursor.fetchall()

    return {
        'statusCode': 200,
        "headers": {"Content-Type": "application/json"},
        'body': json.dumps(result)
    }


def getRestaurantWithId(event, cursor, logger):
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


def getRestaurantWithCity(event, cursor, logger):
    city = event['queryStringParameters']['city']

    try:
        dishType = event['queryStringParameters']['dishType']
        logger.info("Parameters city=" + city + "and dishType=" + dishType)
        
        try:
            specialMenu = event['queryStringParameters']['specialMenu']
            logger.info("Parameters city=" + city + "and dishType=" + dishType + "and specialMenu" + specialMenu)

            query = 'SELECT * FROM falesiedb.Ristoranti WHERE Citta="' + city + '" AND TipoCucina="' + dishType + \
                    '" AND MenuAParte="' + specialMenu + '"'
        except KeyError:
            query = 'SELECT * FROM falesiedb.Ristoranti WHERE Citta="' + city + '" AND TipoCucina="' + dishType + '"'

    except KeyError:
        logger.info("Parameter city=" + city)

        query = 'SELECT * FROM falesiedb.Ristoranti WHERE Citta="' + city + '"'

    cursor.execute(query)
    result = cursor.fetchall()

    logger.info(result)

    return {
        'statusCode': 200,
        "headers": {"Content-Type": "application/json"},
        'body': json.dumps(result)
    }


def getRestaurantWithProvince(event, cursor, logger):
    province = event['queryStringParameters']['province']

    logger.info("Parameter province=" + province)

    query = 'SELECT * FROM falesiedb.Ristoranti WHERE Provincia=%s'
    cursor.execute(query, (province,))
    result = cursor.fetchall()

    return {
        'statusCode': 200,
        "headers": {"Content-Type": "application/json"},
        'body': json.dumps(result)
    }


def getRestaurantWithRegion(event, cursor, logger):
    region = event['queryStringParameters']['region']

    logger.info("Parameter region=" + region)

    query = 'SELECT * FROM falesiedb.Ristoranti WHERE Regione=%s'
    cursor.execute(query, (region,))
    result = cursor.fetchall()

    return {
        'statusCode': 200,
        "headers": {"Content-Type": "application/json"},
        'body': json.dumps(result)
    }


def getRestaurantWithDishType(event, cursor, logger):
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


def getRestaurantWithSpecialMenu(event, cursor, logger):
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
