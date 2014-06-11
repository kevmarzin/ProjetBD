using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DessinObjets
{
    public partial class EditionLien : Form
    {
        Lien lien;

        public EditionLien(Lien li)
        {
            InitializeComponent();
            lien = li;
            Cardinalité.Text = lien.Cardinalité;
        }

        private void EditionLien_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            if(Cardinalité.Text != null)
                lien.Cardinalité = Cardinalité.Text;
            Close();
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
