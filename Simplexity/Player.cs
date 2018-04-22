using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    public class Player
    {
        public Position GetPosition(Grid grid, int rowChecker)
        {
            int position = Convert.ToInt32(Console.ReadLine());
            Position desiredCoordinate = PositionForNumber(position, grid, rowChecker);
            rowChecker = 0;
            return desiredCoordinate;
        }

        public Position PositionForNumber(int position, Grid grid, int rowChecker)
        {

            
            
            //int rowChecker2 = grid.RowInUse(position, rowChecker);
            int rowChecker2 = grid.RowInUse(position, rowChecker);
            Console.WriteLine( "_test" + rowChecker2);
            switch (position)
            {
                case 1:
                    return new Position(6 - rowChecker2, 0); // Bottom Left
                case 2: return new Position(6 - rowChecker2, 1); // Bottom Middle 
                case 3: return new Position(6 - rowChecker2, 2); // Bottom Right
                case 4: return new Position(6 - rowChecker2, 3); // Middle Left
                case 5: return new Position(6 - rowChecker2, 4); // Middle Middle
                case 6: return new Position(6 - rowChecker2, 5); // Middle Right
                case 7: return new Position(6 - rowChecker2, 6); // Top Left
                default: return null;
            }
        }
        
                
    }
}
