/*
 *  Cet exemple propose deux approches pour créer une boîte de dialogue générique 
 *  permettant de modifier les paramètres d'un objet quelconque, 
 *  y compris la fenêtre du programme lui-même. Un paramètre booléen 
 *  du constructeur permet de faire la différence.
 *  La première approche utilise un contrôle prédéfini, PropertyGrid.
 *  La seconde s'appuie sur la Reflexion pour faire (à peu près) la même chose
 *  Pour l'utiliser il suffit de créer une nouvelle Windows Form
 *  de nom Parametres et de remplacer le code du fichier Parametres.cs
 *  par le code ci-dessous (en vérifiant que le namespace est le bon).
 *  Celui de Parametres.designer.cs n'a, en gros, aucune importance !
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DessinObjets
{
    /// <summary>
    /// Boîte de dialogue générique construite par réflexion
    /// </summary>
    public partial class Parametres : Form
    {
        #region variables
        /// <summary>
        /// Variable utilisé pour traiter des données de type liste ou tableau
        /// </summary>
        List<Object> objets;
        /// <summary>
        /// Objet dont les propriétés sont affichées par la boîte
        /// </summary>
        Object ObjetCourant;
        ToolStrip tlb = null;
        int controlWidth;
        int indice;
        #endregion
        #region Création de la boîte
        /// <summary>
        /// Création par réflexion d'une boîte de dialogue générique 
        /// de modification des propriétés d'un objet quelconque
        /// </summary>
        /// <param name="objetGlobal">Objet à éditer</param>
        /// <param name="propGrid">sert à distinguer entre les deux types de boîtes : false pour une boîte sur mesure, true property Grid</param>
        public Parametres(Object objetGlobal, bool propGrid)
        {
            this.Text = Properties.Resources.titreParametres;
            this.AutoScroll = true;
            if (propGrid)
            {
                PropertyGrid prop = new PropertyGrid();
                prop.SelectedObject = objetGlobal;
                Controls.Add(prop);
                prop.Dock = DockStyle.Fill;
            }
            else
            {
                ObjetCourant = objetGlobal;
                Type typeCourant = ObjetCourant.GetType();
                PropertyInfo showAll = typeCourant.GetProperty("Show_Inherited");
                bool show = true;
                if (showAll != null)
                    show = (bool)showAll.GetValue(ObjetCourant);
                if (objetGlobal.GetType().IsGenericType)
                {
                    // On fait l'hypothèse que c'est une liste dont on va parcourir les éléments
                    #region Construction d'une barre d'outils
                    tlb = new ToolStrip();
                    Controls.Add(tlb);
                    tlb.Dock = DockStyle.Top;
                    #region Ajout des boutons
                    List<AspectBouton> boutons = new List<AspectBouton>{
                        new AspectBouton{Texte="|<",Image=global::DessinObjets.Properties.Resources.DataContainer_MoveFirstHS},
                        new AspectBouton{Texte= "<",Image=global::DessinObjets.Properties.Resources.DataContainer_MovePreviousHS}, 
                        new AspectBouton{Texte=">",Image=global::DessinObjets.Properties.Resources.DataContainer_MoveNextHS},
                        new AspectBouton{Texte=">|",Image=global::DessinObjets.Properties.Resources.DataContainer_MoveLastHS}
                    };
                    foreach (AspectBouton bt in boutons)
                    {
                        ToolStripButton boutonBarreOutils = new ToolStripButton(bt.Texte);
                        boutonBarreOutils.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                        boutonBarreOutils.Image = bt.Image;
                        boutonBarreOutils.Click += boutonBarreOutils_Click;
                        tlb.Items.Add(boutonBarreOutils);

                    }
                    #endregion
                    #endregion
                    objets = (List<Object>)objetGlobal;
                    ObjetCourant = objets[indice];
                }
                typeCourant = ObjetCourant.GetType();
                Text = typeCourant.Name;
                PropertyInfo[] properties = typeCourant.GetProperties();
                int gauche = 10;
                int haut = 10;
                if (tlb != null)// Présence d'une barre d'outils
                    haut = tlb.Height + 5;
                #region Création des contrôles
                foreach (PropertyInfo propriété in properties)
                {
                    if (show || (propriété.DeclaringType.Name == typeCourant.Name))
                    {

                        if (propriété.CanWrite)
                        {
                            haut = CreateControl(propriété, new Point(gauche, haut));
                        }
                    }
                }
                #endregion
                Height = haut + 55;
                if (Height > Screen.PrimaryScreen.WorkingArea.Height)
                    Height = Screen.PrimaryScreen.WorkingArea.Height - 100;
                haut = 5;
                if (tlb != null)
                    haut = tlb.Height + 5;
                gauche = controlWidth;
                #region Création des boutons
                string[] texte_Boutons = new string[] { "OK", "Annuler" };
                foreach (string s in texte_Boutons)
                {
                    Button bouton = new Button();
                    Controls.Add(bouton);
                    bouton.Location = new Point(gauche, haut);
                    bouton.Text = s;
                    bouton.Click += ok_button_Click;
                    haut += bouton.Height + 5;
                    Width = bouton.Location.X + bouton.Width + 40;
                }
                #endregion
                UpdateControls();
            }
        }
        /// <summary>
        /// Gestion de la barre d'outils pour des listes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void boutonBarreOutils_Click(object sender, EventArgs e)
        {
            ToolStripButton bt = (ToolStripButton)sender;
            switch (bt.Text)
            {
                case "<":
                    indice--;
                    if (indice < 0)
                        indice = 0;
                    break;
                case ">":
                    indice++;
                    if (indice >= objets.Count)
                        indice = objets.Count - 1;
                    break;
                case "|<":
                    indice = 0;
                    break;
                case ">|":
                    indice = 0;
                    indice = objets.Count - 1;
                     break;
           }
            ObjetCourant = objets[indice];
            UpdateControls();
        }
        /// <summary>
        /// Création d'un contrôle
        /// </summary>
        /// <param name="propriété">Propriété de l'objet</param>
        /// <param name="coordonnées">Emplacement</param>
        /// <returns>Point le plus bas</returns>
        private int CreateControl(PropertyInfo propriété, Point coordonnées)
        {
            #region Création d'un couple Label/Controle pour chaque Propriété modifiable
            Control tb = null;
            Control tb1 = null;
            int x= coordonnées.X;
            int y = coordonnées.Y;
            switch (propriété.PropertyType.Name)
            {
                case "Byte[]":
                    #region Tableau de byte : hypothèse d'une image
                    tb = new PictureBox();
                    tb.Size = new Size(60, 60);
                    ((PictureBox)tb).SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                    #endregion
                case "Boolean":
                    tb = new CheckBox();
                    break;
                case "Single":
                case "Double":
                    tb = new NumericUpDown();
                    tb.Width = 50;
                    ((NumericUpDown)tb).Maximum = 1000;
                    ((NumericUpDown)tb).DecimalPlaces = 4;
                    break;
                case "Int16":
                case "Int32":
                    #region Entiers
                    tb = new NumericUpDown();
                    tb.Width = 50;
                    ((NumericUpDown)tb).Maximum = 3000;
                    ((NumericUpDown)tb).Minimum = -3000;
                    break;
                    #endregion
                case "Point":
                    #region Point
                    tb = new NumericUpDown();
                    ((NumericUpDown)tb).Maximum = 1000;
                    tb.MaximumSize = new Size(0, 1000);
                    tb.Width = 50;
                    tb.Name = propriété.Name + "_X";
                    tb1 = new NumericUpDown();
                    ((NumericUpDown)tb1).Maximum = 1000;
                    tb1.Width = 50;
                    tb1.Name = propriété.Name + "_Y";
                    break;
                    #endregion
                case "Size":
                    #region Taille
                    tb = new NumericUpDown();
                    ((NumericUpDown)tb).Minimum = 0;
                    ((NumericUpDown)tb).Maximum = Screen.PrimaryScreen.Bounds.Width;
                    tb.Name = propriété.Name + "_X";
                    tb.Width = 50;
                    tb1 = new NumericUpDown();
                    ((NumericUpDown)tb1).Minimum = 0;
                    ((NumericUpDown)tb1).Maximum = Screen.PrimaryScreen.Bounds.Height;
                    tb1.Width = 50;
                    tb1.Name = propriété.Name + "_Y";
                    break;
                    #endregion
                case "String":
                    tb = new TextBox();
                    tb.Tag = propriété;
                    break;
                case "Color":
                    #region Couleur
                    tb = new Label();
                    ((Label)tb).BorderStyle = BorderStyle.Fixed3D;
                    tb.Text = "     ";
                    tb.Click += Couleur_Click;
                    break;
                    #endregion
                case "DateTime":
                    #region DateTime
                    tb = new DateTimePicker();
                    break;
                    #endregion
                case "Font":
                    tb = new Label();
                    tb.Text = Properties.Resources.exempleTexte;
                    tb.Click += Police_Click;
                    break;
                case "Icon":
                    break;
                case "Type":
                    #region Type
                    tb = new ComboBox();
                    break;
                    #endregion
                default:
                    if (propriété.PropertyType.IsGenericType)
                    {
                        #region Types nullables
                        if (propriété.PropertyType.Name.Contains("Nullable"))
                        {
                            Type answer = Nullable.GetUnderlyingType(propriété.PropertyType);
                            Object xxy = propriété.GetValue(ObjetCourant);
                            switch (answer.Name)
                            {
                                case "Boolean":
                                    tb = new CheckBox();
                                    break;
                                case "Int32":
                                    tb = new NumericUpDown();
                                    tb.Width = 50;
                                    ((NumericUpDown)tb).Minimum = -5000;
                                    ((NumericUpDown)tb).Maximum = 5000;
                                    ((NumericUpDown)tb).DecimalPlaces = 0;
                                    break;
                                case "Decimal":
                                    break;
                            }
                        }
                        #endregion
                        #region Lists
                        if (propriété.PropertyType.Name.Contains("List"))
                        {
                            Type[] tp = propriété.PropertyType.GetGenericArguments();
                            PropertyInfo[] dt = tp[0].GetProperties();
                            IList a = (IList)ObjetCourant.GetType().GetProperty(propriété.Name).GetValue(ObjetCourant, null);
                            if (a != null)
                                if (a.Count > 0)
                                {
                                    #region
                                    /*
                                    tb = new ListView();
                                    ListView lb = tb as ListView;
                                    lb.View = View.Details;
                                    lb.SelectedIndexChanged += lb_SelectedIndexChanged;
                                    Type tx = a[0].GetType();
                                    dt = tx.GetProperties();
                                    foreach (PropertyInfo pi in dt)
                                    {
                                        lb.Columns.Add(pi.Name, 80);
                                    }
                                    foreach (var elem in a)
                                    {
                                        ListViewItem lw = CreeLvItem(elem);
                                        lb.Items.Add(lw);
                                    }
                                     */
                                    #endregion
                                    tb = new ComboBox();
                                    ComboBox listB = tb as ComboBox;
                                    listB.SelectedIndexChanged += lb_SelectedIndexChanged;
                                    dt = a[0].GetType().GetProperties();
                                    listB.DataSource = a;
                                    listB.ValueMember = dt[0].Name;
                                    listB.DisplayMember = dt[1].Name;
                                    int i = GetIndex(propriété, a);
                                    tb.Width = 180 + 20;
                                    tb.Height = a.Count * 20;
                                }
                            if (propriété.PropertyType.Name.Contains("Array"))
                            {
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        if(propriété.PropertyType.IsEnum)
                        { }
                        else
                        {
                            #region Type ordinaire
                            Type t = propriété.PropertyType;
                            PropertyInfo[] pi = t.GetProperties();
                            tb = new ListView();
                            ListView lb = tb as ListView;
                            lb.View = View.Details;
                            lb.SelectedIndexChanged += lb_SelectedIndexChanged;
                            lb.Columns.Add(t.Name, 80);
                            lb.Columns.Add("Value", 80);
                            tb.Width = lb.Columns.Count * 80 + 20;
                            tb.Height = pi.Length * 20;
                            #endregion
                        }
                    }
                    break;
            }
            if (tb != null)
            {
                #region Ajout des contrôles au formulaire
                tb.Tag = propriété;
                Label lb = new Label();
                lb.Text = propriété.Name.Replace("_", " ");
                lb.Location = new Point(x, y);
                Controls.Add(lb);
                tb.Location = new Point(x + lb.Width + 5, y);
                Controls.Add(tb);
                if (tb1 != null)
                {
                    tb1.Location = new Point(tb.Right + 5, y);
                    Controls.Add(tb1);
                }
                y = tb.Bottom + 3;
                if (tb.Right > controlWidth)
                    controlWidth = tb.Right + 10;
                #endregion
            }
            #endregion
            return y;
        }
        /// <summary>
        /// Met à jour les contrôles
        /// </summary>
        private void UpdateControls()
        {
            PropertyInfo[] pix = ObjetCourant.GetType().GetProperties();
            foreach (PropertyInfo p in pix)
            {
                UpdateControl(p, ObjetCourant);
            }
        }
        private void UpdateControl(PropertyInfo p, Object objet)
        {
            foreach (Control tb in Controls)
            {
                if (tb.Tag != null)
                {
                    if (p.Name == ((PropertyInfo)tb.Tag).Name)
                    {
                        if (p.GetValue(ObjetCourant) != null)
                        {
                            switch (p.PropertyType.Name)
                            {
                                #region Fill controls
                                case "Byte[]":
                                    #region utilisation de tableau de byte comme image
                                    ((PictureBox)tb).Image = null;
                                    byte[] b = (byte[])p.GetValue(ObjetCourant);
                                    MemoryStream ms = new MemoryStream(b);
                                    byte[] start = new byte[4];
                                    ms.Read(start, 0, 4);
                                    bool isJpegPicture = ((start[0] == 0xff) & ((start[1] == 0xd8)) & (start[2] == 0xff) & (start[3] == 0xe0));
                                    if (isJpegPicture)
                                    {
                                        ((PictureBox)tb).Image = Image.FromStream(ms);
                                        ((PictureBox)tb).SizeMode = PictureBoxSizeMode.StretchImage;
                                        tb.Size = new Size(60, 60);
                                    }
                                    else ((PictureBox)tb).Image = null;
                                    break;
                                    #endregion
                                case "Boolean":
                                    ((CheckBox)tb).Checked = (bool)p.GetValue(ObjetCourant);
                                    break;
                                case "Color":
                                    tb.BackColor = (Color)p.GetValue(ObjetCourant);
                                    break;
                                case "Single":
                                case "Double":
                                case "Int16":
                                case "Int32":
                                case "String":
                                    tb.Text = "";
                                    tb.Text = p.GetValue(ObjetCourant).ToString();
                                    break;
                                case "Point":
                                    #region Point
                                    Point point = (Point)p.GetValue(ObjetCourant);
                                    if (point.X > ((NumericUpDown)tb).Maximum)
                                        ((NumericUpDown)tb).Maximum = point.X + 100;
                                    if (point.X < ((NumericUpDown)tb).Minimum)
                                        ((NumericUpDown)tb).Minimum = point.X - 100;
                                    ((NumericUpDown)tb).Value = point.X;
                                    foreach (Control co in Controls)
                                    {
                                        if (co.Name == tb.Name.Replace("X", "Y"))
                                        {
                                            if (point.Y > ((NumericUpDown)co).Maximum)
                                                ((NumericUpDown)co).Maximum = point.Y + 100;
                                            ((NumericUpDown)co).Value = point.Y;
                                        }
                                    }
                                    break;
                                    #endregion
                                case "Size":
                                    #region Taille
                                    Size size = (Size)p.GetValue(ObjetCourant);
                                    if (size.Width > ((NumericUpDown)tb).Maximum)
                                        ((NumericUpDown)tb).Maximum = size.Width + 100;
                                    ((NumericUpDown)tb).Value = size.Width;
                                    foreach (Control co in Controls)
                                    {
                                        if (co.Name == tb.Name.Replace("X", "Y"))
                                        {
                                            if (size.Height > ((NumericUpDown)tb).Maximum)
                                                ((NumericUpDown)tb).Maximum = size.Height + 100;
                                            ((NumericUpDown)co).Value = size.Height;
                                        }
                                    }
                                    #endregion
                                    break;
                                case "DateTime":
                                    break;
                                default:
                                    if (p.PropertyType.IsGenericType)
                                    {
                                        #region Types nullables
                                        if (p.PropertyType.Name.Contains("Nullable"))
                                        {
                                            Type answer = Nullable.GetUnderlyingType(p.PropertyType);
                                            Object xxy = p.GetValue(ObjetCourant);
                                            switch (answer.Name)
                                            {
                                                case "Boolean":
                                                    if (xxy != null)
                                                    {
                                                        ((CheckBox)tb).Checked = (bool)p.GetValue(ObjetCourant);
                                                    }
                                                    break;
                                                case "Int32":
                                                    if (xxy != null)
                                                    {
                                                        tb.Text = p.GetValue(ObjetCourant).ToString();
                                                    }
                                                    break;
                                                case "Decimal":
                                                    if (xxy != null)
                                                    {
                                                        tb.Text = p.GetValue(ObjetCourant).ToString();
                                                    }
                                                    break;
                                            }
                                        }
                                        #endregion
                                        if (p.PropertyType.Name.Contains("List"))
                                        {
                                            var a = (IList)ObjetCourant.GetType().GetProperty(p.Name).GetValue(ObjetCourant, null);
                                            if (a != null)
                                                try
                                                {
                                                    ((ComboBox)tb).SelectedIndex = GetIndex(p, (IList)ObjetCourant.GetType().GetProperty(p.Name).GetValue(ObjetCourant, null));
                                                }
                                                catch { }
                                        }
                                    }
                                    break;
                                #endregion
                            }
                        }
                        else
                        {
                            tb.Text = "";
                        }
                    }
                }
            }
        }
        private int GetIndex(PropertyInfo p, IList a)
        {
            int index = -1;
            PropertyInfo[] dect = p.DeclaringType.GetProperties();
            PropertyInfo[] dt1 = a[0].GetType().GetProperties();
            foreach (PropertyInfo dc in dect)
            {
                if (dc.Name + "_" == p.Name)
                {
                    int cod = (int)dc.GetValue(ObjetCourant);
                    for (int i = 0; i < a.Count; i++)
                    {
                        if ((int)a[i].GetType().GetProperty(dt1[0].Name).GetValue(a[i]) == cod)
                        {
                            index = i;
                            break;
                        }
                    }
                    break;
                }
            }
            return index;
        }
        #region Traitement de listview
        private static ListViewItem CreeLvItem(object elem)
        {
            ListViewItem lw = new ListViewItem(elem.ToString());
            lw.Tag = elem;
            Type t = elem.GetType();
            PropertyInfo[] tx = t.GetProperties();
            lw.Text = elem.GetType().GetProperty(tx[0].Name).GetValue(elem).ToString();
            for (int i = 1; i < tx.Length; i++)
            {
               lw.SubItems.Add(elem.GetType().GetProperty(tx[i].Name).GetValue(elem).ToString());
            }
            return lw;
        }
        void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
       /*     if (((ListView)sender).SelectedItems.Count > 0)
            {
                int i = ((ListView)sender).SelectedIndices[0];
                ListViewItem lw = ((ListView)sender).Items[i];
                Parametres pr = new Parametres(lw.Tag, false);
                if(pr.ShowDialog()== DialogResult.OK)
                {
                    lw = CreeLvItem(lw.Tag);
                    ((ListView)sender).Items[i]=lw;
                }
            }*/
        }
        #endregion
        #endregion
        #region Méthodes de réponses de la boîte "manuelle"
        /// <summary>
        /// Modification de la police
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Police_Click(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            FontDialog fd = new FontDialog();
            fd.Font = lb.Font;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lb.Font = fd.Font;
            }
        }
        /// <summary>
        /// Modification de la couleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Couleur_Click(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            ColorDialog cld = new ColorDialog();
            cld.Color = lb.BackColor;
            if (cld.ShowDialog() == DialogResult.OK)
                lb.BackColor = cld.Color;
        }
        /// <summary>
        /// Validation des modifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ok_button_Click(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            switch (bouton.Text)
            {
                case "OK":
                    DialogResult = DialogResult.OK;
                    foreach (Control c in Controls)
                    {
                        #region Mise à jour des propriétés
                        if (c.Tag != null)
                        {
                            PropertyInfo p = (PropertyInfo)c.Tag;
                            switch (p.PropertyType.Name)
                            {
                                case "Boolean":
                                    p.SetValue(ObjetCourant, ((CheckBox)c).Checked);
                                    break;
                                case "String":
                                    p.SetValue(ObjetCourant, c.Text);
                                    break;
                                case "Single":
                                case "Double":
                                    float value;
                                    if (float.TryParse(c.Text, out value))
                                        p.SetValue(ObjetCourant, value);
                                    break;
                                case "Int32":
                                    int val;
                                    if (int.TryParse(c.Text, out val))
                                        p.SetValue(ObjetCourant, val);
                                    break;
                                case "Color":
                                    p.SetValue(ObjetCourant, c.BackColor);
                                    break;
                                case "Font":
                                    p.SetValue(ObjetCourant, c.Font);
                                    break;
                                case "Point":
                                case "Size":
                                    #region 
                                    int x_coord; int y_coord;
                                    if (int.TryParse(c.Text, out x_coord))
                                    {
                                        foreach (Control cont in Controls)
                                        {
                                            if (cont.Name == c.Name.Replace("X", "Y"))
                                            {
                                                if (int.TryParse(cont.Text, out y_coord))
                                                {
                                                    Object P = null;
                                                    if (p.PropertyType.Name == "Point")
                                                        P = new Point(x_coord, y_coord);
                                                    if (p.PropertyType.Name == "Size")
                                                        P = new Size(x_coord, y_coord);
                                                    p.SetValue(ObjetCourant, P);
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                    #endregion
                                case "Type":
                                    switch (c.Text)
                                    {
                                        case "int":
                                            p.SetValue(ObjetCourant, typeof(int));
                                            break;
                                        case "float":
                                            p.SetValue(ObjetCourant, typeof(float));
                                            break;
                                        case "string":
                                             p.SetValue(ObjetCourant, typeof(string));
                                           break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        #endregion
                    }
                    break;
                case "Annuler":
                    DialogResult = DialogResult.Cancel;
                    break;
            }
            Close();
        }
        #endregion

        private void Parametres_Load(object sender, EventArgs e)
        {

        }
    }
    /// <summary>
    /// Classe décrivant les boutons de la barre d'outils de parcours d'une liste
    /// </summary>
    public class AspectBouton
    {
        /// <summary>
        /// Libellé du bouton
        /// </summary>
        public string Texte { get; set; }
        /// <summary>
        /// Image du bouton
        /// </summary>
        public Image Image { get; set; }
    }

}