using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    public class WinChecker
    {
        public State Check(Grid grid)
        {
            if (CheckForWin(grid, State.W)) return State.W;
            if (CheckForWin(grid, State.w)) return State.w;
            if(CheckForWin(grid, State.R)) return State.R;
            if(CheckForWin(grid, State.r)) return State.r;
            return State.Undecided;
        }

        private bool CheckForWin(Grid grid, State player)
        {
            for (int row = 0; row < 7; row++)
                if (AreAll(grid, new Position[] {
                        new Position(row, 0),
                        new Position(row, 1),
                        new Position(row, 2) }, player))
                    return true;

            for (int column = 0; column < 7; column++)
                if (AreAll(grid, new Position[] {
                        new Position(0, column),
                        new Position(1, column),
                        new Position(2, column) }, player))
                    return true;

            if (AreAll(grid, new Position[] {
                    new Position(0, 0),
                    new Position(1, 1),
                    new Position(2, 2) }, player))
                return true;

            if (AreAll(grid, new Position[] {
                    new Position(2, 0),
                    new Position(1, 1),
                    new Position(0, 2) }, player))
                return true;

            return false;
        }

        private bool AreAll(Grid grid, Position[] positions, State state)
        {
            foreach (Position position in positions)
                if (grid.GetState(position) != state) return false;

            return true;
        }



        public bool IsDraw(Grid grid)
        {
            for (int row = 0; row < 7; row++)
                for (int column = 0; column < 7; column++)
                    if (grid.GetState(new Position(row, column)) == State.Undecided) return false;

            return true;
        }
    }
}
