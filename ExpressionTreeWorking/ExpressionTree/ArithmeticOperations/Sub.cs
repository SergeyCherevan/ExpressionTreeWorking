using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.Interfaces;

namespace ExpressionTreeWorking.ExpressionTree.ArithmeticOperations
{
    public class Sub : IBinaryOperation<double, double, double>, IOperator
    {
        public string Symb => "-";
        public double Rate => 3;

        public IExpressionTree<double> A { get; set; }
        public IExpressionTree<double> B { get; set; }

        public Sub(IExpressionTree<double> a, IExpressionTree<double> b)
        {
            A = a; B = b;
        }

        public double Compute() => A.Compute() - B.Compute();

        public IExpressionTree SetVar(string name, object value)
        {
            A.SetVar(name, value);
            B.SetVar(name, value);

            return this;
        }

        public override string ToString() => $"({A} - {B})";
    }
}
