using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
    class TicTacToeViewModel : INotifyPropertyChanged
    {
        //размер по умолчанию
        public event PropertyChangedEventHandler PropertyChanged;
        private const int DEFAULT_SIZE = 3;
        private Game game;

        public TicTacToeViewModel()
        {
            Game = new Game(DEFAULT_SIZE);
        }
        //доступы
        public Game Game
        {
            get
            {
                return game;
            }
            private set
            {
                game = value;
                OnPropertyChanged("Game");
                OnPropertyChanged("GameFinished");
                OnPropertyChanged("CurrentPlayer");
                OnPropertyChanged("Winner");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Player Winner
        {
            get
            {
                return Game.Winner;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return Game.Player;
            }
        }

        public bool GameFinished
        {
            get
            {
                return Game.Finished;
            }
        }
        //кнопки
        public ICommand NewGame
        {
            get
            {
                return new RelayCommand<int>(HandleNewGame);
            }
        }

        public ICommand CellClick
        {
            get
            {
                return new RelayCommand<int>(HandleCellClick);
            }
        }
        //нью гей м
        public void HandleNewGame(int boardSize)
        {
            Game = new Game(boardSize);
        }
        //обработка нажатия
        public void HandleCellClick(int cellId)
        {
            if (Game.MakeMove(cellId))
            {
                OnPropertyChanged("CurrentPlayer");
                if (Game.Finished)
                {
                    OnPropertyChanged("GameFinished");
                    OnPropertyChanged("Winner");
                }
            }
        }

    }
}