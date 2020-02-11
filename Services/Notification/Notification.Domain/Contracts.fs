namespace DomainContracts
    type INotification = interface end
    
namespace InfrastructureContracts
    open System.Threading.Tasks;

    type IKeyValueProvider =
        abstract member GetValue: key: string -> Task<string>