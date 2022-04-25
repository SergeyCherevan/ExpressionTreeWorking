using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.Interfaces;

namespace ExpressionTreeWorking.ExpressionTree.TrigonometricFunctions
{
    public class Sin : IUnaryOperation<double, double>, IFunction
    {
        public string Symb => "sin";
        public double Rate => 0;

        public IExpressionTree<double> A { get; set; }

        public Sin(IExpressionTree<double> a)
        {
            A = a;
        }

        public double Compute() => Math.Sin(A.Compute());

        public IExpressionTree SetVar(string name, object value)
        {
            A.SetVar(name, value);

            return this;
        }

        public override string ToString() => $"sin({A})";
    }
}
