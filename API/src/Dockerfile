FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Development"

 
FROM mcr.microsoft.com/dotnet/sdk:6.0.302 AS build
WORKDIR /src
COPY ["Padrao.Api/Padrao.Api.csproj", "API/"]
COPY ["Padrao.Data/Padrao.Data.csproj", "Data/"]
COPY ["Padrao.Business/Padrao.Business.csproj", "Business/"]
RUN dotnet restore "API/Padrao.Api.csproj"
COPY . .
WORKDIR "/src/Padrao.Api"
RUN dotnet build "Padrao.Api.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "Padrao.Api.csproj" -c Release -o /app/publish
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Open up port
EXPOSE 5000
ENTRYPOINT ["dotnet", "Padrao.Api.dll"]