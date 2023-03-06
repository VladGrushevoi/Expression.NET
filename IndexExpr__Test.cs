using System.Linq.Expressions;

namespace Expression__Test;

public class IndexExpr__Test
{
    public void Main()
    {
        var arrayExpr = Expression.Parameter(typeof(int[]), "array");
        var indexExpr = Expression.Parameter(typeof(int), "index");
        var valueExpr = Expression.Parameter(typeof(int), "value");

        var arrAccessExpr = Expression.ArrayAccess(
                arrayExpr,
                indexExpr
            );

        var lambda = Expression.Lambda<Func<int[], int, int, int>>(
            Expression.Assign(
                arrAccessExpr, Expression.Add(arrAccessExpr, valueExpr)),
            arrayExpr,
            indexExpr,
            valueExpr
        ).Compile();
        
        Console.WriteLine(lambda(new int[]{ 1, 2, 3, 4, 5 }, 3, 10));
    }
}