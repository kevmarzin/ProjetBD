namespace DessinObjets
{
    partial class EditionEntité
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ChampsEntité = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Taille = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identifiant = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Auto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NotNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IndexChamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.nomEntité = new System.Windows.Forms.TextBox();
            this.Annuler = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChampsEntité)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ChampsEntité);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.nomEntité);
            this.splitContainer1.Panel2.Controls.Add(this.Annuler);
            this.splitContainer1.Panel2.Controls.Add(this.OK);
            this.splitContainer1.Size = new System.Drawing.Size(900, 313);
            this.splitContainer1.SplitterDistance = 740;
            this.splitContainer1.TabIndex = 0;
            // 
            // ChampsEntité
            // 
            this.ChampsEntité.BackgroundColor = System.Drawing.Color.Green;
            this.ChampsEntité.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChampsEntité.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.Type,
            this.Taille,
            this.Identifiant,
            this.Auto,
            this.NotNull,
            this.IndexChamp});
            this.ChampsEntité.Location = new System.Drawing.Point(0, 0);
            this.ChampsEntité.Name = "ChampsEntité";
            this.ChampsEntité.Size = new System.Drawing.Size(740, 310);
            this.ChampsEntité.TabIndex = 0;
            this.ChampsEntité.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Items.AddRange(new object[] {
            "Byte",
            "Byte[]",
            "Date Time",
            "Decimal",
            "Int16",
            "Int32",
            "Single",
            "String"});
            this.Type.Name = "Type";
            // 
            // Taille
            // 
            this.Taille.HeaderText = "Taille";
            this.Taille.Name = "Taille";
            // 
            // Identifiant
            // 
            this.Identifiant.HeaderText = "Identifiant";
            this.Identifiant.Name = "Identifiant";
            // 
            // Auto
            // 
            this.Auto.HeaderText = "Auto";
            this.Auto.Name = "Auto";
            // 
            // NotNull
            // 
            this.NotNull.HeaderText = "Not Null";
            this.NotNull.Name = "NotNull";
            // 
            // IndexChamp
            // 
            this.IndexChamp.HeaderText = "Index Champ";
            this.IndexChamp.Name = "IndexChamp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nom de l\'entité :";
            // 
            // nomEntité
            // 
            this.nomEntité.Location = new System.Drawing.Point(36, 98);
            this.nomEntité.Name = "nomEntité";
            this.nomEntité.Size = new System.Drawing.Size(100, 20);
            this.nomEntité.TabIndex = 2;
            // 
            // Annuler
            // 
            this.Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Annuler.Location = new System.Drawing.Point(36, 229);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(75, 23);
            this.Annuler.TabIndex = 1;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = true;
            this.Annuler.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(36, 166);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseCompatibleTextRendering = true;
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // EditionEntité
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Annuler;
            this.ClientSize = new System.Drawing.Size(900, 313);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditionEntité";
            this.Text = "EditionEntité";
            this.Load += new System.EventHandler(this.EditionEntité_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChampsEntité)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView ChampsEntité;
        private System.Windows.Forms.Button Annuler;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nomEntité;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Taille;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Identifiant;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Auto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NotNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexChamp;
    }
}