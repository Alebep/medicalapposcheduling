

using Microsoft.VisualBasic.PowerPacks;

namespace ModuloDeRegistroClinica_mostrar0
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.TxtbUsuarioLogin = new System.Windows.Forms.TextBox();
            this.TxtbPassword_login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_entrarNoSistema = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelMsgError = new System.Windows.Forms.Label();
            this.pictureBox1LoginFechar = new System.Windows.Forms.PictureBox();
            this.pictureBoxErrorr = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1LoginFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorr)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 308);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(37, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(654, 308);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.White;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 261;
            this.lineShape2.X2 = 621;
            this.lineShape2.Y1 = 172;
            this.lineShape2.Y2 = 172;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 260;
            this.lineShape1.X2 = 620;
            this.lineShape1.Y1 = 100;
            this.lineShape1.Y2 = 100;
            // 
            // TxtbUsuarioLogin
            // 
            this.TxtbUsuarioLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.TxtbUsuarioLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtbUsuarioLogin.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtbUsuarioLogin.ForeColor = System.Drawing.SystemColors.Info;
            this.TxtbUsuarioLogin.Location = new System.Drawing.Point(260, 73);
            this.TxtbUsuarioLogin.Name = "TxtbUsuarioLogin";
            this.TxtbUsuarioLogin.Size = new System.Drawing.Size(361, 24);
            this.TxtbUsuarioLogin.TabIndex = 4;
            this.TxtbUsuarioLogin.Text = "Пользователь";
            this.TxtbUsuarioLogin.TextChanged += new System.EventHandler(this.TxtbUsuario_login_TextChanged);
            this.TxtbUsuarioLogin.Enter += new System.EventHandler(this.TxtbUsuario_login_Enter);
            this.TxtbUsuarioLogin.Leave += new System.EventHandler(this.TxtbUsuario_login_Leave);
            // 
            // TxtbPassword_login
            // 
            this.TxtbPassword_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.TxtbPassword_login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtbPassword_login.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtbPassword_login.ForeColor = System.Drawing.SystemColors.Info;
            this.TxtbPassword_login.Location = new System.Drawing.Point(262, 145);
            this.TxtbPassword_login.Name = "TxtbPassword_login";
            this.TxtbPassword_login.Size = new System.Drawing.Size(361, 24);
            this.TxtbPassword_login.TabIndex = 5;
            this.TxtbPassword_login.Text = "Пароль";
            this.TxtbPassword_login.Enter += new System.EventHandler(this.TxtbPassword_login_Enter);
            this.TxtbPassword_login.Leave += new System.EventHandler(this.TxtbPassword_login_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Chiller", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(370, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Логин";
            // 
            // btn_entrarNoSistema
            // 
            this.btn_entrarNoSistema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_entrarNoSistema.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_entrarNoSistema.FlatAppearance.BorderSize = 0;
            this.btn_entrarNoSistema.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btn_entrarNoSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_entrarNoSistema.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_entrarNoSistema.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_entrarNoSistema.Location = new System.Drawing.Point(262, 237);
            this.btn_entrarNoSistema.Name = "btn_entrarNoSistema";
            this.btn_entrarNoSistema.Size = new System.Drawing.Size(361, 40);
            this.btn_entrarNoSistema.TabIndex = 7;
            this.btn_entrarNoSistema.Text = "ВОЙТИ";
            this.btn_entrarNoSistema.UseVisualStyleBackColor = false;
            this.btn_entrarNoSistema.Click += new System.EventHandler(this.btn_entrarNoSistema_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel1.Location = new System.Drawing.Point(334, 282);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(235, 17);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "rECUPERER SENHA DEPOIS EM RUSSO";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelMsgError
            // 
            this.labelMsgError.AutoSize = true;
            this.labelMsgError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMsgError.ForeColor = System.Drawing.Color.DarkGray;
            this.labelMsgError.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelMsgError.Location = new System.Drawing.Point(280, 189);
            this.labelMsgError.Name = "labelMsgError";
            this.labelMsgError.Size = new System.Drawing.Size(46, 17);
            this.labelMsgError.TabIndex = 11;
            this.labelMsgError.Text = "label2";
            this.labelMsgError.Visible = false;
            // 
            // pictureBox1LoginFechar
            // 
            this.pictureBox1LoginFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1LoginFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1LoginFechar.Image = global::ModuloDeRegistroClinica_mostrar0.Properties.Resources.images;
            this.pictureBox1LoginFechar.Location = new System.Drawing.Point(607, 12);
            this.pictureBox1LoginFechar.Name = "pictureBox1LoginFechar";
            this.pictureBox1LoginFechar.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1LoginFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1LoginFechar.TabIndex = 10;
            this.pictureBox1LoginFechar.TabStop = false;
            this.pictureBox1LoginFechar.Click += new System.EventHandler(this.Fechar);
            // 
            // pictureBoxErrorr
            // 
            this.pictureBoxErrorr.Image = global::ModuloDeRegistroClinica_mostrar0.Properties.Resources.error_icon_16x16_35830289;
            this.pictureBoxErrorr.Location = new System.Drawing.Point(261, 190);
            this.pictureBoxErrorr.Name = "pictureBoxErrorr";
            this.pictureBoxErrorr.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxErrorr.TabIndex = 12;
            this.pictureBoxErrorr.TabStop = false;
            this.pictureBoxErrorr.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(654, 308);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxErrorr);
            this.Controls.Add(this.labelMsgError);
            this.Controls.Add(this.pictureBox1LoginFechar);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_entrarNoSistema);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtbPassword_login);
            this.Controls.Add(this.TxtbUsuarioLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1LoginFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private LineShape lineShape1;
        private System.Windows.Forms.TextBox TxtbPassword_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtbUsuarioLogin;
        private System.Windows.Forms.Button btn_entrarNoSistema;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1LoginFechar;
        private System.Windows.Forms.Label labelMsgError;
        private System.Windows.Forms.PictureBox pictureBoxErrorr;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

