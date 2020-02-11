using System;

namespace OrderService.DataAccess.QueryableExtensionMethods.Base
{
    // Аттрибут [Expandable], котоым мы будем помечать extension-методы для раскрытия.
    // Ведь Where() или Select() тоже extension-методы, а их раскрывать не надо.
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    internal class ExpandableAttribute : Attribute
    {
    }
}