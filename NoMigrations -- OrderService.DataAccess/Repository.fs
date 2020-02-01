module OrderService.DataAccess.Repository

//open OrderService.DataAccess.Context
//
//
//module OrdersRepository = 
//
//    let getAll (context : OrderContext)    = context.Orders
//    let get    (context : OrderContext) id = context.Orders
//                                             |> Seq.tryFind (fun f -> f.id = id)
    
//    let addTranslationAsync (context : TranslationContext) (entity : Translation) = 
//        async {
//            // TODO: verify AsTask
//            context.translations.AddAsync(entity).AsTask()
//            |> Async.AwaitTask
//            |> ignore
//
//            let! result = context.SaveChangesAsync true |> Async.AwaitTask
//            let result = if result >= 1  then Some(entity) else None
//            return result
//        }
//    
//    let updateLabel (context : TranslationContext) (entity : Translation) (id : int) = 
//        let current = context.translations.Find(id)
//        let updated = { entity with Id = id }
//        context.Entry(current).CurrentValues.SetValues(updated)
//        if context.SaveChanges true >= 1  then Some(updated) else None
    
//    let deleteLabel (context : TranslationContext) (id : int) = 
//        let current = context.translations.Find(id)
//        // somehow filters array
//        let deleted = { current with Inactive = true }
//        updateLabel context deleted id

//let getAll              = OrdersRepository.getAll 
//let get                 = OrdersRepository.get
//let addTranslationAsync = LabelsRepository.addTranslationAsync 
//let updateTranslation   = LabelsRepository.updateLabel 