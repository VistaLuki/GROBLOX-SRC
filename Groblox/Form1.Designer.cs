namespace Groblox
{
    partial class Groblox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Groblox));
            this.PlayServer = new System.Windows.Forms.Button();
            this.mapTreeView = new System.Windows.Forms.TreeView();
            this.username = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.usrlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PlaySolo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HostServer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayServer
            // 
            this.PlayServer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlayServer.BackgroundImage")));
            this.PlayServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayServer.Location = new System.Drawing.Point(17, 227);
            this.PlayServer.Name = "PlayServer";
            this.PlayServer.Size = new System.Drawing.Size(133, 50);
            this.PlayServer.TabIndex = 2;
            this.PlayServer.UseVisualStyleBackColor = true;
            this.PlayServer.Click += new System.EventHandler(this.PlayServer_Click);
            // 
            // mapTreeView
            // 
            this.mapTreeView.HideSelection = false;
            this.mapTreeView.Location = new System.Drawing.Point(6, 13);
            this.mapTreeView.Name = "mapTreeView";
            this.mapTreeView.Size = new System.Drawing.Size(461, 143);
            this.mapTreeView.TabIndex = 4;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(17, 30);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(121, 22);
            this.username.TabIndex = 6;
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(17, 88);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(137, 22);
            this.ip.TabIndex = 7;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(17, 152);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(97, 22);
            this.port.TabIndex = 8;
            // 
            // usrlabel
            // 
            this.usrlabel.AutoSize = true;
            this.usrlabel.Location = new System.Drawing.Point(14, 12);
            this.usrlabel.Name = "usrlabel";
            this.usrlabel.Size = new System.Drawing.Size(61, 13);
            this.usrlabel.TabIndex = 9;
            this.usrlabel.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Port:";
            // 
            // PlaySolo
            // 
            this.PlaySolo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlaySolo.BackgroundImage")));
            this.PlaySolo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlaySolo.Location = new System.Drawing.Point(156, 227);
            this.PlaySolo.Name = "PlaySolo";
            this.PlaySolo.Size = new System.Drawing.Size(133, 50);
            this.PlaySolo.TabIndex = 14;
            this.PlaySolo.UseVisualStyleBackColor = true;
            this.PlaySolo.Click += new System.EventHandler(this.PlaySolo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(685, 171);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // HostServer
            // 
            this.HostServer.BackColor = System.Drawing.Color.Gold;
            this.HostServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HostServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HostServer.Location = new System.Drawing.Point(543, 232);
            this.HostServer.Name = "HostServer";
            this.HostServer.Size = new System.Drawing.Size(123, 40);
            this.HostServer.TabIndex = 16;
            this.HostServer.Text = "Host Server";
            this.HostServer.UseVisualStyleBackColor = false;
            this.HostServer.Click += new System.EventHandler(this.HostServer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mapTreeView);
            this.groupBox1.Location = new System.Drawing.Point(199, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 162);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maps";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HostServer);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.PlaySolo);
            this.panel1.Controls.Add(this.usrlabel);
            this.panel1.Controls.Add(this.PlayServer);
            this.panel1.Controls.Add(this.port);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.username);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ip);
            this.panel1.Location = new System.Drawing.Point(12, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 287);
            this.panel1.TabIndex = 18;
            // 
            // lblNotice
            // 
            this.lblNotice.BackColor = System.Drawing.Color.Red;
            this.lblNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotice.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNotice.ForeColor = System.Drawing.Color.White;
            this.lblNotice.Location = new System.Drawing.Point(12, 186);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(685, 23);
            this.lblNotice.TabIndex = 19;
            this.lblNotice.Text = "Welcome to GROBLOX 2.5!";
            this.lblNotice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Groblox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(709, 507);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Groblox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GROBLOX 2.5";
            this.Load += new System.EventHandler(this.Groblox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayServer;
        private System.Windows.Forms.TreeView mapTreeView;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox port;

        private System.Windows.Forms.Label usrlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button PlaySolo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button HostServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNotice;
    }
}