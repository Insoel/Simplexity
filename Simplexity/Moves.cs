using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    public class Moves
    {
        public Position GetPosition(Grid grid, int rowChecker) //Gets an input from the user and converts it to a position in the grid
        {
            int position = Convert.ToInt32(Console.ReadLine());
            Position desiredCoordinate = PositionForNumber(position, grid, rowChecker);
            rowChecker = 0;
            return desiredCoordinate;
        }

        public Position PositionForNumber(int position, Grid grid, int rowChecker)  //After getting the position, the method calls another one to check if that row is open for the piece,
                                                                                    //if it isn't it then it returns the rowChecker which lets this method know in which row to place it
        {
            int rowChecker2 = grid.RowInUse(position, rowChecker);
            switch (position)
            {
                case 1: return new Position(6 - rowChecker2, 0);
                case 2: return new Position(6 - rowChecker2, 1); 
                case 3: return new Position(6 - rowChecker2, 2);
                case 4: return new Position(6 - rowChecker2, 3);
                case 5: return new Position(6 - rowChecker2, 4);
                case 6: return new Position(6 - rowChecker2, 5);
                case 7: return new Position(6 - rowChecker2, 6);
                default: return null;
            }
        }
        
                
    }
}
