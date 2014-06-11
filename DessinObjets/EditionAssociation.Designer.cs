namespace DessinObjets
{
    partial class EditionAssociation
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
            this.champsAssociation = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Taille = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nomAssociation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Annuler = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.CardinalitéSource = new System.Windows.Forms.ComboBox();
            this.CardinalitéDestination = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.champsAssociation)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.champsAssociation);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CardinalitéDestination);
            this.splitContainer1.Panel2.Controls.Add(this.CardinalitéSource);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.nomAssociation);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.Annuler);
            this.splitContainer1.Panel2.Controls.Add(this.OK);
            this.splitContainer1.Size = new System.Drawing.Size(686, 262);
            this.splitContainer1.SplitterDistance = 454;
            this.splitContainer1.TabIndex = 0;
            // 
            // champsAssociation
            // 
            this.champsAssociation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.champsAssociation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.Type,
            this.Taille,
            this.NotNull});
            this.champsAssociation.Location = new System.Drawing.Point(0, 3);
            this.champsAssociation.Name = "champsAssociation";
            this.champsAssociation.Size = new System.Drawing.Size(452, 259);
            this.champsAssociation.TabIndex = 0;
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
            // NotNull
            // 
            this.NotNull.HeaderText = "Not Null";
            this.NotNull.Name = "NotNull";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cardinalité Destination :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cardinalité Source :";
            // 
            // nomAssociation
            // 
            this.nomAssociation.Location = new System.Drawing.Point(119, 16);
            this.nomAssociation.Name = "nomAssociation";
            this.nomAssociation.Size = new System.Drawing.Size(100, 20);
            this.nomAssociation.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nom de l\'association :";
            // 
            // Annuler
            // 
            this.Annuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Annuler.Location = new System.Drawing.Point(18, 173);
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
            this.OK.Location = new System.Drawing.Point(18, 126);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // CardinalitéSource
            // 
            this.CardinalitéSource.FormattingEnabled = true;
            this.CardinalitéSource.Items.AddRange(new object[] {
            "0,1",
            "1,1",
            "0,n",
            "1,n"});
            this.CardinalitéSource.Location = new System.Drawing.Point(104, 64);
            this.CardinalitéSource.Name = "CardinalitéSource";
            this.CardinalitéSource.Size = new System.Drawing.Size(121, 21);
            this.CardinalitéSource.TabIndex = 6;
            // 
            // CardinalitéDestination
            // 
            this.CardinalitéDestination.FormattingEnabled = true;
            this.CardinalitéDestination.Items.AddRange(new object[] {
            "0,1",
            "1,1",
            "0,n",
            "1,n"});
            this.CardinalitéDestination.Location = new System.Drawing.Point(104, 104);
            this.CardinalitéDestination.Name = "CardinalitéDestination";
            this.CardinalitéDestination.Size = new System.Drawing.Size(121, 21);
            this.CardinalitéDestination.TabIndex = 7;
            // 
            // EditionAssociation
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Annuler;
            this.ClientSize = new System.Drawing.Size(686, 262);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditionAssociation";
            this.Text = "EditionAssociation";
            this.Load += new System.EventHandler(this.EditionAssociation_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.champsAssociation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView champsAssociation;
        private System.Windows.Forms.Button Annuler;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox nomAssociation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Taille;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NotNull;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CardinalitéDestination;
        private System.Windows.Forms.ComboBox CardinalitéSource;
    }
}