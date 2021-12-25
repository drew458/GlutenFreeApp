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
        try:
            specialMenu = event['queryStringParameters']['specialMenu']
            logger.info("Parameters city=" + city + " and dishType=" + dishType + " and specialMenu" + specialMenu)

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


def getRestaurantWithProvince(event, cursor, logger):
    province = event['queryStringParameters']['province']

    try:
        dishType = event['queryStringParameters']['dishType']
        try:
            specialMenu = event['queryStringParameters']['specialMenu']
            logger.info("Parameters province=" + province + " and dishType=" + dishType + " and specialMenu" + specialMenu)

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


def getRestaurantWithRegion(event, cursor, logger):
    region = event['queryStringParameters']['region']

    try:
        dishType = event['queryStringParameters']['dishType']
        try:
            specialMenu = event['queryStringParameters']['specialMenu']
            logger.info("Parameters region=" + region + " and dishType=" + dishType + " and specialMenu" + specialMenu)

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
