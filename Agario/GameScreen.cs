using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Agario
{
    public partial class GameScreen : UserControl
    {
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        //list for point boxes 
        List<Square> pointsList = new List<Square>();

        //creates random genrator for x, y and colour of points 
        Random randGen = new Random();
        int newPointCounter = 0;
        //variable for winner 
        public static string winner;

        //player1 values 
        Square player1;
        int points1 = 0;
        public static int player1Size = 10;

        //player2 values 
        Square player2;
        int points2 = 0;
        public static int player2Size = 10;

        //brushes
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Navy);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
      
        public GameScreen()
        {
            InitializeComponent();
            OnStart();            
        }

        public void OnStart()
        {
            //picks a random colour for point boxes 
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

            //random values for points boxes
            int xValue = randGen.Next(1, this.Width - 10);
            int yValue = randGen.Next(1, this.Height - 10);

            Square s = new Square(xValue, yValue, 10, 0, colour);
            pointsList.Add(s);

            //creates player box 
            player1 = new Square(300, 850, player1Size, 15, "");
            player2 = new Square(1300, 850, player2Size, 15, "");

            this.Focus();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            newPointCounter++;

            #region player 1 controls 
           
            if (aDown && player1.x > 0)
            {
                player1.Move("left");
            }
            else if (dDown && player1.x < this.Width - points1- 25)
            {
                player1.Move("right");
            }
            else if (wDown && player1.y > 10)
            {
                player1.Move("up");
            }
            else if (sDown && player1.y < this.Height - points1- 20)
            {
                player1.Move("down");
            }
            #endregion

            #region player 2 controls
            if (vDown && player2.x > 0)
            {
                player2.Move("left");
            }
            else if (xDown && player2.x < this.Width - points2 - 25)
            {
                player2.Move("right");
            }
            else if (cDown && player2.y > 10)
            {
                player2.Move("up");
            }
            else if (zDown && player2.y < this.Height - points2 - 20)
            {
                player2.Move("down");
            }
            #endregion

            //creates points 
            if (newPointCounter == 8)
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

                int xValue = randGen.Next(1, this.Width - 10);
                int yValue = randGen.Next(1, this.Height - 10);

                Square s = new Square(xValue, yValue, 10, 0, colour);
                pointsList.Add(s);

                newPointCounter = 0;
            }
            Refresh();

            //adds points, and changes size if there is a collision 
            for (int i = 0; i < pointsList.Count; i++)
            {
                if (player1.Collision(pointsList[i]))
                {                  
                    points1++;
                    points1Label.Text = $"{points1}";
                    pointsList.RemoveAt(i);
                    player1Size += 1;
                }
                else if (player2.Collision(pointsList[i]))
                {
                    points2++;
                    points2Label.Text = $"{points2}";
                    pointsList.RemoveAt(i);
                    player2Size += 1;
                }
            }
            
            //runs gameover method if either player reaches 250 points 
            if (points1 >= 251)
            {
                winner = "Player 1 Wins!";
                GameOver();               
            }
            else if (points2 >= 251)
            {
                winner = "Player 2 Wins!";
                GameOver();
            }            
        }

        private void GameOver()
        {
            gameTimer.Enabled = false;

            //resets variables 
            player1Size = 10;
            player2Size = 10;
            points1 = 0;
            points2 = 0;

            //displays winner 
            winnerLabel.Text = $"{winner}";
            Refresh();
            Thread.Sleep(4000);
            winnerLabel.Text = "";
            
            //shows main screen after 4 seconds 
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);
            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
        }

        private void GameScreen_Paint_1(object sender, PaintEventArgs e)
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

            //draws players 
            e.Graphics.FillRectangle(whiteBrush, player1.x, player1.y, player1Size, player1Size);
            e.Graphics.FillRectangle(whiteBrush, player2.x, player2.y, player2Size, player2Size);
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

                case Keys.C:
                    cDown = false;
                    break;
                case Keys.Z:
                    zDown = false;
                    break;
                case Keys.V:
                    vDown = false;
                    break;
                case Keys.X:
                    xDown = false;
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

                case Keys.C:
                    cDown = true;
                    break;
                case Keys.Z:
                    zDown = true;
                    break;
                case Keys.V:
                    vDown = true;
                    break;
                case Keys.X:
                    xDown = true;
                    break;
            }
        }

    }
}
