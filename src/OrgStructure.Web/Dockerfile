#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["OrgStructure/OrgStructure.csproj", "OrgStructure/"]
RUN dotnet restore "OrgStructure/OrgStructure.csproj"
COPY . .
WORKDIR "/src/OrgStructure"
RUN dotnet build "OrgStructure.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrgStructure.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrgStructure.dll"]