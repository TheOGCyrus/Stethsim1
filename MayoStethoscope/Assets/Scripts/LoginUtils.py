#!/Documents/GitHub/Stethsim1/MayoStethoscope/Assets/Resources python

import xml.etree.ElementTree as DOM
import xml.dom.minidom
from sys import argv

import DatabaseUtils
database = None

def Start(username, password, action, dob=""):
    global database
    if not database:
        database = DatabaseUtils.Load()

    if "L" in action:
        return Login(username, password)
    elif "C" in action:
        return Create(username, password, dob)
    elif "F" in action:
        return Forgot(username, dob)

def Login(username, password):
    root = database.getroot()
    if root:
        user_profiles = root.find('UserProfiles')
        if user_profiles is not None:
            user_node = GetUserByUsername(user_profiles, username)
            if user_node is not None:
                if user_node.attrib["Password"] == password:
                    return "True"
    # if username in database.keys():
    #     if password == database[password]:
    #         return "True"
    return "False"

def Create(username, password, dob):
    global database
    root = database.getroot()
    if root:
        user_profiles = root.find('UserProfiles')
        # print(user_profiles)
        user_node = GetUserByUsername(user_profiles, username)
        if user_node is None:
        # if user_node.attrib["Username"] != username:
            # if username doesnt already exist
            user_node = DOM.SubElement(user_profiles, 'User')
            user_node.set("Username", username)
            user_node.set("Password", password)
            user_node.set("DoB", dob)
            if DatabaseUtils.Save(root):
                # print("User successfully created")
                return "True"

    # data = DOM.tostring(root).decode()
    # print(data)
    # file = open("database.xml", "w")
    # file.write(data)

    return "False"


    # if username not in database.keys():
    #     file = open("database.txt", "a")
    #     file.write(username + " " + password)
    #     file.close()
    #     return "True"
    # return "The username already exists."

def Forgot(username, dob):
    root = database.getroot()
    if root:
        user_profiles = root.find('UserProfiles')
        if user_profiles is not None:
            user_node = GetUserByUsername(user_profiles, username)
            if user_node is not None:
                if user_node.attrib["DoB"] == dob:
                    new_password = input()
                    user_node.set("Password", new_password)
                    if DatabaseUtils.Save(root):
                        return "True"
    # if username in database.keys():
    #     if password == database[password]:
    #         return "True"
    return "False"

# def populate_database():
#     global database
#     database = DOM.parse('database.xml')
#     root = database.getroot()
#     # data = DOM.tostring(root).decode()
#     # print(data)
#
#     # data = xml.dom.minidom.parse('database.xml')  # or xml.dom.minidom.parseString(xml_string)
#     # pretty_data = data.toprettyxml()
#     # print(pretty_data)
#
#     DatabaseUtils.printprettyDB(root)
#
#     return root


    # with open("database.txt") as file:
    #     for line in file:
    #         (key, val) = line.split()
    #         database[int(key)] = val

def GetUserByUsername(user_profiles, username):
    for user in user_profiles:
        if user.attrib["Username"] == username:
            return user
    return None

# print(Start("", "", "L", ""))
# Start("Matt", "123", "C", "04/06/1999")
# Start("Mick", "qwe", "C", "01/01/2001")
# Start("Will", "000", "C", "04/06/2001")
# print(Start("Will", "000", "L"))
# print(Start("Matt", "000", "L"))
# print(Start("thisismyname", "thisismypassword", "L"))
# Start("Matt", "", "F", "06/04/1999")

# root = database.getroot()
# DatabaseUtils.printprettyDB(root)



# root = database.getroot()
# print(root)
# for child in root:
#     root.remove(child)
# data = DOM.tostring(root).decode()
# file = open("database.xml", "w")
# file.write(data)
#
# data = DOM.tostring(root).decode()
# print(data)

# print(*argv[1:])

print(Start(*argv[1:]), flush=True)
file = open("output.txt", "w")
data = Start(*argv[1:]) + "\n" + str(argv[1:])
file.write(data)

# root = database.getroot()
# DatabaseUtils.printprettyDB(root)