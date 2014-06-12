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
    public partial class EditionAssociation : Form
    {
        Association association;

        public EditionAssociation(Association a)
        {
            InitializeComponent();

            association = a;
            CardinalitéSource.Text = "1,n";
            CardinalitéDestination.Text = "1,n";
            nomAssociation.Text = association.Texte;
            CardinalitéSource.Text = association.LienSource.Cardinalité;
            CardinalitéDestination.Text = association.LienDestination.Cardinalité;
            champsAssociation.Rows.Add(1);
            int ligne = 0;
            foreach (Champ ch in a.Champs)
            {
                if (ligne > 0)
                    champsAssociation.Rows.Add(1);

                champsAssociation.Rows[ligne].SetValues(ch.Nom, ch.TypetoString(), ch.Taille.ToString(), ch.CléPrimaire, ch.Auto, ch.NotNull, ch.IndexChamp.ToString());
                ligne++;
            }
        }

        private void EditionAssociation_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            association.Texte = nomAssociation.Text;
            association.Champs.Clear(); // si on modifie, pour ne pas ajouter des champs en plus

            if (CardinalitéSource.Text != null)
                association.LienSource.Cardinalité = CardinalitéSource.Text;

            if (CardinalitéDestination.Text != null)
                association.LienDestination.Cardinalité = CardinalitéDestination.Text;

            for (int i = 0; i < champsAssociation.RowCount; i++)
            {
                Champ nouvChamp = new Champ();
                if (champsAssociation.Rows[i].Cells[1].Value != null)
                {
                    switch (champsAssociation.Rows[i].Cells[1].Value.ToString())
                    {
                        //nouvChamp.Type = Type.GetType("System."+ ChampsEntité.Rows[i].Cells[1].Value.ToString());

                        case "Byte":
                            nouvChamp.Type = typeof(Byte);
                            break;
                        case "Byte[]":
                            nouvChamp.Type = typeof(Byte[]);
                            break;
                        case "Decimal":
                            nouvChamp.Type = typeof(Decimal);
                            break;
                        case "Date Time":
                            nouvChamp.Type = typeof(DateTime);
                            break;
                        case "Int16":
                            nouvChamp.Type = typeof(Int16);
                            break;
                        case "Int32":
                            nouvChamp.Type = typeof(Int32);
                            break;
                        case "Single":
                            nouvChamp.Type = typeof(Single);
                            break;
                        case "String":
                            nouvChamp.Type = typeof(String);
                            break;
                    }
                }

                if (champsAssociation.Rows[i].Cells[2].Value != null)
                    nouvChamp.Taille = Convert.ToInt32(champsAssociation.Rows[i].Cells[2].Value.ToString());
                if (champsAssociation.Rows[i].Cells[3].Value != null)
                    nouvChamp.NotNull = (bool)champsAssociation.Rows[i].Cells[3].Value;

                if (champsAssociation.Rows[i].Cells[0].Value != null)
                {
                    nouvChamp.Nom = champsAssociation.Rows[i].Cells[0].Value.ToString();
                    association.Champs.Add(nouvChamp);
                }
            }
            Close();
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
