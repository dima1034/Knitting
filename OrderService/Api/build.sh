#!/bin/sh
if [ ! -e "paket.lock" ]
then
    exec mono .paket/paket.exe install
fi
# mono .paket/paket.exe update
dotnet restore src
dotnet build src

# dotnet restore tests/OrderService.Api.UnitTests
# dotnet build tests/OrderService.Api.UnitTests
# dotnet test tests/OrderService.Api.UnitTests
