using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;

namespace ExpressionTreeWorking.ExpressionTree
{
    public interface IExpressionTreeBuilder
    {
        string InputInfixExpression { get; set; }
        IExpressionTreeFacade Facade { get; set; }

        List<IExpressionTree> InfixExpressionSymbols { get; set; }
        Queue<IExpressionTree> OutputQueue { get; set; }
        Stack<IExpressionTree> Stack { get; set; }

        IExpressionTree OutputTree { get; set; }



        IExpressionTree BuildAll();

        IExpressionTreeBuilder BuildInfixExpressionSympols();
        IExpressionTreeBuilder ShuntingYardAlgorithm();
        IExpressionTreeBuilder BuildTree();
    }
}
