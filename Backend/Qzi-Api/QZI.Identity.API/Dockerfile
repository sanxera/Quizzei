#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["QZI.Identity.API/QZI.Identity.API.csproj", "QZI.Identity.API/"]
RUN dotnet restore "QZI.Identity.API/QZI.Identity.API.csproj"
COPY . .
WORKDIR "/src/QZI.Identity.API"
RUN dotnet build "QZI.Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QZI.Identity.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QZI.Identity.API.dll"]