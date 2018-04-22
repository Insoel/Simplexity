using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    /// <summary>
    /// Class Grid that gets the positions/states and sets the positions/states
    /// </summary>
    public class Grid
    {
        
        public State[,] state;
        public Player NextTurn { get; private set; } //Defines which player goes
        public State NextTurn2 { get; private set; } //Defines which piece the player uses

        /// <summary>
        /// Creates a  7 by 7 array/grid
        /// </summary>
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

        /// <summary>
        /// Method that checks if a move is valid and then sets it on that position if it is
        /// </summary>
        /// <param name="position"></param>
        /// <param name="playerState"></param>
        /// <param name="newState"></param>
        /// <param name="rowChecker2"></param>
        /// <returns></returns>
        public bool SetState(Position position, Player playerState, State newState, int rowChecker2)
        {
            if (playerState != NextTurn) return false;
            if (state[position.Row - rowChecker2, position.Column] != State.Undecided) return false;
            state[position.Row - rowChecker2, position.Column] = newState;
            SwitchNextTurn();

            return true;
        }

        /// <summary>
        /// Method that checks if a move is valid and then sets it on that position if it is
        /// </summary>
        /// <param name="position"></param>
        /// <param name="playerState"></param>
        /// <param name="newState"></param>
        /// <param name="rowChecker2"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public bool SetState(Position position, Player playerState, State newState, int rowChecker2, bool first)
        {
            if (playerState != NextTurn) return false;
            if (state[position.Row - rowChecker2, position.Column] != State.Undecided) return false;
            newState = State.W;
            state[position.Row - rowChecker2, position.Column] = newState;
            SwitchNextTurn();

            return true;
        }

        /// <summary>
        /// Method that checks current turn and swaps the player and piece used around
        /// </summary>
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
        /// <summary>
        /// Method that checks if the current row that the piece is falling on is being used, if so it then calls itself and checks again on the row above and so on until it reaches an open row
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rowChecker"></param>
        /// <returns></returns>
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
