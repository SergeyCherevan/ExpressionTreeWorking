using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.Interfaces;

namespace ExpressionTreeWorking.ExpressionTree.ArithmeticOperations
{
    public interface IVar : IPrimitive
    {
        public string Name { get; set; }
    }

    public class Var<T> : IVar, IPrimitive<T>
    {
        public string Symb => null;
        public double Rate => 5;

        public string Name { get; set; }
        public T Value { get; set; }

        public Var(string name) { Name = name; }

        public T Compute() => Value;

        public IExpressionTree SetVar(string name, object value)
        {
            if (Name == name)
            {
                Value = (T)value; 
            }

            return this;
        }

        public override string ToString() => $"{Name}";
    }
}
