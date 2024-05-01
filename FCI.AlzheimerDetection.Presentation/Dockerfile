#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FCI.AlzheimerDetection.Presentation/FCI.AlzheimerDetection.Presentation.csproj", "FCI.AlzheimerDetection.Presentation/"]
COPY ["FCI.AlzheimerDetection.BL/FCI.AlzheimerDetection.BL.csproj", "FCI.AlzheimerDetection.BL/"]
COPY ["FCI.AlzheimerDetection.DAL/FCI.AlzheimerDetection.DAL.csproj", "FCI.AlzheimerDetection.DAL/"]
RUN dotnet restore "./FCI.AlzheimerDetection.Presentation/FCI.AlzheimerDetection.Presentation.csproj"
COPY . .
WORKDIR "/src/FCI.AlzheimerDetection.Presentation"
RUN dotnet build "./FCI.AlzheimerDetection.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FCI.AlzheimerDetection.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FCI.AlzheimerDetection.Presentation.dll"]