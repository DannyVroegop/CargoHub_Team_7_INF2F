import os
import requests


def v2_Post_Handler(data, path):
    url = "http://127.0.0.1:3000/api/v2/" + path
    print(url)
    object = data
    print("BBBBBBBBBBBBBBBBBBBBBBBBBB")
    x = requests.post(url, json = object)
    print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")
    response = x.status_code()
    try:
        print(response)
    except:
        print("Noresponse")
    if response:
        print("Respons van API v2:", response.status_code, response.json())
    else:
        print("Geen respons ontvangen van API v2.")
    return None