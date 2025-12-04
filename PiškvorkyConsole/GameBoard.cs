using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace PiškvorkyConsole
{
    public class GameBoard
    {
        public char[,] board = new char[3, 3];
        public char CurrentPlayer { get; set; } = 'X';
        public Stack<(int, int, char)> historie = new Stack<(int, int, char)>();

        public GameBoard()
        {
            ResetBoard();
        }

        public bool MakeMove(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ')
            {
                return false;
            }
            historie.Push((row, col, CurrentPlayer));
            board[row, col] = CurrentPlayer;
            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
            return true;
        }

        public bool CheckWin(char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                    (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                    return true;
            }
            return (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                   (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player);
        }

        public bool IsBoardFull()
        {
            foreach (var cell in board)
                if (cell == ' ') return false;
            return true;
        }

        public void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = ' ';
            CurrentPlayer = 'X';
        }

        public int EvaluateBoard()
        {
            if (CheckWin('O')) return 10;
            if (CheckWin('X')) return -10;
            return 0;
        }

        public int MiniMax(int depth, bool isMaximizing)
        {
            int score = EvaluateBoard();
            if (score == 10 || score == -10 || IsBoardFull()) return score;

            if (isMaximizing)
            {
                int best = -1000;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == ' ')
                        {
                            board[i, j] = 'O';
                            best = Math.Max(best, MiniMax(depth + 1, false));
                            board[i, j] = ' ';
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = 1000;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == ' ')
                        {
                            board[i, j] = 'X';
                            best = Math.Min(best, MiniMax(depth + 1, true));
                            board[i, j] = ' ';
                        }
                    }
                }
                return best;
            }
        }

        public (int, int) GetBestMove()
        {
            int bestValue = -1000;
            int bestRow = -1, bestCol = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        board[i, j] = 'O';
                        int moveValue = MiniMax(0, false);
                        board[i, j] = ' ';
                        if (moveValue > bestValue)
                        {
                            bestRow = i;
                            bestCol = j;
                            bestValue = moveValue;
                        }
                    }
                }
            }
            return (bestRow, bestCol);
        }
        public bool UndoMove(int row, int col)
        {
            if(historie.Count > 0)
            {
                var lastMove = historie.Peek();
                board[lastMove.Item1, lastMove.Item2] = ' ';
                CurrentPlayer = lastMove.Item3;
                return true;
            }
            return false;
        }

    }
}
