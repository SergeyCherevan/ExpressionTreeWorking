﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.Interfaces;

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

        public double Compute() => Math.Round(new Random().NextDouble() * (B.Compute() - A.Compute()) / C.Compute()) * C.Compute() + A.Compute();

        public IExpressionTree SetVar(string name, object value)
        {
            A.SetVar(name, value);
            B.SetVar(name, value);
            C.SetVar(name, value);

            return this;
        }

        public override string ToString() => $"rand({A}, {B}, {C})";
    }
}
