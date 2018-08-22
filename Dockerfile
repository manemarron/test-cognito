FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
WORKDIR /app
COPY bin/Release/netcoreapp2.1/publish .
ENTRYPOINT ["dotnet", "test-cognito.dll"]
