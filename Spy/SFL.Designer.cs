namespace Spy
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.chkHide = new System.Windows.Forms.CheckBox();
            this.imgCam = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCam)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDevices
            // 
            this.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevices.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(12, 13);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(241, 22);
            this.cmbDevices.TabIndex = 2;
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.status.Location = new System.Drawing.Point(0, 202);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(259, 22);
            this.status.TabIndex = 6;
            this.status.Text = "Status: ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // chkHide
            // 
            this.chkHide.AutoSize = true;
            this.chkHide.Checked = true;
            this.chkHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHide.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHide.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkHide.Location = new System.Drawing.Point(12, 180);
            this.chkHide.Name = "chkHide";
            this.chkHide.Size = new System.Drawing.Size(224, 18);
            this.chkHide.TabIndex = 7;
            this.chkHide.Text = "Hide when the Start button was pressed";
            this.chkHide.UseVisualStyleBackColor = true;
            // 
            // imgCam
            // 
            this.imgCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCam.Location = new System.Drawing.Point(12, 46);
            this.imgCam.Name = "imgCam";
            this.imgCam.Size = new System.Drawing.Size(160, 129);
            this.imgCam.TabIndex = 5;
            this.imgCam.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Image = global::Spy.Properties.Resources.media_playback_start_2;
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(178, 147);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 28);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::Spy.Properties.Resources.view_refresh_3;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(178, 112);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnKill
            // 
            this.btnKill.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKill.Image = global::Spy.Properties.Resources.project_development_close;
            this.btnKill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKill.Location = new System.Drawing.Point(178, 46);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(75, 28);
            this.btnKill.TabIndex = 1;
            this.btnKill.Text = "Kill";
            this.btnKill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLock
            // 
            this.btnLock.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.Image = global::Spy.Properties.Resources.system_lock_screen;
            this.btnLock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLock.Location = new System.Drawing.Point(178, 80);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(75, 28);
            this.btnLock.TabIndex = 0;
            this.btnLock.Text = "Lock";
            this.btnLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.button1_Click);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "media-playback-pause-2.ico");
            this.images.Images.SetKeyName(1, "media-playback-start-2.ico");
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 224);
            this.Controls.Add(this.chkHide);
            this.Controls.Add(this.status);
            this.Controls.Add(this.imgCam);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbDevices);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.btnLock);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpyFriendLocker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SFL_FormClosed);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox imgCam;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox chkHide;
        private System.Windows.Forms.ImageList images;
    }
}

