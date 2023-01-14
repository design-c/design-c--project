FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443
EXPOSE 5015

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

COPY . .

RUN dotnet restore "Api.TestRun/Api.TestRun.csproj" --verbosity normal --disable-parallel
COPY . .
WORKDIR "/src/Api.TestRun"
RUN dotnet build "Api.TestRun.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.TestRun.csproj" -c Release -o /app/publish

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "Api.TestRun.dll", "--urls=http://0.0.0.0:5015"]  
