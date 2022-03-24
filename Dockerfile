FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /app

COPY ./ ./
WORKDIR /app/Api

ARG VERSION=1.0.0
RUN dotnet restore 
RUN dotnet publish -c Release -o /app/out /p:Version=$VERSION

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
RUN apt-get update && apt-get install -y libgdiplus
ARG ENVIRONMENT=production
ENV LANG=en_US.UTF-8
ENV ASPNETCORE_URLS=http://*:80
ENV ASPNETCORE_ENVIRONMENT=$ENVIRONMENT
ENV TZ=America/Sao_Paulo

WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "Api.dll"]