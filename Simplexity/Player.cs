using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    public class Player
    {
        public Position GetPosition(Grid grid)
        {
            int position = Convert.ToInt32(Console.ReadLine());
            Position desiredCoordinate = PositionForNumber(position);

            return desiredCoordinate;
        }

        private Position PositionForNumber(int position)
        {

            
            int rowChecker = 0;
            Grid grid2 = new Grid();
            int ttest = grid2.RowInUse(position, rowChecker);
            switch (position)
            {
                case 1: return new Position(6 - rowChecker, 0); // Bottom Left
                case 2: return new Position(6 - rowChecker, 1); // Bottom Middle 
                case 3: return new Position(6 - rowChecker, 2); // Bottom Right
                case 4: return new Position(6 - rowChecker, 3); // Middle Left
                case 5: return new Position(6 - rowChecker, 4); // Middle Middle
                case 6: return new Position(6 - rowChecker, 5); // Middle Right
                case 7: return new Position(6 - rowChecker, 6); // Top Left
                default: return null;
            }
        }
        
                
    }
}
