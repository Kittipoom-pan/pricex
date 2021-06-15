FROM mcr.microsoft.com/dotnet/sdk:3.1 as builder
WORKDIR /src
ARG BUILD_ENV=dev
COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:3.1
MAINTAINER Titiwut M. <titiwut@feyverly.com>
ARG BUILD_ENV=dev
EXPOSE 3000
ENV DOTNET_URLS=http://0.0.0.0:3000 \
    ASPNETCORE_URLS=http://0.0.0.0:3000
WORKDIR /app
COPY --from=builder /app .
COPY .ci/setting/${BUILD_ENV}.json appsettings.json
ENTRYPOINT ["dotnet", "Api.Pricex.dll"]
