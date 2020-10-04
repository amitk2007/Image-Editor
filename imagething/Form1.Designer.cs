namespace imagething
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.change = new System.Windows.Forms.Button();
            this.savepath = new System.Windows.Forms.Button();
            this.imageFilterBox = new System.Windows.Forms.ComboBox();
            this.moreOptions = new System.Windows.Forms.ComboBox();
            this.secondImagePath = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.filterValus = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.point1 = new System.Windows.Forms.TextBox();
            this.point2 = new System.Windows.Forms.TextBox();
            this.Rcol = new System.Windows.Forms.ComboBox();
            this.Gcol = new System.Windows.Forms.ComboBox();
            this.Bcol = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.RGBLable = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorPickerButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.colorLabel = new System.Windows.Forms.Label();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.thresholdTextBox = new System.Windows.Forms.TextBox();
            this.noBackgroundGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.noColorGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.noBackgroundGroupBox.SuspendLayout();
            this.noColorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(299, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(549, 445);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // change
            // 
            this.change.Location = new System.Drawing.Point(50, 87);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(90, 40);
            this.change.TabIndex = 3;
            this.change.Text = "change pic";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // savepath
            // 
            this.savepath.Location = new System.Drawing.Point(13, 438);
            this.savepath.Name = "savepath";
            this.savepath.Size = new System.Drawing.Size(147, 54);
            this.savepath.TabIndex = 4;
            this.savepath.Text = "Save image";
            this.savepath.UseVisualStyleBackColor = true;
            this.savepath.Click += new System.EventHandler(this.savepath_Click);
            // 
            // imageFilterBox
            // 
            this.imageFilterBox.CausesValidation = false;
            this.imageFilterBox.FormattingEnabled = true;
            this.imageFilterBox.Items.AddRange(new object[] {
            "Default image",
            "No Color",
            "No background",
            "B&W",
            "Combine",
            "Threshold",
            "bluer",
            "bluer Exept",
            "bluer Just",
            "Swich Colors"});
            this.imageFilterBox.Location = new System.Drawing.Point(50, 60);
            this.imageFilterBox.Name = "imageFilterBox";
            this.imageFilterBox.Size = new System.Drawing.Size(90, 21);
            this.imageFilterBox.TabIndex = 8;
            this.imageFilterBox.SelectedIndexChanged += new System.EventHandler(this.imageFilterBox_SelectedIndexChanged);
            // 
            // moreOptions
            // 
            this.moreOptions.FormattingEnabled = true;
            this.moreOptions.Location = new System.Drawing.Point(203, 405);
            this.moreOptions.Name = "moreOptions";
            this.moreOptions.Size = new System.Drawing.Size(90, 21);
            this.moreOptions.TabIndex = 9;
            this.moreOptions.Visible = false;
            // 
            // secondImagePath
            // 
            this.secondImagePath.Location = new System.Drawing.Point(122, 403);
            this.secondImagePath.Name = "secondImagePath";
            this.secondImagePath.Size = new System.Drawing.Size(75, 23);
            this.secondImagePath.TabIndex = 10;
            this.secondImagePath.Text = "add second image";
            this.secondImagePath.UseVisualStyleBackColor = true;
            this.secondImagePath.Visible = false;
            this.secondImagePath.Click += new System.EventHandler(this.secondImagePath_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(626, 308);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(222, 187);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // filterValus
            // 
            this.filterValus.Location = new System.Drawing.Point(207, 432);
            this.filterValus.Name = "filterValus";
            this.filterValus.Size = new System.Drawing.Size(72, 20);
            this.filterValus.TabIndex = 12;
            this.filterValus.Text = "0.X,0.Y";
            this.filterValus.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // point1
            // 
            this.point1.Location = new System.Drawing.Point(221, 2);
            this.point1.Name = "point1";
            this.point1.Size = new System.Drawing.Size(86, 20);
            this.point1.TabIndex = 14;
            this.point1.Visible = false;
            // 
            // point2
            // 
            this.point2.Location = new System.Drawing.Point(221, 24);
            this.point2.Name = "point2";
            this.point2.Size = new System.Drawing.Size(86, 20);
            this.point2.TabIndex = 15;
            this.point2.Visible = false;
            // 
            // Rcol
            // 
            this.Rcol.FormattingEnabled = true;
            this.Rcol.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.Rcol.Location = new System.Drawing.Point(8, 374);
            this.Rcol.Name = "Rcol";
            this.Rcol.Size = new System.Drawing.Size(51, 21);
            this.Rcol.TabIndex = 16;
            // 
            // Gcol
            // 
            this.Gcol.FormattingEnabled = true;
            this.Gcol.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.Gcol.Location = new System.Drawing.Point(65, 374);
            this.Gcol.Name = "Gcol";
            this.Gcol.Size = new System.Drawing.Size(51, 21);
            this.Gcol.TabIndex = 17;
            // 
            // Bcol
            // 
            this.Bcol.FormattingEnabled = true;
            this.Bcol.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.Bcol.Location = new System.Drawing.Point(122, 374);
            this.Bcol.Name = "Bcol";
            this.Bcol.Size = new System.Drawing.Size(48, 21);
            this.Bcol.TabIndex = 18;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.White;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.checkedListBox1.Location = new System.Drawing.Point(22, 44);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(117, 64);
            this.checkedListBox1.TabIndex = 19;
            // 
            // RGBLable
            // 
            this.RGBLable.AutoSize = true;
            this.RGBLable.Location = new System.Drawing.Point(20, 347);
            this.RGBLable.Name = "RGBLable";
            this.RGBLable.Size = new System.Drawing.Size(140, 13);
            this.RGBLable.TabIndex = 20;
            this.RGBLable.Text = "Red           Green          Blue";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openFileLocationToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.saveAsToolStripMenuItem.Text = "Save as..";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open file location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // ColorPickerButton
            // 
            this.ColorPickerButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ColorPickerButton.Location = new System.Drawing.Point(107, 19);
            this.ColorPickerButton.Name = "ColorPickerButton";
            this.ColorPickerButton.Size = new System.Drawing.Size(25, 26);
            this.ColorPickerButton.TabIndex = 22;
            this.ColorPickerButton.UseVisualStyleBackColor = false;
            this.ColorPickerButton.Click += new System.EventHandler(this.ColorPickerButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(108, 61);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(143, 45);
            this.trackBar1.TabIndex = 23;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 130;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(12, 24);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(81, 13);
            this.colorLabel.TabIndex = 24;
            this.colorLabel.Text = "Color to remove";
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(9, 61);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.thresholdLabel.TabIndex = 25;
            this.thresholdLabel.Text = "Threshold";
            // 
            // thresholdTextBox
            // 
            this.thresholdTextBox.Location = new System.Drawing.Point(69, 61);
            this.thresholdTextBox.MaxLength = 3;
            this.thresholdTextBox.Name = "thresholdTextBox";
            this.thresholdTextBox.Size = new System.Drawing.Size(33, 20);
            this.thresholdTextBox.TabIndex = 26;
            this.thresholdTextBox.WordWrap = false;
            this.thresholdTextBox.TextChanged += new System.EventHandler(this.thresholdTextBox_TextChanged_1);
            // 
            // noBackgroundGroupBox
            // 
            this.noBackgroundGroupBox.Controls.Add(this.noColorGroupBox);
            this.noBackgroundGroupBox.Controls.Add(this.thresholdTextBox);
            this.noBackgroundGroupBox.Controls.Add(this.thresholdLabel);
            this.noBackgroundGroupBox.Controls.Add(this.colorLabel);
            this.noBackgroundGroupBox.Controls.Add(this.trackBar1);
            this.noBackgroundGroupBox.Controls.Add(this.ColorPickerButton);
            this.noBackgroundGroupBox.Location = new System.Drawing.Point(8, 133);
            this.noBackgroundGroupBox.Name = "noBackgroundGroupBox";
            this.noBackgroundGroupBox.Size = new System.Drawing.Size(278, 108);
            this.noBackgroundGroupBox.TabIndex = 27;
            this.noBackgroundGroupBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "What color channel do you want to keep?";
            // 
            // noColorGroupBox
            // 
            this.noColorGroupBox.Controls.Add(this.label2);
            this.noColorGroupBox.Controls.Add(this.checkedListBox1);
            this.noColorGroupBox.Location = new System.Drawing.Point(6, 0);
            this.noColorGroupBox.Name = "noColorGroupBox";
            this.noColorGroupBox.Size = new System.Drawing.Size(237, 114);
            this.noColorGroupBox.TabIndex = 29;
            this.noColorGroupBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 515);
            this.Controls.Add(this.noBackgroundGroupBox);
            this.Controls.Add(this.RGBLable);
            this.Controls.Add(this.Bcol);
            this.Controls.Add(this.Gcol);
            this.Controls.Add(this.Rcol);
            this.Controls.Add(this.point2);
            this.Controls.Add(this.point1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filterValus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.secondImagePath);
            this.Controls.Add(this.moreOptions);
            this.Controls.Add(this.imageFilterBox);
            this.Controls.Add(this.savepath);
            this.Controls.Add(this.change);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.noBackgroundGroupBox.ResumeLayout(false);
            this.noBackgroundGroupBox.PerformLayout();
            this.noColorGroupBox.ResumeLayout(false);
            this.noColorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.Button savepath;
        private System.Windows.Forms.ComboBox imageFilterBox;
        private System.Windows.Forms.ComboBox moreOptions;
        private System.Windows.Forms.Button secondImagePath;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox filterValus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox point1;
        private System.Windows.Forms.TextBox point2;
        private System.Windows.Forms.ComboBox Rcol;
        private System.Windows.Forms.ComboBox Gcol;
        private System.Windows.Forms.ComboBox Bcol;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label RGBLable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ColorPickerButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.TextBox thresholdTextBox;
        private System.Windows.Forms.GroupBox noBackgroundGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox noColorGroupBox;
    }
}

