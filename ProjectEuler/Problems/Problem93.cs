using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace ProjectEuler.Problems
{
    public static class Problem93
    {
        private static readonly List<Operation> operations = Enum.GetValues(typeof(Operation)).Cast<Operation>().ToList();
        private static readonly List<List<Operation>> operationOrderings = (from a in operations
                                                                            from b in operations
                                                                            from c in operations
                                                                            select new List<Operation> { a, b, c })
                                                                           .ToList();
        private static readonly List<List<int>> parenthesisOrderings = Combinatorics.GetFullPermutations(Enumerable.Range(1, 3)).Select(x => x.ToList()).ToList();

        public static string Solve()
        {
            string answer = "";
            int longestConsecutiveSet = 0;
            for (int a = 1; a < 7; a++)
            {
                for (int b = a + 1; b < 8; b++)
                {
                    for (int c = b + 1; c < 9; c++)
                    {
                        for (int d = c + 1; d < 10; d++)
                        {
                            int consecutiveSetLength = GetLengthOfConsecutiveTargetIntegers(new int[] { a, b, c, d });
                            if (consecutiveSetLength > longestConsecutiveSet)
                            {
                                longestConsecutiveSet = consecutiveSetLength;
                                answer = String.Format("{0}{1}{2}{3}", a, b, c, d);
                            }
                        }
                    }
                }
            }

            return answer;
        }

        public static int GetLengthOfConsecutiveTargetIntegers(int[] ds)
        {
            HashSet<int> expressibleTargets = new HashSet<int>();
            List<int[]> digitPerms = Combinatorics.GetFullPermutations(ds).Select(x => x.ToArray()).ToList();

            foreach (int[] digits in digitPerms)
            {
                foreach (List<Operation> operationOrder in operationOrderings)
                {
                    foreach (List<int> parenthesisOrder in parenthesisOrderings)
                    {
                        double d = ConstructExpressionTree(digits, operationOrder, parenthesisOrder).NodeValue;
                        if (MiscUtils.IsInteger(d) && d > 0)
                        {
                            expressibleTargets.Add((int)d);
                        }
                    }
                }
            }

            List<int> sorted = expressibleTargets.ToList();
            sorted.Sort();
            expressibleTargets = new HashSet<int>(sorted);
            int max = expressibleTargets.Max();
            int longestSet = FindLongestConsecutiveSet(expressibleTargets);
            return longestSet;
        }

        public static int FindLongestConsecutiveSet(HashSet<int> set)
        {
            int i = 0;
            foreach (int n in set)
            {
                i++;
                if (n != i)
                {
                    return i - 1;
                }
            }
            return i;
        }


        public static ExpressionTree ConstructExpressionTree(int[] digits, List<Operation> opers, List<int> parens)
        {
            ExpressionTree[] nodes = new ExpressionTree[digits.Length];
            for (int i = 0; i < parens.Count; i++)
            {
                int idx1 = parens[i] - 1;
                int idx2 = parens[i];
                ExpressionTree a = nodes[idx1] == null ? new ExpressionTree(digits[idx1]) : nodes[idx1].GetRootExpressionTree();
                ExpressionTree b = nodes[idx2] == null ? new ExpressionTree(digits[idx2]) : nodes[idx2].GetRootExpressionTree();
                Operation op = opers[idx1];
                ExpressionTree exprTree = new ExpressionTree(a, b, op);
                if (nodes[idx1] == null)
                {
                    nodes[idx1] = exprTree;
                }
                if (nodes[idx2] == null)
                {
                    nodes[idx2] = exprTree;
                }
            }

            return nodes[0].GetRootExpressionTree();
        }

        public class ExpressionTree
        {
            public double NodeValue;
            ExpressionTree Left;
            ExpressionTree Right;
            ExpressionTree Parent;
            Operation Op;
            bool IsLeaf;

            public ExpressionTree(double d)
            {
                NodeValue = d;
                Left = null;
                Right = null;
                Parent = null;
                IsLeaf = true;
            }

            public ExpressionTree(ExpressionTree left, ExpressionTree right, Operation op)
            {
                Left = left;
                if (!Left.IsLeaf)
                {
                    Left.Parent = this;
                }
                Right = right;
                if (!Right.IsLeaf)
                {
                    Right.Parent = this;
                }
                Op = op;
                NodeValue = Evaluate();
                IsLeaf = false;
            }

            public ExpressionTree GetRootExpressionTree()
            {
                return Parent == null ? this : Parent.GetRootExpressionTree();
            }

            private double Evaluate()
            {
                return PerformOperation(Left.NodeValue, Right.NodeValue, Op);
            }

            public override string ToString()
            {
                return NodeValue.ToString();
            }
        }

        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }

        public static double PerformOperation(double a, double b, Operation op)
        {
            switch (op)
            {
                case Operation.Add:
                    return a + b;

                case Operation.Subtract:
                    return a - b;

                case Operation.Multiply:
                    return a * b;

                case Operation.Divide:
                    return a / b;

                default:
                    throw new ApplicationException("foobar exception");
            }
        }
    }
}
