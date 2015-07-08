namespace E01Helper
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolstrip = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnResolveChain = new System.Windows.Forms.ToolStripButton();
            this.tsbtnVerifyMD5 = new System.Windows.Forms.ToolStripButton();
            this.tslblInfo = new System.Windows.Forms.ToolStripLabel();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.bgwMain = new System.ComponentModel.BackgroundWorker();
            this.bgwMD5 = new System.ComponentModel.BackgroundWorker();
            this.toolstrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // toolstrip
            // 
            this.toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpen,
            this.tsbtnRefresh,
            this.tsbtnResolveChain,
            this.tsbtnVerifyMD5,
            this.tslblInfo});
            this.toolstrip.Location = new System.Drawing.Point(0, 0);
            this.toolstrip.Name = "toolstrip";
            this.toolstrip.Size = new System.Drawing.Size(743, 25);
            this.toolstrip.TabIndex = 0;
            this.toolstrip.Text = "toolstrip";
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpen.Image")));
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpen.Text = "Open E01...";
            this.tsbtnOpen.Click += new System.EventHandler(this.tsbtnOpen_Click);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRefresh.Text = "Refresh Last File";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // tsbtnResolveChain
            // 
            this.tsbtnResolveChain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnResolveChain.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnResolveChain.Image")));
            this.tsbtnResolveChain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnResolveChain.Name = "tsbtnResolveChain";
            this.tsbtnResolveChain.Size = new System.Drawing.Size(23, 22);
            this.tsbtnResolveChain.Text = "Resolve File Chain";
            this.tsbtnResolveChain.Click += new System.EventHandler(this.tsbtnResolveChain_Click);
            // 
            // tsbtnVerifyMD5
            // 
            this.tsbtnVerifyMD5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnVerifyMD5.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnVerifyMD5.Image")));
            this.tsbtnVerifyMD5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnVerifyMD5.Name = "tsbtnVerifyMD5";
            this.tsbtnVerifyMD5.Size = new System.Drawing.Size(23, 22);
            this.tsbtnVerifyMD5.Text = "Verify MD5";
            this.tsbtnVerifyMD5.Click += new System.EventHandler(this.tsbtnVerifyMD5_Click);
            // 
            // tslblInfo
            // 
            this.tslblInfo.Name = "tslblInfo";
            this.tslblInfo.Size = new System.Drawing.Size(0, 22);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 25);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.Size = new System.Drawing.Size(743, 372);
            this.dgvMain.TabIndex = 1;
            // 
            // bgwMain
            // 
            this.bgwMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMain_DoWork);
            this.bgwMain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMain_RunWorkerCompleted);
            // 
            // bgwMD5
            // 
            this.bgwMD5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMD5_DoWork);
            this.bgwMD5.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMD5_RunWorkerCompleted);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 397);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.toolstrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "E01Helper";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.toolstrip.ResumeLayout(false);
            this.toolstrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolstrip;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.ComponentModel.BackgroundWorker bgwMain;
        private System.Windows.Forms.ToolStripLabel tslblInfo;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripButton tsbtnOpen;
        private System.Windows.Forms.ToolStripButton tsbtnResolveChain;
        private System.Windows.Forms.ToolStripButton tsbtnVerifyMD5;
        private System.ComponentModel.BackgroundWorker bgwMD5;
    }
}

