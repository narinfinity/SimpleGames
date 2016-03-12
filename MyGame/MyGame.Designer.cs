namespace MyGameProgram
{
    partial class MyGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyGame));
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.game = new System.Windows.Forms.ToolStripMenuItem();
            this.newgame = new System.Windows.Forms.ToolStripMenuItem();
            this.savegame = new System.Windows.Forms.ToolStripMenuItem();
            this.pausecontinue = new System.Windows.Forms.ToolStripMenuItem();
            this.exitgame = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsgame = new System.Windows.Forms.ToolStripMenuItem();
            this.difficulty = new System.Windows.Forms.ToolStripMenuItem();
            this.Level1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Level2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Level3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Level4 = new System.Windows.Forms.ToolStripMenuItem();
            this.Level5 = new System.Windows.Forms.ToolStripMenuItem();
            this.backColor = new System.Windows.Forms.ToolStripMenuItem();
            this.backImage = new System.Windows.Forms.ToolStripMenuItem();
            this.helpgame = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutgame = new System.Windows.Forms.ToolStripMenuItem();
            this.bestplayers = new System.Windows.Forms.ToolStripMenuItem();
            this.statusmenue = new System.Windows.Forms.StatusStrip();
            this.elapsedtime = new System.Windows.Forms.ToolStripStatusLabel();
            this.time = new System.Windows.Forms.ToolStripStatusLabel();
            this.clickscount = new System.Windows.Forms.ToolStripStatusLabel();
            this.count = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.loadgame = new System.Windows.Forms.ToolStripMenuItem();
            this.mainmenu.SuspendLayout();
            this.statusmenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainmenu
            // 
            this.mainmenu.AutoSize = false;
            this.mainmenu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.game,
            this.settingsgame,
            this.helpgame,
            this.bestplayers});
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mainmenu.Size = new System.Drawing.Size(621, 24);
            this.mainmenu.TabIndex = 0;
            this.mainmenu.Text = "menuStrip1";
            // 
            // game
            // 
            this.game.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newgame,
            this.savegame,
            this.loadgame,
            this.pausecontinue,
            this.exitgame});
            this.game.Name = "game";
            this.game.Size = new System.Drawing.Size(46, 20);
            this.game.Text = "Game";
            // 
            // newgame
            // 
            this.newgame.Name = "newgame";
            this.newgame.Size = new System.Drawing.Size(152, 22);
            this.newgame.Text = "New";
            this.newgame.Click += new System.EventHandler(this.newgame_Click);
            // 
            // savegame
            // 
            this.savegame.Enabled = false;
            this.savegame.Name = "savegame";
            this.savegame.Size = new System.Drawing.Size(152, 22);
            this.savegame.Text = "Save";
            this.savegame.Click += new System.EventHandler(this.savegame_Click);
            // 
            // pausecontinue
            // 
            this.pausecontinue.Enabled = false;
            this.pausecontinue.Name = "pausecontinue";
            this.pausecontinue.Size = new System.Drawing.Size(152, 22);
            this.pausecontinue.Text = "Pause";
            this.pausecontinue.Click += new System.EventHandler(this.pausecontinue_Click);
            // 
            // exitgame
            // 
            this.exitgame.Name = "exitgame";
            this.exitgame.Size = new System.Drawing.Size(152, 22);
            this.exitgame.Text = "Exit";
            this.exitgame.Click += new System.EventHandler(this.exitgame_Click);
            // 
            // settingsgame
            // 
            this.settingsgame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficulty,
            this.backColor,
            this.backImage});
            this.settingsgame.Name = "settingsgame";
            this.settingsgame.Size = new System.Drawing.Size(58, 20);
            this.settingsgame.Text = "Settings";
            // 
            // difficulty
            // 
            this.difficulty.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Level1,
            this.Level2,
            this.Level3,
            this.Level4,
            this.Level5});
            this.difficulty.Name = "difficulty";
            this.difficulty.Size = new System.Drawing.Size(137, 22);
            this.difficulty.Text = "Difficulty";
            // 
            // Level1
            // 
            this.Level1.Checked = true;
            this.Level1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(109, 22);
            this.Level1.Text = "3 x 4";
            this.Level1.Click += new System.EventHandler(this.table_Click);
            // 
            // Level2
            // 
            this.Level2.Name = "Level2";
            this.Level2.Size = new System.Drawing.Size(109, 22);
            this.Level2.Text = "4 x 5";
            this.Level2.Click += new System.EventHandler(this.table_Click);
            // 
            // Level3
            // 
            this.Level3.Name = "Level3";
            this.Level3.Size = new System.Drawing.Size(109, 22);
            this.Level3.Text = "5 x 6";
            this.Level3.Click += new System.EventHandler(this.table_Click);
            // 
            // Level4
            // 
            this.Level4.Name = "Level4";
            this.Level4.Size = new System.Drawing.Size(109, 22);
            this.Level4.Text = "6 x 7";
            this.Level4.Click += new System.EventHandler(this.table_Click);
            // 
            // Level5
            // 
            this.Level5.Name = "Level5";
            this.Level5.Size = new System.Drawing.Size(109, 22);
            this.Level5.Text = "6 x 8";
            this.Level5.Click += new System.EventHandler(this.table_Click);
            // 
            // backColor
            // 
            this.backColor.Name = "backColor";
            this.backColor.Size = new System.Drawing.Size(137, 22);
            this.backColor.Text = "BackColor";
            this.backColor.Click += new System.EventHandler(this.backColor_Click);
            // 
            // backImage
            // 
            this.backImage.Name = "backImage";
            this.backImage.Size = new System.Drawing.Size(137, 22);
            this.backImage.Text = "BackImage";
            this.backImage.Click += new System.EventHandler(this.backColor_Click);
            // 
            // helpgame
            // 
            this.helpgame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutgame});
            this.helpgame.Name = "helpgame";
            this.helpgame.Size = new System.Drawing.Size(40, 20);
            this.helpgame.Text = "Help";
            // 
            // aboutgame
            // 
            this.aboutgame.Name = "aboutgame";
            this.aboutgame.Size = new System.Drawing.Size(114, 22);
            this.aboutgame.Text = "About";
            this.aboutgame.Click += new System.EventHandler(this.aboutgame_Click);
            // 
            // bestplayers
            // 
            this.bestplayers.Name = "bestplayers";
            this.bestplayers.Size = new System.Drawing.Size(78, 20);
            this.bestplayers.Text = "Best Results";
            this.bestplayers.Click += new System.EventHandler(this.bestplayers_Click);
            // 
            // statusmenue
            // 
            this.statusmenue.AutoSize = false;
            this.statusmenue.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusmenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elapsedtime,
            this.time,
            this.clickscount,
            this.count});
            this.statusmenue.Location = new System.Drawing.Point(0, 489);
            this.statusmenue.Name = "statusmenue";
            this.statusmenue.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusmenue.Size = new System.Drawing.Size(621, 22);
            this.statusmenue.TabIndex = 1;
            this.statusmenue.Text = "statusStrip1";
            // 
            // elapsedtime
            // 
            this.elapsedtime.Name = "elapsedtime";
            this.elapsedtime.Size = new System.Drawing.Size(69, 17);
            this.elapsedtime.Text = "Elapsed Time";
            // 
            // time
            // 
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(51, 17);
            this.time.Text = "00:00:00";
            // 
            // clickscount
            // 
            this.clickscount.Name = "clickscount";
            this.clickscount.Size = new System.Drawing.Size(72, 17);
            this.clickscount.Text = "Clicks\'s Count";
            // 
            // count
            // 
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(13, 17);
            this.count.Text = "0";
            // 
            // loadgame
            // 
            this.loadgame.Enabled = false;
            this.loadgame.Name = "loadgame";
            this.loadgame.Size = new System.Drawing.Size(152, 22);
            this.loadgame.Text = "Load";
            this.loadgame.Click += new System.EventHandler(this.loadgame_Click);
            // 
            // MyGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(621, 511);
            this.Controls.Add(this.statusmenue);
            this.Controls.Add(this.mainmenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainmenu;
            this.Name = "MyGame";
            this.Text = "Image Rotation Game";
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.statusmenue.ResumeLayout(false);
            this.statusmenue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem game;
        private System.Windows.Forms.ToolStripMenuItem newgame;
        private System.Windows.Forms.ToolStripMenuItem savegame;
        private System.Windows.Forms.ToolStripMenuItem pausecontinue;
        private System.Windows.Forms.ToolStripMenuItem exitgame;
        private System.Windows.Forms.ToolStripMenuItem settingsgame;
        private System.Windows.Forms.ToolStripMenuItem difficulty;
        private System.Windows.Forms.ToolStripMenuItem Level1;
        private System.Windows.Forms.ToolStripMenuItem Level2;
        private System.Windows.Forms.ToolStripMenuItem Level3;
        private System.Windows.Forms.ToolStripMenuItem Level4;
        private System.Windows.Forms.ToolStripMenuItem Level5;
        private System.Windows.Forms.ToolStripMenuItem backColor;
        private System.Windows.Forms.ToolStripMenuItem backImage;
        private System.Windows.Forms.ToolStripMenuItem helpgame;
        private System.Windows.Forms.ToolStripMenuItem aboutgame;
        private System.Windows.Forms.ToolStripMenuItem bestplayers;
        private System.Windows.Forms.StatusStrip statusmenue;
        private System.Windows.Forms.ToolStripStatusLabel elapsedtime;
        private System.Windows.Forms.ToolStripStatusLabel time;
        private System.Windows.Forms.ToolStripStatusLabel clickscount;
        private System.Windows.Forms.ToolStripStatusLabel count;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem loadgame;
    }
}

