using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TicTacToe
{
    public class GameState
    {
        public static bool NextIsX { get; set; }
        public static int Steps { get; set; }
        public static bool GameEnded { get; set; }

        public static bool SomeoneHasWon(List<List<Cell>> board)
        {
            ///rows
            if (board[0][0].Content != "" && board[0][0] == board[0][1] && board[0][1] == board[0][2])
            {
                return true;
            }
            if (board[1][0].Content != "" && board[1][0] == board[1][1] && board[1][1] == board[1][2])
            {
                return true;
            }
            if (board[2][0].Content != "" && board[2][0] == board[2][1] && board[2][1] == board[2][2])
            {
                return true;
            }

            //columns
            if (board[0][0].Content != "" && board[0][0] == board[1][0] && board[1][0] == board[2][0])
            {
                return true;
            }
            if (board[0][1].Content != "" && board[0][1] == board[1][1] && board[1][1] == board[2][1])
            {
                return true;
            }
            if (board[0][2].Content != "" && board[0][2] == board[1][2] && board[1][2] == board[2][2])
            {
                return true;
            }

            //diagnal
            if (board[0][0].Content != "" && board[0][0] == board[1][1] && board[1][1] == board[2][2])
            {
                return true;
            }
            if (board[0][2].Content != "" && board[0][2] == board[1][1] && board[1][1] == board[2][0])
            {
                return true;
            }

            return false;
        }
    }
}
