using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.SmithReview.Domain.Extensions {
    public static class LinqExtensions {
        #region OrderBy, ThenBy, Descending
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return (IQueryable<T>)OrderBy((IQueryable)source, propertyName);
        }
        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return (IQueryable<T>)OrderByDescending((IQueryable)source, propertyName);
        }
        public static IQueryable<T> ThenBy<T>(this IQueryable<T> source, string propertyName)
        {
            return (IQueryable<T>)ThenBy((IQueryable)source, propertyName);
        }
        public static IQueryable<T> ThenByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return (IQueryable<T>)ThenByDescending((IQueryable)source, propertyName);
        }
        public static IQueryable OrderBy(this IQueryable source, string propertyName) {
            return ExpandedOrderExpression("OrderBy", source, propertyName);
        }
        public static IQueryable OrderByDescending (this IQueryable source, string propertyName) {
            return ExpandedOrderExpression("OrderByDescending", source, propertyName);
        }
        public static IQueryable ThenBy (this IQueryable source, string propertyName) {
            return ExpandedOrderExpression("ThenBy", source, propertyName);
        }
        public static IQueryable ThenByDescending (this IQueryable source, string propertyName) {
            return ExpandedOrderExpression("ThenByDescending", source, propertyName);
        }
        public static IQueryable ExpandedOrderExpression(string orderMethod, IQueryable source, string propertyName)
        {
            var x = Expression.Parameter(source.ElementType);
            var selector = Expression.Lambda(Expression.PropertyOrField(x, propertyName), x);
            return source.Provider.CreateQuery(
            Expression.Call(typeof(Queryable), orderMethod, new Type[] { source.ElementType, selector.Body.Type },
                    source.Expression, selector
                    ));
        }
        #endregion
    }
}
