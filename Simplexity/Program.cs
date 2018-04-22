using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid();
            WinChecker winChecker = new WinChecker();
            Renderer renderer = new Renderer();
            Player player1 = new Player();
            Player player2 = new Player();
            int rowChecker = 0;


            while (!winChecker.IsDraw(grid, rowChecker) && winChecker.Check(grid) == State.Undecided)
            {
                renderer.Render(grid, rowChecker);

                Position nextMove;
                if (grid.NextTurn == State.W)
                {
                    nextMove = player1.GetPosition(grid, rowChecker);
                    //Console.WriteLine(() + "_1");
                }
                    
                else
                {
                    nextMove = player2.GetPosition(grid, rowChecker);
                    //Console.WriteLine(nextMove.ToString() + "_2");
                }
                    

                if (!grid.SetState(nextMove, grid.NextTurn, rowChecker))
                    Console.WriteLine("That is not a legal move.");
            }

            renderer.Render(grid, rowChecker);
            renderer.RenderResults(winChecker.Check(grid));

            Console.ReadKey();
        }
    }
}
