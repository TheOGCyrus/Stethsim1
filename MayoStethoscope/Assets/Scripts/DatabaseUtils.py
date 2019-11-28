import xml.dom.minidom
import xml.etree.ElementTree as DOM

database = 'database.xml'

def Start():
    return

def Save(root):
    # root = DOM.Element('UserProfiles')
    # user1 = DOM.SubElement(root, 'User')
    # user1.set('Username', 'Matt')
    # user1.set('Password', '123')
    # user2 = DOM.SubElement(root, 'User')
    # user2.set('Username', 'Mick')
    # user2.set('Password', '000')
    data = DOM.tostring(root).decode()
    if data:
        # print(data)
        file = open("database.xml", "w")
        file.write(data)
        return True
    return False

def Load():
    database = DOM.parse('database.xml')
    return database

def printDB(root):
    data = DOM.tostring(root).decode()
    print(data)

def printprettyDB(root):
    data = xml.dom.minidom.parse('database.xml')  # or xml.dom.minidom.parseString(xml_string)
    pretty_data = data.toprettyxml()
    print(pretty_data)

# Save()
# print(DOM.tostring(Load()).decode())
