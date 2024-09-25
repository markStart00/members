# Use the official .NET 8 image for the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80 433 

# Use the official .NET 8 SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file and all project foles
COPY ["src/members.Api/members.Api.csproj", "/src/members.Api/"]
COPY ["src/members.Application/members.Application.csproj", "/src/members.Application/"]
COPY ["src/members.Database.Domain/members.Database.Domain.csproj", "/src/members.Database.Domain/"]
COPY ["src/members.Database.Infrastructure/members.Database.Infrastructure.csproj", "/src/members.Database.Infrastructure/"]
COPY ["src/members.Infrastructure/members.Infrastructure.csproj", "/src/members.Infrastructure/"]
COPY ["src/members.Domain/members.Domain.csproj", "/src/members.Domain/"]

# Restore dependencies
RUN dotnet restore "/src/members.Api/members.Api.csproj"

# Copy the entire source code to the container
COPY . .

# Build the project
WORKDIR "src/members.Api"
RUN dotnet build "members.Api.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "members.Api.csproj" -c Release -o /app/publish

# Final stage: use runtime-only environment
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY localhost.pfx /https/localhost.pfx
COPY ./init-scripts /app/init-scripts
RUN chmod +x ./init-scripts/init-db.sh


ENTRYPOINT ["dotnet", "members.Api.dll"]

