/*This is a basic two player game, based on the online game, Agar.io.
 * Mr. T
 * Oct 6, 2021
 * Julia Dowson
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Agario
{
    public partial class Form1 : Form
    {
        //creates music player 
        System.Windows.Media.MediaPlayer backMusic = new System.Windows.Media.MediaPlayer();

        public Form1()
        {
            InitializeComponent();
            backMusic.Open(new Uri(Application.StartupPath + "/Resources/agarioBackMusic.wav"));
            backMusic.MediaEnded += new EventHandler(backMusic_MediaEnded);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //plays background music 
            backMusic.Play();

            //loads main screen
            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);
            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);

            //disables mouse
            Cursor.Hide();
        }

        private void backMusic_MediaEnded(object sender, EventArgs e)
        {
            backMusic.Stop();
            backMusic.Play();
        }
    }
}
