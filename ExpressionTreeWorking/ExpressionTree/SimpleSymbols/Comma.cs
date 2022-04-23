using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeWorking.ExpressionTree.SimpleSymbols
{
    public class Comma : SimpleSymbol
    {
        public override string Symb { get => ","; protected set { } }

        public override double Rate { get => -1; protected set { } }
    }
}
