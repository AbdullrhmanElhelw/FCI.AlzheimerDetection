FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FCI.AlzheimerDetection.Presentation/FCI.AlzheimerDetection.Presentation.csproj", "FCI.AlzheimerDetection.Presentation/"]
COPY ["FCI.AlzheimerDetection.BL/FCI.AlzheimerDetection.BL.csproj", "FCI.AlzheimerDetection.BL/"]
COPY ["FCI.AlzheimerDetection.DAL/FCI.AlzheimerDetection.DAL.csproj", "FCI.AlzheimerDetection.DAL/"]

RUN dotnet restore "FCI.AlzheimerDetection.Presentation/FCI.AlzheimerDetection.Presentation.csproj"
COPY . .

WORKDIR "/src/FCI.AlzheimerDetection.Presentation"
RUN dotnet build "FCI.AlzheimerDetection.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FCI.AlzheimerDetection.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FCI.AlzheimerDetection.Presentation.dll"]


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FCI.AlzheimerDetection.Presentation/FCI.AlzheimerDetection.Presentation.csproj", "FCI.AlzheimerDetection.Presentation/"]
COPY ["FCI.AlzheimerDetection.BL/FCI.AlzheimerDetection.BL.csproj", "FCI.AlzheimerDetection.BL/"]
COPY ["FCI.AlzheimerDetection.DAL/FCI.AlzheimerDetection.DAL.csproj", "FCI.AlzheimerDetection.DAL/"]

RUN dotnet restore "FCI.AlzheimerDetection.Presentation/FCI.AlzheimerDetection.Presentation.csproj"
RUN dotnet add "FCI.AlzheimerDetection.Presentation/FCI.AlzheimerDetection.Presentation.csproj" package Microsoft.EntityFrameworkCore.Relational
COPY . .

WORKDIR "/src/FCI.AlzheimerDetection.Presentation"
RUN dotnet build "FCI.AlzheimerDetection.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FCI.AlzheimerDetection.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FCI.AlzheimerDetection.Presentation.dll"]
