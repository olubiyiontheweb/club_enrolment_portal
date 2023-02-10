# Building a Club Enrolment Portal on this Repo using Blazor(C#)

### Project images

Use case diagram for the project ![https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/Use%20Case%20Diagram.png?raw=true](https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/Use%20Case%20Diagram.png?raw=true)

UML diagram for the project ![https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/UML%20Class%20Diagram.png?raw=true](https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/UML%20Class%20Diagram.png?raw=true)

Login page ![https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/login%20page.png?raw=true](https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/login%20page.png?raw=true)

Club detail page ![https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/club%20detail%20page.png?raw=true](https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/club%20detail%20page.png?raw=true)

Event page ![https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/event%20page.png?raw=true](https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/event%20page.png?raw=true)

Event page ![https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/event%20page.png?raw=true](https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/event%20page.png?raw=true)

Create an event form ![https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/create%20event.png?raw=true](https://github.com/olubiyiontheweb/club_enrolment_portal/blob/main/create%20event.png?raw=true)

### Setting up the Repo

Install the following packages for applying database migrations:

> dotnet tool install --global dotnet-ef

> dotnet add package SendGrid

> dotnet ef migrations add Event --namespace clubEnrolmentPortal_TheKangaroos.Data.Event --output-dir Data/Migrations

> drop-database
> dotnet-ef database update
> Add-Migration
> Update-Database nameof(Migration)
> dotnet ef migrations add

# blazor sample repo
https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/samples/5.0/BlazorServerEFCoreSample/BlazorServerDbContextExample/Pages/AddContact.razor

### Todo
[]: Edit the user class to add the following properties:
> dotnet ef migrations add User --namespace clubEnrolmentPortal_TheKangaroos.Data.Models --output-dir Data/Migrations 

> dotnet new razorcomponent -n Events -o Pages

Starting the server
> dotnet user-secrets set SendGridKey <key>

> dotnet watch run or dotnet run
