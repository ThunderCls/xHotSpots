namespace DotNetPlugin
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLocateHS = new System.Windows.Forms.Button();
            this.cmbCompiler = new System.Windows.Forms.ComboBox();
            this.lstFoundSpots = new System.Windows.Forms.ListView();
            this.colModule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tFound = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnLocateHS);
            this.groupBox1.Controls.Add(this.cmbCompiler);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Compiler ";
            // 
            // btnLocateHS
            // 
            this.btnLocateHS.Location = new System.Drawing.Point(106, 68);
            this.btnLocateHS.Name = "btnLocateHS";
            this.btnLocateHS.Size = new System.Drawing.Size(110, 26);
            this.btnLocateHS.TabIndex = 2;
            this.btnLocateHS.Text = "Locate Hotspots";
            this.btnLocateHS.UseVisualStyleBackColor = true;
            this.btnLocateHS.Click += new System.EventHandler(this.btnLocateHS_Click);
            // 
            // cmbCompiler
            // 
            this.cmbCompiler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCompiler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCompiler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.cmbCompiler.FormattingEnabled = true;
            this.cmbCompiler.Items.AddRange(new object[] {
            "Visual Basic 5",
            "Visual Basic 6",
            "Borland Delphi/C++",
            "Visual C++ 5/6 (MFC)",
            "Visual C++ 10 (MFC Dynamic Debug)",
            "Visual C++ 10 (MFC Dynamic Release)",
            "Visual C++ 10 (MFC Static Debug)",
            "Visual C++ 10 (MFC Static Release)",
            "Visual C++ 12 (MFC Dynamic Debug)",
            "Visual C++ 12 (MFC Dynamic Release)",
            "Visual C++ 12 (MFC Static Debug)",
            "Visual C++ 12 (MFC Static Release)",
            "Visual C++ 14 (MFC Dynamic Debug)",
            "Visual C++ 14 (MFC Dynamic Release)",
            "Visual C++ 14 (MFC Static Debug)",
            "Visual C++ 14 (MFC Static Release)",
            "Point H-MEMCPY (Generic)"});
            this.cmbCompiler.Location = new System.Drawing.Point(43, 32);
            this.cmbCompiler.Name = "cmbCompiler";
            this.cmbCompiler.Size = new System.Drawing.Size(230, 21);
            this.cmbCompiler.TabIndex = 0;
            // 
            // lstFoundSpots
            // 
            this.lstFoundSpots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFoundSpots.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colModule,
            this.colAddress});
            this.lstFoundSpots.FullRowSelect = true;
            this.lstFoundSpots.Location = new System.Drawing.Point(12, 136);
            this.lstFoundSpots.Name = "lstFoundSpots";
            this.lstFoundSpots.Size = new System.Drawing.Size(311, 189);
            this.lstFoundSpots.TabIndex = 2;
            this.lstFoundSpots.UseCompatibleStateImageBehavior = false;
            this.lstFoundSpots.View = System.Windows.Forms.View.Details;
            // 
            // colModule
            // 
            this.colModule.Text = "Module";
            this.colModule.Width = 169;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 103;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tFound});
            this.statusBar.Location = new System.Drawing.Point(0, 337);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(335, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabel1.Text = "Hotspots found: ";
            // 
            // tFound
            // 
            this.tFound.Name = "tFound";
            this.tFound.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 359);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.lstFoundSpots);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HotSpots";
            this.groupBox1.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCompiler;
        private System.Windows.Forms.ListView lstFoundSpots;
        public System.Windows.Forms.ListView LstFoundSpots
        {
            get { return lstFoundSpots; }
            set { lstFoundSpots = value; }
        }

        private System.Windows.Forms.ColumnHeader colModule;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tFound;
        public System.Windows.Forms.ToolStripStatusLabel Found
        {
            get { return tFound; }
            set { tFound = value; }
        }
        private System.Windows.Forms.Button btnLocateHS;
    }
}