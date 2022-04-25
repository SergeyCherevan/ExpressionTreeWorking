using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeWorking.ExpressionTree.Interfaces
{
    public interface ITernaryOperation : IOperation
    {
        public IExpressionTree A { get; set; }
        public IExpressionTree B { get; set; }
        public IExpressionTree C { get; set; }
    }

    public interface ITernaryOperation<out TR, TA, TB, TC> : ITernaryOperation, IExpressionTree<TR>
    {
        IExpressionTree ITernaryOperation.A { get => A; set => A = value as IExpressionTree<TA>; }
        IExpressionTree ITernaryOperation.B { get => B; set => B = value as IExpressionTree<TB>; }
        IExpressionTree ITernaryOperation.C { get => C; set => C = value as IExpressionTree<TC>; }

        public new IExpressionTree<TA> A { get; set; }
        public new IExpressionTree<TB> B { get; set; }
        public new IExpressionTree<TC> C { get; set; }
    }
}
