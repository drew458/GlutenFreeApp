def deleteRestaurant(event, connection, logger):
    restaurantId = event['queryStringParameters']['restaurantId']

    logger.info("Parameter restaurantId=" + restaurantId)

    query = ('DELETE FROM falesiedb.Ristoranti WHERE ID=' + restaurantId)

    cursor = connection.cursor()
    cursor.execute(query)
    connection.commit()

    return {
        'statusCode': 200,
    }
