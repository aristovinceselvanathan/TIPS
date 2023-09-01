# Practice Exercise
Understand the application requirements: Basic Contact Manager Console Application. Create a simple console-based contact manager application that allows users to store and manage their contacts. The application should have the following requirements:
1. Contact Information: <br>
  i) The application should allow users to enter contact information, including name, phone number, email address, and any additional notes.
2. Contact List:<br>
  i) The application should maintain an in-memory list of contacts, allowing users to view, add, edit, and delete contacts.<br>
ii) The contact list should display the name of each contact for easy identification.
3. Search Functionality:<br>
  i) Users should be able to search for contacts based on their names or other relevant details.<br>
  ii) The search functionality should display the matching contacts or indicate if no results were found.
4. User Interface:<br>
  i) The application should provide a console-based user interface to interact with the contact manager.<br>
  ii) Use appropriate console input and output methods to display and manipulate contact information.<br>
  iii) Consider using a menu system to allow users to access different functionalities.
5. Error Handling:<br>
  i) Implement proper error-handling mechanisms to prevent crashes and handle exceptions gracefully.<br>
  ii) Try to learn the basis of try-catch statements in C#. Later during the TIPS journey, you will learn error handling in detail.<br>
  iii) Display meaningful error messages to users in case of input validation failures or unexpected errors.
6. Data Persistence:<br>
  i) As the application is based on in-memory storage, the contact data will be lost
when the application is closed or restarted.
 ii) Data persistence beyond the application's runtime is not required for this
version.
7. User Experience:<br>
  i) Ensure that the application provides a smooth and intuitive user experience within the console environment.
  ii) Implement features like sorting contacts, displaying contact details, or providing keyboard shortcuts for common actions.

# Documentation Report
## Overview
The Basic Contact Manager Console Application is a simple console-based application that allows users to manage their contacts. Users can enter, view, edit, delete, and search for contacts using a text-based interface. The application maintains an in-memory list of contacts for the current session.

## Requirements

1. **Contact Information**
   - Users can input contact information, including name, phone number, email address, and additional notes.

2. **Contact List**
   - The application manages an in-memory list of contacts.
   - Users can perform the following actions on the contact list:
     - View all contacts with their names displayed.
     - Add a new contact.
     - Edit an existing contact's details.
     - Search through the directory for a contact.
     - Delete a contact from the list.

3. **Search Functionality**
   - Users can search for contacts based on names or other relevant details.
   - Search results are displayed, or a message indicates if no matching contacts are found.

4. **User Interface**
   - The application offers a console-based user interface.
   - Input and output are managed using appropriate console methods.
   - A menu system provides access to various functionalities.

5. **Error Handling**
   - The application employs proper error-handling mechanisms.
   - Exceptions are caught using try-catch statements.
   - Meaningful error messages are shown to users for input validation failures and unexpected errors.

6. **Data Persistence**
   - Contact data is stored in-memory and is lost upon application closure or restart.
   - Data persistence beyond the application's runtime is not required.

7. **User Experience**
   - The application strives for a smooth and intuitive user experience within the console environment.
   - Additional features like contact sorting, detailed contact viewing, and keyboard shortcuts enhance the user experience.

## Description about the methods in Program Class:
1. **Main Method**
   - The main method asks for the operations to be performed like add, remove, search, show all the contacts manager
   -it will call corresponding method for the actions by the passing the required parameters.
2. **Add**
   - It will run the certain conditions like evaluate the person is valid to add the person into the list.
   - It creates the object for each person that are added.
3. **Edit**
   - It Prompts the user to enter what details want to edit.
   - it sets corresponding values by the public methods that are present in the Person class.
4.  **Search**
   - It prints directory is empty when the no contacts are stored.
   - It Search by Name, Email, Phone number to select the required contact.
5. **Display all**
   - It prints all the entries in the contacts directory.
## Description about the methods in the Person Class:
1. **Get Details**
   - It returns the string of the details of the person.
2. **Get name**
   - It returns the name of the person.
3. **Get Email**   
   - It returns the email of the person.
4. **Get Phone**   
   - It returns the phone number of the person.
5. **Set Name**
   - It sets the name of the person.
6. **Set Email**  
   - It uses the regex to match the email is valid or not.
   - Once the email is valid it sets the email of the person.
7. **Set Phone** 
   - It uses the regex to match the phone number is valid or not.
   - Once the phone number is valid it sets the phone number of the person.
8. **Set Notes** 
   - It sets the notes of the person.
9. **Equals**
   - It overrides the Equals method in the object class.
   - It checks the equality of the two objects.
## Usage

1. **Main Menu**
   - Users are presented with a main menu upon launching the application.
   - Options include:
     - View all contacts.
     - Add a new contact.
     - Edit an existing contact.
     - Delete a contact.
     - Search for contacts.
     - Exit the application.

2. **Viewing Contacts**
   - Users can choose to view all stored contacts, which displays their names.

3. **Adding a New Contact**
   - Users input contact details, including name, phone number, email, and notes.
   - The new contact is added to the in-memory list.

4. **Editing a Contact**
   - Users select a contact to edit and update its information.

5. **Deleting a Contact**
   - Users choose a contact to delete from the list.

6. **Searching for Contacts**
   - Users can search for contacts using name or details.
   - Matching contacts are displayed, or a message indicates no results.

## Implementation Considerations

- The application is written in C# and utilizes console input and output methods.
- A menu-driven approach guides users through different functionalities.
- Enhance user experience, consider implementing features like sorting contacts and providing shortcuts for common actions.
- The Search the directory by the different means such as Name, Phone, Email.

### By Aristo Vince S
