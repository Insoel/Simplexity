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
        public Player NextTurn { get; private set; }
        public State NextTurn2 { get; private set; }

        public Grid()
        {
            state = new State[7, 7];
        }

        public State GetState(Position position)
        {
            return state[position.Row, position.Column];
        }

        public State GetState(Position position, int rowChecker)
        {
            return state[position.Row - rowChecker, position.Column];
        }

        public bool SetState(Position position, Player playerState, State newState, int rowChecker2)
        {
            if (playerState != NextTurn) return false;
            if (state[position.Row - rowChecker2, position.Column] != State.Undecided) return false;
            state[position.Row - rowChecker2, position.Column] = newState;
            SwitchNextTurn();

            return true;
        }

        public bool SetState(Position position, Player playerState, State newState, int rowChecker2, bool first)
        {
            if (playerState != NextTurn) return false;
            if (state[position.Row - rowChecker2, position.Column] != State.Undecided) return false;
            newState = State.W;
            state[position.Row - rowChecker2, position.Column] = newState;
            SwitchNextTurn();

            return true;
        }


        private void SwitchNextTurn()
        {
            if (NextTurn == Player.p1)
            {
                NextTurn = Player.p2;
                NextTurn2 = State.R;
            }
            else
            {
                NextTurn = Player.p1;
                NextTurn2 = State.W;
            }
        }

        public int RowInUse(int position, int rowChecker)
        {
            Position pos = new Position(6 - rowChecker, position - 1);
            if (state[pos.Row, (pos.Column)] != State.Undecided && rowChecker < 6)
                {
                    rowChecker++;
                return RowInUse(position, rowChecker);

                }
            return rowChecker;
        }

    }
}
