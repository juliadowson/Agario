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
        public int x, y, size, speed;
        public string colour;

        public Square(int _x, int _y, int _size, int _speed, string _colour)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            colour = _colour;
        }

        public void Move(string direction)
        {
            //changes direction of player depending on the button press
            if (direction == "left")
            {
                x -= speed;
            }
            else if (direction == "right")
            {
                x += speed;
            }
            else if (direction == "up")
            {
                y -= speed;
            }
            else if (direction == "down")
            {
                y += speed;
            }
        }

        public bool Collision(Square s)
        {
            //creates rectangles for collisions 
            Rectangle player1Rec = new Rectangle(x, y, GameScreen.player1Size, GameScreen.player1Size);
            Rectangle player2Rec = new Rectangle(x, y, GameScreen.player2Size, GameScreen.player2Size);
            Rectangle pointsRec = new Rectangle(s.x,s.y, s.size, s.size);

            if (player1Rec.IntersectsWith(pointsRec) || player2Rec.IntersectsWith(pointsRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
