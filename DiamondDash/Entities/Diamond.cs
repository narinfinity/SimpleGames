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
    public class Diamond : Panel, IDiamond
    {
        Image[] diamondImg;        
        bool shine;
        List<Diamond> sibList = new List<Diamond>();        
        static Timer timer;
        
        public virtual bool Locked { get; set; }
        public virtual int Index { get; set; }
        public virtual int ImgIndex { get; private set; }

        public Diamond(Point location, Size size, Image[] images, int imgIndex)
        {
            DoubleBuffered = true;
            this.Location = location;
            this.Size = size; 
            diamondImg = images;
            ImgIndex = imgIndex;            

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += timer_Tick;           

            this.Hide();
            this.Paint += _Paint;
            this.MouseDown += _Click;
            this.MouseUp += _MouseUp; timer.Enabled = true;           
        }

        protected virtual bool Added(Diamond d)
        {
            foreach (Diamond dd in this.sibList)
                if (d == dd) return true;
            return false;
        }
        
        protected virtual void timer_Tick(object sender, EventArgs e)
        {                          
            sibList.Clear(); 
            sibList.Add(this);
            LookAround(this);    
        }

        protected virtual void LookAround(Diamond d)
        {                    
            Diamond dmd = null;
            
            dmd = d.InUp();
            if (dmd != null && dmd.ImgIndex == d.ImgIndex && !Added(dmd))
            { sibList.Add(dmd); LookAround(dmd); }
            
            dmd = d.InDown();
            if (dmd != null && dmd.ImgIndex == d.ImgIndex && !Added(dmd))
            { sibList.Add(dmd); LookAround(dmd); }
            
            dmd = d.InLeft();
            if (dmd != null && dmd.ImgIndex == d.ImgIndex && !Added(dmd))
            { sibList.Add(dmd); LookAround(dmd); }
            
            dmd = d.InRight();
            if (dmd != null && dmd.ImgIndex == d.ImgIndex && !Added(dmd))
            { sibList.Add(dmd); LookAround(dmd); }            
        }


        protected virtual void _Paint(object source, PaintEventArgs e)
        {         
            Image tmp = diamondImg[1];
            Graphics g = e.Graphics;
            if (shine) tmp = diamondImg[0];
            if (tmp != null) g.DrawImage(tmp, ClientRectangle);
            //Font font = new Font("Arial", 10, FontStyle.Bold);
            //g.DrawString(sibList.Count.ToString(), font, Brushes.Black, ClientRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            shine = false;            
        }

        protected virtual void _Click(object sender, EventArgs e)
        {                   
            if (this.Locked) return;
                //player.PlayLooping();           
            int n = sibList.Count;
            if (n > 2)
            {
                foreach (Diamond d in sibList) if (d != null) d.CreateGraphics().DrawImage(diamondImg[0], ClientRectangle);
                System.Threading.Thread.Sleep(20);
                foreach (Diamond d in sibList)
                    if (d != null) d.Disappear(); 
            }
            else if (n == 2)
            {
                foreach (Diamond d in sibList) d.Shine();
            }            
        }

        protected virtual void _MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Diamond d in sibList) d.Invalidate();
        }


        //Implemented methods
        public virtual void Display()
        {
            this.Show();
        }

        public virtual void Disappear()
        {           
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
                this.Dispose();
            }
        }

        public virtual void Shine()
        {
            shine = true;
            Invalidate();
        }


        public virtual void FallTo(int fallUntil)
        {            
            int currentY = this.Location.Y;
            this.Location = new Point(this.Location.X, currentY + fallUntil);            
        }







    }
}
