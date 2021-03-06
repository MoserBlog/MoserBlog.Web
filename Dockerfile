FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MoserBlog.Web/MoserBlog.Web.csproj", "src/MoserBlog.Web/"]
COPY ["src/MoserBlog.Persistence/MoserBlog.Persistence.csproj", "src/MoserBlog.Persistence/"]
COPY ["src/MoserBlog.Application/MoserBlog.Application.csproj", "src/MoserBlog.Application/"]
COPY ["src/MoserBlog.Domain/MoserBlog.Domain.csproj", "src/MoserBlog.Domain/"]

RUN dotnet restore "src/MoserBlog.Web/MoserBlog.Web.csproj"

COPY . .

WORKDIR "/src/src/MoserBlog.Web"
RUN dotnet build "MoserBlog.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoserBlog.Web.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "MoserBlog.Web.dll"]