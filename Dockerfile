FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["VueChatApp.csproj", ""]
RUN dotnet restore "/VueChatApp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "VueChatApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VueChatApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VueChatApp.dll"]