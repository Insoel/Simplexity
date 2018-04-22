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
        public Player NextTurn { get; private set; } //Defines which player goes
        public State NextTurn2 { get; private set; } //Defines which piece the player uses

        public Grid()
        {
            state = new State[7, 7]; // 7 by 7 grid
        }

        public State GetState(Position position)
        {
            return state[position.Row, position.Column];
        }

        public State GetState(Position position, int rowChecker)
        {
            return state[position.Row - rowChecker, position.Column];
        }

        public bool SetState(Position position, Player playerState, State newState, int rowChecker2) //Method that checks if a move is valid and then sets it on that position if it is
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


        private void SwitchNextTurn() //Method that checks current turn and swaps the player and piece used around
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

        public int RowInUse(int position, int rowChecker)   //Method that checks if the current row that the piece is falling on is being used, 
                                                            // if so it then calls itself and checks again on the row above and so on until it reaches an open row
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
