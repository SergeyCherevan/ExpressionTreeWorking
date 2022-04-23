using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;

namespace ExpressionTreeWorking.ExpressionTree.TrigonometricFunctions
{
    public class Tan : IUnaryOperation<double, double>, IFunction
    {
        public string Symb => "tan";
        public double Rate => 0;

        public IExpressionTree<double> A { get; set; }

        public Tan(IExpressionTree<double> a)
        {
            A = a;
        }

        public double Compute() => Math.Tan(A.Compute());

        public override string ToString() => $"tan({A})";
    }
}
