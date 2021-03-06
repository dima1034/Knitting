using System;
using System.Linq.Expressions;

namespace OrderService.DataAccess.Specification.Contracts
{
    public interface ISpecification<T>
    {
        bool                      IsSatisfiedBy(T entity);
        Expression<Func<T, bool>> ToExpression();
    }
}