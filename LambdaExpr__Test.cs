using System.Linq.Expressions;

namespace Expression__Test;

public class LambdaExpr__Test
{
    public void Main()
    {
        Func<int, string, bool> checkUser = (age, name) => age >= 18 && name != "";
        Console.WriteLine(checkUser(24, "Jorge"));

        Expression<Func<int, string, bool>> isValidUserExpr = (age, name) => age >= 18 && name != "";
        var funcUserValidation = isValidUserExpr.Compile();
        
        Console.WriteLine(funcUserValidation(15, ""));
    }
}