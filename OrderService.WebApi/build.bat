IF NOT EXIST paket.lock (
    START /WAIT .paket/paket.exe install
)
dotnet restore src/OrderService.WebApi
dotnet build src/OrderService.WebApi

dotnet restore tests/OrderService.WebApi.Tests
dotnet build tests/OrderService.WebApi.Tests
dotnet test tests/OrderService.WebApi.Tests
