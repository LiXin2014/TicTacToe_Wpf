using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace TicTacToe
{
    public class Cell : INotifyPropertyChanged
    {
        private string content;
        public string Content { 
            get { return content; } 
            set { 
                this.content = value;
                onPropertyChanged(nameof(Content));
            } 
        }

        public RelayCommand ButtonCommand { get; set; }

        public Cell(string content)
        {
            Content = content;
            ButtonCommand = new RelayCommand(ButtonClicked, CanButtonClick);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler OnClicked;

        public void ButtonClicked(object message)
        {
            if (GameState.NextIsX)
            {
                Content = "X";
            }
            else
            {
                Content = "O";
            }

            GameState.NextIsX = !GameState.NextIsX;
            GameState.Steps++;
            OnClicked?.Invoke(this, EventArgs.Empty);
        }

        public bool CanButtonClick(object message)
        {
            return Content.Equals(String.Empty) || GameState.GameEnded;
        }

        public void onPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Cell c = (Cell)obj;
                return (Content == c.Content);
            }
        }

        public static bool operator ==(Cell x, Cell y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Cell x, Cell y)
        {
            return !x.Equals(y);
        }
    }
}
