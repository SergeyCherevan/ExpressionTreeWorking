using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.ArithmeticOperations;
using ExpressionTreeWorking.ExpressionTree.TrigonometricFunctions;
using ExpressionTreeWorking.ExpressionTree.Interfaces;
using ExpressionTreeWorking.ExpressionTree.SimpleSymbols;

namespace ExpressionTreeWorking.ExpressionTree
{
    public class ExpressionTreeFacade : IExpressionTreeFacade
    {
        public static IExpressionTree<double> sum(IExpressionTree<double> a, IExpressionTree<double> b)
            => new Sum(a, b);

        public static IExpressionTree<double> sub(IExpressionTree<double> a, IExpressionTree<double> b)
            => new Sub(a, b);

        public static IExpressionTree<double> mul(IExpressionTree<double> a, IExpressionTree<double> b)
            => new Mul(a, b);

        public static IExpressionTree<double> div(IExpressionTree<double> a, IExpressionTree<double> b)
            => new Div(a, b);

        public static IExpressionTree<double> pow(IExpressionTree<double> a, IExpressionTree<double> b)
            => new Pow(a, b);

        public static IExpressionTree<double> neg(IExpressionTree<double> a)
            => new Neg(a);

        public static IExpressionTree<double> sin(IExpressionTree<double> a)
            => new Sin(a);

        public static IExpressionTree<double> cos(IExpressionTree<double> a)
            => new Cos(a);

        public static IExpressionTree<double> tan(IExpressionTree<double> a)
            => new Tan(a);

        public static IExpressionTree<double> atan(IExpressionTree<double> a)
            => new Atan(a);

        public static IExpressionTree<double> atan2(IExpressionTree<double> a, IExpressionTree<double> b)
            => new Atan2(a, b);

        public static IExpressionTree<double> rand(IExpressionTree<double> a, IExpressionTree<double> b, IExpressionTree<double> c)
            => new Rand(a, b, c);

        public static IExpressionTree<double> var(string name)
            => new Var<double>(name);

        public static IExpressionTree<double> num(double val)
            => new Num<double>(val);



        private static List<IExpressionTree> symbols;

        static ExpressionTreeFacade()
        {
            IExpressionTree<double> n = null;

            symbols = new List<IExpressionTree>()
            {
                sum(n, n), sub(n, n), mul(n, n), div(n, n), pow(n, n), neg(n),
                sin(n), cos(n), tan(n), atan(n), atan2(n, n),
                rand(n, n, n),
                var(null), num(double.NaN),
                new OpenBracket(), new ClosingBracket(), new Comma(),
            };
        }

        public List<IExpressionTree> Symbols => symbols;

        public IExpressionTreeBuilder GetBuilder(string inputString) => new ExpressionTreeBuilder(inputString, this);

        public Type GetTypeOfNum(object context = null) => typeof(Num<double>);
        public Type GetTypeOfVar(object context = null) => typeof(Var<double>);
    }
}
