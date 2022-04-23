using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;

namespace ExpressionTreeWorking.ExpressionTree.ArithmeticOperations
{
    public class Rand : ITernaryOperation<double, double, double, double>, IFunction
    {
        public string Symb => "rand";
        public double Rate => 4;

        public IExpressionTree<double> A { get; set; }
        public IExpressionTree<double> B { get; set; }
        public IExpressionTree<double> C { get; set; }

        public Rand(IExpressionTree<double> a, IExpressionTree<double> b, IExpressionTree<double> c)
        {
            A = a; B = b; C = c; 
        }

        public double Compute() => Math.Round(new Random().NextDouble() * (A.Compute() - B.Compute()) / C.Compute()) * C.Compute() + A.Compute();

        public override string ToString() => $"Rand({A}, {B}, {C})";
    }
}
