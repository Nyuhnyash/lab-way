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

        static public int size, pixelsize;
        static Cell[,] mcell;
        static Board()
        {
            pen = new Pen(Color.Aquamarine, 8);
            size = 4;
            pixelsize = 100;
        }
        public static void Paint()
        {
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
            if (Check())
            {
                MessageBox.Show("Путь найден");
                New();
            }
        }
        public static bool Check()
        {
            List<Cell> mc = new List<Cell>();
            foreach (var c in mcell)
            {
                mc.Add(c);
            }
            int[,] A = new int[size * size, size * size];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                        A[i, j] = Connected(mc[i], mc[j]);
                }
            }
                int[,] R = A;
            for (int i = 0; i < 20 || R[1, 14] > 0; i++)
            {
                R = Mmult(R, A);
                if (R[1, 14] > 0)
                    return true;
            }
            return false;
                
            mc.Clear();
        }
        public static int Connected(Cell a, Cell b)
        {
            if (a is EndCell)
                return a.p1==b.p1 || a.p1==b.p2 ? 1 : 0;
            else
                if (b is EndCell)
                return a.p1==b.p1 || a.p2==b.p1 ? 1 : 0;
            else
                return (a.p1==b.p1 || a.p1==b.p2 || a.p2==b.p1 || a.p2==b.p2) ? 1 : 0;
        }
        static int[,] Mmult(int[,] a, int[,] b)
        {
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
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
            Paint();
        }
    }
}
