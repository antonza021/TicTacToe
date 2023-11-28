using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    class Player
    {
        public Player(string id)
        {
            Id = id;
        }
        // доступ
        public string Id
        {
            get; private set;
        }
    }
}