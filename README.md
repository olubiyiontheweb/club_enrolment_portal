# 700111-2122-group-project-kangaroos
700111-2122-group-project-kangaroos created by GitHub Classroom

## The Kangaroos are building a Club Enrolment Portal on this Repo using Blazor(C#)

> https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli

> https://docs.microsoft.com/en-us/aspnet/core/?utm_source=aspnet-start-page&utm_campaign=vside&view=aspnetcore-6.0

> https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-6.0

> https://github.com/dotnet/aspnetcore/tree/1dcf7acfacf0fe154adcc23270cb0da11ff44ace/src/Identity/UI/src/Areas/Identity

> https://docs.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-6.0#rau

> https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio

Identity tutorial to learn more about Identity and implement
> https://www.tektutorialshub.com/asp-net-core/asp-net-core-identity-tutorial/

### Setting up the Repo

Install the following packages for applying database migrations:

> dotnet tool install --global dotnet-ef

> dotnet add package SendGrid

> dotnet ef migrations add Event --namespace clubEnrolmentPortal_TheKangaroos.Data.Event --output-dir Data/Migrations

> drop-database
> dotnet ef database update
> Add-Migration

### Todo
[]: Edit the user class to add the following properties:
> dotnet ef migrations add User --namespace clubEnrolmentPortal_TheKangaroos.Data.Models --output-dir Data/Migrations 

> dotnet new razorcomponent -n Events -o Pages

Starting the server
> dotnet user-secrets set SendGridKey <key>

> dotnet watch run or dotnet run