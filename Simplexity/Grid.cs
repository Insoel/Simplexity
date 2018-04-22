using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    public class Grid
    {
        public State[,] state;
        public State NextTurn { get; private set; }

        public Grid()
        {
            state = new State[7, 7];
        }

        public State GetState(Position position)
        {
            return state[position.Row, position.Column];
        }

        public bool SetState(Position position, State newState)
        {
            if (newState != NextTurn) return false;
            if (state[position.Row, position.Column] != State.Undecided) return false;

            state[position.Row, position.Column] = newState;
            SwitchNextTurn();
            return true;
        }

        private void SwitchNextTurn()
        {
            if (NextTurn == State.W) NextTurn = State.R;
            else NextTurn = State.W;
        }

        public int RowInUse(int position, int rowChecker)
        {
            Position pos = new Position(position, 6 - rowChecker);
            if (state[pos.Row, pos.Column] != State.Undecided)
            {
                if (rowChecker < 7)
                {
                    rowChecker++;
                    Console.WriteLine(rowChecker);
                    RowInUse(position, rowChecker);
                }
            }
                
            return rowChecker;
        }

    }
}
