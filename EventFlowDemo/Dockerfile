FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["EventFlowDemo/EventFlowDemo.csproj", "EventFlowDemo/"]
RUN dotnet restore "EventFlowDemo/EventFlowDemo.csproj"
COPY . .
WORKDIR "/src/EventFlowDemo"
RUN dotnet build "EventFlowDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventFlowDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventFlowDemo.dll"]