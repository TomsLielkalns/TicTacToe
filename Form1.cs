using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool xPlayerTurn = true;

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeCell();
        }
        private void InitializeGrid()
        {
            Grid.BackColor = Color.LightCoral;
            Grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
        }

        private void InitializeCell()
        {
            string labelName;
            for (int i = 1; i <= 9; i++)
            {
                labelName = "label" + i;
                Grid.Controls[labelName].Text = string.Empty;
            }
        }

        private void Player_click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (xPlayerTurn)
            {
                label.Text = "X";
            }
            else
            {
                label.Text = "O";
            }
            xPlayerTurn = !xPlayerTurn;
        }
    }
}
