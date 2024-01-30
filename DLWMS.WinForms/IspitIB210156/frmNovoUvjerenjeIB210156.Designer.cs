namespace DLWMS.WinForms.IspitIB210156
{
    partial class frmNovoUvjerenjeIB210156
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
            components = new System.ComponentModel.Container();
            cmbVrstaUvjerenja = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtSvrhaIzdavanja = new TextBox();
            pbUplatnica = new PictureBox();
            label3 = new Label();
            btnSacuvaj = new Button();
            errorProvider1 = new ErrorProvider(components);
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbUplatnica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cmbVrstaUvjerenja
            // 
            cmbVrstaUvjerenja.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVrstaUvjerenja.FormattingEnabled = true;
            cmbVrstaUvjerenja.Items.AddRange(new object[] { "Uvjerenje o statusu studenta", "Uvjerenje o položenim ispitima" });
            cmbVrstaUvjerenja.Location = new Point(12, 34);
            cmbVrstaUvjerenja.Name = "cmbVrstaUvjerenja";
            cmbVrstaUvjerenja.Size = new Size(247, 28);
            cmbVrstaUvjerenja.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 1;
            label1.Text = "Vrsta uvjerenja";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 2;
            label2.Text = "Svrha izdavanja";
            // 
            // txtSvrhaIzdavanja
            // 
            txtSvrhaIzdavanja.Location = new Point(12, 103);
            txtSvrhaIzdavanja.Multiline = true;
            txtSvrhaIzdavanja.Name = "txtSvrhaIzdavanja";
            txtSvrhaIzdavanja.Size = new Size(247, 243);
            txtSvrhaIzdavanja.TabIndex = 3;
            // 
            // pbUplatnica
            // 
            pbUplatnica.BorderStyle = BorderStyle.FixedSingle;
            pbUplatnica.Location = new Point(299, 34);
            pbUplatnica.Name = "pbUplatnica";
            pbUplatnica.Size = new Size(407, 269);
            pbUplatnica.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUplatnica.TabIndex = 4;
            pbUplatnica.TabStop = false;
            pbUplatnica.DoubleClick += pbUplatnica_DoubleClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 9);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 5;
            label3.Text = "Uplatnica";
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(612, 317);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(94, 29);
            btnSacuvaj.TabIndex = 6;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmNovoUvjerenjeIB210156
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(726, 360);
            Controls.Add(btnSacuvaj);
            Controls.Add(label3);
            Controls.Add(pbUplatnica);
            Controls.Add(txtSvrhaIzdavanja);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbVrstaUvjerenja);
            Name = "frmNovoUvjerenjeIB210156";
            Text = "Novi zahtjev za izdavanjem uvjerenja";
            ((System.ComponentModel.ISupportInitialize)pbUplatnica).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbVrstaUvjerenja;
        private Label label1;
        private Label label2;
        private TextBox txtSvrhaIzdavanja;
        private PictureBox pbUplatnica;
        private Label label3;
        private Button btnSacuvaj;
        private ErrorProvider errorProvider1;
        private OpenFileDialog openFileDialog1;
    }
}