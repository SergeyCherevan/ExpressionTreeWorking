using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

using ExpressionTreeWorking.ExpressionTree;
using ExpressionTreeWorking.ExpressionTree.Interfaces;
using static ExpressionTreeWorking.ExpressionTree.ExpressionTreeFacade;

namespace ExpressionTreeWorking
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*IExpressionTree<double> expression =
                mul(
                    sum(
                        num(2),
                        var("x")
                       ),
                    num(4)
                   );

            string funcJson = JsonConvert.SerializeObject(expression, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    TypeNameHandling = TypeNameHandling.All,
                });

            Console.WriteLine($"{expression} = {expression.Compute()} \n");
            Console.WriteLine(funcJson);*/



            /*Queue<IExpressionTree> expressionList
                = new ExpressionTreeBuilder("2 * 4 ^ 5 + 3 * 8", new ExpressionTreeFacade())
                .BuildInfixExpressionSympols()
                .ShuntingYardAlgorithm()
                .OutputQueue;

            string listJson = JsonConvert.SerializeObject(expressionList, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    TypeNameHandling = TypeNameHandling.All,
                });

            Console.WriteLine($"{listJson}\n");*/



            IExpressionTree expression = new ExpressionTreeFacade().GetBuilder("x ^ y").BuildAll().SetVar("x", 2.0).SetVar("y", 3.0);

            string funcJson = JsonConvert.SerializeObject(expression, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    TypeNameHandling = TypeNameHandling.All,
                });

            Console.WriteLine($"{expression} = {(expression.Compute() as IFormattable).ToString(null, new NumberFormatInfo() { CurrencyDecimalSeparator = "." })} \n");
            Console.WriteLine(funcJson);
        }
    }
}
