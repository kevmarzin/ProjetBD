namespace DessinObjets
{
    partial class AttributRelation
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GridChamps = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TailleDonnée = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CléPrimaire = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Auto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NotNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IndexChamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Annuler = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.NomRelation = new System.Windows.Forms.TextBox();
            this.NomR = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridChamps)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 416);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GridChamps);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.NomR);
            this.splitContainer1.Panel2.Controls.Add(this.Annuler);
            this.splitContainer1.Panel2.Controls.Add(this.OK);
            this.splitContainer1.Panel2.Controls.Add(this.NomRelation);
            this.splitContainer1.Size = new System.Drawing.Size(1054, 416);
            this.splitContainer1.SplitterDistance = 931;
            this.splitContainer1.TabIndex = 1;
            // 
            // GridChamps
            // 
            this.GridChamps.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.GridChamps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridChamps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridChamps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.Type,
            this.TailleDonnée,
            this.CléPrimaire,
            this.Auto,
            this.NotNull,
            this.IndexChamp});
            this.GridChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridChamps.Location = new System.Drawing.Point(0, 0);
            this.GridChamps.Name = "GridChamps";
            this.GridChamps.Size = new System.Drawing.Size(931, 416);
            this.GridChamps.TabIndex = 0;
            this.GridChamps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridChamps_CellContentClick);
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
            // TailleDonnée
            // 
            this.TailleDonnée.HeaderText = "Taille Donnée";
            this.TailleDonnée.Name = "TailleDonnée";
            // 
            // CléPrimaire
            // 
            this.CléPrimaire.HeaderText = "Clé Primaire";
            this.CléPrimaire.Name = "CléPrimaire";
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
            // Annuler
            // 
            this.Annuler.Location = new System.Drawing.Point(25, 349);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(75, 23);
            this.Annuler.TabIndex = 2;
            this.Annuler.Text = "Annuler";
            this.Annuler.UseVisualStyleBackColor = true;
            this.Annuler.Click += new System.EventHandler(this.Annuler_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(25, 305);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // NomRelation
            // 
            this.NomRelation.Location = new System.Drawing.Point(13, 79);
            this.NomRelation.Name = "NomRelation";
            this.NomRelation.Size = new System.Drawing.Size(100, 20);
            this.NomRelation.TabIndex = 0;
            this.NomRelation.Tag = "";
            // 
            // NomR
            // 
            this.NomR.AutoSize = true;
            this.NomR.Location = new System.Drawing.Point(15, 63);
            this.NomR.Name = "NomR";
            this.NomR.Size = new System.Drawing.Size(98, 13);
            this.NomR.TabIndex = 3;
            this.NomR.Text = "Nom de la relation :";
            // 
            // AttributRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 416);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Name = "AttributRelation";
            this.Text = "AttributRelation";
            this.Load += new System.EventHandler(this.AttributRelation_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridChamps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView GridChamps;
        private System.Windows.Forms.Button Annuler;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox NomRelation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn TailleDonnée;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CléPrimaire;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Auto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NotNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexChamp;
        private System.Windows.Forms.Label NomR;
    }
}