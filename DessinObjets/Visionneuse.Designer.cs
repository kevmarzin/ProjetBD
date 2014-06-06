namespace DessinObjets
{
    partial class Visionneuse
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
            this.texte = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // texte
            // 
            this.texte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.texte.Location = new System.Drawing.Point(0, 0);
            this.texte.Name = "texte";
            this.texte.Size = new System.Drawing.Size(943, 474);
            this.texte.TabIndex = 0;
            this.texte.Text = "";
            // 
            // Visionneuse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 474);
            this.Controls.Add(this.texte);
            this.Name = "Visionneuse";
            this.ShowIcon = false;
            this.Text = "Visionneuse";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox texte;
    }
}