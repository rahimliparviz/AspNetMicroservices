#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApps/Web.RazorPage/Web.RazorPage.csproj", "WebApps/Web.RazorPage/"]
RUN dotnet restore "WebApps/Web.RazorPage/Web.RazorPage.csproj"
COPY . .
WORKDIR "/src/WebApps/Web.RazorPage"
RUN dotnet build "Web.RazorPage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.RazorPage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.RazorPage.dll"]
