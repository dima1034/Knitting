module OrderService.DataAccess.IntegrationTests

open NUnit.Framework
open System.Linq
open OrderService.DataAccess
open OrderService.DataAccess.Entities
open OrderService.DataAccess.Specification
open OrderService.DataAccess.QueryableExtensionMethods.Base.Extensions

//let createInMemoryContext (databaseName : string) = 
//    let builder = new DbContextOptionsBuilder<OrderContext>()
//    new OrderContext(builder.UseInMemoryDatabase(databaseName).Options)
//    
//let setupOptions (optionsBuilder: DbContextOptionsBuilder<OrderContext>) =
//    optionsBuilder.UseNpgsql(
//        "Host=localhost;Port=5432;Database=knitting;Username=postgres;Password=1",
//        fun opt -> opt.MigrationsAssembly "OrderService.DataAccess.Migrations" |> ignore)
//    
//let createContext = 
//    let builder = new DbContextOptionsBuilder<OrderContext>()
//    
//    //let options = setupOptions builder  
//    //new OrderContext(options.Options)
//    
//    new OrderContext(builder.Options)
//
//[<SetUp>]
//let Setup () =
//    ()
//
//[<Test>]
//let ``getAll should not return empty result``() = 
//    //Arrange
//    let context = createInMemoryContext "knitting"
//
//    //Act
//    Repository.getAll context |> printf "%A"
//
//    // Assert
//    Assert.Ignore |> ignore
//    
//[<Test>]
//let ``getAll``() = 
//    //Arrange
//    let context = createContext
//    
//    Migrate context
//    
//    context.Database.CanConnect() |> printf "%A"
//    context.Database.EnsureCreated() |> ignore
//
//    //Act
//    context.orders |> Seq.iter (printfn "%A") |> ignore
//
//    // Assert
//    Assert.Ignore |> ignore

[<Test>]
let ``verify connection with Postgresql``() = 
    //Arrange
    use context = new OrderDbContext()
    
    context.Database.CanConnect() |> printf "%A"
    context.Database.EnsureCreated() |> printf "%A"

    //Act
    context.Orders |> Seq.iter (printfn "%A") |> ignore

    // Assert
    Assert.Ignore |> ignore
    
    
[<Test>]
let ``Test Specifications``() = 
    //Arrange
    use context = new OrderDbContext()
    
    let specification = OrderById(0)
    context.Orders.Where(specification.ToExpression()) |> Seq.iter (fun c -> (printfn "%A" c.created_at))
    
    let order = Order(id = 0)
    
    Assert.IsTrue (specification.IsSatisfiedBy(order))
    
    
[<Test>]
let ``Test OrderQueryableExtensions``() = 
    //Arrange
    use context = new OrderDbContext()
    
    let result = context.Orders
                    .AsExpandable<Order>()
                    .FirstOrDefault()    
    
    Assert.NotNull (result)