using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using ExpressionTreeWorking.ExpressionTree.ArithmeticOperations;
using ExpressionTreeWorking.ExpressionTree.OperationsInterfaces;
using ExpressionTreeWorking.ExpressionTree.SimpleSymbols;

namespace ExpressionTreeWorking.ExpressionTree
{
    public class ExpressionTreeBuilder : IExpressionTreeBuilder
    {
        public string InputInfixExpression { get; set; }
        public IExpressionTreeFacade Facade { get; set; }

        public List<IExpressionTree> InfixExpressionSymbols { get; set; }
        public Queue<IExpressionTree> OutputQueue { get; set; }
        public Stack<IExpressionTree> Stack { get; set; }

        public IExpressionTree OutputTree { get; set; }





        public ExpressionTreeBuilder(string inputString, IExpressionTreeFacade facade)
        {
            InputInfixExpression = inputString.Replace(" ", "").Replace("\t", "").Replace("\n", "");
            Facade = facade;
        }

        public IExpressionTree BuildAll()
        {
            BuildInfixExpressionSympols();

            ShuntingYardAlgorithm();

            BuildTree();

            return OutputTree;
        }

        public IExpressionTreeBuilder BuildInfixExpressionSympols()
        {
            InfixExpressionSymbols = new List<IExpressionTree>(InputInfixExpression.Length);

            for (int strI = 0, exprI = 0; strI < InputInfixExpression.Length; exprI++)
            {
                IExpressionTree symb = GetSymbol(strI, exprI);

                if (symb != null)
                {
                    strI += symb.Symb.Length;
                }
                else
                {
                    int i = strI;
                    for (; i < InputInfixExpression.Length && GetSymbol(i, exprI) == null; i++) ;
                    string symbStr = InputInfixExpression.Substring(strI, i - strI);

                    if (Char.IsNumber(InputInfixExpression, strI))
                    {
                        symb = GenerateSymbolByType(Facade.GetTypeOfNum(), symbStr);
                    }
                    else
                    {
                        symb = GenerateSymbolByType(Facade.GetTypeOfVar(), symbStr);
                    }

                    strI += symbStr.Length;
                }

                InfixExpressionSymbols.Add(symb);
            }

            return this;
        }

        public IExpressionTree GetSymbol(int strPos, int exprPos)
        {
            string expression = InputInfixExpression;

            Predicate<IExpressionTree> pred = e =>
            {
                try
                {
                    if(e.Symb == expression.Substring(strPos, e.Symb.Length))
                    {
                        return true;
                    }
                }
                catch { }

                return false;
            };

            int first = Facade.Symbols.FindIndex(pred),
                last = Facade.Symbols.FindLastIndex(pred);

            if (first == -1)
            {
                return null;
            }
            else if (first == last)
            {
                return GenerateSymbolByType(Facade.Symbols[first].GetType());
            }
            else
            {
                IExpressionTree unary, binary;

                if (GenerateSymbolByType(Facade.Symbols[first].GetType()) is IUnaryOperation u)
                {
                    unary = u; binary = GenerateSymbolByType(Facade.Symbols[last].GetType());
                }
                else
                {
                    unary = GenerateSymbolByType(Facade.Symbols[last].GetType());
                    binary = GenerateSymbolByType(Facade.Symbols[first].GetType());
                }

                try
                {
                    IExpressionTree prevSymb = InfixExpressionSymbols[exprPos - 1];

                    if (prevSymb is not IOperation)
                    {
                        return binary;
                    }
                }
                catch { }

                return unary;
            }
        }

        public IExpressionTree GenerateSymbolByType(Type type)
        {
            ConstructorInfo constructor = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];
            object[] args = new object[constructor.GetParameters().Length];

            return constructor.Invoke(args) as IExpressionTree;
        }

        public IExpressionTree GenerateSymbolByType(Type type, string str)
        {
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(string) });
            object[] args = new object[1] { str };

            return constructor.Invoke(args) as IExpressionTree;
        }

        public IExpressionTreeBuilder ShuntingYardAlgorithm()
        {
            OutputQueue = new Queue<IExpressionTree>(InfixExpressionSymbols.Count);
            Stack = new Stack<IExpressionTree>(InfixExpressionSymbols.Count);

            foreach (IExpressionTree tocken in InfixExpressionSymbols)
            {
                if (tocken is IPrimitive)
                {
                    OutputQueue.Enqueue(tocken);
                }
                else if (tocken is IFunction)
                {
                    Stack.Push(tocken);
                }
                else if (tocken is Comma)
                {
                    while (Stack.First() is not OpenBracket)
                    {
                        OutputQueue.Enqueue(Stack.Pop());
                    }
                }
                else if (tocken is IOperator op1)
                {
                    while (Stack.Any() && Stack.First() is IOperator op2 && op2.Rate < op1.Rate)
                    {
                        OutputQueue.Enqueue(Stack.Pop());
                    }
                    Stack.Push(tocken);
                }
                else if (tocken is OpenBracket)
                {
                    Stack.Push(tocken);
                }
                else if (tocken is ClosingBracket)
                {
                    while (Stack.Any() && Stack.First() is not OpenBracket)
                    {
                        OutputQueue.Enqueue(Stack.Pop());
                    }
                    Stack.Pop();
                    if (Stack.Any() && Stack.First() is IFunction)
                    {
                        OutputQueue.Enqueue(Stack.Pop());
                    }
                }
            }

            while (Stack.Any())
            {
                OutputQueue.Enqueue(Stack.Pop());
            }

            return this;
        }

        public IExpressionTreeBuilder BuildTree()
        {
            Stack<IExpressionTree> computationStack = new Stack<IExpressionTree>(OutputQueue.Count);

            while (OutputQueue.Any())
            {
                IExpressionTree elem = OutputQueue.Dequeue();

                if (elem is IPrimitive)
                {
                    computationStack.Push(elem);
                }
                else if (elem is IUnaryOperation unary)
                {
                    unary.A = computationStack.Pop();
                    computationStack.Push(unary);
                }
                else if (elem is IBinaryOperation binary)
                {
                    binary.B = computationStack.Pop();
                    binary.A = computationStack.Pop();
                    computationStack.Push(binary);
                }
                else if (elem is ITernaryOperation ternary)
                {
                    ternary.C = computationStack.Pop();
                    ternary.B = computationStack.Pop();
                    ternary.A = computationStack.Pop();
                    computationStack.Push(ternary);
                }
            }

            OutputTree = computationStack.Pop();

            return this;
        }
    }
}
