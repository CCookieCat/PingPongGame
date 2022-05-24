using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {


        public int speed_left = 4 ; //Geschwindigkeit
        public int speed_top = 4 ;
        public int points = 0; //Punkte



        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None; //border weg
            //this.TopMost = false;    //form vorbringen, hier nicht immer im Vordergrund.
            this.Bounds = Screen.PrimaryScreen.Bounds; //fullscreen

            racket.Top = playground.Bottom - (playground.Bottom / 10); //Position
            
            lbl_gameover.Left = (playground.Width/2) - (lbl_gameover.Width/2); //Position von GO
            lbl_gameover.Top = (playground.Height/2) - (lbl_gameover.Height/2);
            lbl_gameover.Visible = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2); // Schläger zentrieren

            ball.Left += speed_left;    //Ball bewegen
            ball.Top += speed_top;

            if(ball.Bottom >= racket.Top && ball.Bottom >= racket.Bottom && ball.Left >=racket.Left && ball.Right <= racket.Right) //Collidierug
            {
                speed_top += 1;
                speed_left += 1;
                speed_top = -speed_top; //Richtungswechsel
                points += 1;

                lbl_points.Text = points.ToString();

                Random r = new Random();
                ball.BackColor = Color.FromArgb(r.Next(100,200) , r.Next(100,200), r.Next(100,200)); //Nur bis 256
            }

            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <=  playground.Top)
            {
                speed_top = -speed_top;
            }

            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false; //aus dem Spiel
                lbl_gameover.Visible = true;
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();   //schließen
            }
            
            
            if (e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                lbl_points.Text = "0";
                lbl_gameover.Visible = false;
                timer1.Enabled = true;

            }
        }


    }
}
