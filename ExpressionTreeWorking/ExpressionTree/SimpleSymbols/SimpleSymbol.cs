using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;

namespace ExpressionTreeWorking.ExpressionTree.SimpleSymbols
{
    /// <summary>
    /// class SimpleSymbol are not using in buidlded ExpressionTree, but we use it in building alhoritms
    /// So we don't define method Compute() in this class
    /// </summary>
    public class SimpleSymbol : IExpressionTree
    {
        public virtual string Symb { get; protected set; }

        public virtual double Rate { get; protected set; }

        public virtual object Compute() => throw new NotImplementedException();

        public override string ToString() => Symb;
    }
}
