namespace DessinObjets
{
    partial class EditionLien
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
            this.Cardinalité = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Annuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cardinalité
            // 
            this.Cardinalité.FormattingEnabled = true;
            this.Cardinalité.Items.AddRange(new object[] {
            "0,1",
            "1,1",
            "0,n",
            "1,n"});
            this.Cardinalité.Location = new System.Drawing.Point(63, 42);
            this.Cardinalité.Name = "Cardinalité";
            this.Cardinalité.Size = new System.Drawing.Size(121, 21);
            this.Cardinalité.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cardinalité :";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(12, 80);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 10;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Annuler
            // 
            this.Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Annuler.Location = new System.Drawing.Point(143, 80);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(75, 23);
            this.Annuler.TabIndex = 11;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = true;
            this.Annuler.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // EditionLien
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Annuler;
            this.ClientSize = new System.Drawing.Size(239, 122);
            this.Controls.Add(this.Annuler);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cardinalité);
            this.Name = "EditionLien";
            this.Text = "EditionLien";
            this.Load += new System.EventHandler(this.EditionLien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cardinalité;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Annuler;
    }
}