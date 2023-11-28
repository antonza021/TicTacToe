using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    class Game
    {
        //дефолт значения игрока
        public Game(int boardSize)
        {
            Board = new Board(boardSize);
            Player = new Player("V");
            Opponent = new Player("Z");
            Winner = null;
            Finished = false;
        }
        //доступы игрока
        public Player Player
        {
            get; private set;
        }

        private Player Opponent
        {
            get; set;
        }

        public Player Winner
        {
            get; private set;
        }

        private Board Board
        {
            get; set;
        }

        public bool Finished
        {
            get; private set;
        }

        public List<Cell> Cells
        {
            get
            {
                return Board.Cells;
            }
        }
        //разрешение на ход
        public bool MakeMove(int cellId)
        {
            Cell cell = Board.Cells[cellId];

            if (cell.Player == null && !Finished)
            {
                cell.Player = Player;
                Player = Opponent;
                Opponent = cell.Player;
                //проверка победки
                Finished = CheckWinCondition();
                return true;
            }

            return false;
        }
        // чек фор вин 
        private bool CheckWinCondition()
        {
            bool result = true;
            foreach (Cell cell in Cells)
            {
                if (cell.Player == null)
                {
                    result = false;
                    break;
                }
            }

            return HasWon(Player) || HasWon(Opponent) || result;
        }
        //проверка по столбам диагоналям и строкам
        private bool HasWon(Player player)
        {
            bool result;


            for (int row = 0; row < Board.Size; ++row)
            {
                result = true;
                for (int col = 0; col < Board.Size; ++col)
                {
                    if (!player.Equals(Cells[row * Board.Size + col].Player))
                    {
                        result = false;
                        break;
                    }
                }
                if (result)
                {
                    Winner = player;
                    return true;
                }
            }

            for (int col = 0; col < Board.Size; ++col)
            {
                result = true;
                for (int row = 0; row < Board.Size; ++row)
                {
                    if (!player.Equals(Cells[row * Board.Size + col].Player))
                    {
                        result = false;
                        break;
                    }
                }
                if (result)
                {
                    Winner = player;
                    return true;
                }
            }


            result = true;
            for (int cell = 0; cell < Board.Size; ++cell)
            {
                if (!player.Equals(Cells[cell * Board.Size + cell].Player))
                {
                    result = false;
                    break;
                }
            }
            if (result)
            {
                Winner = player;
                return true;
            }

            result = true;
            for (int cell = 0; cell < Board.Size; ++cell)
            {
                if (!player.Equals(Cells[(Board.Size - 1 - cell) * Board.Size + cell].Player))
                {
                    result = false;
                    break;
                }
            }
            if (result)
            {
                Winner = player;
                return true;
            }

            return false;
        }

    }
}
