# GlutenFreeApp

Carefully selected gluten free restaurants in Italy ready to be explored 🍔🥗

## UI

![Map page](/resources/page-map.jpg)
![Restaurants page](/resources/page-restaurants.jpg)
![Regions page](/resources/page-regions.jpg)
![Restaurant detail page](/resources/page-restaurantdetail.jpg)

## Platforms
* iOS 8+
* Android 5+ (Target: 11+)

## Features
* Interactive map with pins
* Navigable list divided by regions and provinces
* Nation-wide search
* Light/Dark mode with "System" option

## Technical Implementations
* [Login](https://github.com/drew458/GlutenFreeApp/tree/main/GlutenFreeApp/GlutenFreeApp.LambdaLogin) with client side encryption and (30 days) session expiration 
* Restaurants data [pulled](https://github.com/drew458/GlutenFreeApp/tree/main/GlutenFreeApp/RDSQuery) from remote database, accessed via HTTP APIs with a serveless function
* Local database caching (SQLlite)
* MVVM
* Shell navigation
* Localization
  * Italian
  * English
  * Spanish
* Key-Value store in native Preferences storage 

## Backend Architecture
![Backend Architecture](/resources/GlutenFreeApp-arch.jpg)

## Login/Registration Flow
![Backend Architecture](/resources/GlutenFreeApp-loginFlow.jpg)
