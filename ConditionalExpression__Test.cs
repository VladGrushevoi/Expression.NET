using System.Linq.Expressions;

namespace Expression__Test;

public class ConditionalExpression__Test
{
    public void Main()
    {
        var param1 = Expression.Parameter(typeof(string), "p1");
        var expressionCond = Expression.Condition(
            Expression.AndAlso(
                Expression.NotEqual(param1, Expression.Constant(null)),
                Expression.NotEqual(param1, Expression.Constant(""))
            ),
            Expression.Call(
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                param1
            ),
            Expression.Call(
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                Expression.Constant($"{param1} is equal null", typeof(string))
                )
        );

        var nullCheck = Expression.Lambda<Action<string>>(expressionCond, param1).Compile();

        nullCheck("j");
        nullCheck("hello");
        nullCheck("");
    }
}