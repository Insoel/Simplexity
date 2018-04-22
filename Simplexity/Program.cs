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
            Moves player1 = new Moves();
            Moves player2 = new Moves();
            int rowChecker = 0; // Var that tell the method which row it is supposed to check for an open space

            Console.WriteLine("Welcome to my wannabe Simplexity Game \n");
            Console.WriteLine("Here are the rules:\n");
            Console.WriteLine(" - Press from 1 to 7 to choose the column you want to put your piece on. \n");
            Console.WriteLine(" - Player 1 goes first, and is the white pieces. \n");
            Console.WriteLine(" - First one to score 4 in a line with either Lowercase or Uppercase Wins. \n ");
            Console.WriteLine("Ready to play? (Y/N)");

            string answer = Console.ReadLine(); //String checks if the player wants to start the gameloop

            if (answer == "Y" || answer == "y")
            {
                bool first = true; //Var that checks if it's the first turn
                while (!winChecker.IsDraw(grid, rowChecker) && winChecker.Check(grid) == State.Undecided)
                {



                    renderer.Render(grid, rowChecker); //Renders the grid every loop


                    Position nextMove; //Recieves the input from the player and assigns it to this var.
                    if (grid.NextTurn == Player.p1)
                    {
                        if (first != false)
                        {
                            //Console.WriteLine("Player 1, choose your piece. Cilinder or Cube?");
                            //answer = Console.ReadLine();
                            Console.WriteLine("Player 1, choose which column to put your piece on");
                            nextMove = player1.GetPosition(grid, rowChecker);
                            first = false;
                            if (!grid.SetState(nextMove, grid.NextTurn, grid.NextTurn2, rowChecker, first))
                            {

                            }
                                
                        }
                        else
                        {
                            //Console.WriteLine("Player 1, choose your piece. Cilinder or Cube?");
                            //answer = Console.ReadLine();
                            Console.WriteLine("Player 1, choose which column to put your piece on");
                            nextMove = player1.GetPosition(grid, rowChecker);
                        }
                        
                    }
                    else
                    {
                        //Console.WriteLine("Player 2, choose your piece. Cilinder or Cube?");
                        //answer = Console.ReadLine();
                        Console.WriteLine("Player 2, choose which column to put your piece on");
                        nextMove = player2.GetPosition(grid, rowChecker);
                    }


                    if (!grid.SetState(nextMove, grid.NextTurn, grid.NextTurn2, rowChecker))
                        Console.WriteLine("That is not a valid move.");
                }

                renderer.Render(grid, rowChecker);
                renderer.RenderResults(winChecker.Check(grid));
            }
            Console.WriteLine("I'll see ya next time, goodbye!");
        }
    }
}
