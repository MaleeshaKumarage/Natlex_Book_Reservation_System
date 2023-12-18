# Use the official .NET 8 SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY . ./
RUN dotnet restore

# Publish the application
RUN dotnet publish -c Release -o out

# Use the official .NET 8 runtime image as the final image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app

# Copy the published output from the build image
COPY --from=build /app/out ./

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Api.dll"]