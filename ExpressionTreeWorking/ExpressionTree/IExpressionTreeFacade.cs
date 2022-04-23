using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;

namespace ExpressionTreeWorking.ExpressionTree
{
    public interface IExpressionTreeFacade
    {
        List<IExpressionTree> Symbols { get; }

        IExpressionTreeBuilder GetBuilder(string inputString);

        Type GetTypeOfNum(object context = null);
        Type GetTypeOfVar(object context = null);
    }
}
