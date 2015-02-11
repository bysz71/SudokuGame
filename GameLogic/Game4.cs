using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
class Game4 : Game
    {
        private int[,] _matrix4 = new int[4,4];

        public Game4(int gameSize, List<string> dataList)
        {
            _gameSize = gameSize;
            _dataList = dataList;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _matrix4[i, j] = 0;
                }
            }

            foreach (string item in _dataList)
            {
                string[] temp = item.Split(' ');
                int row = int.Parse(temp[0]);
                int col = int.Parse(temp[1]);
                int val = int.Parse(temp[2]);
                _matrix4[row, col] = val;
            }
        }

        public void ValueChange(int row, int col, int val)
        {
            _matrix4[row, col] = val;
        }

        public bool TestRow(int row)
        {
            for (int i = 0; i < 4; i++)
            {
                int temp = _matrix4[row, i];
                int cnt = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (temp == _matrix4[row, j])
                        cnt++;
                }
                if (cnt != 1 && temp != 0)
                    return false;
            }
            return true;
        }

        public bool TestCol(int col)
        {
            for (int i = 0; i < 4; i++)
            {
                int temp = _matrix4[i, col];
                int cnt = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (temp == _matrix4[i, col])
                        cnt++;
                }
                if (cnt != 1 && temp != 0)
                    return false;
            }
            return true;
        }

        public bool TestBlock(int row, int col)
        {
            int blockX = row / 2;
            int blockY = col / 2;
            for (int i = blockX*2; i < blockX*2 + 2; i++)
            {
                for (int j = blockY*2; j < blockY*2 + 2; j++)
                {
                    int temp = _matrix4[i, j];
                    int cnt = 0;
                    for (int m = blockX * 2; m < blockX * 2 + 2; m++)
                    {
                        for (int n = blockY * 2; n < blockY * 2 + 2; n++)
                        {
                            if (temp == _matrix4[m, n])
                                cnt++;
                        }
                        if (cnt != 1)
                            return false;
                    }
                }
            }
            return true;
        }

        public bool TestFinish(int row, int col)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_matrix4[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


    }
}
