using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private MyButton[,] btnGrid = new MyButton[3, 3];
        int NrOfClicks = 0;
        public Symbol CurrentSymbol;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameSet();
        }

        private void GameSet() 
        {
            panel.Controls.Clear();
            CurrentSymbol = 0;
            label.ForeColor = SetForecolor(CurrentSymbol);
            label.Text = CurrentSymbol.ToString();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    btnGrid[i, j] = new MyButton(i, j);
                    panel.Controls.Add(btnGrid[i, j]);
                    btnGrid[i, j].Click += OnClick;

                    btnGrid[i, j].Location = new Point(i * MyButton.Btn_size, j * MyButton.Btn_size);
                }
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            MyButton btn = (MyButton)sender;
            if (btn.Text != " ") return;

            btn.SetSymbol(CurrentSymbol);
            CheckTable();
            NrOfClicks++;
            CurrentSymbol = (Symbol)(NrOfClicks % 2);

            label.ForeColor = SetForecolor(CurrentSymbol);

            label.Text = CurrentSymbol.ToString();

        }
        private void CheckTable() 
        {
            for (int i = 0; i < 3; i++)
            {
                if ((btnGrid[i, 0].Symbol == btnGrid[i, 1].Symbol ) && (btnGrid[i, 1].Symbol == btnGrid[i, 2].Symbol)) 
                {
                    MessageBox.Show(CurrentSymbol + " Won");
                    GameSet();
                    return;
                    
                }
                if ((btnGrid[0, i].Symbol == btnGrid[1, i].Symbol) && (btnGrid[1, i].Symbol == btnGrid[2, i].Symbol))
                {
                    MessageBox.Show(CurrentSymbol + " Won");
                    GameSet();
                    return;
                }
            }
            if ((btnGrid[0, 0].Symbol == btnGrid[1, 1].Symbol) && (btnGrid[1, 1].Symbol == btnGrid[2, 2].Symbol))
            {
                MessageBox.Show(CurrentSymbol + " Won");
                GameSet();
                return;
            }
            if ((btnGrid[2, 0].Symbol == btnGrid[1, 1].Symbol) && (btnGrid[1, 1].Symbol == btnGrid[0, 2].Symbol))
            {
                MessageBox.Show(CurrentSymbol + " Won");
                GameSet();
                return;
            }
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (btnGrid[i, j].Text != " ") counter++;
                }
            }
            if (counter == 9) 
            {
                MessageBox.Show("Draw");
                GameSet();
                return;
            }

            
        }

        private System.Drawing.Color SetForecolor(Symbol symbol) 
        {
            if (symbol == Symbol.X)
            {
                return System.Drawing.Color.Red;
            }
            return System.Drawing.Color.Black;
        }
    }
}
