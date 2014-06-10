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
    public partial class EditionContrainte : Form
    {

        Contrainte contrainte;
        Relation relationSource;
        Relation relationDestination;

        public EditionContrainte(Contrainte c,  Relation relationS,  Relation relationD)
        {
            InitializeComponent();
            contrainte = c;
            relationSource = relationS;
            relationDestination = relationD;
            foreach (Champ ch in relationSource.Champs)
                cléRelation1.Items.Add(ch.ToString());

            foreach (Champ ch in relationDestination.Champs)
                cléRelation2.Items.Add(ch.ToString());

            if (contrainte.Nom != null)
            {
                cléRelation1.Text=contrainte.ChampSource.Nom;
                cléRelation2.Text = contrainte.ChampDestination.Nom;
                NomRelation.Text = contrainte.Nom;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            //contrainte.ChampSource = (Champ)cléRelation1.ToString();
            //contrainte.ChampDestination = (Champ)CléRelation2.ToString();

            contrainte.Nom = NomRelation.Text;

            foreach (Champ ch in relationSource.Champs)
                if(ch.ToString()== cléRelation1.Text)
                    contrainte.ChampSource =ch;

            foreach (Champ ch in relationDestination.Champs)
                if (ch.ToString() == cléRelation2.Text)
                    contrainte.ChampDestination = ch;

            Close();
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditionContrainte_Load(object sender, EventArgs e)
        {

        }
    }
}
