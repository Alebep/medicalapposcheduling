namespace ModuloDeRegistroClinica_mostrar0.View
{
    partial class RegisterConsultation
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
            this.metroCombBxPatient = new MetroFramework.Controls.MetroComboBox();
            this.metroComboBoxDoctor = new MetroFramework.Controls.MetroComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBoxTime = new System.Windows.Forms.MaskedTextBox();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPatronymic = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.pictureBoxDoctor = new System.Windows.Forms.PictureBox();
            this.pictureBoxData = new System.Windows.Forms.PictureBox();
            this.pictureBoxPatient = new System.Windows.Forms.PictureBox();
            this.maskedTextBoxWeight = new System.Windows.Forms.MaskedTextBox();
            this.richTextBoxPrognostic = new System.Windows.Forms.RichTextBox();
            this.metroComboBoxSpecialty = new MetroFramework.Controls.MetroComboBox();
            this.pictureBoxSpecialty = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBoxHeight = new System.Windows.Forms.MaskedTextBox();
            this.pictureBoxTime = new System.Windows.Forms.PictureBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpecialty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTime)).BeginInit();
            this.SuspendLayout();
            // 
            // metroCombBxPatient
            // 
            this.metroCombBxPatient.FormattingEnabled = true;
            this.metroCombBxPatient.ItemHeight = 23;
            this.metroCombBxPatient.Location = new System.Drawing.Point(97, 216);
            this.metroCombBxPatient.Name = "metroCombBxPatient";
            this.metroCombBxPatient.Size = new System.Drawing.Size(266, 29);
            this.metroCombBxPatient.TabIndex = 140;
            this.metroCombBxPatient.UseSelectable = true;
            // 
            // metroComboBoxDoctor
            // 
            this.metroComboBoxDoctor.FormattingEnabled = true;
            this.metroComboBoxDoctor.ItemHeight = 23;
            this.metroComboBoxDoctor.Location = new System.Drawing.Point(97, 159);
            this.metroComboBoxDoctor.Name = "metroComboBoxDoctor";
            this.metroComboBoxDoctor.Size = new System.Drawing.Size(266, 29);
            this.metroComboBoxDoctor.TabIndex = 138;
            this.metroComboBoxDoctor.UseSelectable = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(429, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 22);
            this.label2.TabIndex = 136;
            this.label2.Text = "Дата";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(429, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 135;
            this.label1.Text = "Прогноз";
            // 
            // maskedTextBoxTime
            // 
            this.maskedTextBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBoxTime.ForeColor = System.Drawing.SystemColors.InfoText;
            this.maskedTextBoxTime.Location = new System.Drawing.Point(433, 330);
            this.maskedTextBoxTime.Mask = "00:00";
            this.maskedTextBoxTime.Name = "maskedTextBoxTime";
            this.maskedTextBoxTime.PromptChar = '-';
            this.maskedTextBoxTime.Size = new System.Drawing.Size(266, 29);
            this.maskedTextBoxTime.TabIndex = 131;
            this.maskedTextBoxTime.ValidatingType = typeof(System.DateTime);
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Location = new System.Drawing.Point(433, 273);
            this.metroDateTime1.MaxDate = new System.DateTime(2053, 7, 23, 0, 0, 0, 0);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 29);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(266, 29);
            this.metroDateTime1.TabIndex = 130;
            this.metroDateTime1.Value = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.metroDateTime1.ValueChanged += new System.EventHandler(this.metroDateTime1_ValueChanged);
            this.metroDateTime1.Leave += new System.EventHandler(this.metroDateTime1_Leave);
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhoneNumber.Location = new System.Drawing.Point(429, 305);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(65, 22);
            this.labelPhoneNumber.TabIndex = 121;
            this.labelPhoneNumber.Text = "Время";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(93, 305);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(49, 22);
            this.labelEmail.TabIndex = 120;
            this.labelEmail.Text = "Рост";
            // 
            // labelPatronymic
            // 
            this.labelPatronymic.AutoSize = true;
            this.labelPatronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPatronymic.Location = new System.Drawing.Point(93, 248);
            this.labelPatronymic.Name = "labelPatronymic";
            this.labelPatronymic.Size = new System.Drawing.Size(41, 22);
            this.labelPatronymic.TabIndex = 119;
            this.labelPatronymic.Text = "Вес";
            this.labelPatronymic.Click += new System.EventHandler(this.labelPatronymic_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(93, 191);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(82, 22);
            this.labelName.TabIndex = 118;
            this.labelName.Text = "Пациент";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastName.Location = new System.Drawing.Point(93, 134);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(52, 22);
            this.labelLastName.TabIndex = 117;
            this.labelLastName.Text = "Врач";
            // 
            // pictureBoxDoctor
            // 
            this.pictureBoxDoctor.Image = global::ModuloDeRegistroClinica_mostrar0.Properties.Resources.error_icon_16x16_35830289;
            this.pictureBoxDoctor.Location = new System.Drawing.Point(369, 165);
            this.pictureBoxDoctor.Name = "pictureBoxDoctor";
            this.pictureBoxDoctor.Size = new System.Drawing.Size(17, 17);
            this.pictureBoxDoctor.TabIndex = 134;
            this.pictureBoxDoctor.TabStop = false;
            this.pictureBoxDoctor.Visible = false;
            // 
            // pictureBoxData
            // 
            this.pictureBoxData.Image = global::ModuloDeRegistroClinica_mostrar0.Properties.Resources.error_icon_16x16_35830289;
            this.pictureBoxData.Location = new System.Drawing.Point(705, 280);
            this.pictureBoxData.Name = "pictureBoxData";
            this.pictureBoxData.Size = new System.Drawing.Size(17, 17);
            this.pictureBoxData.TabIndex = 133;
            this.pictureBoxData.TabStop = false;
            this.pictureBoxData.Visible = false;
            // 
            // pictureBoxPatient
            // 
            this.pictureBoxPatient.Image = global::ModuloDeRegistroClinica_mostrar0.Properties.Resources.error_icon_16x16_35830289;
            this.pictureBoxPatient.Location = new System.Drawing.Point(369, 223);
            this.pictureBoxPatient.Name = "pictureBoxPatient";
            this.pictureBoxPatient.Size = new System.Drawing.Size(17, 17);
            this.pictureBoxPatient.TabIndex = 125;
            this.pictureBoxPatient.TabStop = false;
            this.pictureBoxPatient.Visible = false;
            // 
            // maskedTextBoxWeight
            // 
            this.maskedTextBoxWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBoxWeight.ForeColor = System.Drawing.SystemColors.InfoText;
            this.maskedTextBoxWeight.Location = new System.Drawing.Point(97, 273);
            this.maskedTextBoxWeight.Mask = "000";
            this.maskedTextBoxWeight.Name = "maskedTextBoxWeight";
            this.maskedTextBoxWeight.PromptChar = '-';
            this.maskedTextBoxWeight.Size = new System.Drawing.Size(266, 29);
            this.maskedTextBoxWeight.TabIndex = 148;
            this.maskedTextBoxWeight.ValidatingType = typeof(int);
            this.maskedTextBoxWeight.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // richTextBoxPrognostic
            // 
            this.richTextBoxPrognostic.Location = new System.Drawing.Point(433, 108);
            this.richTextBoxPrognostic.Name = "richTextBoxPrognostic";
            this.richTextBoxPrognostic.Size = new System.Drawing.Size(266, 137);
            this.richTextBoxPrognostic.TabIndex = 149;
            this.richTextBoxPrognostic.Text = "";
            // 
            // metroComboBoxSpecialty
            // 
            this.metroComboBoxSpecialty.FormattingEnabled = true;
            this.metroComboBoxSpecialty.ItemHeight = 23;
            this.metroComboBoxSpecialty.Location = new System.Drawing.Point(97, 102);
            this.metroComboBoxSpecialty.Name = "metroComboBoxSpecialty";
            this.metroComboBoxSpecialty.Size = new System.Drawing.Size(266, 29);
            this.metroComboBoxSpecialty.TabIndex = 152;
            this.metroComboBoxSpecialty.UseSelectable = true;
            this.metroComboBoxSpecialty.TextChanged += new System.EventHandler(this.metroComboBoxSpecialty_TextChanged);
            // 
            // pictureBoxSpecialty
            // 
            this.pictureBoxSpecialty.Image = global::ModuloDeRegistroClinica_mostrar0.Properties.Resources.error_icon_16x16_35830289;
            this.pictureBoxSpecialty.Location = new System.Drawing.Point(369, 108);
            this.pictureBoxSpecialty.Name = "pictureBoxSpecialty";
            this.pictureBoxSpecialty.Size = new System.Drawing.Size(17, 17);
            this.pictureBoxSpecialty.TabIndex = 151;
            this.pictureBoxSpecialty.TabStop = false;
            this.pictureBoxSpecialty.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 22);
            this.label3.TabIndex = 150;
            this.label3.Text = "Специальность";
            // 
            // maskedTextBoxHeight
            // 
            this.maskedTextBoxHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBoxHeight.ForeColor = System.Drawing.SystemColors.InfoText;
            this.maskedTextBoxHeight.Location = new System.Drawing.Point(97, 330);
            this.maskedTextBoxHeight.Mask = "000";
            this.maskedTextBoxHeight.Name = "maskedTextBoxHeight";
            this.maskedTextBoxHeight.PromptChar = '-';
            this.maskedTextBoxHeight.Size = new System.Drawing.Size(266, 29);
            this.maskedTextBoxHeight.TabIndex = 153;
            this.maskedTextBoxHeight.ValidatingType = typeof(int);
            // 
            // pictureBoxTime
            // 
            this.pictureBoxTime.Image = global::ModuloDeRegistroClinica_mostrar0.Properties.Resources.error_icon_16x16_35830289;
            this.pictureBoxTime.Location = new System.Drawing.Point(705, 336);
            this.pictureBoxTime.Name = "pictureBoxTime";
            this.pictureBoxTime.Size = new System.Drawing.Size(17, 17);
            this.pictureBoxTime.TabIndex = 154;
            this.pictureBoxTime.TabStop = false;
            this.pictureBoxTime.Visible = false;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(272, 393);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(91, 41);
            this.metroButton1.TabIndex = 155;
            this.metroButton1.Text = "Записать";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(433, 393);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(91, 41);
            this.metroButton2.TabIndex = 156;
            this.metroButton2.Text = "Очистить";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(343, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 31);
            this.label4.TabIndex = 158;
            this.label4.Text = "Прием";
            // 
            // RegisterConsultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.pictureBoxTime);
            this.Controls.Add(this.maskedTextBoxHeight);
            this.Controls.Add(this.metroComboBoxSpecialty);
            this.Controls.Add(this.pictureBoxSpecialty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxPrognostic);
            this.Controls.Add(this.maskedTextBoxWeight);
            this.Controls.Add(this.metroCombBxPatient);
            this.Controls.Add(this.metroComboBoxDoctor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxDoctor);
            this.Controls.Add(this.pictureBoxData);
            this.Controls.Add(this.maskedTextBoxTime);
            this.Controls.Add(this.metroDateTime1);
            this.Controls.Add(this.pictureBoxPatient);
            this.Controls.Add(this.labelPhoneNumber);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelPatronymic);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelLastName);
            this.Name = "RegisterConsultation";
            this.Text = "RegisterConsultation";
            this.Load += new System.EventHandler(this.RegisterConsultation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpecialty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxDoctor;
        private System.Windows.Forms.PictureBox pictureBoxData;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTime;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private System.Windows.Forms.PictureBox pictureBoxPatient;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPatronymic;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLastName;
        internal MetroFramework.Controls.MetroComboBox metroCombBxPatient;
        internal MetroFramework.Controls.MetroComboBox metroComboBoxDoctor;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxWeight;
        private System.Windows.Forms.RichTextBox richTextBoxPrognostic;
        internal MetroFramework.Controls.MetroComboBox metroComboBoxSpecialty;
        private System.Windows.Forms.PictureBox pictureBoxSpecialty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxHeight;
        private System.Windows.Forms.PictureBox pictureBoxTime;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.Label label4;
    }
}