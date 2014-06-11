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
    public partial class EditionEntité : Form
    {
        Entité entité;
        

        public EditionEntité(Entité e)
        {
            InitializeComponent();
            entité = e;
            nomEntité.Text = entité.Texte;
            ChampsEntité.Rows.Add(1);
            int ligne = 0;
            foreach (Champ ch in e.Champs)
            {
                if (ligne > 0)
                    ChampsEntité.Rows.Add(1);

                ChampsEntité.Rows[ligne].SetValues(ch.Nom, ch.TypetoString(), ch.Taille.ToString(), ch.CléPrimaire, ch.Auto, ch.NotNull, ch.IndexChamp.ToString());
                ligne++;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            entité.Texte = nomEntité.Text;
            entité.Champs.Clear(); // si on modifie, pour ne pas ajouter des champs en plus

            for (int i = 0; i < ChampsEntité.RowCount; i++)
            {
                Champ nouvChamp = new Champ();
                if (ChampsEntité.Rows[i].Cells[1].Value != null)
                {
                    switch (ChampsEntité.Rows[i].Cells[1].Value.ToString())
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

                if (ChampsEntité.Rows[i].Cells[2].Value != null)
                    nouvChamp.Taille = Convert.ToInt32(ChampsEntité.Rows[i].Cells[2].Value.ToString());
                if (ChampsEntité.Rows[i].Cells[3].Value != null)
                    nouvChamp.CléPrimaire = (bool)ChampsEntité.Rows[i].Cells[3].Value;
                if (ChampsEntité.Rows[i].Cells[4].Value != null)
                    nouvChamp.Auto = (bool)ChampsEntité.Rows[i].Cells[4].Value;
                if (ChampsEntité.Rows[i].Cells[5].Value != null)
                    nouvChamp.NotNull = (bool)ChampsEntité.Rows[i].Cells[5].Value;
                if (ChampsEntité.Rows[i].Cells[6].Value != null)
                    nouvChamp.IndexChamp = Convert.ToInt32(ChampsEntité.Rows[i].Cells[6].Value.ToString());


                if (ChampsEntité.Rows[i].Cells[0].Value != null)
                {
                    nouvChamp.Nom = ChampsEntité.Rows[i].Cells[0].Value.ToString();
                    entité.Champs.Add(nouvChamp);
                }
            }
            Close();
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditionEntité_Load(object sender, EventArgs e)
        {

        }
    }
}
