FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR /app
EXPOSE 80
COPY obj/Docker/publish .
ENTRYPOINT ["dotnet", "FridgeAPI.dll"]
