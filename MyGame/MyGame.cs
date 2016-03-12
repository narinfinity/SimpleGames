using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyGameProgram.Properties;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MyGameProgram
{   
    public partial class MyGame : Form
    {
        Random r = new Random();
        Image[] backImgs = null;
        Image[] panelImgs = null;        
        
        int backImg = 0;
        Color bColor = Color.AliceBlue;
        ToolStripMenuItem colorItem = null, item = null;

        Timer click = null, elapsed = null;

        Point pt = new Point(10, 30);        
        Size size = new Size(80, 120);

        MyPanel[] pans = null;
        int[] selected = null;

        MyPanel[] panels = null;
        bool[] visibleState = null;
        int[] index = null;
        int level = 0;

        string[,] playersTable = new string[6, 4];        

        uint startTime = 0, clcount = 0;
        uint rows = 0, columns = 0;

        [Serializable]
        private class SaveGame
        {
            public int backImg = 0;
            public Color bColor = Color.AliceBlue;
            public int level = 0;
            public int[] selected = null;            
            public int[] index = null;
            public bool[] visibleState = null;            
            public uint startTime = 0, clcount = 0;
            public uint rows = 0, columns = 0;

            public SaveGame(int bimg, Color col, int lev, int[] select, int[] ind, bool[] visible, uint[] param)
            {
                this.backImg = bimg;
                this.bColor = col;
                this.level = lev;
                this.selected = select;
                this.index = ind;
                this.visibleState = visible;                
                this.startTime = param[0];
                this.clcount = param[1];
                this.rows = param[2];
                this.columns = param[3];
            }
        }
        
        public MyGame()
        {            
            InitializeComponent();
            ResizeRedraw = true;
            pans = new MyPanel[3];

            this.Load += new EventHandler(MyGame_Load);            

            click = new Timer();
            click.Interval = 500;
            click.Tick += new EventHandler(click_Tick);
            elapsed = new Timer();            
            elapsed.Interval = 1000;
            elapsed.Tick += new EventHandler(elapsed_Tick);
            this.StartPosition = FormStartPosition.CenterScreen;

            table_Click(Level1, EventArgs.Empty);

            InitializePlayersTable();
        }

        void InitializePlayersTable()
        {
            playersTable[0, 0] = "Difficulty";
            playersTable[1, 0] = Level1.Text;
            playersTable[2, 0] = Level2.Text;
            playersTable[3, 0] = Level3.Text;
            playersTable[4, 0] = Level4.Text;
            playersTable[5, 0] = Level5.Text;
            playersTable[0, 1] = "Player's Name";
            playersTable[0, 2] = "Best Time";
            playersTable[0, 3] = "Click's Count";

            for (int i = 1; i < playersTable.GetLength(0); i++)
            {
                playersTable[i, 1] = "Guest";
                playersTable[i, 2] = "00:00:00";
                playersTable[i, 3] = "000";
            }      
        }

        void MyGame_Load(object sender, EventArgs e)
        {
            panelImgs = new Bitmap[25] { Resources.b00, Resources.a01, Resources.a02, Resources.a03, Resources.a04, Resources.a05, Resources.a06, Resources.a07, Resources.a08, Resources.a09, Resources.a10, 
                                    Resources.a11, Resources.a12, Resources.a13, Resources.a14, Resources.a15, Resources.a16, Resources.a17, Resources.a18, Resources.a19, Resources.a20, Resources.a21, 
                                    Resources.a22, Resources.a23, Resources.a24 };

            backImgs = new Bitmap[10] { Resources.b01, Resources.b02, Resources.b03, Resources.b04, Resources.b05, Resources.b06, Resources.b07, Resources.b08, Resources.b09, Resources.b10 };
        }       

        void elapsed_Tick(object sender, EventArgs e)
        {
            time.Text = String.Format("{0,2:00}", (++startTime/3600)%12) + ":" +
                        String.Format("{0,2:00}", (startTime/60)%60) + ":" +
                        String.Format("{0,2:00}", (startTime%60));           
        }        

        void pan_Click(object sender, EventArgs e)
        {
            MyPanel pan = sender as MyPanel;
            if (pan != null && pan.isLocked) return;            

            pausecontinue.Enabled = true;            
            elapsed.Enabled = true;
            count.Text = (++clcount).ToString();
            
            if (pan == pans[0] || pan == pans[1] || pan == pans[2]) return;
            else
                for (int j = 0; j < pans.Length; j++)
                    if (pans[j] == null) { pans[j] = pan; break; }

            if (pans[1] != null)
            {
                selected = new int[2];
                for (int j = 0, k = 0; j < panels.Length; j++)
                    if (panels[j] == pans[0] | panels[j] == pans[1])
                        selected[k++] = j;                

                for (int i = 0, numvisible = 0; i < panels.Length; ++i)
                    if ((!panels[i].Visible) && (++numvisible == (panels.Length - 2)))
                    {
                        elapsed.Enabled = false;
                        pausecontinue.Enabled = false;
                        RefreshResults();
                    }
            }


            if (pans[2] != null)
            {         
                selected = new int[3];                
                for (int j = 0, k = 0; j < panels.Length; j++)
                {                    
                    if (panels[j] == pans[0] | panels[j] == pans[1] | panels[j] == pans[2])
                        selected[k++] = j;
                    else
                        panels[j].isLocked = true;
                }   
                click.Enabled = true;
            }
            
        }


        void RefreshResults()
        {
            string[,] about = new string[4, 2];
            about[0, 0] = "YOU WON!";
            about[2, 0] = "Your time is";
            about[2, 1] = time.Text;
            about[3, 0] = "Clicks are";
            about[3, 1] = count.Text;

            Table wontable = new Table(about, new Size(300, 200), StringAlignment.Near);
            wontable.Icon = this.Icon;
            wontable.Text = "Message";

            Button butt = new Button();
            butt.Text = "OK";            
            butt.Location = new Point((wontable.ClientSize.Width - butt.Width) / 2, wontable.ClientSize.Height - 3 * butt.Height / 2);
            butt.Click += (s, e) => 
            { 
                if (panels != null)
                    for (int j = 0; j < panels.Length; j++) panels[j].Visible = false;
                time.Text = "00:00:00";
                count.Text = "0";
                wontable.Close();
                savegame.Enabled = false;
            };
            wontable.AcceptButton = butt;
            TextBox textbox = new TextBox();
            textbox.Size = new Size(150, 0);
            textbox.Visible = false;
            textbox.Location = new Point((wontable.ClientSize.Width - textbox.Width) / 2, wontable.ClientSize.Height - 3 * textbox.Height);

            wontable.Resize += (s, e) =>
            {
                butt.Location = new Point((wontable.ClientSize.Width - butt.Width) / 2, wontable.ClientSize.Height - 3 * butt.Height / 2);
                textbox.Location = new Point((wontable.ClientSize.Width - textbox.Width) / 2, wontable.ClientSize.Height - 3 * textbox.Height);
            };

            wontable.Controls.Add(butt);
            wontable.Controls.Add(textbox);

            int dif = level;     

            char[] ch = new char[] { ':' };
            string[] ss = playersTable[dif, 2].Split(ch);

            int a = int.Parse(ss[0]) * 3600 + int.Parse(ss[1]) * 60 + int.Parse(ss[2]);
            int b = int.Parse(playersTable[dif,3]);

            textbox.TextChanged += (s, e) => { if (!string.Equals(textbox.Text, "Enter Your name here!")) playersTable[dif, 1] = textbox.Text; };

            if (a == 0 || a > startTime)
            {
                playersTable[dif, 2] = time.Text;
                playersTable[dif, 3] = count.Text;
                if (a == 0) about[0, 0] = "YOU WON!";
                else about[0, 0] = "You Beat the Record";                
                textbox.Visible = true;
                textbox.Text = "Enter Your name here!";               
            }
            else if (a == startTime && (b == 0 || b > clcount))
            {
                playersTable[dif, 3] = count.Text;
                if (b == 0) about[0, 0] = "YOU WON!";
                else about[0, 0] = "You Beat the Record";                 
                textbox.Visible = true;
                textbox.Text = "Enter Your name here!";                
            }
            wontable.Show();
        }        

        void click_Tick(object sender, EventArgs e)
        {
            if (pans[2] == null) return;
            if (pans[2].isRotated) { click.Enabled = false; ResetRotated(pans); }
        }

        void ResetRotated(MyPanel[] p)
        {            
            if (pans[0].Img == pans[1].Img)
            {
                pans[0].Visible = false;
                pans[1].Visible = false;
                pans[2].ResetRotate();
            }
            else if (p[0].Img == p[2].Img)
            {
                p[0].Visible = false;
                p[2].Visible = false;
                p[1].ResetRotate();
            }
            else if (p[1].Img == p[2].Img)
            {
                p[1].Visible = false;
                p[2].Visible = false;
                p[0].ResetRotate();
            }            
            for (int j = 0; j < p.Length; j++)
                p[j].ResetRotate();            

            for (int j = 0; j < pans.Length; j++)
                pans[j] = null;
            
            for (int j = 0; j < panels.Length; j++)
                panels[j].isLocked = false;                          
        }        

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (colorItem == backColor & bColor != Color.Black)
            {               
                BackColor = bColor;
                BackgroundImage = null;
                mainmenu.BackColor = bColor;
                statusmenue.BackColor = bColor;
            }
            else if (colorItem == backImage)
            {                
                g.DrawImage(backImgs[backImg], ClientRectangle);                
            }    
        }

        private void exitgame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newgame_Click(object sender, EventArgs e)
        {
            char[] ch = { ' ', 'x' };
            rows = uint.Parse(item.Text.Split(ch)[0]);
            columns = uint.Parse(item.Text.Split(ch)[3]);
            level = int.Parse(item.Name.Substring(item.Name.Length - 1, 1));

            for (int j = 0; j < pans.Length; j++)
                pans[j] = null;

            savegame.Enabled = true;
            pausecontinue.Enabled = false;
            pausecontinue.Text = "Pause";
            elapsed.Enabled = false;            
            startTime = 0;
            clcount = 0;
            time.Text = "00:00:00";
            count.Text = "0";
            // New Game starts here!
            newGame();            
        }

        void newGame() 
        {
            if (panels != null)
                for (int j = 0; j < panels.Length; j++)
                    Controls.Remove(panels[j]);

            panels = new MyPanel[rows * columns];
            index = new int[panels.Length];
            bool[] flags = new bool[panelImgs.Length];
            
            int tmp = 1, i = 0;
            int len = index.Length;
            while (true)
            {
                tmp = r.Next(1, 25);
                if (i < len / 2 && !flags[tmp])
                {
                    index[i++] = tmp;
                    flags[tmp] = true;                   
                }
                else if (i >= len / 2 && i < len && flags[tmp])
                {
                    index[i++] = tmp;
                    flags[tmp] = false;                    
                }
                else if (i >= len) break;
            }

            Point startPt = pt;
            MyPanel pan;
            for (int j = 0; j < panels.Length; j++)
            {
                pan = panels[j] = new MyPanel(panelImgs[0], panelImgs[index[j]]);
                pan.Click += new EventHandler(pan_Click);               
                pan.Location = startPt;
                pan.Size = size;
                startPt.X += size.Width;
                if (startPt.X == (columns * size.Width + pt.X)) { startPt.X = pt.X; startPt.Y += size.Height; }                                             
            }
            startPt = pt;            
            Controls.AddRange(panels);
        }         

        private void pausecontinue_Click(object sender, EventArgs e)
        {
            if (elapsed.Enabled && string.Equals(pausecontinue.Text, "Pause"))
            {               
                elapsed.Enabled = false;
                pausecontinue.Text = "Continue";
                for (int j = 0; j < panels.Length; j++)
                    panels[j].isLocked = true;
            }
            else if (!elapsed.Enabled && string.Equals(pausecontinue.Text, "Continue"))
            {
                elapsed.Enabled = true;
                pausecontinue.Text = "Pause";
                for (int j = 0; j < panels.Length; j++)
                    panels[j].isLocked = false;
            }
            
        }        

        private void backColor_Click(object sender, EventArgs e)
        {
            colorItem = sender as ToolStripMenuItem;
            if (colorItem == backColor && colorDialog1.ShowDialog() == DialogResult.OK)
            {
                backColor.Checked = !(backImage.Checked = false);
                bColor = colorDialog1.Color;
            }
            else
            {
                backImage.Checked = !(backColor.Checked = false);
                int tmp = r.Next(0, 9);
                while (tmp == backImg) { tmp = r.Next(0, 9); }
                backImg = tmp;
            }
            Invalidate();
        }         

        private void table_Click(object sender, EventArgs e)
        {    
            if(item != null)
            item.Checked = false;
            item = sender as ToolStripMenuItem;
            item.Checked = true;
        }

        private void aboutgame_Click(object sender, EventArgs e)
        {
            string[,] about = new string[5,1];            
            about[0, 0] = this.Text;
            about[1, 0] = "Copyright (c) 2012";
            about[2, 0] = "MIC Armenia";
            about[3, 0] = "All rights reserved";
            about[4, 0] = "Powered by Narek Mkrtchyan";
            Table abtable = new Table(about, new Size(350, 150), StringAlignment.Near);
            abtable.Icon = this.Icon;
            abtable.BackColor = Color.AliceBlue;
            abtable.Text = "Message";
            if (abtable == null) return;
            abtable.Show();
        }

        private void bestplayers_Click(object sender, EventArgs e)
        {
            Table bptable = new Table(playersTable, new Size(480, 170), StringAlignment.Center);
            bptable.Icon = this.Icon;
            bptable.BackColor = Color.AliceBlue;
            bptable.Text = "Best Results";
            if (bptable == null) return;
            bptable.Show();
        } 
  
        private void savegame_Click(object sender, EventArgs e)
        {   
                Save();
                loadgame.Enabled = true;
        }

        void Save()
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.InitialDirectory = ".";
                save.Filter = "MyGame (*.mg)|*.mg";
                save.RestoreDirectory = true;
                save.FileName = "MyGame1";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Stream ms = save.OpenFile();
                    if (ms != null)
                    {
                        BinaryFormatter myBF = new BinaryFormatter();

                        visibleState = new bool[panels.Length];                        
                        for (int j = 0; j < panels.Length; j++)
                        visibleState[j] = panels[j].Visible;
                        SaveGame sg = new SaveGame(backImg, bColor, level, selected, index, visibleState, new uint[] { startTime, clcount, rows, columns });                        
                        myBF.Serialize(ms, sg);
                        ms.Close();
                    }
                }
            } 
        }

        private void loadgame_Click(object sender, EventArgs e)
        {
            LoadGame();
        }

        void LoadGame()
        {
            savegame.Enabled = true;
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.InitialDirectory = ".";
                open.Filter = "MyGame (*.mg)|*.mg";
                open.RestoreDirectory = true;
                open.FileName = "MyGame1";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Stream ms = open.OpenFile();
                    if (ms != null)
                    {
                        BinaryFormatter myBF = new BinaryFormatter();
                        SaveGame sg = (SaveGame)myBF.Deserialize(ms);
                        ms.Close();

                        this.backImg = sg.backImg;
                        this.bColor = sg.bColor;
                        this.level = sg.level;
                        this.selected = sg.selected;
                        this.index = sg.index;
                        this.visibleState = sg.visibleState;
                        this.startTime = sg.startTime;
                        this.clcount = sg.clcount;
                        this.rows = sg.rows;
                        this.columns = sg.columns;

                        if (panels != null)
                            for (int j = 0; j < panels.Length; j++)
                                Controls.Remove(panels[j]);
                        panels = new MyPanel[rows * columns];
                        Point startPt = pt;
                        MyPanel pan;
                        for (int j = 0; j < panels.Length; j++)
                        {
                            pan = panels[j] = new MyPanel(panelImgs[0], panelImgs[index[j]]);
                            pan.Click += new EventHandler(pan_Click);
                            pan.Location = startPt;
                            pan.Size = size;
                            pan.Visible = visibleState[j];
                            startPt.X += size.Width;
                            if (startPt.X == (columns * size.Width + pt.X)) { startPt.X = pt.X; startPt.Y += size.Height; }
                        }
                        startPt = pt;
                        Controls.AddRange(panels);

                        for (int j = 0; j < panels.Length; j++)
                            panels[j].isLocked = false;
                        pans = new MyPanel[3];
                        for (int j = 0; j < selected.Length; j++)
                        {
                            pans[j] = panels[selected[j]];
                            pans[j].MyPanel_Click(null, EventArgs.Empty);
                        }
                        count.Text = (++clcount).ToString();

                        time.Text = String.Format("{0,2:00}", (++startTime / 3600) % 12) + ":" +
                        String.Format("{0,2:00}", (startTime / 60) % 60) + ":" +
                        String.Format("{0,2:00}", (startTime % 60));

                        elapsed.Enabled = true;
                        pausecontinue.Enabled = true;
                        pausecontinue.Text = "Pause";

                        Invalidate();
                    }
                }
            }

        }



    }
}
