# Simple-Events-Manager

Simple Events Manager is a lightweight application that provides a RESTful backend service for managing events along with a web application for creating and listing events. The backend is designed to handle event creation, storage, and retrieval, while the frontend web application offers an interface for users to interact with the events.
  
## Activity time control
| Task | Time spent  |
|--|--|
| Analysis and planning | 20 Min. |
| Review of documentation on components and technologies to be used. | 40 min. |
| Coding and testing of the created service. | 90 min. |
| Coding and testing of user interface app. | - |
| Documentation (including this) | 40 min. |
|--|--|
| Total | 180 Min. (3h) |


## Backend - RESTful Service:

**Features**
* Create new events.
* Retrieve events.

**Technologies Used**
*  .NET Core
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
* *TODO*

## How to use
1.  **Clone the Repository:**       
    `git clone https://github.com/Turing-IA-IHC/Simple-Events-Manager.git` 
    
2.  **Backend run:**    
    -   Navigate to: 
    `backend/Simple-Events-Manager/Simple-Events-Manager`  
        
    -   Run the backend service:
    `dotnet run`

3.  **Backend simple test:**
	- Open this url in web browser:
	`http://localhost:5321/api/event`
	- (Optional) Open this file in Postman application for full service test
    `backend/Postman_Tests/EventTests.postman_collection.json`  
    - (Optional) If you want a clean database, stop the service from running, delete the following file and run again (Don't worry, the application will create a new database).
   `Backend/NetService_EventsManager/NetService_EventsManager/Data/events.db`  

4.  **Frontend run:**


5.   **Frontend simple test:**
	- In a web browser open:
	`frontend/EvenManager/index.html`


## Code revision
To carry out the code review there are 2 main projects that must be opened:
	- REST API code:
	`Backend/NetService_EventsManager/NetService_EventsManager.sln`
	- User interface code:
	`Frontend/....sln`


# Thanks!
*This project is shared with the world and anyone who wants to use it, freely.*
<span>&#129505;</span> Made with love by **Gavit0** <span>&#129505;</span>
