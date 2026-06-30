using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_1
{
    internal interface IGamePosition
    {
        public double HeuristicValue();

        public Boolean IsTerminal();

        public IGamePosition[] GetChildren();
    }
}
