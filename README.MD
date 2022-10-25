# ASP.NET Core WEB API Template

- A ready-to-use template for ASP.NET Core WEB API with repositories, services, models mapping, DI.
- **Check Home Controller before using**

## Authors

- [Sinan Abdulgafurov](https://github.com/Sinkarq)

## Code snippets from
 
- [Nikolay Kostov](https://github.com/NikolayIT)
  - https://github.com/NikolayIT/ASP.NET-Core-Template
- [Ivaylo Kenov](https://github.com/ivaylokenov)
  - https://www.youtube.com/watch?v=TwsB9dhDbEU&list=PLLGdqRi7N09Yiq6Qo8lHAasz4ZpaqQdau

## Package Installation 

You can install this template using [NuGet](https://www.nuget.org/packages/WEB-API-TEMPLATE/):

```powershell
dotnet new -i WEB-API-TEMPLATE
```

```powershell
dotnet new aspnet-core-web-api -n YourProjectName
```

## Package Installation CQRS Version

You can install this template using [NuGet](https://www.nuget.org/packages/WEB-API-CQRS-TEMPLATE/1.0.1):

```powershell
dotnet new --install WEB-API-CQRS-TEMPLATE
```

```powershell
dotnet new aspnet-core-web-api-cqrs -n YourProjectName
```

### Common

**WEB-API.Common** contains common things for the project solution. For example:

- [GlobalConstants.cs](https://github.com/Sinkarq/WEB-API-Template/blob/master/YourProject.Common/GlobalConstants.cs).

### Data

This solution folder contains three subfolders:

- WEB-API-Template.Data.Common
- WEB-API-Template.Data.Models
- WEB-API-Template.Data

#### WEB-API-Template.Data.Common

[WEB-API-Template.Data.Common.Models](https://github.com/Sinkarq/WEB-API-Template/tree/master/Data/YourProject.Data.Common/Models) provides abstract generics classes and interfaces, which holds information about our entities. For example when the object is Created, Modified, Deleted or IsDeleted. It contains a property for the primary key as well.

[WEB-API-Template.Data.Common.Repositories](https://github.com/Sinkarq/WEB-API-Template/tree/master/Data/YourProject.Data.Common/Repositories) provides two interfaces IDeletableEntityRepository and IRepository, which are part of the **repository pattern**.

#### WEB-API.Data.Models

[WEB-API-Template.Data.Models](https://github.com/Sinkarq/WEB-API-Template/tree/master/Data/YourProject.Data.Models) contains models related to the database including the user class.

#### WEB-API-Template.Data

[WEB-API-Template.Data](https://github.com/Sinkarq/WEB-API-Template/tree/master/Data/YourProject.Data) contains DbContext, Migrations and Configuraitons for the EF Core. There is Seeding and Repository functionality as well.

## License

This project is licensed with the [MIT license](LICENSE).
