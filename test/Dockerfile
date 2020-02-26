FROM mcr.azk8s.cn/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY ["test.csproj", "."]
RUN dotnet restore "test.csproj"
COPY . .
RUN dotnet publish "test.csproj" -c Release -o /out

FROM mcr.azk8s.cn/dotnet/core/aspnet:3.1
WORKDIR /src
EXPOSE 80
COPY --from=build-env /out .
ENTRYPOINT ["dotnet", "test.dll"]