using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeWorking.ExpressionTree.OperationsInterfaces
{
    public interface IExpressionTree
    {
        public string Symb { get; }
        public double Rate { get; }
        object Compute();
    }

    public interface IExpressionTree<out T> : IExpressionTree
    {
        object IExpressionTree.Compute()
        {
            return Compute();
        }

        new T Compute();
    }
}
