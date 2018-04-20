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
            if (CheckForWin(grid, State.R)) return State.R;
            if (CheckForWin(grid, State.r)) return State.r;
            return State.Undecided;
        }

        private bool CheckForWin(Grid grid, State player)
        {
            for (int row = 0; row < 7; row++)
                for (int possib = 0; possib < 4; possib++)
                {
                    if (AreAll(grid, new Position[] {
                            new Position(row, possib),
                            new Position(row, possib + 1),
                            new Position(row, possib + 2),
                            new Position(row, possib + 3) }, player))
                        return true;
                }
                    

            for (int column = 0; column < 7; column++)
                for (int possib = 0; possib < 3; possib++)
                {
                    if (AreAll(grid, new Position[] {
                            new Position(possib, column),
                            new Position(possib + 1, column),
                            new Position(possib + 2, column),
                            new Position(possib + 3, column) }, player))
                        return true;
                }
                    

            for (int possib = 0; possib < 3; possib++)
            {
                if (AreAll(grid, new Position[] {
                        new Position(0, possib),
                        new Position(1, possib + 1),
                        new Position(2, possib + 2),
                        new Position(3, possib + 3) }, player))
                    return true;
            }
                
            for (int possib = 6; possib > 3; possib--)
            {
                if (AreAll(grid, new Position[] {
                        new Position(0, possib),
                        new Position(1, possib - 1),
                        new Position(2, possib - 2),
                        new Position(3, possib - 3) }, player))
                    return true;
            }

            for (int possib = 1; possib < 3; possib++)
            {
                if (AreAll(grid, new Position[] {
                        new Position(possib, 6),
                        new Position(possib + 1, 5),
                        new Position(possib + 2, 4),
                        new Position(possib + 3, 3) }, player))
                    return true;
            }

            for (int possib = 1; possib < 3; possib++)
            {
                if (AreAll(grid, new Position[] {
                        new Position(possib, 0),
                        new Position(possib + 1, 1),
                        new Position(possib + 2, 2),
                        new Position(possib + 3, 3) }, player))
                    return true;
            }

            for (int possib = 6; possib > 4; possib--)
            {
                if (AreAll(grid, new Position[] {
                        new Position(possib, 0),
                        new Position(possib - 1, 1),
                        new Position(possib - 2, 2),
                        new Position(possib - 3, 3) }, player))
                    return true;
            }

            for (int possib = 1; possib < 2; possib++)
            {
                if (AreAll(grid, new Position[] {
                        new Position(6, possib),
                        new Position(5, possib + 1),
                        new Position(4, possib + 2),
                        new Position(3, possib + 3) }, player))
                    return true;
            }

            for(int possib = 5; possib > 4; possib--)
            {
                if (AreAll(grid, new Position[] {
                        new Position(6, possib),
                        new Position(5, possib - 1),
                        new Position(4, possib - 2),
                        new Position(3, possib - 3) }, player))
                    return true;
            }

            for(int possib = 6; possib > 4; possib--)
            {
                if (AreAll(grid, new Position[] {
                        new Position(possib, 6),
                        new Position(possib - 1, 5),
                        new Position(possib - 2, 4),
                        new Position(possib - 3, 3) }, player))
                    return true;
            }

            if (AreAll(grid, new Position[] {
                        new Position(1, 1),
                        new Position(2, 2),
                        new Position(3, 3),
                        new Position(4, 4) }, player))
                return true;

            if (AreAll(grid, new Position[] {
                        new Position(2, 1),
                        new Position(3, 2),
                        new Position(4, 3),
                        new Position(5, 4) }, player))
                return true;

            if (AreAll(grid, new Position[] {
                        new Position(1, 2),
                        new Position(2, 3),
                        new Position(3, 4),
                        new Position(4, 5) }, player))
                return true;

            if (AreAll(grid, new Position[] {
                        new Position(2, 2),
                        new Position(3, 3),
                        new Position(4, 4),
                        new Position(5, 5) }, player))
                return true;

            if (AreAll(grid, new Position[] {
                        new Position(1, 4),
                        new Position(2, 3),
                        new Position(3, 2),
                        new Position(4, 1) }, player))
                return true;

            if (AreAll(grid, new Position[] {
                        new Position(1, 5),
                        new Position(2, 4),
                        new Position(3, 3),
                        new Position(4, 2) }, player))
                return true;

            if (AreAll(grid, new Position[] {
                        new Position(2, 5),
                        new Position(3, 4),
                        new Position(4, 3),
                        new Position(5, 2) }, player))
                return true;

            if (AreAll(grid, new Position[] {
                        new Position(5, 1),
                        new Position(4, 2),
                        new Position(3, 3),
                        new Position(2, 4) }, player))
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
