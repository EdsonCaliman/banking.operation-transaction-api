#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
ENV TZ="America/Sao_Paulo"
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Banking.Operation.Transaction.Api/Banking.Operation.Transaction.Api.csproj", "Banking.Operation.Transaction.Api/"]
COPY ["Banking.Operation.Transaction.CrossCutting.Ioc/Banking.Operation.Transaction.CrossCutting.Ioc.csproj", "Banking.Operation.Transaction.CrossCutting.Ioc/"]
COPY ["Banking.Operation.Transaction.Infra.Data/Banking.Operation.Transaction.Infra.Data.csproj", "Banking.Operation.Transaction.Infra.Data/"]
COPY ["Banking.Operation.Transaction.Domain/Banking.Operation.Transaction.Domain.csproj", "Banking.Operation.Transaction.Domain/"]
RUN dotnet restore "Banking.Operation.Transaction.Api/Banking.Operation.Transaction.Api.csproj"
COPY . .
WORKDIR "/src/Banking.Operation.Transaction.Api"
RUN dotnet build "Banking.Operation.Transaction.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Banking.Operation.Transaction.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banking.Operation.Transaction.Api.dll"]