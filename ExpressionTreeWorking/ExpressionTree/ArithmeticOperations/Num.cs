using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;

namespace ExpressionTreeWorking.ExpressionTree.ArithmeticOperations
{
    public class Num<T> : IPrimitive<T>
    {
        public string Symb => null;
        public double Rate => 5;

        public T Value { get; set; }

        public Num(T val) { Value = val; }

        public Num(string str)
        {
            decimal dec = Convert.ToDecimal(str);
            
            Type type = typeof(T),
                 convertT = typeof(Convert);

            MethodInfo methodInfo = convertT.GetMethod($"To{type.Name}", new Type[] { typeof(decimal) });

            Value = (T)methodInfo.Invoke(null, new object[] { dec });
        }

        public T Compute() => Value;

        public override string ToString() => $"{Value}";
    }
}
