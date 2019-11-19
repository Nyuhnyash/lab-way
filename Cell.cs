using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace lab_way
{
    class Cell
    {
        public Pen pen;
        public Point p1, p2;
        public Cell(Point p1, Point p2)
        {

            pen = new Pen(Color.Black);
            this.p1 = p1;
            this.p2 = p2;
        }
        public void Paint()
        {
                Form1.g.DrawLine(pen, p1, p2);
        }
    }
    class StraigthCell : Cell
    {
        public StraigthCell(Point p1, Point p2) : base(p1,p2)
        {

        }
        public void Paint()
        {
            Form1.g.DrawLine(pen, p1, p2);
            
        }
    }
    //class CornerCell : Cell
    //{
        
    //}
}
