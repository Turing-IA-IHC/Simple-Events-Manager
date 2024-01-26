
# Simple-Events-Manager

Simple Events Manager is a lightweight application that provides a RESTful backend service for managing events along with a web application for creating and listing events. The backend is designed to handle event creation, storage, and retrieval, while the frontend web application offers an interface for users to interact with the events.

![Application Overview.](/Docs/Architecture.png)

## Activity time control

| Task | Time spent |
|--|--|
| Analysis and planning | 20 Min. |
| Review of documentation on components and technologies to be used. | 60 min. |
| Coding and testing of the created service. | 90 min. |
| Coding and testing of user interface app. | 160 |
| Documentation (including this) | 60 min. |
|--|--|
| Total | 390 Min. (6h30) |

## Backend - RESTful Service:
  
**Features**
* Create new events.
* Retrieve events.  

**Technologies Used**
* .NET Core
* SQLite  

**Aditional packages used:**
*  *GeoTimeZone* for calculate TimeZone from Latitude and Longitude (https://github.com/mattjohnsonpint/GeoTimeZone).
*  *Microsoft.Data.Sqlite* for SQLite database. 

## Frontend - Web Application:
**Features**
* User interface for creating events.
* List existing events.
* Seamless integration with the backend service. 

**Technologies Used**
* .NET Core

**Aditional packages used:**
  *  *Newtonsoft.Json* for manipulate JSON structures. 


## How to use

1.  **Clone the Repository:**
`git clone https://github.com/Turing-IA-IHC/Simple-Events-Manager.git`

2.  **Backend run:**
	-  **Option 1**
		- In a terminal navigate to:
		`backend/Simple-Events-Manager/Simple-Events-Manager/`

		- Run the backend service:
		`dotnet run`

	-  **Option 2**
		- Open in Visual Studio 2022:
		`backend/Simple-Events-Manager/NetService_EventsManager.sln`
		- Press F5 key

3.  **Backend test:**
	-  **Option 1**
		- Open this url in web browser:
		`http://localhost:5321/swagger/index.html`		

	-  **Option 2**
		- Open this file in Postman application for full service test
		`backend/Postman_Tests/EventTests.postman_collection.json`

	-  ***(Optional)*** If you want a clean database, stop the service from running, delete the following file and run again (Don't worry, the application will create a new database).	`Backend/NetService_EventsManager/NetService_EventsManager/Data/events.db`
	 

4.  **Frontend run:**
	-  **Option 1**
		- In a terminal navigate to:
		`Frontend/NetUI_EventsManager/NetUI_EventsManager/`

		- Run the backend service:
		`dotnet run`

	-  **Option 2**
		- Open in Visual Studio 2022:
		`Frontend/NetUI_EventsManager/NetUI_EventsManager.sln`
		- Press F5 key
   

5.  **Frontend test:**
	- Open this url in web browser:
	`http://localhost:8532/`


## Code revision

To carry out the code review there are 2 main projects that must be opened: 

- REST API code:	
	`Backend/NetService_EventsManager/NetService_EventsManager.sln`
	- Controllers/EventController.cs : Logic to expose get and create methods.
	- Models/Event.cs : Class with structure of an event.
	- Data/Events.db : Database.
	- Data/Db.cs : Code to interact with database.
	
- User interface code:
`Frontend/NetUI_EventsManager/NetUI_EventsManager.sln`
	- Controllers/EventController.cs : Bussiness logic.
	- Models/EventViewModel.cs : Class with structure of an event.
	- Views/Event/ : Folder with UI templates to show data.
  
## Some images
 
  
# Thanks!

*This project is shared with the world and anyone who wants to use it, freely.*

<span>&#129505;</span> Made with love by **Gavit0** <span>&#129505;</span>