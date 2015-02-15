using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GameLogic;

namespace GameWinFrom
{
    public partial class Form1 : Form
    {
        Label[,] _map = new Label[9, 9];
        Game4 newGame4;
        Game6 newGame6;
        Game9 newGame9;
        int gameSize = 0;
        //
        //_map initiation
        //
        void InitMap()
        {
            //use loop to create 9*9 TextBox matrix
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    var temp = new Label();
                    temp.Text = "";
                    temp.Size = new Size(24, 24);
                    temp.Location = new Point(col * 30 + 30, row * 30 + 30);
                    temp.BorderStyle = BorderStyle.FixedSingle;
                    temp.BackColor = Color.White;
                    temp.Visible = false;
                    temp.Click += new System.EventHandler(this.Map_Click);
                    _map[row, col] = temp;
                    this.Controls.Add(temp);
                }
            }
        }
        //
        //form1 initiation
        //
        public Form1()
        {
            InitMap();
            InitializeComponent();
        }
        //
        //loadGame click event handler
        //
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                string line;
                StreamReader file = new StreamReader(fileName);
                try
                {
                    //read game size and read game template into a list
                    List<string> dataList = new List<string>();
                    line = file.ReadLine();
                    string temp = line.Substring(0, 1);
                    gameSize = int.Parse(temp);

                    while ((line = file.ReadLine()) != null)
                    {
                        dataList.Add(line);
                    }

                    //initiate the game with gameSize and template known
                    loadGameInit(gameSize, dataList);
                }
                catch (IOException)
                {
                }
                file.Close();
            }
        }
        //
        //game initiation
        //
        private void loadGameInit(int gameSize, List<string> dataList)
        {
            //tells user the game size
            labelGameSize.Text = "This is a " + gameSize + "*" + gameSize + " game.";
            labelSysMonitor.Text = "Console:>_ \n\n";
           // if (gameSize == 4)
                //Game4 newGame = new Game4(dataList);
            //else
               // Game6 newGame = new Game6(dataList);
            if (gameSize == 4)
                newGame4 = new Game4(dataList);
            else if (gameSize == 6)
                newGame6 = new Game6(dataList);
            else if (gameSize == 9)
                newGame9 = new Game9(dataList);

            //initiate the TextBox array property settings
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i < gameSize && j < gameSize)
                    {
                        _map[i, j].Visible = true;
                    }
                    else
                    {
                        _map[i, j].Visible = false;
                    }

                }
            }

            //present the game template to the System monitor label
            // and initiate the TextBox value and enability
            foreach (string item in dataList)
            {
                labelSysMonitor.Text = labelSysMonitor.Text + item + "\n";
                string[] tempArray = item.Split(' ');
                int row = int.Parse(tempArray[0]);
                int col = int.Parse(tempArray[1]);
                int val = int.Parse(tempArray[2]);
                _map[row, col].Text = val.ToString();
                _map[row, col].BackColor = Color.Transparent;

            }
        }
        //
        //label click event
        //
        private void Map_Click(object sender, EventArgs e)
        {
            if (((Label)sender).BackColor == Color.White)
            {
                labelSysMonitor.Text = "Console:>_ \n\n";

                int tempInt;
                int tempRow = 0;
                int tempCol = 0;
                string tempStr = ((Label)sender).Text;

                if (tempStr == "")
                    tempInt = 0;
                else
                    tempInt = int.Parse(tempStr);
                if (tempInt == 9)
                    tempInt = 0;
                tempInt++;
                tempStr = tempInt.ToString();
                ((Label)sender).Text = tempStr;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (((object)sender).Equals(_map[i, j]))
                        {
                            tempRow = i;
                            tempCol = j;
                        }
                    }
                }

                if (gameSize == 4)
                {
                    newGame4.ValueChange(tempRow, tempCol, tempInt);
                    labelSysMonitor.Text += newGame4.Test();

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (newGame4.TestValid(i, j))
                                ColorChangeBlack(i, j);
                            else
                                ColorChangeRed(i, j);
                        }
                    }

                    labelSysMonitor.Text += newGame4.BoolTest();
                    if (newGame4.TestComplete())
                        labelSysMonitor.Text += "completed\n\n";
                    else
                        labelSysMonitor.Text += "not completed\n\n";
                    if (newGame4.TestWin())
                    {
                        labelSysMonitor.Text += "you win\n";
                        MessageBox.Show("You win");
                        return;
                    }
                    else
                    {
                        labelSysMonitor.Text += "not win yet";
                    }
                }
                else if (gameSize == 6)
                {
                    newGame6.ValueChange(tempRow, tempCol, tempInt);
                    labelSysMonitor.Text += newGame6.Test();

                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (newGame6.TestValid(i, j))
                                ColorChangeBlack(i, j);
                            else
                                ColorChangeRed(i, j);
                        }
                    }

                    labelSysMonitor.Text += newGame6.BoolTest();
                    if (newGame6.TestComplete())
                        labelSysMonitor.Text += "completed\n\n";
                    else
                        labelSysMonitor.Text += "not completed\n\n";
                    if (newGame6.TestWin())
                    {
                        labelSysMonitor.Text += "you win\n";
                        MessageBox.Show("You win");
                        return;
                    }
                    else
                    {
                        labelSysMonitor.Text += "not win yet";
                    }
                }
                else if (gameSize == 9)
                {
                    newGame9.ValueChange(tempRow, tempCol, tempInt);
                    labelSysMonitor.Text += newGame9.Test();

                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (newGame9.TestValid(i, j))
                                ColorChangeBlack(i, j);
                            else
                                ColorChangeRed(i, j);
                        }
                    }

                    labelSysMonitor.Text += newGame9.BoolTest();
                    if (newGame9.TestComplete())
                        labelSysMonitor.Text += "completed\n\n";
                    else
                        labelSysMonitor.Text += "not completed\n\n";
                    if (newGame9.TestWin())
                    {
                        labelSysMonitor.Text += "you win\n";
                        MessageBox.Show("You win");
                        return;
                    }
                    else
                    {
                        labelSysMonitor.Text += "not win yet";
                    }
                }


            }
        }

        private void ColorChangeRed(int row, int col)
        {
            _map[row, col].ForeColor = Color.Red;
        }

        private void ColorChangeBlack(int row, int col)
        {
            _map[row, col].ForeColor = Color.Black;
        }

    }
}
