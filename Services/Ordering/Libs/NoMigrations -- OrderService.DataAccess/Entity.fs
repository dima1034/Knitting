module OrderService.DataAccess.Entity

open System

// If you use record types you need to add the CLIMutable attribute.
// Adding the CLIMutable attribute causes it to be compiled
// to a Common Language Infrastructure (CLI) representation
// with a default constructor with property getters and setters.
//// Which I believe means it acts more like a class.
type [<CLIMutable>] Order =
    {
        id                 : int
        created_at         : DateTime
        will_finished_at   : DateTime
        finished_at        : System.Nullable<DateTime>
        customer_id        : int
        worker_id          : int
        clothes_id         : int
    }
    
    
