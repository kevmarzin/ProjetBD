using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DessinObjets
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ListeNoeuds : Form
    {
        List<Noeud> noeuds;
        /// <summary>
        /// 
        /// </summary>
        public ListeNoeuds()
        {
            InitializeComponent();         
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="noeuds"></param>
        public void Init(List<Noeud> noeuds)
        {
            listeDesNoeuds.Columns.Clear();
            listeDesNoeuds.Columns.Add("Titre");
            listeDesNoeuds.Columns.Add("Position");
            listeDesNoeuds.Columns.Add("Couleur");
            listeDesNoeuds.View = View.Details;
            this.noeuds = noeuds;
            foreach (Noeud n in noeuds)
            {
                ListViewItem it = new ListViewItem(n.ID.ToString());
                it.SubItems.Add(n.Position.ToString());
                it.SubItems.Add(n.CouleurBord.ToString());
                listeDesNoeuds.Items.Add(it);
            }
        }
    }
}
