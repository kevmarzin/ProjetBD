namespace DessinObjets
{
    partial class EditionContrainte
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
            this.OK = new System.Windows.Forms.Button();
            this.Annuler = new System.Windows.Forms.Button();
            this.NomRelation = new System.Windows.Forms.TextBox();
            this.cléRelation1 = new System.Windows.Forms.ComboBox();
            this.cléRelation2 = new System.Windows.Forms.ComboBox();
            this.ChampRelation1 = new System.Windows.Forms.Label();
            this.ChampRelation2 = new System.Windows.Forms.Label();
            this.NomRela = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(345, 90);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Annuler
            // 
            this.Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Annuler.Location = new System.Drawing.Point(453, 90);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(75, 23);
            this.Annuler.TabIndex = 1;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = true;
            this.Annuler.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // NomRelation
            // 
            this.NomRelation.Location = new System.Drawing.Point(428, 25);
            this.NomRelation.Name = "NomRelation";
            this.NomRelation.Size = new System.Drawing.Size(100, 20);
            this.NomRelation.TabIndex = 2;
            // 
            // cléRelation1
            // 
            this.cléRelation1.FormattingEnabled = true;
            this.cléRelation1.Location = new System.Drawing.Point(15, 25);
            this.cléRelation1.Name = "cléRelation1";
            this.cléRelation1.Size = new System.Drawing.Size(121, 21);
            this.cléRelation1.TabIndex = 3;
            // 
            // cléRelation2
            // 
            this.cléRelation2.FormattingEnabled = true;
            this.cléRelation2.Location = new System.Drawing.Point(181, 25);
            this.cléRelation2.Name = "cléRelation2";
            this.cléRelation2.Size = new System.Drawing.Size(121, 21);
            this.cléRelation2.TabIndex = 4;
            // 
            // ChampRelation1
            // 
            this.ChampRelation1.AutoSize = true;
            this.ChampRelation1.Location = new System.Drawing.Point(12, 9);
            this.ChampRelation1.Name = "ChampRelation1";
            this.ChampRelation1.Size = new System.Drawing.Size(46, 13);
            this.ChampRelation1.TabIndex = 5;
            this.ChampRelation1.Text = "Relation";
            // 
            // ChampRelation2
            // 
            this.ChampRelation2.AutoSize = true;
            this.ChampRelation2.Location = new System.Drawing.Point(178, 9);
            this.ChampRelation2.Name = "ChampRelation2";
            this.ChampRelation2.Size = new System.Drawing.Size(46, 13);
            this.ChampRelation2.TabIndex = 6;
            this.ChampRelation2.Text = "Relation";
            this.ChampRelation2.Click += new System.EventHandler(this.label2_Click);
            // 
            // NomRela
            // 
            this.NomRela.AutoSize = true;
            this.NomRela.Location = new System.Drawing.Point(425, 9);
            this.NomRela.Name = "NomRela";
            this.NomRela.Size = new System.Drawing.Size(29, 13);
            this.NomRela.TabIndex = 7;
            this.NomRela.Text = "Nom";
            // 
            // EditionContrainte
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Annuler;
            this.ClientSize = new System.Drawing.Size(580, 176);
            this.Controls.Add(this.NomRela);
            this.Controls.Add(this.ChampRelation2);
            this.Controls.Add(this.ChampRelation1);
            this.Controls.Add(this.cléRelation2);
            this.Controls.Add(this.cléRelation1);
            this.Controls.Add(this.NomRelation);
            this.Controls.Add(this.Annuler);
            this.Controls.Add(this.OK);
            this.Name = "EditionContrainte";
            this.Text = "EditionContrainte";
            this.Load += new System.EventHandler(this.EditionContrainte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Annuler;
        private System.Windows.Forms.TextBox NomRelation;
        private System.Windows.Forms.ComboBox cléRelation1;
        private System.Windows.Forms.ComboBox cléRelation2;
        private System.Windows.Forms.Label ChampRelation1;
        private System.Windows.Forms.Label ChampRelation2;
        private System.Windows.Forms.Label NomRela;
    }
}