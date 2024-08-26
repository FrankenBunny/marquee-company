# Marquee Rental Service Web Application

Web application for a marquee rental service company.  Developed for internal use to streamline operations for company workers within different departments and workflows.

## Implementation

The implementation of the application has been separated into two main headings, development and deployment.

### Development

|Layer|Technologies|Dependencies|
|---|---|---|
|Frontend|React, Vite |Tailwind, ShadCN|
|Backend|ASP.NET Core|Entity Framework, Swagger|
|Database|Microsoft SQL Server, Docker||

#### Hosting the Backend
From container -> [http://localhost:8090/swagger](http://localhost:8090/swagger) <br/>
From IDE -> [http://localhost:5019/swagger/index.html](http://localhost:5019/swagger/index.html)


### Deployment

The web application is hosted by Vercel and is accessible [here](https://marquee-company.vercel.app).

## Features

The system includes a variety of features designed to streamline operations for company workers. Each feature corresponds to a department or major workflow within the company and consists of multiple sub-features, referred to as functionalities. These functionalities are tailored to support specific tasks within the broader feature. Each listed feature is detailed in their respective sections below. Features currently being implemented or already implemented include:

- [ ] Authentication and Authorization (AA)
- [ ] Inventory Management System (IMS)

### Authenication and Authorization

The Authentication and Authorization features enables the use of role-based authentication and claim-based authentication to restrict access to certain features and resources. The following features entail details on how authorization has been utilized specificallty in the respective feature. The roles have been developed using *the principle of least prielege*. The table below lists the currently available roles, the respective feature they relate to, and a description of the permission given to each role.

|Role|Feature|Description|
|---|---|---|
|Admin|Global|Posseses all permissions within the system, including administrative and configuration capabilites.|
|Role Manager|AA|Posseses permissions to manage roles, including adding and removing roles, as well as managing permissions given to roles.|
|User Manager|AA|Posseses permissions to manage users and their roles, including adding, removing, and updating users, whilst also managing users' roles.|
|Inventory Manager|IMS|Posseses all permissions given within the inventory management system. Including adding, editing, deleting inventory items, and modyfying the list of items.|
|Inventory Worker|IMS|Posseses the minimal required permissions to perform daily inventory tasks, such as updating stock levels and recording transactions.|
|Inventory Viewer|IMS| Posseses read-only permissions, allowing them to view inventory data without making any changes.|

<!--- FOR REMEMBRANCE
> [!NOTE]
> Useful information that users should know, even when skimming content. 
-->

#### AA Functionalities

|Name|Purpose|Description|
|---|---|---|
|Login|Allows for the authentication of users.|The user is required to log in when accessing the internal pages.|
|Authorized routing|Restricts access to certain functionalities by restricting page access to certain roles and claims.|The user is required to posses the correct permissions to access restricted pages.|
|Tokens|Provides secure token-based authentication and authorization.|JWT (JSON Web Tokens) are used to securely transmit information between parties and verify user identities and permissions.|
|Role Dashboard|Allows the user to modify the roles within the system.|The user may add, update, and remove roles. The user may also modify a roles' permissions by modifying its claims.|
|User Dashboard|Allows the user to access the user within the system.|The user may add, update, and remove users within the system. The user may also modify a user's permissions either by modifying their roles or claims.|

#### AA Database Diagram

The database diagram relating to authentication and authorization within the application is shown below.
![Authentication and Authorization database diagram](documentation-images/aa-diagram.png)

### Inventory management system

The inventory management system helps workers to efficiently track and update inventory. It allows the users to update the item quantity in stock, rented out, and marked faulty for each item available in the system. Additionally, the system supports role-based access control, enabling certain users to edit the inventory items themselves based on their assigned role. The system uses general-purpose objects to accommodate a wide range of items that may be stored in the inventory, ensuring flexibility and scalability.

#### Inventory Database Diagram

![Inventory database diagram](documentation-images/inventory-diagram.png)
|Table|Purpose|Real-world example|
|---|---|---|
|Rentable|Items that are available for rental.|A 5x5 tent.|
|Part|Distinct parts that make up a rentable.|Roof, wall, steel beam.|
|Item|Common parts used in multiple a rentable.|Nails, bolts.|
|RentableCategory|A category of rentables.|Tents, decor.|
|RentableTag|A tag for rentables.|New, dirty, faulty.|

#### Inventory Functionalities

|Name|Purpose|Description|
|---|---|---|
|Inventory List|Allows users to CRUD the items within list which the inventory is based off of.|A user may add a new tent model to keep inventory of.|
|Inventory Items|Allows users to adjust the quantity of items in stock and rented out.|A user may adjust the number of tents in stock.|
|Inventory Categories|Allows the users to CRUD categories which are used to categorize items within the inventory.|A user may categorize an item as a tent.|
|Inventory Tags|Allows the users to CRUD tags which are used to tag items as for example "dirty", "broken", etc.|A user may tag an item as dirty.|

#### Authorization within Inventory subsystem

The roles associated with the inventory management system have been listed and described in the table below. The roles are listed so that the ones in the top of the table have the most permissions.

|Role|Description|
|---|---|
|Inventory Manager|Has full control over the inventory system, including the ability to add, edit, and remove items, and update item quantities (in stock, rented out, faulty), types, and tags.|
|Inventory Worker|Responsible for the day-to-day management of inventory. They can update the status of items (in stock, rented out, faulty), record transactions, and report discrepancies using the existing tags.|
|Inventory Viewer|Has read-only access to the inventory system. They can view items, quantities, and associated tags but cannot make any changes to the inventory data. This role is suitable for users who need to monitor inventory levels and statuses without directly interacting with or modifying the data.|

## Booking management system

The rentable items are constructed using the items in the inventory system, the items may also be created in variants.

## Potential future features

- [ ] Booking management system
