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

## Routes
[POST]
_[http://{host}:{port}/api/add/department]()_ - add new Department to DB

Example for Body content
```json
{
  "name": "Accounting"
}
```

[POST]
_[http://{host}:{port}/api/add/user]()_ - add new User to DB

```json
{
  "name": "Bob",
  "desc": "python",
  "departmentid": 1
}
```

[PUT]
_[http://{host}:{port}/api/update/department]()_ - update Department in DB

```json
{
  "DepartmentId": 1,
  "name": "Development"
}
```

[PUT]
_[http://{host}:{port}/api/update/user]()_ - update User in DB

```json
{
  "UserId": 1,
  "name": "Jack",
  "desc": "c#",
  "departmentid": 2
}
```

[DELETE]
_[http://{host}:{port}/api/del/department]()_ - delete Department in DB

```json
{
  "DepartmentId": 1
}
```

[DELETE]
_[http://{host}:{port}/api/del/user]()_ - delete User in DB

```json
{
  "userid": 1
}
```

[GET]
_[http://{host}:{port}/api/get/user/department]()_ - get Users by Department

```json
{
  "DepartmentId": 1
}
```
[GET]
_[http://{host}:{port}/get/user?page=2&size=2]()_ - get pageable Users

[GET]
_[http://{host}:{port}/get/all]()_ - get all Users

[GET]
_[http://{host}:{port}/get/department]()_ - get all Departments

## Database

_To update database use:_

```console
cd MailApi
dotnet ef database update --connection {connection string}"
```
