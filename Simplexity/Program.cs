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

            while (!winChecker.IsDraw(grid) && winChecker.Check(grid) == State.Undecided)
            {
                renderer.Render(grid);

                Position nextMove;
                if (grid.NextTurn == State.W)
                    nextMove = player1.GetPosition(grid);
                else
                    nextMove = player2.GetPosition(grid);

                if (!grid.SetState(nextMove, grid.NextTurn))
                    Console.WriteLine("That is not a legal move.");
            }

            renderer.Render(grid);
            renderer.RenderResults(winChecker.Check(grid));

            Console.ReadKey();
        }
    }
}
