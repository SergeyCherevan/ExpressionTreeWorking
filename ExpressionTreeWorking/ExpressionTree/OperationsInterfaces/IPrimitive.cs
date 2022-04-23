using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeWorking.ExpressionTree.OperationsInterfaces
{
    public interface IPrimitive : IExpressionTree
    {
        public object Value { get; set; }
    }

    public interface IPrimitive<T> : IPrimitive, IExpressionTree<T>
    {
        object IPrimitive.Value { get => Value; set => Value = (T)value; }
        public new T Value { get; set; }
    }
}
