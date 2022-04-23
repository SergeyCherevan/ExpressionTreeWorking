using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;

namespace ExpressionTreeWorking.ExpressionTree.TrigonometricFunctions
{
    public class Cos : IUnaryOperation<double, double>, IFunction
    {
        public string Symb => "cos";
        public double Rate => 0;

        public IExpressionTree<double> A { get; set; }

        public Cos(IExpressionTree<double> a)
        {
            A = a;
        }

        public double Compute() => Math.Cos(A.Compute());

        public override string ToString() => $"cos({A})";
    }
}
