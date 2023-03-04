using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public enum Symbol { X, O };

    class MyButton : Button
    {
        public Symbol Symbol { get; set; }
        public int X { get; set; }
        public int y { get; set; }

        public static int Btn_size = 80;

        public MyButton(int x, int y) 
        {
            Width = Height = Btn_size;
            this.X = x;
            this.y = y;
            this.Text = " ";
            this.Symbol = (Symbol)(9 +(x * 3 + y));
           
            
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }
        public void SetSymbol(Symbol S) 
        {
            this.Symbol = S;
            this.Text = S.ToString();
            if (S == Symbol.X)
            {
                this.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
