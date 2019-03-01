FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["test.csproj", "."]
RUN dotnet restore "test.csproj"
COPY . .
RUN dotnet build "test.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "test.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "test.dll"]