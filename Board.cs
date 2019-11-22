using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_way
{
    static class Board
    {
        static public Pen pen;
        static public float size, pixelsize;
        static Cell[,] mcell;
        static Board()
        {
            pen = new Pen(Color.Aquamarine, 4);
            size = 4;
            pixelsize = 50;
            //New();
        }
        public static void Paint()
        {
            Pen borderpen = new Pen(Color.Black);
            for (float i = 0; i < (size+1) * pixelsize; i+=pixelsize)
            {
                Form1.g.DrawLine(borderpen,0,i, size * pixelsize, i);
                Form1.g.DrawLine(borderpen, i, 0, i, size * pixelsize);
            }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    mcell[i, j].Paint();
        }
        public static void Reaction(int X, int Y)
        {
            // целочисленное деление
            Cell c = mcell[X / (int)pixelsize, Y / (int)pixelsize]; 
            // делим на прямые ( 2 сост) и на остальные (4 сост)
            if (c is StraigthCell)
                c.state = c.state == 1 ? 0 : 1;
            else
                c.state += c.state == 3 ? -3 : 1;
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
                { new CornerCell(3), new StartCell(3),    new StraigthCell(0), new CornerCell(3) },
                { new CornerCell(3), new StraigthCell(1), new CornerCell(0),   new CornerCell(2) },
                { new CornerCell(2), new StraigthCell(1), new CornerCell(2),   new CornerCell(3) },
                { new CornerCell(2), new StraigthCell(0), new FinishCell(1),   new CornerCell(2) },
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
