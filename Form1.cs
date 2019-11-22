using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_way
{
    public partial class Form1 : Form
    {
        public static Graphics g;
        public Pen pen;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            Board.New();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Board.Paint();
        }

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Board.Reaction(e.X, e.Y);
        }
    }
}
