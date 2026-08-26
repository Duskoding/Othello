using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_1
{
    internal static class MinimaxSolver
    {
        /// <summary>
        /// Runs Minimax with Alpha-Beta pruning.
        /// Returns the (heuristic value, best child position) pair.
        /// </summary>
        public static (double val, IGamePosition pos) Minimax(
        IGamePosition node,
        int depth,
        bool maximizingPlayer,
        double alpha = double.NegativeInfinity,
        double beta = double.PositiveInfinity)
        {
            if (depth == 0 || node.IsTerminal())
                return (node.HeuristicValue(), node);
            IGamePosition[] children = node.GetChildren(maximizingPlayer);

            if (children == null || children.Length == 0)
            {
                return (node.HeuristicValue(), node);
            }

            if (maximizingPlayer)
            {
                double bestVal = double.NegativeInfinity;
                IGamePosition bestPos = children[0];
                foreach (IGamePosition child in children)
                {
                    (double v, _) = Minimax(child, depth - 1, false, alpha, beta);
                    if (v > bestVal)
                    {
                        bestVal = v;
                        bestPos = child;
                    }
                    alpha = Math.Max(alpha, bestVal);
                    if (beta <= alpha) break; // β cut-off
                }
                return (bestVal, bestPos);
            }
            else
            {
                double bestVal = double.PositiveInfinity;
                IGamePosition bestPos = children[0];
                foreach (IGamePosition child in children)
                {
                    (double v, _) = Minimax(child, depth - 1, true, alpha, beta);
                    if (v < bestVal)
                    {
                        bestVal = v;
                        bestPos = child;
                    }
                    beta = Math.Min(beta, bestVal);
                    if (beta <= alpha) break; // α cut-off
                }
                return (bestVal, bestPos);
            }
        }
    }
}
