# Use official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.sln ./
COPY MovieListApp/*.csproj ./MovieListApp/
RUN dotnet restore

# Copy the rest of the code and build
COPY MovieListApp/. ./MovieListApp/
WORKDIR /app/MovieListApp
RUN dotnet publish -c Release -o out

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/MovieListApp/out ./

# Set environment port variable
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "MovieListApp.dll"]
