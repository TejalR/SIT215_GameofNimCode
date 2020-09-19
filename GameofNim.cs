using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GONsolution
{
    class Program
    {
        const int COMPUTER = 1;
        const int HUMAN = 2;

        public struct move
        {
            public int pile_index;
            public int stones_removed;
        };

        static public void showPiles(int[] piles, int n)
        {

            Console.Write("Current Game Status - > ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(piles[i].ToString() + " ");
            }
            Console.WriteLine();
            return;
        }

        static public bool gameOver(int[] piles, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (piles[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        static public void declareWinner(int whoseTurn)
        {
            if (whoseTurn == COMPUTER)
            {
                Console.WriteLine("Human won!!!");
            }
            else
            {
                Console.WriteLine("Computer won!!!");
            }
            return;
        }

        static public int calculateNimSum(int[] piles, int n)
        {
            int nimsum = piles[0];

            for (int i = 1; i < n; i++)
            {
                nimsum = nimsum ^ piles[i];
            }
            return nimsum;
        }

        static public void makeMove(int[] piles, int n, ref move moves)
        {
            int nim_sum = calculateNimSum(piles, n);
            if (nim_sum != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if ((piles[i] ^ nim_sum) < piles[i])
                    {
                        moves.pile_index = i;
                        moves.stones_removed = piles[i] - (piles[i] ^ nim_sum);
                        piles[i] = (piles[i] ^ nim_sum);
                        break;
                    }
                }
            }
            else
            {
                int[] non_zero_indices = new int[n];
                int count = 0;

                for (int i = 0; i < n; i++)
                {
                    if (piles[i] > 0)
                        non_zero_indices[count++] = i;
                }

                Random random = new Random();

                Console.WriteLine(count);

                int v = random.Next(0, count - 1);

                moves.pile_index = (random.Next(0, count - 1));
                moves.stones_removed = 1 + (random.Next(piles[moves.pile_index] - 1));

                piles[moves.pile_index] = piles[moves.pile_index] - moves.stones_removed;

                if (piles[moves.pile_index] < 0)
                    piles[moves.pile_index] = 0;
            }
        }

        static public void humanMove(int[] piles, int n, ref move moves)
        {
            int pileNum = 0, num = 0;
            string temp;
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine("Input must be a number between 1 and " + n.ToString() + "!");
                Console.Write("Which pile? (1 to " + n.ToString() + ") ");
                temp = Console.ReadLine();
                valid = int.TryParse(temp, out pileNum);
                if (valid)
                {
                    pileNum = Convert.ToInt32(temp);

                    if (pileNum < 1 || pileNum > n)
                    {
                        valid = false;
                    }
                }
            }

            valid = false;

            while (!valid)
            {
                Console.WriteLine("Input must be a number between 1 and " + piles[pileNum - 1].ToString() + "!");
                Console.Write("How many? (1 to " + piles[pileNum - 1].ToString() + ") ");
                temp = Console.ReadLine();
                valid = int.TryParse(temp, out num);
                if (valid)
                {
                    num = Convert.ToInt32(temp);

                    if (num < 1 || num > piles[pileNum - 1])
                    {
                        valid = false;
                    }
                }
            }

            //Console.Write("How many? ");
            //temp = Console.ReadLine();

            //num = Convert.ToInt32(temp);

            moves.pile_index = pileNum - 1;
            moves.stones_removed = num;

            piles[moves.pile_index] = piles[moves.pile_index] - moves.stones_removed;
        }

        static public void playGame(int[] piles, int n, int whoseTurn)
        {
            Console.WriteLine("\nGAME STARTS\n");
            move moves = new move();

            while (gameOver(piles, n) == false)
            {
                showPiles(piles, n);

                if (whoseTurn == COMPUTER)
                {
                    makeMove(piles, n, ref moves);
                    Console.WriteLine("===== COMPUTER removes " + moves.stones_removed.ToString() + " stones from pile at index " +
                           moves.pile_index.ToString() + " ====== ");
                    whoseTurn = HUMAN;
                }
                else
                {
                    humanMove(piles, n, ref moves);
                    Console.WriteLine("===== HUMAN removes " + moves.stones_removed.ToString() + " stones from pile at index " + moves.pile_index.ToString() + " ===== ");
                    whoseTurn = COMPUTER;
                }
            }

            showPiles(piles, n);
            declareWinner(whoseTurn);
            return;
        }

        static public void knowWinnerBeforePlaying(int[] piles, int n, int whoseTurn)
        {
            Console.WriteLine("Prediction before playing the game -> ");

            if (calculateNimSum(piles, n) != 0)
            {
                if (whoseTurn == COMPUTER)
                    Console.WriteLine("COMPUTER will win");
                else
                    Console.WriteLine("HUMAN will win");
            }
            else
            {
                if (whoseTurn == COMPUTER)
                    Console.WriteLine("HUMAN will win");
                else
                    Console.WriteLine("COMPUTER will win");
            }
            return;
        }

        static void Main(string[] args)
        {
            int[] piles = { 4, 1, 8, 6 };
            int n = piles.Length;

            knowWinnerBeforePlaying(piles, n, COMPUTER);

            playGame(piles, n, COMPUTER);

            Console.ReadKey();
        }
    }
}