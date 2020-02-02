#!/bin/sh
if [ ! -e "paket.lock" ]
then
    exec mono .paket/paket.exe install
fi
dotnet restore src/OrderService.WebApi
dotnet build src/OrderService.WebApi

dotnet restore tests/OrderService.WebApi.Tests
dotnet build tests/OrderService.WebApi.Tests
dotnet test tests/OrderService.WebApi.Tests
