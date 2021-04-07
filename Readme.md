**API ASSIGNMENT**

**SOLUTION**

**By: Aakankshu Rawat**

Tools Required:

-   Visual Studio Code

-   SSMS

-   Docker Desktop

Steps

1.  Open Visual Code =\> create a new project =\> Choose "ASP.NET CORE
    WEB API"

2.  A template API will be created known as WeatherForecast API.

3.  The first step to create Student API is to create controller for the
    same within the controller folder using "Add Controller" Option.

![image](https://user-images.githubusercontent.com/47878584/113865050-47937980-97c9-11eb-9211-061951d49a87.png)


The role of the controller will be to provide the route methods and
destinations for CRUD operations along with what needs to be displayed
on each URL.

4.  Now in order to interact with MS SQL SERVER, Entity Framework will
    be used for which certain dependencies need to be installed:
    "Microsoft.EntityFrameworkCore.SqlServer" and
    "Microsoft.EntityFrameworkCore.Tools"

5.  Now, two class model and context will be created to give structure
    to the database.

![image](https://user-images.githubusercontent.com/47878584/113865103-58dc8600-97c9-11eb-9573-3b22fc2658cd.png)


6.  In Student.cs (the model) structure of the database table "Student"
    is defined.

![image](https://user-images.githubusercontent.com/47878584/113865142-61cd5780-97c9-11eb-849e-289d35434d3d.png)


Here, a table with the columns/attributes: StudentID, RollNo, FirstName
and LastName would be created. Annotations are used for the purpose of
validation. StudentID is the primary key to fetch any student. Roll No
and FirstName are required entities with a MaxLength constraint.

7.  In StudentContext.cs class, code is written to create a table in the
    database using Student.cs model class.

![image](https://user-images.githubusercontent.com/47878584/113865171-6c87ec80-97c9-11eb-945a-9a6697f31f2f.png)


Here DbContext is inherited/implemented in StudentContext class using
Entity Framework. The constructor of the class creates options object
for the class which inherits from the base startup file where actual
connection with the database would be made. Then DbSet function is used
to create the Students table within the database.

8.  Now services need to be added to the startup file in order to
    connect to the database.

![image](https://user-images.githubusercontent.com/47878584/113865225-79a4db80-97c9-11eb-9dec-970a37edfdaf.png)


![image](https://user-images.githubusercontent.com/47878584/113865241-80335300-97c9-11eb-8dbb-024e01d73466.png)


Here the connection string is added in appsettings.json file and then
called in startup.cs file within the ConfigureServices section.

9.  Now StudentData folder is created with an interface and a class. The
    interface defines all the functions to be performed with the
    database. Then further, the class inherits the interface and
    consists of the code describing those actions.

![image](https://user-images.githubusercontent.com/47878584/113865279-89bcbb00-97c9-11eb-9643-ba372320fbb0.png)


This is the IStudentData interface which would be implemented by the
SQLStudentData class.

![image](https://user-images.githubusercontent.com/47878584/113865432-b375e200-97c9-11eb-9c6a-427b838e9442.png)


In SQLStudentData class, the IStudentData interface is implemented along
with the core functionalities.

![image](https://user-images.githubusercontent.com/47878584/113865459-bbce1d00-97c9-11eb-8115-0dc3a6fe40e6.png)


Also, add "Addscoped" parameter in startup file so that the API is aware
that SQLStudentData is implemented by IStudentData interface.

10. Now, the controller class is coded in order to route and respond to
    the requests with the help of the model and the SQLStudentData
    class.

![image](https://user-images.githubusercontent.com/47878584/113865496-c7214880-97c9-11eb-8842-c32e9762d107.png)


As can be seen, the controller routes each function and defines the http
method associated with function. It is also responsible for what to
respond with on the screen/console.

11. Now using Package Manager Console, Add-Migration and Update-Database
    so that the database and table within is created in the local
    machine MSSQL server.

![image](https://user-images.githubusercontent.com/47878584/113865534-d1434700-97c9-11eb-8f67-c95b1ce428b9.png)


12. On running the API on IIS Server, an empty list is returned as no
    data is added to the table.

![image](https://user-images.githubusercontent.com/47878584/113865563-daccaf00-97c9-11eb-886a-5677465eef6e.png)


13. We'll try out all the CRUD operations using POSTMAN.

ADD:

![image](https://user-images.githubusercontent.com/47878584/113865602-e61fda80-97c9-11eb-99be-6c5efcdab488.png)


![image](https://user-images.githubusercontent.com/47878584/113865624-eb7d2500-97c9-11eb-8ebd-1c14b9718e5e.png)


GET-ALL:

![image](https://user-images.githubusercontent.com/47878584/113865651-f3d56000-97c9-11eb-80eb-7b951d993de8.png)


GET:

![image](https://user-images.githubusercontent.com/47878584/113865670-fb950480-97c9-11eb-80f1-4d344208c45a.png)


DELETE:

![image](https://user-images.githubusercontent.com/47878584/113865684-018ae580-97ca-11eb-9434-aa4fbef44e09.png)


UPDATE:

![image](https://user-images.githubusercontent.com/47878584/113865706-094a8a00-97ca-11eb-8cbb-05c7cab2ede2.png)


14. As the API is successfully running locally, let's add Dockerfile to
    build an image of the API and run it on a container.

![image](https://user-images.githubusercontent.com/47878584/113865740-14051f00-97ca-11eb-8012-ae33743ffa8d.png)


![image](https://user-images.githubusercontent.com/47878584/113865808-28e1b280-97ca-11eb-881c-6cae6fae3d8e.png)
![image](https://user-images.githubusercontent.com/47878584/113865818-2d0dd000-97ca-11eb-9d52-e817dffbe164.png)
![image](https://user-images.githubusercontent.com/47878584/113865825-30a15700-97ca-11eb-80a3-1d1663a3593c.png)
![image](https://user-images.githubusercontent.com/47878584/113865839-3434de00-97ca-11eb-83cf-bc97a0422ea3.png)
![image](https://user-images.githubusercontent.com/47878584/113865850-37c86500-97ca-11eb-9626-b9e934a1ee4b.png)


As it is visible, weatherforecast API is running perfectly as it is
hardcoded in the image, but the students api is not opening as the SQL
server is present locally while the API is running on a container within
a Pod having a separate IP address, hence the server was inaccessible.

15. The way to solve this issue is to use SQLite DB as it can be
    embedded in the image. For the same, install
    "Microsoft.EntityFrameworkCore.SQLite" package.

![image](https://user-images.githubusercontent.com/47878584/113865877-40b93680-97ca-11eb-967f-3e0f55ec5ccb.png)


Add a connection string for the sqlite db.

![image](https://user-images.githubusercontent.com/47878584/113865894-46af1780-97ca-11eb-91c6-b6eb973cb8e0.png)


Change the Dbcontext for Sqlite in order to connect to sqlite db.

16. Once add Add-Migration and Update-Database to add the db in the
    project directory.

![image](https://user-images.githubusercontent.com/47878584/113865914-4f9fe900-97ca-11eb-8b71-3f48285710fa.png)


17. Finally, once again add a Dockerfile, create image and run in a
    container.

![image](https://user-images.githubusercontent.com/47878584/113865965-5f1f3200-97ca-11eb-84b0-8908807bc735.png)
![image](https://user-images.githubusercontent.com/47878584/113865986-63e3e600-97ca-11eb-9a65-a6a0eb20741c.png)
![image](https://user-images.githubusercontent.com/47878584/113866002-67776d00-97ca-11eb-9cba-6d9be5d5eb4a.png)


Now, new entries will be added using POSTMAN. (4)

![image](https://user-images.githubusercontent.com/47878584/113866048-76f6b600-97ca-11eb-8f7c-8ba3cdda8350.png)
![image](https://user-images.githubusercontent.com/47878584/113866060-79f1a680-97ca-11eb-8ad6-b8e7dcb6a231.png)


Now, the last entry is deleted.

![image](https://user-images.githubusercontent.com/47878584/113866080-81b14b00-97ca-11eb-8fef-f03114e76690.png)


The second last entry would be edited from Shrey to Rahul.

![image](https://user-images.githubusercontent.com/47878584/113866109-8970ef80-97ca-11eb-8c6a-72f5a8c94c95.png)


Now, see the changes:

![image](https://user-images.githubusercontent.com/47878584/113866135-91c92a80-97ca-11eb-92c7-cd4890ee0605.png)


Let's try to fetch the second entry only.

![image](https://user-images.githubusercontent.com/47878584/113866166-9b529280-97ca-11eb-9bf3-fd8d23522799.png)


Hence, the CRUD API is working perfectly in a docker container.

**FINISH**
