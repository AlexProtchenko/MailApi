FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MailApi/MailApi.csproj", "MailApi/"]
RUN dotnet restore "MailApi/MailApi.csproj"
COPY . .
WORKDIR "/src/MailApi"
RUN dotnet build "MailApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MailApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MailApi.dll"]



