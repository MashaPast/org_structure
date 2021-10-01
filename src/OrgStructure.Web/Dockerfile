#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/OrgStructure.Web/OrgStructure.Web.csproj", "src/OrgStructure.Web/"]
COPY ["src/OrgStructure/OrgStructure.csproj", "src/OrgStructure/"]
COPY ["src/OrgStructure.Contracts/OrgStructure.Contracts.csproj", "src/OrgStructure.Contracts/"]
RUN dotnet restore "src/OrgStructure.Web/OrgStructure.Web.csproj"
COPY . .
WORKDIR "/src/src/OrgStructure.Web"
RUN dotnet build "OrgStructure.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrgStructure.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrgStructure.Web.dll"]