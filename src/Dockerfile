FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
COPY ["src/configmap.csproj", "src/"]
RUN dotnet restore "src/configmap.csproj"
COPY src/ src/
RUN dotnet build "src/configmap.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/configmap.csproj" --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS fin
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "configmap.dll"]