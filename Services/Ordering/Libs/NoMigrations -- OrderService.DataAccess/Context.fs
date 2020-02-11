module Deprecated.OrderService.DataAccess.Context

open Microsoft.EntityFrameworkCore
open OrderService.DataAccess.Entity

type OrderContext(options: DbContextOptions<OrderContext>) =
    inherit DbContext(options)
    
    override __.OnConfiguring (optionsBuilder: DbContextOptionsBuilder) =
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=admin;Password=1")
        |> ignore
        
    override __.OnModelCreating modelBuilder =
       
        let expr = modelBuilder
                       .Entity<Order>()
                       .HasKey(fun order -> (order.id) :> (*:> - Converts a type to type that is higher in the hierarchy*) obj) 
        
        modelBuilder
            .Entity<Order>()
            .Property(fun order -> order.id).ValueGeneratedOnAdd()
        |> ignore
        
        modelBuilder
            .Entity<Order>()
            .Property(fun order -> order.worker_id)
        |> ignore
        
        modelBuilder
            .Entity<Order>()
            .Property(fun order -> order.clothes_id)
        |> ignore
        
        modelBuilder
            .Entity<Order>()
            .Property(fun order -> order.customer_id)
        |> ignore
        
        modelBuilder
            .Entity<Order>()
            .Property(fun order -> order.created_at)
        |> ignore
        
        modelBuilder
            .Entity<Order>()
            .Property(fun order -> order.finished_at)
        |> ignore
        
        modelBuilder
            .Entity<Order>()
            .Property(fun order -> order.will_finished_at)
        |> ignore
        
    [<DefaultValue>]
    val mutable Orders : DbSet<Order>
        member x.orders
            with get ()    = x.Orders
            and  set value = x.Orders <- value
            
//    [<DefaultValue>] val mutable orders : DbSet<Order>
//    member x.Orders with get() = x.Orders and set v = x.Orders <- v

//    member val Orders = DbSet<Order>() with get,set
            
let Migrate (context: OrderContext) =
    // use - automatically disposes
    context.Database.Migrate()


