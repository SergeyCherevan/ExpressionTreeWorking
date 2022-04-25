using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeWorking.ExpressionTree.Interfaces
{
    public interface IExpressionTree
    {
        public string Symb { get; }
        public double Rate { get; }
        object Compute();
        IExpressionTree SetVar(string name, object value);
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
