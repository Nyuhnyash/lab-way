using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace lab_way
{
    static class Board
    {
        static public Pen pen;

        static public float size, pixelsize;
        static Cell[,] mcell;
        static Board()
        {
            pen = new Pen(Color.Aquamarine, 8);
            size = 4;
            pixelsize = 50;
        }
        public static void Paint()
        {
            //for (float i = 0; i < (size+1) * pixelsize; i+=pixelsize)
            //{
            //    Form1.g.DrawLine(borderpen,0,i, size * pixelsize, i);
            //    Form1.g.DrawLine(borderpen, i, 0, i, size * pixelsize);
            //}
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    mcell[i, j].Paint();
        }
        public static void Reaction(Point p, MouseButtons mb)
        {
            // целочисленное деление
            Cell c = mcell[p.Y / (int)pixelsize, p.X / (int)pixelsize]; 
            // делим на прямые ( 2 сост) и на остальные (4 сост)
            if (c is StraigthCell)
                c.state = c.state == 1 ? 0 : 1;
            else
                if (mb.ToString() == "Right")
                c.state += c.state == 3 ? -3 : 1;
                else
                c.state -= c.state == 0 ? -3 : 1;
            c.Paint();
            /*
               foreach (Cell c in mcell)
                if (new Rectangle(pixelsize * c.i, pixelsize * c.j, pixelsize, pixelsize).Contains(X, Y))
                {
                    for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                            if ((c.i == i) || (c.j == j))
                                if (c is StraigthCell)
                                    mcell[i, j].state = mcell[i, j].state == 1 ? 0 : 1;
                                else
                                    mcell[i, j].state += mcell[i, j].state == 3 ? -3 : 1;
                    return;
                }
            */
        }
        public static void New()
        {
            mcell = new Cell[,] {
                { new CornerCell(0), new FinishCell(3),    new StraigthCell(0), new CornerCell(3) },
                { new CornerCell(1), new StraigthCell(1), new CornerCell(2),   new CornerCell(0) },
                { new CornerCell(0), new StraigthCell(1), new CornerCell(0),   new CornerCell(3) },
                { new CornerCell(1), new StraigthCell(0), new StartCell(1),   new CornerCell(0) },
            };
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mcell[j, i].i = i;
                    mcell[j, i].j = j;
                }
            }
        }
    }
}
