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
        public void Paint()
        {
            Form1.g.FillRectangle(new SolidBrush(Color.LightGray), Board.pixelsize * i, Board.pixelsize * j, Board.pixelsize, Board.pixelsize);
            Form1.g.DrawRectangle(new Pen(Color.Black), Board.pixelsize * i+1, Board.pixelsize * j+1, Board.pixelsize-2, Board.pixelsize-2);
            Paint2();
        }
        abstract public void Paint2();
    }
    class StraigthCell : Cell
    {
        public StraigthCell(int state) : base(state)
        {

        }
        public override void Paint2()
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
        public override void Paint2()
        {
            PointF pc = new PointF(Board.pixelsize * (float)(i + 0.5), Board.pixelsize * (float)(j + 0.5)),
                   p1 = new PointF(Board.pixelsize * (float)(i + 0.5 + 0.5 * Math.Sin(state * Math.PI / 2)), Board.pixelsize * (float)(j + 0.5 + 0.5 * Math.Cos(state * Math.PI / 2))),
                   p2 = new PointF(Board.pixelsize * (float)(i + 0.5 + 0.5 * Math.Sin(state * Math.PI / 2 + Math.PI / 2)), Board.pixelsize * (float)(j + 0.5 + 0.5 * Math.Cos(state * Math.PI / 2 + Math.PI / 2)));
            Form1.g.DrawLine(Board.pen, p1, pc);
            Form1.g.DrawLine(Board.pen, p2, pc);

        }
    }
    abstract class EndCell : Cell
    {
        public Brush endbrush;
        public EndCell(int state) : base(state)
        {

        }
        public override void Paint2()
        {
            PointF pc = new PointF(Board.pixelsize * (float)(i + 0.5), Board.pixelsize * (float)(j + 0.5)),
                   p = new PointF(Board.pixelsize * (float)(i + 0.5 + 0.5 * Math.Sin(state * Math.PI / 2)), Board.pixelsize * (float)(j + 0.5 + 0.5 * Math.Cos(state * Math.PI / 2)));
            Form1.g.DrawLine(Board.pen, p, pc);
            float r = Board.pixelsize / 5;
            Form1.g.FillEllipse(endbrush, pc.X - r, pc.Y - r, 2 * r, 2 * r);
        }
    }
    class StartCell : EndCell
    {
        public StartCell(int state) : base(state)
        {
            endbrush = new SolidBrush(Color.Blue);
        }
    }
    class FinishCell : EndCell
    {
        public FinishCell(int state) : base(state)
        {
            endbrush = new SolidBrush(Color.Red);
        }
    }
}
