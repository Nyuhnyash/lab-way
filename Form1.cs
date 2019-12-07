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
            panel1.Size = new System.Drawing.Size((int)(Board.size * Board.pixelsize+90), (int)(Board.size * Board.pixelsize+90));
            Board.New();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Board.Paint();
        }

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Board.Reaction(e.Location,e.Button);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Board.New();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Designed by Егор Курясев");
        }
    }
}
