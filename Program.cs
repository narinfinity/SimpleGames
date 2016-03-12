using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MyGameProgram
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyGame());
        }

    }
   
    public class MyPanel : Panel 
    {
        Image foreImage, backImage;
        Timer timer;
        float viewMode;

        public bool isRotated { get; private set; }
        public bool isLocked { get; set; }

        public MyPanel(Image fImg, Image bImg)
        {
            foreImage = fImg;
            backImage = bImg;
            timer = new Timer();
            viewMode = 1;
            isRotated = false;
            isLocked = false;
            timer.Interval = 1;
            timer.Tick += new EventHandler(timer_Tick);
            this.Click += new EventHandler(MyPanel_Click);
            this.Paint += new PaintEventHandler(MyPanel_Paint);
        }

        public Image Img { get { return backImage; } }        

        public void ResetRotate()
        {
            if (!isRotated) return;            
            viewMode = -1;
            timer.Enabled = true;            
        }

        public virtual void MyPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel;
            if (viewMode > 0.01f || viewMode < -0.01f)
            {
                float translate = this.ClientSize.Width * (1 - viewMode) / 2 - 0.35f;
                g.Transform = new Matrix(viewMode, 0, 0, 1, translate, 0);

                if (viewMode > 0)
                    g.DrawImage(foreImage, this.ClientRectangle);
                else                
                    g.DrawImage(backImage, this.ClientRectangle);                
            }
            if (viewMode < -1) { viewMode = -1; timer.Enabled = false; isRotated = true; }
            if (viewMode > +1) { viewMode = +1; timer.Enabled = false; isRotated = false; }
        }

        void timer_Tick(object sender, EventArgs e)
        {            
            if (!isRotated) { viewMode -= 0.1f;  }
            else            { viewMode += 0.1f;  }

            this.Invalidate();
        }

       public virtual void MyPanel_Click(object sender, EventArgs e)
        {
            if (isLocked || isRotated) return;            
            timer.Enabled = true;
        }

    }


    public class Table : Form
    {
        string[,] playersTable = null;
        StringFormat strformat;

        public Table(string[,] players, Size size, StringAlignment sa)
        {            
            ResizeRedraw = true;
            playersTable = players;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = size;
            strformat = new StringFormat();
            strformat.Alignment = sa;
        }

        public void setPlayersTable(string[,] players)
        {
            if (players == null) return;
            playersTable = players;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Arial Armenian", 12, FontStyle.Regular);
            for (int j = 0, x = 40; j < playersTable.GetLongLength(1); j++)
            {
                int y = 10;
                for (int i = 0; i < playersTable.GetLongLength(0); i++)
                {
                    g.DrawString(playersTable[i, j], font, Brushes.Black, x, y, strformat);
                    y += font.Height;
                }
                x += 120;
            }
        }
    }

   
}
