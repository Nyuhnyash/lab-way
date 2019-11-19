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
        Board board = new Board();
        public static Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            board.Paint();
        }
    }
}
