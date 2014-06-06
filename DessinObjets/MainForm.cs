using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DessinObjets
{
    /// <summary>
    /// Fenêtre Principale du programme
    /// </summary>
    public partial class MainForm : Form
    {
        OptionsMain options = new OptionsMain();
        /// <summary>
        /// Options du programme
        /// </summary>
        public OptionsMain Options
        {
            get { return options; }
            set { options = value; }
        }
        List<string> currentFiles = new List<string>();
        /// <summary>
        /// Constructeur
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            choixLangue.Text = options.Langue;
            listeServeurs.Items.Add("localhost");
            listeServeurs.Items.Add("INFO-SIMPLET");
            listeServeurs.SelectedIndex = 0;
            options.Serveur_Base_de_données = (string)listeServeurs.SelectedItem;
            ListeBases(options.Chaine_Base_de_données);
            InitialisationRessources();
        }
        /// <summary>
        /// Initialisation des ressources chaines de caractères
        /// </summary>
        private void InitialisationRessources()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(options.Langue);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            fichierToolStripMenuItem.Text = resources.GetString("fichier");
            fichierToolStripMenuItem.ToolTipText = fichierToolStripMenuItem.Text.Replace("&", "");
            outilsToolStripMenuItem.Text = resources.GetString("ouvrir");
            nouveauToolStripMenuItem.Text = resources.GetString("nouveau");
            nouveauToolStripButton.ToolTipText = nouveauToolStripMenuItem.Text.Replace("&", "");
            ouvrirToolStripMenuItem.Text = resources.GetString("ouvrir");
            ouvrirToolStripButton.ToolTipText = resources.GetString("ouvrir").Replace("&", "");
            enregistrerToolStripMenuItem.Text = resources.GetString("enregister");

            quitterToolStripMenuItem.Text = resources.GetString("quitter");
            editionToolStripMenuItem.Text = resources.GetString("edition");
            annulerToolStripMenuItem.Text = resources.GetString("annuler");
            rétablirToolStripMenuItem.Text = resources.GetString("rétablir");
            copierToolStripMenuItem.Text = resources.GetString("copier");
            collerToolStripMenuItem.Text = resources.GetString("coller");
            couperToolStripMenuItem.Text = resources.GetString("couper");
            sélectionnertoutToolStripMenuItem.Text = resources.GetString("sélectionner");
            outilsToolStripMenuItem.Text = resources.GetString("outils");
            personnaliserToolStripMenuItem.Text = resources.GetString("personnaliser");
            optionsToolStripMenuItem.Text = resources.GetString("options");
            choixDuServeurToolStripMenuItem.Text = resources.GetString("serveur");
            choixServeurButton.Text = choixDuServeurToolStripMenuItem.Text;
            aideToolStripMenuItem.Text = resources.GetString("aide");
            indexToolStripMenuItem.Text = resources.GetString("index");
            sommaireToolStripMenuItem.Text = resources.GetString("sommaire");
            rechercherToolStripMenuItem.Text = resources.GetString("recherche");
            àproposdeToolStripMenuItem.Text = resources.GetString("apropos");
            menuFenêtre.Text = resources.GetString("fenetre");
            mosaiqueToolStripMenuItem.Text = resources.GetString("mosaique");
            tileButton.Text = mosaiqueToolStripMenuItem.Text.Replace("&", "");
            cascadeButton.Text = resources.GetString("cascade").Replace("&", "");
            grapheToolStripMenuItem.Text = resources.GetString("graphe");
            schémaRelationnelToolStripMenuItem.Text = resources.GetString("relationnel");
            relationnelToolStripMenuItem.Text = resources.GetString("relationnel");
            entitéAssociationToolStripMenuItem.Text = resources.GetString("entité");
            listeServeurs.ToolTipText=resources.GetString("listeServeurs");
            listeBd.ToolTipText = resources.GetString("listeBD");
            choixDuServeurToolStripMenuItem.ToolTipText = resources.GetString("choixServeur");
            reverseEngineerToolStripButton.ToolTipText = resources.GetString("reverse");
            GrapheBouton.Text = resources.GetString("graphe");
            relationnelBouton.Text = resources.GetString("relationnel");
            EABouton.Text = resources.GetString("entité");
            closeBouton.Text = resources.GetString("fermer");
            enregistrerToolStripMenuItem.Text = resources.GetString("enregistrer");
            enregistrersousToolStripMenuItem.Text = resources.GetString("enregistrersous");
            Enable(false);
        }
        private void Enable(bool en)
        {
            cascadeButton.Enabled = en;
            cascadeToolStripMenuItem.Enabled = en;
            mosaiqueToolStripMenuItem.Enabled = en;
            tileButton.Enabled = en;
        }
        /// <summary>
        /// Réaffichage du panneau central
        /// </summary>
        private void Restore()
        {
            if (MdiChildren.Count() == 0)
                panneauAccueil.Show();
        }
        private void ListeBases(string conStr)
        {
            listeBd.Items.Clear();
            List<string> db = AccèsSQL.GetDatabases(conStr);
            if (db != null)
            {
                foreach (string s in db)
                    listeBd.Items.Add(s);
                listeBd.SelectedIndex = 0;
            }
        }
        #region Réorganisation
        private void mosaiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }
        #endregion
        #region Création de fenêtres
        /// <summary>
        /// Crée une nouvelle fenêtre fille
        /// </summary>
        /// <param name="titre">Titre de la fenêtre</param>
        /// <param name="typeSchéma">Type de schéma à créer</param>
        /// <returns></returns>
        private void NouvelleFenêtre(string titre, TypeSchéma typeSchéma)
        {
            #region Création
            Graphe nouveauDessin = new Graphe(titre, typeSchéma, this);
            nouveauDessin.FormClosed += nouveauDessin_FormClosed;
            #endregion
            #region Ajout d'une référence de la fenêtre
            if (MdiChildren.Length == 0)
            {
                menuFenêtre.DropDownItems.Add(new ToolStripSeparator());
                menuFenêtre.DropDownItems[0].Enabled = true;
                menuFenêtre.DropDownItems[1].Enabled = true;
                tileButton.Enabled = true;
                cascadeButton.Enabled = true;
            }
            ToolStripMenuItem menuItem = new ToolStripMenuItem(nouveauDessin.ToString());
            menuItem.Tag = nouveauDessin;
            menuItem.Click += menuItem_Click;
            menuFenêtre.DropDownItems.Add(menuItem);
            nouveauDessin.Tag = menuItem;
            nouveauDessin.Show();
            panneauAccueil.Hide();
            Enable(true);
            #endregion
        }
        void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            foreach (Graphe graphe in MdiChildren)
            {
                if (graphe == (Graphe)menuItem.Tag)
                    graphe.Activate();
            }
        }
        void nouveauDessin_FormClosed(object sender, FormClosedEventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)((Form)sender).Tag;
            menuFenêtre.DropDownItems.Remove(menuItem);
            if (menuFenêtre.DropDownItems.Count == 3)
            {
                menuFenêtre.DropDownItems.RemoveAt(2);
                menuFenêtre.DropDownItems[0].Enabled = false;
                menuFenêtre.DropDownItems[1].Enabled = false;
                tileButton.Enabled = false;
                cascadeButton.Enabled = false;
            }
            ((Form)sender).MdiParent = null;
            Restore();
        }
        #endregion
        #region Eléments de menu
        private void choixServeurButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            List<string> servers = AccèsSQL.GetSQLServerInstances();
            if (servers.Count > 0)
            {
                listeServeurs.Items.Clear();
                foreach (string s in servers)
                {
                    listeServeurs.Items.Add(s);
                }
                listeServeurs.SelectedIndex = 0;
            }
            options.Serveur_Base_de_données = (string)listeServeurs.SelectedItem;
            ListeBases(options.Chaine_Base_de_données);
            Cursor = Cursors.Default;
        }
        private void listeServeurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            options.Serveur_Base_de_données = (string)listeServeurs.SelectedItem;
            ListeBases(options.Chaine_Base_de_données);
        }
        private void créationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem bt = (ToolStripMenuItem)sender;
            NouvelleFenêtre(bt.Text, type_schéma((string)bt.Tag));
        }
        private void panneauCentralBouton_Click(object sender, EventArgs e)
        {
            string mode = (string)((Control)sender).Tag;
            switch (mode)
            {
                case "Fermer":
                    Close();
                    break;
                default:
                    NouvelleFenêtre(((Control)sender).Text.Replace("&",""), type_schéma(mode));
                    break;
            }
        }
        private void reverseEngineer_Click(object sender, EventArgs e)
        {
            NouvelleFenêtre(listeBd.Text, TypeSchéma.SqlReverse);
        }
        private TypeSchéma type_schéma(string s)
        {
            TypeSchéma typeSchéma = TypeSchéma.Graphe;
            switch (s)
            {
                case "Graphe":
                    typeSchéma = TypeSchéma.Graphe;
                    break;
                case "Relationnel":
                    typeSchéma = TypeSchéma.Relationnel;
                    break;
                case "EntitéAssociation":
                    typeSchéma = TypeSchéma.EntitéAssociation;
                    break;
            }
            return typeSchéma;
        }

        private void personnaliserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parametres pa = new Parametres(options, false);
            pa.Show();
            ListeBases(options.Chaine_Base_de_données);
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = Properties.Resources.sauvegarde;
            opfd.InitialDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (opfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentFiles.Add(opfd.FileName);
                Graphe dessin = new Graphe(opfd.FileName, this);
                if (dessin.MdiParent != null)
                {
                    panneauAccueil.Hide();
                    dessin.FormClosed += nouveauDessin_FormClosed;
                    dessin.Show();
                }
            }

        }
        private void Dessin_Resize(object sender, EventArgs e)
        {
            containerBoutons.Left = (Width - containerBoutons.Width) / 2;
            containerBoutons.Top = (Height - containerBoutons.Height) / 2;
            Refresh();
        }
        #endregion
        #region Aide en ligne
        private void àproposdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APropos ap = new APropos();
            if (ap.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void help_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Aide.chm");

        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelpIndex(this, "Aide.chm");
        }

        private void rechercherToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void choixLangue_SelectedIndexChanged(object sender, EventArgs e)
        {
            options.Langue = choixLangue.Text;
            InitialisationRessources();
            foreach (Graphe g in MdiChildren)
                g.InitialisationRessources();
        }
    }
    /// <summary>
    /// Classe décrivant les options de la fenêtre principale
    /// </summary>
    public class OptionsMain
    {
        string serveur_Base_de_données = "localhost";
        string base_par_Défaut;
        string utilisateur="ETD";
        string mot_de_passe="ETD";
        bool sécurité_Intégrée = false;
        string langue = "fr";
        /// <summary>
        /// Langue de l'application
        /// </summary>
        public string Langue
        {
            get { return langue; }
            set { langue = value; }
        }
        /// <summary>
        /// Chaine de connexion
        /// </summary>
        public string Chaine_Base_de_données
        {
            get
            {
                if (sécurité_Intégrée)
                    return @"Provider=SQLOLEDB;Data Source=" + serveur_Base_de_données + ";Integrated Security=SSPI";
                else return @"Provider=SQLOLEDB;Data Source=" + serveur_Base_de_données + ";Uid=" + utilisateur + "; Pwd=" + mot_de_passe;
            }
        }
        /// <summary>
        /// Type de sécurité pour l'accès à la base
        /// </summary>
        public bool Sécurité_Intégrée
        {
            get { return sécurité_Intégrée; }
            set { sécurité_Intégrée = value; }
        }
        /// <summary>
        /// Nom du serveur
        /// </summary>
        public string Serveur_Base_de_données
        {
            get { return serveur_Base_de_données; }
            set { serveur_Base_de_données = value; }
        }
        /// <summary>
        /// Base de données par defaut
        /// </summary>
        public string Base_par_Défaut
        {
            get { return base_par_Défaut; }
            set { base_par_Défaut = value; }
        }
        /// <summary>
        /// Nom utilisateur
        /// </summary>
        public string Utilisateur
        {
            get { return utilisateur; }
            set { utilisateur = value; }
        }
        /// <summary>
        /// Mot de passe
        /// </summary>
        public string Mot_de_passe
        {
            get { return mot_de_passe; }
            set { mot_de_passe = value; }
        }
    }
    /// <summary>
    /// Enumération des types de graphes possibles
    /// </summary>
    public enum TypeSchéma { 
        /// <summary>
        /// Graphe simple
        /// </summary>
        Graphe,
        /// <summary>
        /// Schéma relationnel
        /// </summary>
        Relationnel, 
        /// <summary>
        /// Schéma entité association
        /// </summary>
        EntitéAssociation, 
        /// <summary>
        /// Schéma construit par reverse engineering d'une base SQL
        /// </summary>
        SqlReverse }
}
