using System.Linq.Expressions;

namespace Expression__Test;

public class BlockExpression__Test
{
    public void Main()
    {
        var param1 = Expression.Parameter(typeof(string), "s1");
        var param2 = Expression.Parameter(typeof(string), "s2");
        var blockExpression = Expression.Block(
                Expression.Call(
                    null, 
                    typeof(Console).GetMethod("Write", new Type[]{ typeof(string)}),
                    param1
                    ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[]{ typeof(string)}),
                    param2
                    ),
                param1
            );

        var blockFunc = Expression.Lambda<Func<string,string,string>>(blockExpression, param1, param2).Compile();

        blockFunc(" *Allo* ", "__Allo__");

    }
}