using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool xPlayerTurn = true;
        int turnCount = 0;
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

        private void RestartGame()
        {
            InitializeCell();
            turnCount = 0;
            xPlayerTurn = false;
        }

        private void InitializeCell()
        {
            string labelName;
            for (int i = 1; i <= 9; i++)
            {
                labelName = "pictureBox" + i;
                Grid.Controls[labelName].Tag = string.Empty;
                Grid.Controls[labelName].BackColor = Color.Transparent;
            }
        }

        private void Player_click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;

            if(pic.Tag != string.Empty)
            {
                return;
            }

            if (xPlayerTurn)
            {
                pic.Tag = "X";
            }
            else
            {
                pic.Tag = "O";
            }
            turnCount++;
            PlayTurnSound();
            CheckForWin();
            CheckForDraw();
            xPlayerTurn = !xPlayerTurn;
        }

        private void CheckForWin()
        {
            if((pictureBox1.Tag == pictureBox2.Tag && pictureBox2.Tag == pictureBox3.Tag && pictureBox1.Tag != string.Empty) ||
               (pictureBox4.Tag == pictureBox6.Tag && pictureBox5.Tag == pictureBox6.Tag && pictureBox4.Tag != string.Empty) ||
               (pictureBox7.Tag == pictureBox8.Tag && pictureBox8.Tag == pictureBox9.Tag && pictureBox7.Tag != string.Empty) ||
               (pictureBox1.Tag == pictureBox4.Tag && pictureBox4.Tag == pictureBox7.Tag && pictureBox1.Tag != string.Empty) ||
               (pictureBox2.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox8.Tag && pictureBox2.Tag != string.Empty) ||
               (pictureBox3.Tag == pictureBox6.Tag && pictureBox6.Tag == pictureBox9.Tag && pictureBox3.Tag != string.Empty) ||
               (pictureBox1.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox9.Tag && pictureBox1.Tag != string.Empty) ||
               (pictureBox3.Tag == pictureBox5.Tag && pictureBox5.Tag == pictureBox7.Tag && pictureBox3.Tag != string.Empty))
            {
                GameOver();
            }
        }

         private void WinnerCellsChangeColor()
        {
            if (pictureBox1.Tag == pictureBox2.Tag && pictureBox1.Tag == pictureBox3.Tag && pictureBox1.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox1, pictureBox2, pictureBox3, Color.Purple);
            }
            else if (pictureBox4.Tag == pictureBox5.Tag && pictureBox4.Tag == pictureBox6.Tag && pictureBox4.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox4, pictureBox5, pictureBox6, Color.Purple);
            }
            else if (pictureBox7.Tag == pictureBox8.Tag && pictureBox7.Tag == pictureBox9.Tag && pictureBox7.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox7, pictureBox8, pictureBox9, Color.Purple);
            }
            else if (pictureBox1.Tag == pictureBox4.Tag && pictureBox1.Tag == pictureBox7.Tag && pictureBox1.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox1, pictureBox4, pictureBox7, Color.Purple);
            }
            else if (pictureBox2.Tag == pictureBox5.Tag && pictureBox2.Tag == pictureBox8.Tag && pictureBox2.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox2, pictureBox5, pictureBox8, Color.Purple);
            }
            else if (pictureBox3.Tag == pictureBox6.Tag && pictureBox3.Tag == pictureBox9.Tag && pictureBox3.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox3, pictureBox6, pictureBox9, Color.Purple);
            }
            else if (pictureBox1.Tag == pictureBox5.Tag && pictureBox1.Tag == pictureBox9.Tag && pictureBox1.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox1, pictureBox5, pictureBox9, Color.Purple);
            }
            else if (pictureBox3.Tag == pictureBox5.Tag && pictureBox3.Tag == pictureBox7.Tag && pictureBox3.Tag != string.Empty)
            {
                ChangeCellColors(pictureBox3, pictureBox5, pictureBox7, Color.Purple);
            }
        }

        private void ChangeCellColors(PictureBox firstLabel, PictureBox secondLabel, PictureBox thirdLabel, Color color)
        {
            firstLabel.BackColor = color;
            secondLabel.BackColor = color;
            thirdLabel.BackColor = color;
        }

        private void PlayTurnSound()
        {
            if (xPlayerTurn == true)
            {
                System.IO.Stream str = Properties.Resources.o_turn;
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                snd.Play();
            }
            else if (xPlayerTurn == false)
            {
                System.IO.Stream str = Properties.Resources.x_turn;
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                snd.Play();
            }
        }

        private void PlayVictorySound()
        {
            System.IO.Stream str = Properties.Resources.victory;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        private void PlayDrawSound()
        {
            System.IO.Stream str = Properties.Resources.Bruh_Sound_Effect;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        private void CheckForDraw()
        {
            if(turnCount == 9)
            {
                PlayDrawSound();
                MessageBox.Show("Draw!");
                RestartGame();
            }
        }

        private void GameOver()
        {
            string winner;
            if (xPlayerTurn)
            {
                winner = "X";
            }
            else
            {
                winner = "O";
            }
            WinnerCellsChangeColor();
            PlayVictorySound();
            MessageBox.Show(winner + " wins!");
            RestartGame();
        }
    }
}
