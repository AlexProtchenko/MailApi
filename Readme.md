# Mail Repo

## Database management for email

## Dependencies

Mail Repo uses a number of open source projects to work properly:

- [Entity Framework Core](https://docs.microsoft.com/en-gb/ef/core/) - modern object-database mapper for .NET
- [PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL) - PostgreSQL/Npgsql provider for Entity Framework Core.
- [ASP.NET Core MVC](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Core) - Cross-platform framework for building modern cloud based internet connected applications, such as web apps, IoT apps and mobile backends.

## Running

```console
dotnet build
dotnet run 
```

## Docker
#### Build with code

1. Change./docker-compose. yml for you preferences
2. ```console
   docker-compose up
   ```
   
## Authentication
[GET]
_[http://{host}:{port}/api/jwt]()_ - get jwt token for 15 minutes

## Routes
_all requests needs jwt token in header to authentication_

[POST]
_[http://{host}:{port}/api/department]()_ - add new Department to DB

Example for Body content
```json
{
  "name": "Accounting"
}
```

[POST]
_[http://{host}:{port}/api/user]()_ - add new User to DB

```json
{
  "name": "Bob",
  "description": "python",
  "department_id": 1
}
```

[PUT]
_[http://{host}:{port}/api/department]()_ - update Department in DB

```json
{
  "department_id": 1,
  "name": "Development"
}
```

[PUT]
_[http://{host}:{port}/api/user]()_ - update User in DB

```json
{
  "user_id": 1,
  "name": "Jack",
  "description": "c#",
  "department_id": 2
}
```

[DELETE]
_[http://{host}:{port}/api/department]()_ - delete Department in DB

```json
{
  "department_id": 1
}
```

[DELETE]
_[http://{host}:{port}/api/user]()_ - delete User in DB

```json
{
  "user_id": 1
}
```

[GET]
_[http://{host}:{port}/api/users/department]()_ - get Users by Department

```json
{
  "department_id": 1
}
```
[GET]
_[http://{host}:{port}/api/pageable_users?page=1&size=2?page=2&size=2]()_ - get pageable Users

[GET]
_[http://{host}:{port}/api/users]()_ - get all Users

[GET]
_[http://{host}:{port}/api/departments]()_ - get all Departments

## Database

_To update database use:_

```console
cd MailApi
dotnet ef database update --connection {connection string}"
```
