using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiamondDash.Helpers;
using DiamondDash.Interfaces;
using DiamondDash.Properties;

namespace DiamondDash.Entities
{
    public class Dashcolumn : Panel, IDashcolumn
    {
        Random r = new Random(DateTime.Now.Millisecond);
        Image[] diamondImg = new Bitmap[] { Resources.Shine, Resources.Red, Resources.Green, Resources.Blue, Resources.Yellow, Resources.Purple, Resources.Diamond };

        static Timer timer;        
        //int lastCildIndex = -1;

        public virtual int RowCount { get; private set; }        

        public Dashcolumn(Point location, Size size, Color backColor, int rowCount)
        {
            DoubleBuffered = true;
            this.Location = location;
            this.Size = size;
            this.BackColor = backColor;
            this.RowCount = rowCount;

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += timer_Tick; _DiamondsAdd();

            this.Paint += _Paint;
            this.Click += _Click;
            this.ControlRemoved += _ControlRemoved; 

        }

        protected virtual void _DiamondsAdd()
        {            
           int lastCildIndex = this.Controls.Count - 1;
            Diamond diamond;
            int imgIndex;
            for (int i = lastCildIndex + 1; i < RowCount; ++i )
            {
                imgIndex = r.Next(1, 6);
                diamond = new Diamond(
                                        new Point(0, 0),
                                        new Size(this.Width, this.Width),
                                        new Image[] { diamondImg[0], diamondImg[imgIndex] },
                                        imgIndex
                          );
                
                diamond.Index = i;
                this.Controls.Add(diamond);                               
            }            
            for (int i = lastCildIndex + 1; i < RowCount; ++i)
            {
                
                diamond = this.Controls[i] as Diamond;
                diamond.Display();
                diamond.FallTo(this.Height - ((i + 1) * diamond.Height));
            }
            timer.Enabled = true;
        }

        
        protected virtual void timer_Tick(object sender, EventArgs e)
        {
            if (this.Controls.Count < RowCount) _DiamondsAdd();         
            //if (++lastCildIndex >= RowCount) return;
            //Diamond diamond;
            //diamond = this.Controls[lastCildIndex] as Diamond;
            //diamond.Display();
            //diamond.FallTo(this.Height - ((lastCildIndex + 1) * diamond.Height));           
        }


        protected virtual void _ControlRemoved(object sender, ControlEventArgs e)
        {
            Dashcolumn column = sender as Dashcolumn;
            Diamond diamond = e.Control as Diamond;            
            Diamond tmp;
            for (int i = diamond.Index; i < column.Controls.Count; i++)
            {
                tmp = column.Controls[i] as Diamond;
                --tmp.Index;
                tmp.FallTo(diamond.Height);                                
            }               
        }

        protected virtual void _Paint(object source, PaintEventArgs e)
        {
        }

        protected virtual void _Click(object sender, EventArgs e)
        {
        }



    }
}
