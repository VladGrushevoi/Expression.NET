using System.Linq.Expressions;

namespace Expression__Test;

public class BinaryExpressionTest
{
    public void Main()
    {
        var param1 = Expression.Parameter(typeof(double), "p1");
        var param2 = Expression.Parameter(typeof(double), "p2");
        var binaryExpressionSubtract = Expression.MakeBinary(
            ExpressionType.Subtract,
            param1,
            param2
        );

        var binaryExpressionPow = Expression.MakeBinary(
            ExpressionType.Divide,
            param1,
            param2
        );

        var subtractFunc = Expression.Lambda<Func<double, double, double>>(binaryExpressionSubtract, param1, param2).Compile();
        var powFunc = Expression.Lambda<Func<double, double, double>>(binaryExpressionPow, param1, param2).Compile();
        Console.WriteLine(subtractFunc(24, 12));
        Console.WriteLine(powFunc(2, 8));
    }
}