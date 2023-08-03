
namespace DontStarveServerRunner
{
    partial class DontStarveServerRunner
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.buttonStopServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.buttonReloadStatus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNumberOfShardsValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxServerPath = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartServer.Location = new System.Drawing.Point(12, 268);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(301, 23);
            this.buttonStartServer.TabIndex = 0;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // buttonStopServer
            // 
            this.buttonStopServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopServer.Location = new System.Drawing.Point(12, 310);
            this.buttonStopServer.Name = "buttonStopServer";
            this.buttonStopServer.Size = new System.Drawing.Size(301, 23);
            this.buttonStopServer.TabIndex = 1;
            this.buttonStopServer.Text = "Stop Server";
            this.buttonStopServer.UseVisualStyleBackColor = true;
            this.buttonStopServer.Click += new System.EventHandler(this.buttonStopServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server Status:";
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelServerStatus.Location = new System.Drawing.Point(179, 203);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(0, 13);
            this.labelServerStatus.TabIndex = 3;
            // 
            // buttonReloadStatus
            // 
            this.buttonReloadStatus.Location = new System.Drawing.Point(12, 352);
            this.buttonReloadStatus.Name = "buttonReloadStatus";
            this.buttonReloadStatus.Size = new System.Drawing.Size(301, 23);
            this.buttonReloadStatus.TabIndex = 4;
            this.buttonReloadStatus.Text = "Reload Status";
            this.buttonReloadStatus.UseVisualStyleBackColor = true;
            this.buttonReloadStatus.Click += new System.EventHandler(this.buttonReloadStatus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of shards:";
            // 
            // labelNumberOfShardsValue
            // 
            this.labelNumberOfShardsValue.AutoSize = true;
            this.labelNumberOfShardsValue.ForeColor = System.Drawing.Color.Black;
            this.labelNumberOfShardsValue.Location = new System.Drawing.Point(179, 230);
            this.labelNumberOfShardsValue.Name = "labelNumberOfShardsValue";
            this.labelNumberOfShardsValue.Size = new System.Drawing.Size(0, 13);
            this.labelNumberOfShardsValue.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Server Path:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxServerPath
            // 
            this.textBoxServerPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxServerPath.Location = new System.Drawing.Point(15, 406);
            this.textBoxServerPath.Name = "textBoxServerPath";
            this.textBoxServerPath.ReadOnly = true;
            this.textBoxServerPath.Size = new System.Drawing.Size(298, 20);
            this.textBoxServerPath.TabIndex = 8;
            this.textBoxServerPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxPath_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DontStarveServerRunner.Properties.Resources.dont_starve_wallpaper;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // DontStarveServerRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxServerPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNumberOfShardsValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonReloadStatus);
            this.Controls.Add(this.labelServerStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStopServer);
            this.Controls.Add(this.buttonStartServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DontStarveServerRunner";
            this.Text = "Dont Starve Together Server Runner";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Button buttonStopServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.Button buttonReloadStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelNumberOfShardsValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxServerPath;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

