using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;

namespace ExpressionTreeWorking.ExpressionTree.ArithmeticOperations
{
    public class Neg : IUnaryOperation<double, double>, IOperator
    {
        public string Symb => "-";
        public double Rate => 0;

        public IExpressionTree<double> A { get; set; }

        public Neg(IExpressionTree<double> a)
        {
            A = a;
        }

        public double Compute() => -A.Compute();

        public override string ToString() => $"-({A})";
    }
}
