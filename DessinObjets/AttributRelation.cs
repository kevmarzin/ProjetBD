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
    public partial class AttributRelation : Form
    {
        Relation relation;
        //int nb_lignes=1;

        public AttributRelation(Relation r)
        {
            InitializeComponent();
            NomRelation.Text = "Relation";
            GridChamps.Rows.Add(1);
            int ligne = 0;
            foreach (Champ ch in r.Champs)
            {
                if (ligne > 0)
                    GridChamps.Rows.Add(1);

                GridChamps.Rows[ligne].SetValues(ch.Nom, ch.TypetoString(), ch.Taille.ToString(), ch.CléPrimaire, ch.Auto, ch.NotNull, ch.IndexChamp.ToString());
                ligne++;
            }
            relation = r;
        }

        private void AttributRelation_Load(object sender, EventArgs e)
        {

        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            relation.Texte = NomRelation.Text;
            relation.Champs.Clear(); // si on modifie, pour ne pas ajouter des champs en plus

            for (int i =0; i<GridChamps.RowCount; i++)
            {
                Champ nouvChamp = new Champ();
                if (GridChamps.Rows[i].Cells[1].Value != null)
                {
                    switch(GridChamps.Rows[i].Cells[1].Value.ToString())
                    {

                        //nouvChamp.Type = Type.GetType("System."+ GridChamps.Rows[i].Cells[1].Value.ToString());

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

                if (GridChamps.Rows[i].Cells[2].Value != null)
                    nouvChamp.Taille = Convert.ToInt32(GridChamps.Rows[i].Cells[2].Value.ToString());
                if (GridChamps.Rows[i].Cells[3].Value != null)
                    nouvChamp.CléPrimaire = (bool)GridChamps.Rows[i].Cells[3].Value;
                if (GridChamps.Rows[i].Cells[4].Value != null)
                    nouvChamp.Auto = (bool)GridChamps.Rows[i].Cells[4].Value;
                if (GridChamps.Rows[i].Cells[5].Value != null)
                    nouvChamp.NotNull = (bool)GridChamps.Rows[i].Cells[5].Value;
                if (GridChamps.Rows[i].Cells[6].Value != null)
                    nouvChamp.IndexChamp = Convert.ToInt32(GridChamps.Rows[i].Cells[6].Value.ToString());


                if (GridChamps.Rows[i].Cells[0].Value != null)
                {
                    nouvChamp.Nom = GridChamps.Rows[i].Cells[0].Value.ToString();
                    relation.Champs.Add(nouvChamp);
                }

            }         

            Close();
        }

        private void GridChamps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
