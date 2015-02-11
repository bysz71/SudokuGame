using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Game
    {
        protected int _gameSize;
        protected List<string> _dataList;

        public Game()
        {

        }

        public Game(int gameSize, List<string> dataList)
        {
            _gameSize = gameSize;
            _dataList = dataList;
        }
    }
}
