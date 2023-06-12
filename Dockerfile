# Base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set working directory
WORKDIR /app

# Copy csproj and restore dependencies
COPY muhtas2/*.csproj ./muhtas2/
RUN dotnet restore muhtas2/*.csproj

# Copy the rest of the project and build
COPY . .
RUN dotnet publish muhtas2/*.csproj -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
# ENV ASPNETCORE_URLS=http://0.0.0.0:5005;http://0.0.0.0:5010;
ENV ASPNETCORE_URLS=http://0.0.0.0:5005
EXPOSE 5005
# EXPOSE 5010

# Set the entry point
ENTRYPOINT ["dotnet", "muhtas2.dll"]
