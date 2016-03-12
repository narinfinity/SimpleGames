using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiamondDash.Entities;
using DiamondDash.Interfaces;
using DiamondDash.Properties;

namespace DiamondDash
{
    public partial class MyForm : Form
    {
        Random r = new Random(DateTime.Now.Millisecond);
        Timer timer;
        int seconds = 60;
        int scores = 0;
        Dashboard dash;
        Image[] background;
        static System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.Ticks);

        public MyForm()
        {
            //DoubleBuffered = true;
            InitializeComponent();
           
            dash = new Dashboard(new Point(60, 72), new Size(316, 283), 10, 9);            
            this.Controls.Add(dash);
            
            foreach(Dashcolumn dashcolume in dash.Controls)
                dashcolume.ControlRemoved += dashcolume_ControlRemoved;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
           
            this.Load += new EventHandler(MyGame_Load);            
        }
        protected virtual void dashcolume_ControlRemoved(object sender, ControlEventArgs e)
        {   
            scores += 30;
            ScorePanel.Invalidate();
        }
               
        protected virtual void timer_Tick(object sender, EventArgs e)
        {
            TimePanel.Invalidate();
            if (--seconds == 0) 
            {
                //player.Stop();
                timer.Enabled = false;
                _LockDiamonds(true);
                if (DialogResult.OK == MessageBox.Show("Time's Up", "Oops!", MessageBoxButtons.OK))
                    this.Close();
            }
            if (seconds == 10) player.Play();
        }

        protected virtual void MyGame_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;
            background = new Bitmap[] { Resources.Background };
            this.BackgroundImage = background[0];
            this.ClientSize = background[0].Size;
        }

        protected virtual void PauseButton_Click(object sender, EventArgs e)
        {
            Button butt = sender as Button;
            dash.Locked = !dash.Locked;
            if (dash.Locked)
            {                
                timer.Enabled = false;
                player.Stop();
                butt.Text = "Play";
                _LockDiamonds(true);
            }
            else
            {
                //player.Play();
                timer.Enabled = true;
                butt.Text = "Pause";
                _LockDiamonds(false);
            }
        }

        private void _LockDiamonds(bool locked)
        {
            if (this.HasChildren)
                foreach (Dashcolumn child in dash.Controls)
                    foreach (Diamond ch in child.Controls)
                        if (ch is Diamond)
                            (ch as Diamond).Locked = locked;
        }


        
        protected virtual void TimePanel_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Segoe Print", 15, FontStyle.Bold);
            Graphics g = e.Graphics;
            g.DrawString(seconds.ToString(), font, Brushes.Purple, TimePanel.ClientRectangle, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
        }

        protected virtual void ScorePanel_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Segoe Print", 11, FontStyle.Bold);
            Graphics g = e.Graphics;
            g.DrawString(scores.ToString("### ### ##0"), font, Brushes.White, ScorePanel.ClientRectangle, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });

        }

    }
}
