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
    public class Dashboard : Panel, IDashboard
    {
        Image[] background = new Bitmap[] { Resources.Dashboard };

        public virtual bool Locked { get; set; }
        public virtual int ColumnCount { get; private set; }
        public virtual int RowCount { get; private set; }

        public Dashboard(Point location, Size size, int colCount, int rowCount)
        {
            this.Location = location;
            this.Size = size;
            this.ColumnCount = colCount;
            this.RowCount = rowCount;

            _ControlAdd();
            this.Paint += _Paint;
            this.Click += _Click;
        }


        protected virtual void _ControlAdd()
        {
            Point startPoint = new Point(3, 0);
            int colWidth = this.Width / this.ColumnCount;

            for (int i = 0; i < ColumnCount; i++)
            {
                this.Controls.Add(new Dashcolumn(
                                        startPoint, 
                                        new Size(colWidth, this.Height), 
                                        Color.Transparent,
                                        this.RowCount
                                    ));               
                startPoint.X += colWidth;                
            }            
        }

        protected virtual void _Paint(object source, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Image tmp = background[0];

            if (tmp != null) g.DrawImage(tmp, new Rectangle(new Point(0,0), new Size(this.Width+1, this.Height)));
        }

        protected virtual void _Click(object sender, EventArgs e)
        {
        }

    }
}
