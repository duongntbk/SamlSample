#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SamlSample/SamlSample.csproj", "SamlSample/"]
RUN dotnet restore "SamlSample/SamlSample.csproj"
COPY . .
WORKDIR "/src/SamlSample"
RUN dotnet build "SamlSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SamlSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SamlSample.dll"]