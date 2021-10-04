using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agario
{
    public partial class GameScreen : UserControl
    {
        Boolean aDown, sDown, dDown, wDown;

        //list for point boxes 
        List<Square> pointsList = new List<Square>();

        Random randGen = new Random();

        //brushes
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Navy);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        int newPointCounter = 0;


        public GameScreen()
        {
            InitializeComponent();
            OnStart();        
        }

        public void OnStart()
        {
            //TODO - set game start values
            int colourValue = randGen.Next(1, 4);
            string colour = "white";

            if (colourValue == 1)
            {
                colour = "blue";
            }
            else if (colourValue == 2)
            {
                colour = "red";
            }
            else
            {
                colour = "yellow";
            }

            int xValue = randGen.Next(1, 200);
            int yValue = randGen.Next(1, 300);

            Square s = new Square(xValue, yValue, 40, colour);
            pointsList.Add(s);

            //hero = new Box(330, 500, 30, 5, "blue");

        }



        private void gameTimer_Tick(object sender, EventArgs e)
        {
            newPointCounter++;

            if (newPointCounter == 4)
            {
                int colourValue = randGen.Next(1, 4);
                string colour = "white";

                if (colourValue == 1)
                {
                    colour = "blue";
                }
                else if (colourValue == 2)
                {
                    colour = "red";
                }
                else
                {
                    colour = "yellow";
                }

                int xValue = randGen.Next(1, 200);
                int yValue = randGen.Next(1, 300);

                Square s = new Square(xValue, yValue, 50, colour);
                pointsList.Add(s);

                newPointCounter = 0;
            }
            Refresh();

        }


        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.A:
                    aDown = true;
                break;
                case Keys.W:
                    wDown = true;
                break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Square s in pointsList)
            {
                switch (s.colour)
                {
                    case "blue":
                        e.Graphics.FillRectangle(blueBrush, s.x, s.y, s.size, s.size);                  
                        break;
                    case "red":
                        e.Graphics.FillRectangle(redBrush, s.x, s.y, s.size, s.size);
                        break;
                    case "yellow":
                        e.Graphics.FillRectangle(yellowBrush, s.x, s.y, s.size, s.size);
                        break;
                }
            }

            //test
            e.Graphics.FillRectangle(blueBrush, 300, 300, 50, 50);
            label1.Text = "";
            label1.Text = "test";
        }
    }
}
