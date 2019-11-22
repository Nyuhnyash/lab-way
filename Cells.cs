using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace lab_way
{
    abstract class Cell
    {
        public int i, j, state;
        public Cell(int state)
        {
            this.state = state;
        }
        abstract public void Paint();
    }
    class StraigthCell : Cell
    {
        public StraigthCell(int state) : base(state)
        {

        }
        public override void Paint()
        {
            PointF p1, p2;
            // Запутанный метод
            //p1 = new PointF(Board.pixelsize * (i + state * 1 / 2), Board.pixelsize * (j + state * 1 / 2));
            //p2 = new PointF(Board.pixelsize * (i + 1 / (state + 1)), Board.pixelsize * (j + 1 / (state + 1)));

            // метод попроще
            if (state == 0)
            {
                p1 = new PointF(Board.pixelsize * i, Board.pixelsize * (float)(j +  0.5));
                p2 = new PointF(Board.pixelsize * (i + 1), Board.pixelsize * (float)(j + 0.5));
            }
            else
            {
                p1 = new PointF(Board.pixelsize * (i + (float)1 / 2), Board.pixelsize * j);
                p2 = new PointF(Board.pixelsize * (i + (float)1 / 2), Board.pixelsize * (j + (float)1));
            }
            Form1.g.DrawLine(Board.pen, p1, p2);
        }
    }
    class CornerCell : Cell
    {
        public CornerCell(int state) : base(state)
        {
            
        }
        public override void Paint()
        {
            PointF pc = new PointF(Board.pixelsize * (float)(i + 0.5), Board.pixelsize * (float)(j + 0.5)),
                   p1 = new PointF(Board.pixelsize * (float)(i + 0.5 + Math.Sin(state * Math.PI / 2)), Board.pixelsize * (float)(j + 0.5 + Math.Cos(state * Math.PI / 2)));

            Form1.g.DrawLine(Board.pen, p1, pc);

        }
    }
    abstract class EndCell : Cell
    {
        public Pen endpen;
        public EndCell(int state) : base(state)
        {

        }
        public override void Paint()
        {
            //throw new NotImplementedException();
        }
    }
    class StartCell : EndCell
    {
        public StartCell(int state) : base(state)
        {
            endpen = new Pen(Color.Blue);
        }
    }
    class FinishCell : EndCell
    {
        public FinishCell(int state) : base(state)
        {
            endpen = new Pen(Color.Red);
        }
    }
}
