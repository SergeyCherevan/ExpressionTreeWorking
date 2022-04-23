using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;

namespace ExpressionTreeWorking.ExpressionTree.TrigonometricFunctions
{
    public class Atan : IUnaryOperation<double, double>, IFunction
    {
        public string Symb => "atan";
        public double Rate => 0;

        public IExpressionTree<double> A { get; set; }

        public Atan(IExpressionTree<double> a)
        {
            A = a;
        }

        public double Compute() => Math.Atan(A.Compute());

        public override string ToString() => $"atan({A})";
    }
}
