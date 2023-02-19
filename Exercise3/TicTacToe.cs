using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class TicTacToe
    {
        private int player;
        private int k, j;
        private bool ans1;
        private bool ans2;
        private bool checkNum { get; set; }
        private string[,] position { get; set; } = new string[3, 3];
        private int[] reviewBoxes { get; set; } = new int[9];
        private string x
        {
            get
            {
                return "X";
            }
        }
        private string circ
        {
            get
            {
                return "☻";
            }
        }
        public void Default()
        {
            position[0, 0] = "1";
            position[0, 1] = "2";
            position[0, 2] = "3";
            position[1, 0] = "4";
            position[1, 1] = "5";
            position[1, 2] = "6";
            position[2, 0] = "7";
            position[2, 1] = "8";
            position[2, 2] = "9";
            k = 0;j = 0;
            for (int i = 0; i < reviewBoxes.Length; i++)
            {
                reviewBoxes[i] = 0;
            }
        }
        public void Chart()
        {
            Console.WriteLine("     :     :");
            Console.WriteLine("  {0}  :  {1}  :  {2} ", position[0, 0], position[0, 1], position[0, 2]);
            Console.WriteLine("_____:_____:_____");
            Console.WriteLine("     :     :");
            Console.WriteLine("  {0}  :  {1}  :  {2} ", position[1, 0], position[1, 1], position[1, 2]);
            Console.WriteLine("_____:_____:_____");
            Console.WriteLine("     :     :");
            Console.WriteLine("  {0}  :  {1}  :  {2} ", position[2, 0], position[2, 1], position[2, 2]);
            Console.WriteLine("     :     :");
        }
        public void Player(int round)
        {
            Chart();
            do
            {
                if (round==1)
                {
                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                    Console.WriteLine("Player {0}: please choose a section...", round);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Player {0}: please choose a section...", round);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                checkNum = int.TryParse(Console.ReadLine(), out player);
                if (!checkNum || player < 1 || player > 9)
                {
                    Console.Clear();
                    Chart();
                    continue;
                }
            }
            while (!checkNum || player<1 || player>9);
            if (ReviewBoxes(player))
            {
                Player(round);
            }
            else
            {
                j++;
                switch (round)
                {
                     case 1: PlaceLetter(player, x); break;
                     case 2: PlaceLetter(player, circ); break;
                }
                reviewBoxes[k++] = player;
                if (CheckWinner() == false && j == 9)
                {
                    Chart();
                    Console.WriteLine("It's a TIE");
                    Console.WriteLine("Press any key to reload the game");
                    Console.ReadKey();
                    Default();
                    Console.Clear();
                    Player(1);
                }
            }
        }
        private void PlaceLetter(int player, string letter)
        {
            switch (player)
            {
                case 1:position[0, 0] = letter; break;
                case 2:position[0, 1] = letter; break;
                case 3:position[0, 2] = letter; break;
                case 4:position[1, 0] = letter; break;
                case 5:position[1, 1] = letter; break;
                case 6:position[1, 2] = letter; break;
                case 7:position[2, 0] = letter; break;
                case 8:position[2, 1] = letter; break;
                case 9:position[2, 2] = letter; break;
            }
            Console.Clear();
        }
        public bool CheckWinner()
        {
            ans1 = false;
            if (position[0, 0] == position[0,1] && position[0,1] == position[0,2])
            { ans1 = true; }            
            else if (position[1, 0] == position[1,1] && position[1,1] == position[1,2])
            { ans1 = true; }
            else if (position[2, 0] == position[2,1] && position[2,1] == position[2,2])
            { ans1 = true; }
            else if (position[0, 0] == position[1,0] && position[1,0] == position[2,0])
            { ans1 = true; }
            else if (position[0, 1] == position[1,1] && position[1,1] == position[2,1])
            { ans1 = true; }
            else if (position[0, 2] == position[1,2] && position[1,2] == position[2,2])
            { ans1 = true; }
            else if (position[0, 0] == position[1,1] && position[1,1] == position[2,2])
            { ans1 = true; }
            else if (position[0, 2] == position[1,1] && position[1,1] == position[2,0])
            { ans1 = true; }
            return ans1;
        }
        private bool ReviewBoxes(int player)
        {
            ans2= false;
            foreach (int item in reviewBoxes)
            {
                if (item==player)
                {
                    ans2 = true;
                    Console.Clear();
                }
            }
            return ans2;
        }
    }
}