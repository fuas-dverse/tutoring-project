#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

# Stage for building and running tests
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS test
WORKDIR /src
COPY ["TutoringPlatformBackEnd/TutoringPlatformBackEnd.csproj", "TutoringPlatformBackEnd/"]
RUN dotnet restore "TutoringPlatformBackEnd/TutoringPlatformBackEnd.csproj"
COPY . .
WORKDIR "/src/TutoringPlatformBackEnd"
RUN dotnet test "TutoringPlatformBackEnd.csproj" -c Release --logger trx

# Base stage for the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage for the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TutoringPlatformBackEnd/TutoringPlatformBackEnd.csproj", "TutoringPlatformBackEnd/"]
RUN dotnet restore "TutoringPlatformBackEnd/TutoringPlatformBackEnd.csproj"
COPY . .
WORKDIR "/src/TutoringPlatformBackEnd"
RUN dotnet build "TutoringPlatformBackEnd.csproj" -c Release -o /app/build

# Publish stage for the application
FROM build AS publish
RUN dotnet publish "TutoringPlatformBackEnd.csproj" -c Release -o /app/publish /p:UseAppHost=false

#Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TutoringPlatformBackEnd.dll"]