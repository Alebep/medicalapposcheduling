namespace ModuloDeRegistroClinica_mostrar0.View
{
    partial class MenuExam
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.типыМедицинскогоОсмотраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.медицинскийОсмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типыМедицинскогоОсмотраToolStripMenuItem,
            this.медицинскийОсмотрToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(871, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // типыМедицинскогоОсмотраToolStripMenuItem
            // 
            this.типыМедицинскогоОсмотраToolStripMenuItem.Name = "типыМедицинскогоОсмотраToolStripMenuItem";
            this.типыМедицинскогоОсмотраToolStripMenuItem.Size = new System.Drawing.Size(180, 20);
            this.типыМедицинскогоОсмотраToolStripMenuItem.Text = "типы медицинского осмотра";
            this.типыМедицинскогоОсмотраToolStripMenuItem.Click += new System.EventHandler(this.типыМедицинскогоОсмотраToolStripMenuItem_Click);
            // 
            // медицинскийОсмотрToolStripMenuItem
            // 
            this.медицинскийОсмотрToolStripMenuItem.Name = "медицинскийОсмотрToolStripMenuItem";
            this.медицинскийОсмотрToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.медицинскийОсмотрToolStripMenuItem.Text = "медицинский осмотр";
            this.медицинскийОсмотрToolStripMenuItem.Click += new System.EventHandler(this.медицинскийОсмотрToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 466);
            this.panel1.TabIndex = 1;
            // 
            // MenuExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 490);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuExam";
            this.Text = "MenuExam";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem типыМедицинскогоОсмотраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem медицинскийОсмотрToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}