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

        public State GetState(Position position, int rowChecker)
        {
            return state[position.Row - rowChecker, position.Column];
        }

        public bool SetState(Position position, State newState, int rowChecker2)
        {
            //Console.WriteLine((position.Row - rowChecker) + "_" + (position.Column) + "_" + state[position.Row - rowChecker, position.Column] + "_" + rowChecker);
            //Console.WriteLine(newState.ToString() + "_" + NextTurn.ToString());
            if (newState != NextTurn) return false;
           // Console.WriteLine(state[position.Row - rowChecker2, position.Column] + "_R" + rowChecker2 + "_P" + position.Row);
            //if (state[position.Row - rowChecker2, position.Column] != State.Undecided) return false;
            

            state[position.Row - rowChecker2, position.Column] = newState;
            //Console.WriteLine(state[4, 4].ToString());
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
            Position pos = new Position(6 - rowChecker, position - 1);
            
            //state[position, 6 - rowChecker] = 
            //Console.WriteLine(state[pos.Row, pos.Column].ToString() + "_" + State.Undecided.ToString() + "_" + rowChecker);
            //Console.WriteLine(linha + "_" + coluna);
            //Console.WriteLine(pos.Row + "_" + rowChecker + "_" + pos.Column + "_" + (6 - rowChecker));
            //Console.WriteLine(state[pos.Row - rowChecker, pos.Column].ToString());
            if (state[pos.Row, (pos.Column)] != State.Undecided && rowChecker < 6)
                {
                    rowChecker++;
                    Console.WriteLine(rowChecker);
                //RowInUse(position, rowChecker);
                return RowInUse(position, rowChecker);

                }
            return rowChecker;
        }

    }
}
