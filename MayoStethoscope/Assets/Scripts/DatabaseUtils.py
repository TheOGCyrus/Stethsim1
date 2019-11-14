from xml.dom import minidom
import xml.etree.ElementTree as DOM


def Start():
    return

def Save():
    root = DOM.Element('UserProfiles')
    user1 = DOM.SubElement(root, 'User')
    user1.set('Username', 'Matt')
    user1.set('Password', '123')
    user2 = DOM.SubElement(root, 'User')
    user2.set('Username', 'Mick')
    user2.set('Password', '000')
    data = DOM.tostring(root).decode()
    print(data)
    file = open("database.xml", "w")
    file.write(data)
    return

def Load():
    return

Save()
