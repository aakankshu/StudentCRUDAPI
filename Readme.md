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

![](media/image1.png){width="6.5in" height="2.9451388888888888in"}

The role of the controller will be to provide the route methods and
destinations for CRUD operations along with what needs to be displayed
on each URL.

4.  Now in order to interact with MS SQL SERVER, Entity Framework will
    be used for which certain dependencies need to be installed:
    "Microsoft.EntityFrameworkCore.SqlServer" and
    "Microsoft.EntityFrameworkCore.Tools"

5.  Now, two class model and context will be created to give structure
    to the database.

![](media/image2.png){width="6.5in" height="2.4444444444444446in"}

6.  In Student.cs (the model) structure of the database table "Student"
    is defined.

![](media/image3.png){width="6.5in" height="4.5881944444444445in"}

Here, a table with the columns/attributes: StudentID, RollNo, FirstName
and LastName would be created. Annotations are used for the purpose of
validation. StudentID is the primary key to fetch any student. Roll No
and FirstName are required entities with a MaxLength constraint.

7.  In StudentContext.cs class, code is written to create a table in the
    database using Student.cs model class.

![](media/image4.png){width="6.5in" height="3.922222222222222in"}

Here DbContext is inherited/implemented in StudentContext class using
Entity Framework. The constructor of the class creates options object
for the class which inherits from the base startup file where actual
connection with the database would be made. Then DbSet function is used
to create the Students table within the database.

8.  Now services need to be added to the startup file in order to
    connect to the database.

![](media/image5.png){width="6.5in" height="4.4631944444444445in"}

![](media/image6.png){width="6.5in" height="2.8944444444444444in"}

Here the connection string is added in appsettings.json file and then
called in startup.cs file within the ConfigureServices section.

9.  Now StudentData folder is created with an interface and a class. The
    interface defines all the functions to be performed with the
    database. Then further, the class inherits the interface and
    consists of the code describing those actions.

![](media/image7.png){width="6.5in" height="4.413194444444445in"}

This is the IStudentData interface which would be implemented by the
SQLStudentData class.

![](media/image8.png){width="6.5in" height="4.408333333333333in"}

In SQLStudentData class, the IStudentData interface is implemented along
with the core functionalities.

![](media/image9.png){width="6.5in" height="4.381944444444445in"}

Also, add "Addscoped" parameter in startup file so that the API is aware
that SQLStudentData is implemented by IStudentData interface.

10. Now, the controller class is coded in order to route and respond to
    the requests with the help of the model and the SQLStudentData
    class.

![](media/image10.png){width="6.5in" height="4.339583333333334in"}

As can be seen, the controller routes each function and defines the http
method associated with function. It is also responsible for what to
respond with on the screen/console.

11. Now using Package Manager Console, Add-Migration and Update-Database
    so that the database and table within is created in the local
    machine MSSQL server.

![](media/image11.png){width="2.5416666666666665in"
height="4.527777777777778in"}

12. On running the API on IIS Server, an empty list is returned as no
    data is added to the table.

![](media/image12.png){width="6.5in" height="1.1243055555555554in"}

13. We'll try out all the CRUD operations using POSTMAN.

ADD:

![](media/image13.png){width="6.5in" height="3.8243055555555556in"}

![](media/image14.png){width="6.5in" height="3.4875in"}

GET-ALL:

![](media/image15.png){width="6.5in" height="3.661111111111111in"}

GET:

![](media/image16.png){width="6.5in" height="3.0590277777777777in"}

DELETE:

![](media/image17.png){width="6.5in" height="2.642361111111111in"}

UPDATE:

![](media/image18.png){width="6.5in" height="3.0722222222222224in"}

14. As the API is successfully running locally, let's add Dockerfile to
    build an image of the API and run it on a container.

![](media/image19.png){width="6.5in" height="3.1958333333333333in"}

![](media/image20.png){width="6.5in"
height="2.2270833333333333in"}![](media/image21.png){width="6.5in"
height="1.1506944444444445in"}![](media/image22.png){width="6.5in"
height="1.8958333333333333in"}

![](media/image23.png){width="6.5in"
height="1.3916666666666666in"}![](media/image24.png){width="6.5in"
height="3.316666666666667in"}

As it is visible, weatherforecast API is running perfectly as it is
hardcoded in the image, but the students api is not opening as the SQL
server is present locally while the API is running on a container within
a Pod having a separate IP address, hence the server was inaccessible.

15. The way to solve this issue is to use SQLite DB as it can be
    embedded in the image. For the same, install
    "Microsoft.EntityFrameworkCore.SQLite" package.

![](media/image25.png){width="6.5in" height="3.2305555555555556in"}

Add a connection string for the sqlite db.

![](media/image26.png){width="6.5in" height="4.127777777777778in"}

Change the Dbcontext for Sqlite in order to connect to sqlite db.

16. Once add Add-Migration and Update-Database to add the db in the
    project directory.

![](media/image27.png){width="3.3194444444444446in"
height="5.180555555555555in"}

17. Finally, once again add a Dockerfile, create image and run in a
    container.

![](media/image28.png){width="6.5in" height="2.2416666666666667in"}

![](media/image29.png){width="6.5in" height="1.445138888888889in"}

![](media/image30.png){width="6.5in" height="1.2527777777777778in"}

Now, new entries will be added using POSTMAN. (4)

![](media/image31.png){width="6.5in" height="4.095138888888889in"}

![](media/image32.png){width="6.5in" height="4.072916666666667in"}

Now, the last entry is deleted.

![](media/image33.png){width="6.5in" height="2.5506944444444444in"}

The second last entry would be edited from Shrey to Rahul.

![](media/image34.png){width="6.5in" height="3.0694444444444446in"}

Now, see the changes:

![](media/image35.png){width="6.5in" height="2.4895833333333335in"}

Let's try to fetch the second entry only.

![](media/image36.png){width="6.5in" height="2.188888888888889in"}

Hence, the CRUD API is working perfectly in a docker container.

**FINISH**
