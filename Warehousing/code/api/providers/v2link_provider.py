import os
import requests


def v2_Post_Handler(data, path):
    try:
        url = "http://127.0.0.1:3000/api/v2/" + path
        object = data
        x = requests.post(url, json = object)
        response = x.status_code
        if response == 201:
            print("Response van API v2:", response)
        else:
            print("Geen respons ontvangen van API v2.")
    except:
        print("v2 problems")
    return None

def v2_Put_Handler(data, path, id):
    try:
        url = "http://127.0.0.1:3000/api/v2/" + path + "/" + id
        object = data
        x = requests.put(url, json = object)
        response = x.status_code
        if response == 201:
            print("API v2 Response:", response)
        else:
            print("No/Bad response of API v2.")
    except:
        print("v2 problems")
    return None

def v2_Put_Handler(data, path, id):
    try:
        url = "http://127.0.0.1:3000/api/v2/" + path + "/" + id
        object = data
        x = requests.put(url, json = object)
        response = x.status_code
        if response == 200:
            print("API v2 Response:", response)
        else:
            print("No/Bad response of API v2.")
    except:
        print("v2 problems")
    return None

def v2_Delete_Handler(path, id):
    try:
        url = "http://127.0.0.1:3000/api/v2/" + path + "/" + id
        x = requests.put(url)
        response = x.status_code
        if response == 201:
            print("API v2 Response:", response)
        else:
            print("No/Bad response of API v2.")
    except:
        print("v2 problems")
    return None