namespace Domain
    open System.Threading.Tasks;

    type INotification = interface end
    
    type IKeyValueProvider =
        abstract member GetValue: key: string -> Task<string>