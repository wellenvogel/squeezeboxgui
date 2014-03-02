namespace StartSqueeze
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tfServer = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tfName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPlayer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // tfServer
            // 
            this.tfServer.Location = new System.Drawing.Point(56, 18);
            this.tfServer.Name = "tfServer";
            this.tfServer.Size = new System.Drawing.Size(167, 20);
            this.tfServer.TabIndex = 1;
            this.tfServer.TextChanged += new System.EventHandler(this.tfServer_TextChanged);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(145, 129);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(78, 23);
            this.btStart.TabIndex = 5;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tfName
            // 
            this.tfName.Location = new System.Drawing.Point(56, 44);
            this.tfName.Name = "tfName";
            this.tfName.Size = new System.Drawing.Size(167, 20);
            this.tfName.TabIndex = 2;
            this.tfName.TextChanged += new System.EventHandler(this.tfName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // lbPlayer
            // 
            this.lbPlayer.AutoSize = true;
            this.lbPlayer.Location = new System.Drawing.Point(53, 102);
            this.lbPlayer.Name = "lbPlayer";
            this.lbPlayer.Size = new System.Drawing.Size(57, 13);
            this.lbPlayer.TabIndex = 6;
            this.lbPlayer.Text = "not started";
            this.lbPlayer.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Location = new System.Drawing.Point(56, 71);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(113, 17);
            this.cbAuto.TabIndex = 3;
            this.cbAuto.Text = "Start Automatically";
            this.cbAuto.UseVisualStyleBackColor = true;
            this.cbAuto.CheckedChanged += new System.EventHandler(this.cbAuto_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 162);
            this.Controls.Add(this.cbAuto);
            this.Controls.Add(this.lbPlayer);
            this.Controls.Add(this.tfName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tfServer);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SqueezeBox Starter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tfServer;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tfName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPlayer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbAuto;
    }
}

