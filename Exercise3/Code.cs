using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class Code
    {
        static void Main(string[] args)
        {
            bool startBottom=true;
            int i = 1;
            TicTacToe tictactoe = new TicTacToe();
            tictactoe.Default();
            while (startBottom)
            {
                    tictactoe.Player(i++);
                    if (tictactoe.CheckWinner())
                    {
                        tictactoe.Chart();
                        Console.WriteLine("Congratulations Player {0} you've won the game", i - 1);
                        Console.WriteLine("Press any key to reload the game");
                        i = 1; tictactoe.Default();
                        Console.ReadKey(); Console.Clear();
                    }
                    if (i == 3)
                    {
                        i = 1;
                    }
            }

        }
    }
}
