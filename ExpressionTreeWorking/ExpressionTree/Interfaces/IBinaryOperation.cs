using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeWorking.ExpressionTree.Interfaces
{
    public interface IBinaryOperation : IOperation
    {
        public IExpressionTree A { get; set; }
        public IExpressionTree B { get; set; }
    }

    public interface IBinaryOperation<TR, TA, TB> : IBinaryOperation, IExpressionTree<TR>
    {
        IExpressionTree IBinaryOperation.A { get => A; set => A = value as IExpressionTree<TA>; }
        IExpressionTree IBinaryOperation.B { get => B; set => B = value as IExpressionTree<TB>; }

        public new IExpressionTree<TA> A { get; set; }
        public new IExpressionTree<TB> B { get; set; }
    }
}
