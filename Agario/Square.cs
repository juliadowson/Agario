using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Agario
{
    
    class Square
    {
        public int x, y, size;
        public string colour;

        public Square(int _x, int _y, int _size, string _colour)
        {
            x = _x;
            y = _y;
            size = _size;
            colour = _colour;
        }
    }
}
