# Marquee Rental Service Web Application

Web application for a marquee rental service company.  Developed for internal use to streamline operations for company workers within different departments.

## Features

The system includes a variety of features designed to streamline operations for company workers. Each listed feature is detailed in their respective section below. Features currently being implemented or already implemented include:

- [ ] Authentication and Authorization
- [ ] Inventory management system

### Authenication and Authorization

The Authentication and Authorization features enables the use of role-based authentication and claim-based authentication to restrict access to certain features and resources. The following features entail details on how authorization has been utilized specificallty in the respective feature. The roles have been developed using *the principle of least prielege*. The roles currently offered by the system are:

|Role|Feature|Description|
|---|---|---|
|Admin|Global|Posseses all permissions within the system, including administrative and configuration capabilites|
|Inventory Manager|Inventory Management System|Posseses all permissions given within the inventory management system. Including adding, editing, deleting inventory items, and modyfying the list of items.|
|Inventory Worker|Inventory Management System|Posseses the minimal required permissions to perform daily inventory tasks, such as updating stock levels and recording transactions.|
|Inventory Viewer|Inventory Management System| Posseses read-only permissions, allowing them to view inventory data without making any changes.|

[!NOTE]
Useful information that users should know, even when skimming content.

#### Functionalities

- [ ] Login functionaliy
- [ ] Authorized routing

### Inventory management system

The inventory management system helps workers track and update the inventory. The system allows the users to update the number of items in stock, rented out, and faulty for each item available in the system. Specific users may also edit the list of items themselves, determined by their role.

#### Authorization

|Role|Feature|Description|
|---|---|---|


## Potential future features

- [ ] Booking management system
