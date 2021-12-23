import json
import random


def postRestaurant(event, connection, logger):
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
    command = "INSERT INTO `falesiedb`.`Ristoranti` (`ID`, `Nome`, `Indirizzo`, `Citta`, `Provincia`, `Regione`, `Latitudine`, `Longitudine`, `TipoCucina`, `MenuAParte`) VALUES ('" + str(restaurantId) + "', '" + name + "', '" + address + "', '" + city + "', '" + province + "', '" + region + "', '" + latitude + "', '" + longitude + "', '" + dishType + "', '" + specialMenu + "');"
    print(command)

    cursor = connection.cursor()
    cursor.execute(command)
    connection.commit()

    return {
        "statusCode": 200,
    }