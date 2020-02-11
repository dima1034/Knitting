using System;
using System.Linq.Expressions;
using OrderService.DataAccess.Contracts;

namespace OrderService.DataAccess
{
    public class Specification<T> : ISpecification<T>
    {
        private Func<T, bool> _function;

        private Func<T, bool> Function => _function ??= Predicate.Compile();

        protected Expression<Func<T, bool>> Predicate;

        protected Specification() { }

        public Specification(Expression<Func<T, bool>> predicate) { Predicate = predicate; }

        public bool IsSatisfiedBy(T entity) { return Function.Invoke(entity); }

        public Expression<Func<T, bool>> ToExpression() { return Predicate; }

        public static Specification<T> operator!(Specification<T> spec)
        {
            return new Specification<T>(
                Expression.Lambda<Func<T, bool>>(Expression.Not(spec.Predicate.Body), spec.Predicate.Parameters));
        }

        public static Specification<T> operator&(Specification<T> left, Specification<T> right)
        {
            var leftExpr   = left.Predicate;
            var rightExpr  = right.Predicate;
            var leftParam  = leftExpr.Parameters[0];
            var rightParam = rightExpr.Parameters[0];

            return new Specification<T>(
                Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(
                        leftExpr.Body,
                        new ParameterReplacer(rightParam, leftParam).Visit(rightExpr.Body)
                        ?? throw new InvalidOperationException()),
                    leftParam));
        }

        public static Specification<T> operator|(Specification<T> left, Specification<T> right)
        {
            var leftExpr   = left.Predicate;
            var rightExpr  = right.Predicate;
            var leftParam  = leftExpr.Parameters[0];
            var rightParam = rightExpr.Parameters[0];

            return new Specification<T>(
                Expression.Lambda<Func<T, bool>>(
                    Expression.OrElse(
                        leftExpr.Body,
                        new ParameterReplacer(rightParam, leftParam).Visit(rightExpr.Body)
                        ?? throw new InvalidOperationException()),
                    leftParam));
        }
    }
}