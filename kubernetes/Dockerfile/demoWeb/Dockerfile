FROM microsoft/aspnetcore

WORKDIR /app
COPY . .

ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet","DemoApp.dll"]
