# Kata 4 – Search Functionality

Implement a city search functionality. The function takes a string (search text) as input and returns the found cities which correspond to the search text.

## Prerequisites

Create a collection of strings that will act as a database for the city names.

**City names:** Paris, Budapest, Skopje, Rotterdam, Valencia, Vancouver, Amsterdam, Vienna, Sydney, New York City, London, Bangkok, Hong Kong, Dubai, Rome, Istanbul

## Requirements

### 1. Minimum Search Length
If the search text is fewer than 2 characters, then should return no results. (It is an optimization feature of the search functionality.)

### 2. Exact Prefix Match
If the search text is equal to or more than 2 characters, then it should return all the city names starting with the exact search text.

**Example:** For search text "Va", the function should return Valencia and Vancouver

### 3. Case Insensitive
The search functionality should be case insensitive.

### 4. Partial Match
The search functionality should work also when the search text is just a part of a city name.

**Example:** "ape" should return "Budapest" city

### 5. Wildcard Search
If the search text is a "*" (asterisk), then it should return all the city names.