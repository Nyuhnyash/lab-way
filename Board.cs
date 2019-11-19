using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab_way
{
    class Board
    {
        int size;
        Cell[,] mcell;
        public Board()
        {
            size = 4;
            mcell = new Cell[size, size];
            Cell c = new Cell(new Point(10, 10), new Point(10, 20));
            mcell[0,0] = c;
        }
        public void Paint()
        {
            mcell[0, 0].Paint();
            //foreach (var c in mcell)
            //{
            //    c.Paint();
            //}
        }
    }
}
