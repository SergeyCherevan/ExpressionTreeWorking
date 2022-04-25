using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.Interfaces;

namespace ExpressionTreeWorking.ExpressionTree.TrigonometricFunctions
{
    public class Atan2 : IBinaryOperation<double, double, double>, IFunction
    {
        public string Symb => "atan2";
        public double Rate => 0;

        public IExpressionTree<double> A { get; set; }
        public IExpressionTree<double> B { get; set; }

        public Atan2(IExpressionTree<double> a, IExpressionTree<double> b)
        {
            A = a; B = b;
        }

        public double Compute() => Math.Atan2(A.Compute(), B.Compute());

        public IExpressionTree SetVar(string name, object value)
        {
            A.SetVar(name, value);
            B.SetVar(name, value);

            return this;
        }

        public override string ToString() => $"atan2({A}, {B})";
    }
}
