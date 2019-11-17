import xml.etree.ElementTree as DOM
database = ''

def Start(username, password, action=""):

    if database:
        populate_database()

    if "L" in action:
        return Login(username, password)
    elif "C" in action:
        return Create(username, password)
    elif "F" in action:
        return Forgot(username)

def Login(username, password):
    if username in database.keys():
        if password == database[password]:
            return "True"
    return "False"

def Create(username, password):
    if username not in database.keys():
        file = open("database.txt", "a")
        file.write(username + " " + password)
        file.close()
        return "True"
    return "The username already exists."

def Forgot(username):
    return

def populate_database():
    global database
    database = DOM.parse('database.xml')
    root = database.getroot()
    return root

    with open("database.txt") as file:
        for line in file:
            (key, val) = line.split()
            database[int(key)] = val
