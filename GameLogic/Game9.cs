using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Game9
    {
        private int[,] _matrix9 = new int[9, 9];
        private bool[,] _stats9 = new bool[9, 9];
        private List<string> _dataList;

        public Game9(List<string> dataList)
        {
            _dataList = dataList;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _matrix9[i, j] = 0;
                    _stats9[i, j] = true;
                }
            }

            foreach (string item in _dataList)
            {
                string[] temp = item.Split(' ');
                int row = int.Parse(temp[0]);
                int col = int.Parse(temp[1]);
                int val = int.Parse(temp[2]);
                _matrix9[row, col] = val;
            }
        }

        public string Test()
        {
            string temp = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    temp = temp + _matrix9[i, j] + " ";
                }
                temp += "\n";
            }
            temp += "\n";
            return temp;
        }

        public string BoolTest()
        {
            string temp = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    temp = temp + _stats9[i, j] + " ";
                }
                temp += "\n";
            }
            temp += "\n";
            return temp;
        }

        public void ValueChange(int row, int col, int val)
        {
            _matrix9[row, col] = val;
        }

        public bool TestRow(int row, int col)
        {
            int cnt = 0;
            for (int i = 0; i < 9; i++)
            {
                if (_matrix9[row, col] == _matrix9[row, i])
                    cnt++;
            }
            if (cnt > 1 && _matrix9[row, col] != 0)
                return false;
            else
                return true;
        }

        public bool TestCol(int row, int col)
        {
            int cnt = 0;
            for (int i = 0; i < 9; i++)
            {
                if (_matrix9[row, col] == _matrix9[i, col])
                    cnt++;
            }
            if (cnt > 1 && _matrix9[row, col] != 0)
                return false;
            else
                return true;
        }

        public bool TestBlock(int row, int col)
        {
            int blockX = row / 3;
            int blockY = col / 3;
            int cnt = 0;
            for (int i = blockX * 3; i < blockX * 3 + 3; i++)
            {
                for (int j = blockY * 3; j < blockY * 3 + 3; j++)
                {
                    if (_matrix9[row, col] == _matrix9[i, j])
                        cnt++;
                }
            }
            if (cnt > 1 && _matrix9[row, col] != 0)
                return false;
            else
                return true;

        }



        public bool TestValid(int row, int col)
        {
            if (TestRow(row, col) && TestCol(row, col) && TestBlock(row, col))
            {
                _stats9[row, col] = true;
                return true;
            }
            else
            {
                _stats9[row, col] = false;
                return false;
            }
        }

        public bool TestComplete()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_matrix9[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        public bool TestWin()
        {
            if (TestComplete())
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (_stats9[i, j] == false)
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
