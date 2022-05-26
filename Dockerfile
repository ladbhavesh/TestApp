# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY   ./puboutput .
ENTRYPOINT ["dotnet", "TestApp.dll"]