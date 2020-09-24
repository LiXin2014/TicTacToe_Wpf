using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace TicTacToe
{
    public class GameBoard : INotifyPropertyChanged
    {
        private List<List<Cell>> board;
        public List<List<Cell>> Board { get { return board; } private set { this.board = value; OnPropertyChanged(nameof(Board)); } }
        public int Rows { get; set; }

        /// <summary>
        /// Initialize GameModel
        /// </summary>
        /// <param name="num">represents board's size is num * num</param>
        public GameBoard(int num)
        {
            Board = new List<List<Cell>>();
            Rows = num;
            for (int i = 0; i < Rows; i++)
            {
                Board.Add(new List<Cell>());

                for (int j = 0; j < Rows; j++)
                {
                    Cell cell = new Cell("");
                    Board[i].Add(cell);
                    cell.OnClicked += CheckGameState;
                }
            }
            GameState.NextIsX = true;
            GameState.Steps = 0;
            GameState.GameEnded = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ReinitializeGame()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Board[i][j].Content = "";
                }
            }

            GameState.NextIsX = true;
            GameState.Steps = 0;
            GameState.GameEnded = false;
        }

        public void CheckGameState(object sender, EventArgs eventArgs)
        {
            Cell cell = sender as Cell;
            if (GameState.GameEnded)
            {
                ReinitializeGame();
            }
            if (GameState.SomeoneHasWon(Board))
            {
                MessageBox.Show($"{cell.Content} has won!");
                GameState.GameEnded = true;
            }
            else if (GameState.Steps == 9)
            {
                MessageBox.Show($"It's a tie!");
                GameState.GameEnded = true;
            }
        }

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
