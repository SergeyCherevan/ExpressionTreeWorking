using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeWorking.ExpressionTree.Interfaces
{
    public interface IUnaryOperation : IOperation
    {
        public IExpressionTree A { get; set; }
    }

    public interface IUnaryOperation<TR, TA> : IUnaryOperation, IExpressionTree<TR>
    {
        IExpressionTree IUnaryOperation.A { get => A; set => A = value as IExpressionTree<TA>; }
        public new IExpressionTree<TA> A { get; set; }
    }
}
