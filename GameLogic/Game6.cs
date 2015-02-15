using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Game6
    {
        private int[,] _matrix6 = new int[6, 6];
        private bool[,] _stats6 = new bool[6, 6];
        private List<string> _dataList;

        public Game6(List<string> dataList)
        {
            _dataList = dataList;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    _matrix6[i, j] = 0;
                    _stats6[i, j] = true;
                }
            }

            foreach (string item in _dataList)
            {
                string[] temp = item.Split(' ');
                int row = int.Parse(temp[0]);
                int col = int.Parse(temp[1]);
                int val = int.Parse(temp[2]);
                _matrix6[row, col] = val;
            }
        }

        public string Test()
        {
            string temp = "";
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp = temp + _matrix6[i, j] + " ";
                }
                temp += "\n";
            }
            temp += "\n";
            return temp;
        }

        public string BoolTest()
        {
            string temp = "";
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp = temp + _stats6[i, j] + " ";
                }
                temp += "\n";
            }
            temp += "\n";
            return temp;
        }

        public void ValueChange(int row, int col, int val)
        {
            _matrix6[row, col] = val;
        }

        public bool TestRow(int row, int col)
        {
            int cnt = 0;
            for (int i = 0; i < 6; i++)
            {
                if (_matrix6[row, col] == _matrix6[row, i])
                    cnt++;
            }
            if (cnt > 1 && _matrix6[row, col] != 0)
                return false;
            else
                return true;
        }

        public bool TestCol(int row, int col)
        {
            int cnt = 0;
            for (int i = 0; i < 6; i++)
            {
                if (_matrix6[row, col] == _matrix6[i, col])
                    cnt++;
            }
            if (cnt > 1 && _matrix6[row, col] != 0)
                return false;
            else
                return true;
        }

        public bool TestBlock(int row, int col)
        {
            int blockX = row / 2;
            int blockY = col / 3;
            int cnt = 0;
            for (int i = blockX * 2; i < blockX * 2 + 2; i++)
            {
                for (int j = blockY * 3; j < blockY * 3 + 3; j++)
                {
                    if (_matrix6[row, col] == _matrix6[i, j])
                        cnt++;
                }
            }
            if (cnt > 1 && _matrix6[row, col] != 0)
                return false;
            else
                return true;

        }



        public bool TestValid(int row, int col)
        {
            if (TestRow(row, col) && TestCol(row, col) && TestBlock(row, col))
            {
                _stats6[row, col] = true;
                return true;
            }
            else
            {
                _stats6[row, col] = false;
                return false;
            }
        }

        public bool TestComplete()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (_matrix6[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        public bool TestWin()
        {
            if (TestComplete())
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (_stats6[i, j] == false)
                            return false;
                    }
                    Console.Write("\n");
                }
                return true;
            }
            else
                return false;
        }



    }
}
