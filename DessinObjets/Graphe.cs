using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
/* Version 1.0 
 *     avec menu contextuel de modification des paramètres et de suppression d'un noeud ou d'un trait. 
 *     sauvegarde XML
 *     sérialisation
 *     validation des traits
 *     impression
 *     couper-coller
 *     undo-redo
 * */
namespace DessinObjets
{
    /// <summary>
    /// Classe de base d'affichage d'un graphe
    /// </summary>
    public partial class Graphe : Form
    {
        #region Données du programme
        List<Noeud> noeuds = new List<Noeud>();
        /// <summary>
        /// Liste des noeuds, pour créér une vue différente
        /// </summary>
        public List<Noeud> Noeuds
        {
            get { return noeuds; }
            set { noeuds = value; }
        }
        List<Trait> traits = new List<Trait>();
        /// <summary>
        /// Booléen indiquant la façon d'afficher les paramètres
        /// </summary>
        public bool Property_Grid
        {
            get { return useCustomDialog; }
            set { useCustomDialog = value; }
        }
        Options option = new Options();
        internal Options Option
        {
            get { return option; }
            set { option = value; }
        }
        #endregion
        #region Variables
        Noeud noeudCourant = null;
        List<Noeud> selectedNodes;
        Trait traitCourant = null;
        Point pointCourant = Point.Empty;
        Rectangle sélection = Rectangle.Empty;
        string currentFileName = "";
        bool Déplacement_Simple;
        bool DéplacementMultipleEncours;
        Point StartBlockMovement;
        bool dessinTrait;
        bool useCustomDialog = false;
        string base_données;
        Graph g;
        TypeSchéma typeSchéma;
        #endregion
        #region Constructeurs
        /// <summary>
        /// Constructeur de base
        /// </summary>
        /// <param name="texte">Nom du schéma</param>
        /// <param name="parent">Parent Mdi</param>
        /// <param name="type">Type de schéma</param>
        public Graphe(string texte, TypeSchéma type, Form parent)
        {
            Création(type, parent, texte);
            if (type == TypeSchéma.SqlReverse)
                ReverseEngineer(texte);
        }
        /// <summary>
        /// Construit le graphe à partir d'un fichier
        /// </summary>
        /// <param name="fileName">Nom du fichier</param>
        /// <param name="parent">Parent Mdi</param>
        public Graphe(string fileName, Form parent)
        {
            if (CreateFromFile(fileName))
                Création(typeSchéma, parent, fileName); 
        }
        /// <summary>
        /// Affichage par défaut
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return Text; }
        private void ReverseEngineer(string baseSQL)
        {
            base_données = baseSQL;
            this.Text = baseSQL;
            //A faire
        }
        private void Création(TypeSchéma type, Form parent, string texte)
        {
            InitializeComponent();
            Text = texte;
            MdiParent = parent;
            typeSchéma = type;
            g = new Graph(noeuds, traits);
            foreach (string lt in System.Enum.GetNames(typeof(GraphLayoutType)))
                layoutComboBox.Items.Add(lt);
            option.Type_schéma = type;
            this.MouseWheel += DessinObjets_MouseWheel;
            vScroll.Minimum = 000;
            vScroll.Maximum = 800;
            vScroll.SmallChange = 4;
            vScroll.LargeChange = 50;
            hScroll.MouseWheel += hScroll_MouseWheel;
            déplacement.Checked = false;
            option.Origine_Zoom = new Point(this.Width / 2, this.Height / 2);
            homothétie.Text = "100%";
            Option.Type_schéma = type;
            créeEntitéAssociationButton.Visible = false;
            créeRelationsBouton.Visible = false;
            versSQL.Visible = false;
            applySql.Visible = false;
            parcoursSQL.Visible = false;
            switch (option.Type_schéma)
            {
                case TypeSchéma.Graphe:
                    separatorRelation.Visible = false;
                    separatorEntité.Visible = false;
                    break;
                case TypeSchéma.SqlReverse:
                case TypeSchéma.Relationnel:
                    versSQL.Visible = true;
                    applySql.Visible = true;
                    parcoursSQL.Visible = true;
                    créeEntitéAssociationButton.Visible = true;
                    break;
                case TypeSchéma.EntitéAssociation:
                    créeRelationsBouton.Visible = true;
                    separatorEntité.Visible = false;
                    break;
            }
            InitialisationRessources();
        }
        /// <summary>
        /// Initialisation des chaines de caractères dans la langue choisie
        /// </summary>
        public void InitialisationRessources()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(((MainForm)this.MdiParent).Options.Langue);

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            fichierToolStripMenuItem.Text = resources.GetString("fichier");
            fichierToolStripMenuItem.ToolTipText = fichierToolStripMenuItem.Text.Replace("&", "");
            outilsToolStripMenuItem.Text = resources.GetString("ouvrir");
            nouveauToolStripMenuItem.Text = resources.GetString("nouveau");
            nouveauToolStripButton.ToolTipText = nouveauToolStripMenuItem.Text.Replace("&", "");
            ouvrirToolStripMenuItem.Text = resources.GetString("ouvrir");
            ouvrirToolStripButton.ToolTipText = resources.GetString("ouvrir").Replace("&", "");
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
            aideToolStripMenuItem.Text = resources.GetString("aide");
            indexToolStripMenuItem.Text = resources.GetString("index");
            rechercherToolStripMenuItem.Text = resources.GetString("recherche");
            àproposdeToolStripMenuItem.Text = resources.GetString("apropos");
            enregistrerToolStripMenuItem.Text = resources.GetString("enregistrer");
            enregistrersousToolStripMenuItem.Text = resources.GetString("enregistrersous");
            imprimerToolStripButton.Text = resources.GetString("imprimer");
            aperçuavantimpressionToolStripMenuItem.Text = resources.GetString("aperçu");
            undoButton.Text = resources.GetString("annuler");
            redoButton.Text = resources.GetString("rétablir");
            imprimerToolStripButton.ToolTipText = resources.GetString("imprimer").Replace("&", "");
            printPreviewButton.ToolTipText = resources.GetString("aperçu").Replace("&", "");
            layoutButton.ToolTipText = resources.GetString("disposer");
            collerToolStripButton.ToolTipText = resources.GetString("coller").Replace("&", "");
            couperToolStripButton.ToolTipText = resources.GetString("couper").Replace("&", "");
            copierToolStripButton.ToolTipText = resources.GetString("copier").Replace("&", "");
            créeRelationsBouton.ToolTipText = resources.GetString("créeRelation");
            créeEntitéAssociationButton.ToolTipText = resources.GetString("créeEntité");
            applySql.ToolTipText = resources.GetString("créeBase");
            versSQL.ToolTipText = resources.GetString("créeSql");
            parcoursSQL.ToolTipText = resources.GetString("browseDb");
            imprimerToutButton.ToolTipText = resources.GetString("printAll");
            printScaleButton.ToolTipText = resources.GetString("scale");
            switch(typeSchéma)
            {
                case TypeSchéma.Graphe:
                    Text = resources.GetString("graphe").Replace("&","");
                    break;
                case TypeSchéma.Relationnel:
                    Text = resources.GetString("relationnel").Replace("&", "");
                   break;
                case TypeSchéma.EntitéAssociation:
                   Text = resources.GetString("entité").Replace("&", "");
                   break;
            }
        }
        private void DessinObjets_Resize(object sender, EventArgs e)
        {
            option.Origine_Zoom = new Point(this.Width / 2, this.Height / 2);
        }
        #endregion
        #region Création d'objets par défaut
        private Noeud NoeudParDéfaut(Point point, TypeSchéma typeschéma)
        {
            Noeud noeud = null;
            switch (typeSchéma)
            {
                case TypeSchéma.Graphe:
                    noeud = new Noeud(point, option.Taille_Noeud, option.Couleur_Noeud, option.Épaisseur_Noeud);
                    noeuds.Add(noeud);
                    break;

                case TypeSchéma.Relationnel:
                    noeud = new Relation(point, option.Taille_Noeud, option.Couleur_Noeud, option.Épaisseur_Noeud);
                    noeuds.Add(noeud);
                    break;

           }
            return noeud;
        }
        #endregion
        #region Affichage
        private void DessinObjets_Paint(object sender, PaintEventArgs e)
        {
            Dessine(e.Graphics, zoom, origin);
            this.AllowTransparency = false;
            #region Dessin du trait accessoire
            if ((pointCourant != Point.Empty) & (noeudCourant != null))
            {
                Rectangle rect = new Rectangle((int)((pointCourant.X - option.Taille_Noeud.Width / 2) * zoom)
                    + origin.X, (int)((pointCourant.Y - option.Taille_Noeud.Height / 2) * zoom) + origin.Y,
                    (int)(option.Taille_Noeud.Width * zoom), (int)(option.Taille_Noeud.Height * zoom));
                Point p = new Point((int)(pointCourant.X * zoom) + origin.X, (int)(pointCourant.Y * zoom) + origin.Y);
                e.Graphics.DrawRectangle(Pens.Red, rect);
                e.Graphics.DrawLine(Pens.Red, noeudCourant.CentreDessin(zoom, origin, option.Origine_Zoom), p);
            }
            if (sélection != Rectangle.Empty)
            {

                Pen p = new Pen(Color.Gray, 1);
                p.DashStyle = DashStyle.Dot;
                e.Graphics.DrawRectangle(p, sélection);
            }
            #endregion
        }
        /// <summary>
        /// Cette fonction est utilisé pour l'affichage à l'écran et l'impression
        /// </summary>
        /// <param name="graphics">zone d'affichage</param>
        /// <param name="zoom">Facteur de zoom</param>
        /// <param name="origin">Origine du dessin</param>
        private void Dessine(Graphics graphics, float zoom, Point origin)
        {
            foreach (Noeud n in noeuds) n.Dessine(graphics, zoom, origin, option.Origine_Zoom);
            foreach (Trait t in traits)
                t.Dessine(graphics, zoom, origin, option.Origine_Zoom);
            foreach (Noeud n in noeuds)
                n.Dessine(graphics, zoom, origin, option.Origine_Zoom);
        }
        #endregion
        #region Gestion de la souris
        Point origineDéplacement = Point.Empty;
        private void DessinObjets_MouseDown(object sender, MouseEventArgs e)
        {
            #region Mode sélection multiple activé
            if (sélection != Rectangle.Empty)
            {
                if (sélection.Contains(e.Location))
                {
                    DéplacementMultipleEncours = true;
                    StartBlockMovement = e.Location;
                    origineDéplacement = e.Location;
                    return;
                }
                else
                {
                    sélection = Rectangle.Empty;
                    DéplacementMultipleEncours = false;
                }
            }
            #endregion
            #region Recherche éléments courant
            Point pointInModel = ScreenToModel(e.Location);
            // Vérifier que le point convient
            if (!Screen.PrimaryScreen.Bounds.Contains(e.Location))
                return;
            noeudCourant = TrouveNoeudCourant(pointInModel);
            traitCourant = TrouveTraitCourant(e.Location);
            #endregion
            if (e.Button == MouseButtons.Right)
            {
                #region Bouton droit
                if (noeudCourant != null)
                {
                    List<string> libellés = new List<string>() { "Supprimer", "_", "Modifier" };
                    switch (noeudCourant.GetType().Name)
                    {
                        case "Noeud":
                            break;
                        case "Relation":
                            libellés.Add("Editer la relation");
                            break;
                        case "Entité":
                            libellés.Add("Editer l'entité");
                            break;
                    }
                    ContextMenuStrip cm = new ContextMenuStrip();
                    foreach (string t in libellés)
                    {
                        if (t == "_")
                            cm.Items.Add(new ToolStripSeparator());
                        else
                        {
                            ToolStripMenuItem suppr = new ToolStripMenuItem(t);
                            suppr.Click += new EventHandler(traitementMenu_Click);
                            cm.Items.Add(suppr);
                        }
                    }
                    System.Diagnostics.Trace.WriteLine(noeudCourant);
                    cm.Show(this, e.Location);
                }
                else if (traitCourant != null)
                {
                    switch (traitCourant.GetType().Name)
                    {
                        case "Contrainte":
                            break;
                        case "Lien":
                            break;
                        default:
                            Parametres pa = new Parametres(traitCourant, false);
                            pa.ShowDialog();
                            break;
                    }
                    Refresh();
                }
                else
                {
                    Parametres pa = new Parametres(this.option, useCustomDialog);
                    pa.ShowDialog();
                    Refresh();
                }
                #endregion
            }
            else if (e.Button == MouseButtons.Left)
            {
                #region Bouton gauche
                if (déplacement.Checked)
                {
                    if (noeudCourant != null)
                    {
                        #region Déplacement Simple
                        Déplacement_Simple = true;
                        origineDéplacement = pointInModel;
                        StartBlockMovement = e.Location;
                        #endregion
                    }
                    else
                    {
                        #region Déplacement multiple
                        if (sélection != Rectangle.Empty)
                        {
                            if (sélection.Contains(e.Location))
                            {
                                selectedNodes = new List<Noeud>();
                            }
                        }
                        else
                        {
                            sélection = new Rectangle(e.Location, new Size(0, 0));
                            selectedNodes = new List<Noeud>();
                        }
                        #endregion
                    }
                }
                else
                {
                    #region mode dessin
                    if (noeudCourant == null)
                    {
                        Noeud nouv = null;

                        nouv = NoeudParDéfaut(pointInModel, Option.Type_schéma);
                        if (nouv != null)
                        {
                            PushUndo(new Action(Type_Action.Créer, new List<object>() { nouv }));
                        }
                    }
                    else
                    { dessinTrait = true; }
                    #endregion
                }
                Refresh();
                #endregion
            }
        }
        private void DessinObjets_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point pointInModel = ScreenToModel(e.Location);
                if (!Screen.PrimaryScreen.Bounds.Contains(e.Location))
                    return;
                if (Déplacement_Simple)
                {
                    #region Mode modification
                    if (noeudCourant != null)
                    {
                       noeudCourant.Déplace(pointInModel);
                    }
                    #endregion
                }
                else
                    if (sélection != Rectangle.Empty)
                    {
                        if (DéplacementMultipleEncours)
                        {
                            #region Déplacement_Bloc
                            foreach (Noeud n in noeuds)
                            {
                                if (n.IsSelected)
                                {
                                    Point offset = ScreenToModel(e.Location);
                                    offset.Offset(-ScreenToModel(StartBlockMovement).X, -ScreenToModel(StartBlockMovement).Y);
                                    n.DéplaceVers(offset);
                                }
                            }
                            sélection = new Rectangle(sélection.X + e.Location.X - StartBlockMovement.X, sélection.Y + e.Location.Y - StartBlockMovement.Y, sélection.Width, sélection.Height);
                            StartBlockMovement = e.Location;
                            #endregion
                        }
                        else
                        {
                            #region Mise à jour Rectangle Selection et des noeuds sélectionnés
                            sélection.Size = new Size(e.X - sélection.Left, e.Y - sélection.Y);
                            foreach (Noeud n in noeuds)
                                n.UnSelect();
                            foreach (Noeud n in noeuds)
                                if (sélection.Contains(ModelToScreen(n.Centre)))
                                    n.Select();
                            #endregion
                        }
                    }
                if (dessinTrait)
                {
                    pointCourant = pointInModel;
                }
                Refresh();
            }
        }
        private void DessinObjets_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Bounds.Contains((e.Location)))
            {
                if (dessinTrait)
                {
                    if (noeudCourant != null)
                    {
                        #region Création d'une arête
                        Point pointInModel = ScreenToModel(e.Location);
                        Noeud fin = TrouveNoeudCourant(pointInModel);
                        Action subAction = null;
                        if (fin == null)
                        {
                            fin = NoeudParDéfaut(pointInModel, Option.Type_schéma);
                            subAction = new Action(Type_Action.Créer, new List<object>() { fin });
                        }
                        Trait trait = null;
                        Trait trait_1 = null;
                        if (fin != null)
                        {
                            switch (Option.Type_schéma)
                            {
                                case TypeSchéma.Graphe:
                                    trait = new Trait(noeudCourant, fin, option.Couleur_Lien, option.Épaisseur_Lien);
                                    break;
                                case TypeSchéma.Relationnel:
                                    break;
                                case TypeSchéma.EntitéAssociation:
                                    break;
                            }
                        }
                        if (trait_1 != null)
                        {
                            traits.Add(trait_1);
                            Action action = new Action(Type_Action.Créer, new List<object>() { trait_1 });
                            PushUndo(action);
                            if (subAction != null)
                                action.AddSubAction(subAction);
                        }

                        if (trait != null)
                        {
                            traits.Add(trait);
                            Action action = new Action(Type_Action.Créer, new List<object>() { trait });
                            PushUndo(action);
                            if (subAction != null)
                                action.AddSubAction(subAction);
                        }
                        pointCourant = Point.Empty;
                        Refresh();
                        dessinTrait = false;
                        #endregion
                    }
                }
                else
                {
                    #region Déplacement
                    Point pointInModel = ScreenToModel(e.Location);
                    if (Déplacement_Simple)
                    {
                        #region Mode modification
                        if (noeudCourant != null)
                        {
                            noeudCourant.Déplace(pointInModel);
                            PushUndo(new Action(Type_Action.Déplacer, new List<object>() { noeudCourant, origineDéplacement, pointInModel }));
                        }
                        #endregion
                    }
                    else
                    {
                        if (sélection != Rectangle.Empty)
                        {
                            if (DéplacementMultipleEncours)
                            {
                                #region Déplacement_Bloc
                                Action act = new Action(Type_Action.EnBloc, new List<object>());
                                foreach (Noeud n in noeuds)
                                {
                                    if (n.IsSelected)
                                    {
                                        Point offset = new Point(e.Location.X - StartBlockMovement.X, e.Location.Y - StartBlockMovement.Y);
                                        n.DéplaceVers(offset);
                                        Point offsetGlobal = new Point(e.Location.X - origineDéplacement.X, e.Location.Y - origineDéplacement.Y);
                                        Action ac = new Action(Type_Action.EnBloc, new List<object>() { n, offsetGlobal });
                                        act.AddSubAction(ac);
                                    }
                                }
                                PushUndo(act);
                                annulerToolStripMenuItem.Enabled = true;
                                sélection = new Rectangle(sélection.X + e.Location.X - StartBlockMovement.X, sélection.Y + e.Location.Y - StartBlockMovement.Y, sélection.Width, sélection.Height);
                                StartBlockMovement = e.Location;
                                #endregion
                            }
                            else
                            {
                            }
                        }
                    }
                    #endregion
                }
                Déplacement_Simple = false;
            }
            else
            {
                pointCourant = Point.Empty;
                Refresh();
            }
        }
        private void DessinObjets_MouseWheel(object sender, MouseEventArgs e)
        {
            sélection = Rectangle.Empty;
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                #region zoom
                if (e.Delta > 0)
                {
                    zoom *= 1.1f;
                    if (zoom > 15f)
                        zoom = 15f;
                }
                else
                {
                    zoom /= 1.1f;
                    if (zoom < 0.1f)
                        zoom = 0.1f;
                }
                Refresh();
                #endregion
            }
            else
            {
                #region défilement
                int x = - vScroll.Maximum / ((e.Delta) / 10);
                if (x > 0)
                {
                    if ((vScroll.Value + x) < vScroll.Maximum)
                    {
                        vScroll.Value += x;
                    }
                }
                else
                {
                    if ((vScroll.Value + x) >= vScroll.Minimum)
                    {
                        vScroll.Value += x;
                    }
                }
                #endregion
            }
            Refresh();
        }
        private void DessinObjets_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                return;
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    noeudCourant = null;
                    sélection = Rectangle.Empty;
                    break;
                case Keys.Down:
                    origin.Y += 1;
                    break;
                case Keys.Up:
                    origin.Y -= 1;
                    break;
                case Keys.Right:
                    origin.X += 1;
                    e.Handled = true;
                    break;
                case Keys.Left:
                    origin.X -= 1;
                    e.Handled = true;
                    break;
                case Keys.PageDown:
                    origin.Y += 50;
                    break;
                case Keys.PageUp:
                    origin.Y -= 50;
                    break;
            }
            Refresh();
        }
        void hScroll_MouseWheel(object sender, MouseEventArgs e) { return; }
        private void traitementMenu_Click(object sender, EventArgs e)
        {
            if (noeudCourant != null)
            {
                ToolStripMenuItem tm = (ToolStripMenuItem)sender;
                switch (tm.Text)
                {
                    case "Modifier":
                        #region Edition des propriétés
                        Noeud noeudAvant = noeudCourant.Clone();
                        Parametres pa = new Parametres(noeudCourant, false);
                        pa.ShowDialog();
                        if (noeudAvant != null)
                        {
                            Action act = new Action(Type_Action.Paramètres, new List<object>() { noeudCourant, noeudAvant, noeudCourant.Clone() });
                            PushUndo(act);
                        }
                        Refresh();
                        break;
                        #endregion
                    case "Supprimer":
                        #region Suppression
                        Supprime(noeudCourant);
                        Refresh();
                        #endregion
                        break;
                }
            }
        }
        private void Supprime(Noeud noeud)
        {
            Action action = new Action(Type_Action.Détruire, new List<Object> { noeud });
            PushUndo(action);
            for (int i = traits.Count - 1; i >= 0; i--)
            {
                Trait t = traits[i];
                if ((t.Source == noeud) || (t.Destination == noeud))
                {
                    Supprime(t);
                    action.AddSubAction(new Action(Type_Action.Détruire, new List<Object> { t }));
                }
            }
            noeud.Supprime();
        }
        private void Supprime(Trait trait)
        {
            trait.Supprime();
            //           traits.Remove(trait);
        }
        private Noeud TrouveNoeudCourant(Point p)
        {
            foreach (Noeud re in noeuds)
            {
                if (re.Contains(p))
                {
                    return re;
                }
            }
            return null;
        }
        private Trait TrouveTraitCourant(Point p)
        {
            foreach (Trait t in traits)
                t.Deselect();
            Refresh();
            foreach (Trait t in traits)
            {
                if (t.Contient(p))
                {
                    return t;
                }
            }
            return null;
        }
        private void zoom_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tm = sender as ToolStripMenuItem;
            zoom = float.Parse(tm.Text.Replace("%", "")) / 100;
            homothétie.Text = tm.Text;
            Refresh();
        }
        #endregion
        #region Conversion écran <-> modèle
        private Point ScreenToModel(Point x) { return new Point((int)((x.X - option.Origine_Zoom.X - origin.X) / zoom + option.Origine_Zoom.X), (int)((x.Y - option.Origine_Zoom.Y - origin.Y) / zoom + option.Origine_Zoom.Y)); }
        private Point ModelToScreen(Point x) { return new Point((int)(((x.X - option.Origine_Zoom.X) * zoom + option.Origine_Zoom.X + origin.X)), (int)(((x.Y - option.Origine_Zoom.Y) * zoom + option.Origine_Zoom.Y + origin.Y))); }
        #endregion
        #region Elements de menu et barre d'outils
        private void nouveauToolStripButton_Click(object sender, EventArgs e)
        {
            noeuds.Clear();
            traits.Clear();
            zoom = 1;
            origin = Point.Empty;
            Refresh();
        }
        private void couperToolStripButton_Click(object sender, EventArgs e)
        {
            Couper();
        }
        private void copierToolStripButton_Click(object sender, EventArgs e)
        {
            Copier();
        }
        private void collerToolStripButton_Click(object sender, EventArgs e)
        {
            Coller();
        }
        private void sélectionnertoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Noeud n in noeuds)
                n.Select();
            Refresh();
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parametres pr = new Parametres(this.option, false);
            pr.Show();
        }
        private void personnaliserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parametres pr = new Parametres(this, false);
            pr.Show();
        }
        private void layoutButton_Click(object sender, EventArgs e)
        {
            Graph g = GraphLayout.LayoutGraph(new Graph(noeuds, traits), this.Bounds, (GraphLayoutType)layoutComboBox.SelectedIndex);
            Refresh();
        }
        #endregion
        #region Sauvegarde
        #region XML
        private void SauveXML(string nomFichier)
        {
            StreamWriter sw = new StreamWriter(nomFichier);
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?> ");
            sw.WriteLine("<DESSIN>");
            foreach (Noeud r in noeuds)
            {
                sw.WriteLine(r.ToXML());
            }
            sw.WriteLine("</DESSIN>");
            sw.Close();
        }
        /// <summary>
        /// Sauvegarde XML par réflexion
        /// </summary>
        /// <param name="nomFichier"></param>
        private void CréationXML(string nomFichier)
        {
            Type t = g.GetType();
            PropertyInfo[] pix = t.GetProperties();
            XmlDocument xml = new XmlDocument();
            XmlElement racine = xml.CreateElement(this.Text);
            xml.AppendChild(racine);
            foreach (PropertyInfo pi in pix)
            {
                if (pi.CanWrite)
                {
                    XmlElement n = xml.CreateElement(pi.Name);
                    racine.AppendChild(n);
                    if (pi.PropertyType.IsGenericType)
                    {
                        Type[] tp = pi.PropertyType.GetGenericArguments();
                        PropertyInfo[] dtix = tp[0].GetProperties();
                        IList a = (IList)g.GetType().GetProperty(pi.Name).GetValue(g, null);
                        if (a != null)
                            if (a.Count > 0)
                            {
                                foreach (var x in a)
                                {
                                    Type tx = x.GetType();
                                    XmlElement n0 = xml.CreateElement(tx.Name);
                                    n.AppendChild(n0);

                                    foreach (PropertyInfo dti in dtix)
                                    {
                                        if (dti.CanWrite)
                                        {
                                            XmlElement n1 = xml.CreateElement(dti.Name);
                                            n0.AppendChild(n1);
                                            object oc = x.GetType().GetProperty(dti.Name).GetValue(x);
                                            switch (oc.GetType().Name)
                                            {
                                               case "String":
                                                    XmlText n2_ = xml.CreateTextNode(oc.ToString());
                                                    n1.AppendChild(n2_);
                                                    break;
                                               case "Color":
                                                    n2_ = xml.CreateTextNode(((Color)oc).ToArgb().ToString());
                                                    n1.AppendChild(n2_);
                                                    break;
                                               default:
                                                    PropertyInfo[] ocix = oc.GetType().GetProperties();
                                                    if (ocix.Length > 0)
                                                    {
                                                        foreach (PropertyInfo oci in ocix)
                                                        {
                                                            if (oci.CanWrite || oc.GetType().Name=="Font")
                                                            {
                                                                XmlElement n2 = xml.CreateElement(oci.Name);
                                                                n1.AppendChild(n2);
                                                                try
                                                                {
                                                                    object ocd = oc.GetType().GetProperty(oci.Name).GetValue(oc);
                                                                    XmlText n3 = xml.CreateTextNode(ocd.ToString());
                                                                    n2.AppendChild(n3);
                                                                }
                                                                catch { }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        XmlText n2 = xml.CreateTextNode(oc.ToString());
                                                        n1.AppendChild(n2);
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                    }
                }
            } 
            xml.Save(nomFichier);
        }
        #endregion
        #region Sérialisation
        private void Serialize(string fileName)
        {
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, typeSchéma);
            bformatter.Serialize(stream, noeuds);
            bformatter.Serialize(stream, traits);
            stream.Close();
        }
        private void Deserialize(string fileName)
        {
            Stream stream = File.Open(fileName, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            try
            {
                typeSchéma = (TypeSchéma)bformatter.Deserialize(stream);
                noeuds = (List<Noeud>)bformatter.Deserialize(stream);
                traits = (List<Trait>)bformatter.Deserialize(stream);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new IOException(message, ex);
            }
            finally
            {
                stream.Close();
            }
            foreach (Trait t in traits)
            {
                foreach (Noeud n in noeuds)
                {
                    if (t.Source.ID == n.ID)
                    {
                        t.Source = n;
                    }
                    if (t.Destination.ID == n.ID)
                    {
                        t.Destination = n;
                    }
                }
            }
            Refresh();
        }
        #endregion
        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "Binaire|*.bin|Fichier xml|*.xml";
            opfd.InitialDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (opfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentFileName = opfd.FileName;
                CreateFromFile(currentFileName);
            }
        }
        private bool CreateFromFile(string fileName)
        {
            bool ok = true;
            noeuds.Clear();
            traits.Clear();
            currentFileName = fileName;
            switch (Path.GetExtension(currentFileName))
            {
                case ".xml":
                    #region Lecture XML à faire
    /*                XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(currentFileName);
                    noeuds.Clear();
                    traits.Clear();
                    foreach (XmlNode xN in xdoc.ChildNodes)
                    {
                        Text = xN.Name;
   //                     if (xN.Name == "DESSIN")
                        {
                            foreach (XmlNode xNN in xN.ChildNodes)
                            {
                                switch (xNN.Name)
                                {
                                    case "Noeuds":
                                        foreach (XmlNode xNNn in xNN.ChildNodes)
                                        {
                                            string typeNoeud = xNNn.Name;
                                            Noeud r = new Noeud(xNNn);
                                            noeuds.Add(r);
                                        }
                                        break;
                                    case "Traits":
                                        foreach (XmlNode xNNN in xNN.ChildNodes)
                                        {

                                            Trait t = new Trait(xNNN, noeuds);
                                            traits.Add(t);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                  XDocument xydoc = XDocument.Load(currentFileName);
               var coll =     xydoc.Descendants((XName)"Noeuds");
                    var requete = from d in xydoc.Descendants((XName)"Noeuds")
              where d.Name == "Relation"
              select d;
                    var liste = requete.ToList();
                    foreach(var n in coll)
                    {

                    }
                    IEnumerable<XElement> childElements = from el in xydoc.Elements() select el;
                   
                    break; */
                    break;
                    #endregion
                case ".bin":
                    #region Graphe sérialisé
                    try
                    {
                        Deserialize(currentFileName);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                        ok = false;
                    }
                    break;
                    #endregion
            }
            Refresh();
            return ok;
        }
        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFileName == "")
            {
                enregistrersousToolStripMenuItem_Click(sender, e);
            }
            else
                Sauve(currentFileName);
        }
        private void enregistrersousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svfd = new SaveFileDialog();
            svfd.Filter = "Binaire|*.bin|Fichier xml|*.xml";
            svfd.InitialDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (svfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentFileName = svfd.FileName;
                Sauve(currentFileName);
            }
        }
        private void Sauve(string FileName)
        {
            switch (Path.GetExtension(FileName))
            {
                case ".bin":
                    Serialize(FileName);
                    break;
                case ".xml":
                    CréationXML(FileName);
                    break;
                /*    StreamWriter sw = new StreamWriter(FileName);
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?> ");
                    sw.WriteLine("<DESSIN>");
                    foreach (Noeud r in noeuds)
                    {
                        sw.WriteLine(r.ToXML());
                    }
                    foreach (Trait r in traits)
                    {
                        sw.WriteLine(r.ToXML());
                    }
                    sw.WriteLine("</DESSIN>");
                    sw.Close();
                    break;*/
            }
        }
        #endregion
        #region Impression
        #region variables pour l'impression
        PrintDocument Impression;
        PrinterSettings printer;
        int horizPages;
        int vertPages;
        int currentVertPage;
        int currentHorizPage;
        bool landscape;
        #endregion
        private void imprimerToolStripButton_Click(object sender, EventArgs e)
        {
            printer = null;
            ApercuImpression();
        }
        private void aperçuavantimpressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApercuImpression();
        }
        private void imprimerToutButton_Click(object sender, EventArgs e)
        {
            ApercuImpression();
        }
        private void printScaleButton_Click(object sender, EventArgs e)
        {
            if (printer != null)
            {
                #region Calcul du nombre de pages
                Rectangle graphBounds = Rectangle.Empty;
                foreach (Noeud n in noeuds)
                {
                    if (n.Centre.X > graphBounds.Right)
                        graphBounds = new Rectangle(graphBounds.Left, graphBounds.Top, n.Centre.X, graphBounds.Height);
                    if (n.Centre.Y > graphBounds.Height)
                        graphBounds = new Rectangle(graphBounds.Left, graphBounds.Top, graphBounds.Width, n.Centre.Y);
                }
                landscape = graphBounds.Width > graphBounds.Height;
                if (landscape)
                {
                    zoom = (float)(printer.DefaultPageSettings.Bounds.Width) / graphBounds.Width;
                }
                else
                {
                    zoom = (float)(printer.DefaultPageSettings.Bounds.Height) / graphBounds.Height;

                }
                PrintPreviewDialog ptPrev = new PrintPreviewDialog();
                ptPrev.Document = Impression;
                ptPrev.ShowDialog();
                #endregion
            }
        }
        private void ApercuImpression()
        {
            ChoixImprimante();
            Impression = new PrintDocument();
            Impression.BeginPrint += Impression_BeginPrint;
            Impression.PrintPage += Impression_PrintPage;
            PrintPreviewDialog ptPrev = new PrintPreviewDialog();
            ptPrev.Document = Impression;
            ptPrev.ShowDialog();
        }
        private void ChoixImprimante()
        {
            if (printer == null)
            {
                PrintDialog printDial = new PrintDialog();
                printDial.AllowSelection = false;
                printDial.AllowSomePages = true;
                printDial.PrintToFile = false;
                if (printDial.ShowDialog() == DialogResult.OK)
                {
                    printer = printDial.PrinterSettings;
                }
            }
        }
        private void Impression_BeginPrint(object sender, PrintEventArgs e)
        {
            Impression.DefaultPageSettings.Landscape = printer.DefaultPageSettings.Landscape;
            if (landscape)
                Impression.DefaultPageSettings.Landscape = landscape;
            if (printer != null)
            {
                #region Calcul du nombre de pages
                Rectangle graphBounds = Rectangle.Empty;
                foreach (Noeud n in noeuds)
                {
                    if (n.Centre.X > graphBounds.Right)
                        graphBounds = new Rectangle(graphBounds.Left, graphBounds.Top, n.Centre.X, graphBounds.Height);
                    if (n.Centre.Y > graphBounds.Height)
                        graphBounds = new Rectangle(graphBounds.Left, graphBounds.Top, graphBounds.Width, n.Centre.Y);
                }
                horizPages = (int)Math.Ceiling((float)graphBounds.Width / (float)printer.DefaultPageSettings.Bounds.Width);
                vertPages = (int)Math.Ceiling((float)graphBounds.Height / (float)printer.DefaultPageSettings.Bounds.Height);
                currentHorizPage = 0;
                currentVertPage = 0;
                #endregion
            }
        }
        private void Impression_PrintPage(object sender, PrintPageEventArgs e)
        {
            #region Impression de l'en-tête
            string En_tete = Text;
            if ((horizPages > 1) || (vertPages > 1))
                En_tete += " " + Properties.Resources.page + " " + ((currentHorizPage * vertPages) + currentVertPage + 1).ToString();
            Font police = new System.Drawing.Font("Times New Roman", 18);
            Pen p = new Pen(Color.Blue, 14);
            SizeF size = e.Graphics.MeasureString(En_tete, police);
            int sh = (printer.DefaultPageSettings.Bounds.Width - (int)size.Width) / 2;
            int y = 20;
            e.Graphics.DrawString(En_tete, police, Brushes.Blue, new Point(sh, y));
            int shift = (int)size.Height + y;
            #endregion
            #region calcule l'oigine de la page
            Point orig = new Point(-currentHorizPage * printer.DefaultPageSettings.Bounds.Width, shift - currentVertPage * printer.DefaultPageSettings.Bounds.Height);
            #endregion
            Dessine(e.Graphics, zoom, orig);
            #region passage à la page suivante
            if (currentVertPage < vertPages)
            {
                if (currentHorizPage < horizPages)
                {
                    currentHorizPage += 1;
                    if (currentHorizPage >= horizPages)
                    {
                        currentVertPage += 1;
                        currentHorizPage = 1;
                    }
                    if ((currentVertPage >= vertPages) || (currentHorizPage >= horizPages))
                        e.HasMorePages = false;
                    else
                        e.HasMorePages = true;
                }
            }
            else
                e.HasMorePages = false;
            #endregion
        }
        #endregion
        #region Scrolling et mise à l'échelle
        float zoom = 1;
        Point origin;
        private void vScroll_ValueChanged(object sender, EventArgs e)
        {
            origin.Y = - vScroll.Value;
        }
        private void hScroll_ValueChanged(object sender, EventArgs e)
        {
            origin.X = - hScroll.Value;
        }
        private void vScroll_Scroll(object sender, ScrollEventArgs e)
        {
            vScroll.Value = e.NewValue;
            Refresh();
        }
        private void hScroll_Scroll(object sender, ScrollEventArgs e)
        {
            hScroll.Value = e.NewValue;
            Refresh();
        }
        #endregion
        #region Fonctions de couper coller
        private void Couper()
        {
            for (int i = noeuds.Count - 1; i >= 0; i--)
                if (noeuds[i].IsSelected)
                    Supprime(noeuds[i]);
            Refresh();
        }
        private void Copier()
        {
            if (noeudCourant != null)
            {
                #region Copie un noeud
                Clipboard.SetData("Noeud", noeudCourant);
                return;
                #endregion
            }
            else
            {
                #region Copie une liste de noeuds
                List<Noeud> nods = new List<Noeud>();
                foreach (Noeud n in noeuds)
                    if (n.IsSelected)
                        nods.Add(n);
                Clipboard.SetData("Noeuds", nods);
                #endregion
                return;
            }
            /*if (selectedNodes == null)
                Clipboard.SetData(DataFormats.Text, noeuds[0].ToXML());*/
        }
        private void Coller()
        {
            if (Clipboard.ContainsData("Noeud"))
            {
                #region Colle un noeud
                Object x = (Object)Clipboard.GetData("Noeud");
                if (x != null)
                {
                    Noeud n = x as Noeud;
                    Noeud n1 = n.Clone();
                    List<Trait> nouveauxTraits = new List<Trait>();
                    foreach (Trait t in traits)
                    {
                        if (t.Source.ID == n.ID)
                            nouveauxTraits.Add(new Trait(n1, t.Destination, t.Couleur, t.Epaisseur));
                        if (t.Destination.ID == n.ID)
                            nouveauxTraits.Add(new Trait(t.Source, n1, t.Couleur, t.Epaisseur));
                    }
                    noeuds.Add(n1);
                    Action action = new Action(Type_Action.Créer, new List<object> { n1 });
                    PushUndo(action);
                    foreach (Trait t in nouveauxTraits)
                    {
                        traits.Add(t);
                        action.AddSubAction(new Action(Type_Action.Créer, new List<object> { t }));
                    }
                    Refresh();
                    return;
                }
                #endregion
            }
            if (Clipboard.ContainsData("Noeuds"))
            {
                #region Colle une liste de noeuds
                List<Noeud> ns = (List<Noeud>)Clipboard.GetData("Noeuds");
                if (ns != null)
                {
                    List<Noeud> nouveauNoeuds = new List<Noeud>();
                    List<Trait> nouveauxTraits = new List<Trait>();
                    foreach (Noeud n in ns)
                    {
                        Point p = n.Position;
                        p.Offset(20, 20);
                        Noeud n1 = new Noeud(p, n.Taille, n.CouleurBord, n.Epaisseur);
                        nouveauNoeuds.Add(n1);
                        Action action = new Action(Type_Action.Créer, new List<object> { n1 });
                        PushUndo(action);
                        foreach (Trait t in traits)
                        {
                            if (t.Source.ID == n.ID)
                            {
                                nouveauxTraits.Add(new Trait(n1, t.Destination, t.Couleur, t.Epaisseur));
                                action.AddSubAction(new Action(Type_Action.Créer, new List<object> { t }));
                            }
                            if (t.Destination.ID == n.ID)
                            {
                                nouveauxTraits.Add(new Trait(t.Source, n1, t.Couleur, t.Epaisseur));
                                action.AddSubAction(new Action(Type_Action.Créer, new List<object> { t }));
                            }
                        }
                    }
                    foreach (Noeud n in nouveauNoeuds)
                        noeuds.Add(n);
                    foreach (Trait t in nouveauxTraits)
                        traits.Add(t);
                    Refresh();
                    return;
                }
                #endregion
            }
            if (Clipboard.ContainsData(DataFormats.Text))
            {
                string t = (string)Clipboard.GetData(DataFormats.Text);
                return;
            }
            sélection = Rectangle.Empty;
            Refresh();
        }
        #endregion
        #region Bases de données
        /// <summary>
        /// Création du script SQl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vers_SQL_Click(object sender, EventArgs e)
        {          
            string findeLigne = "\r";
            string CreateDataBase ="";
            CreateDataBase += "-- " + Properties.Resources.createDB + findeLigne;
            CreateDataBase+= "CREATE DATABASE " + Text + findeLigne + findeLigne;
            CreateDataBase += "--" + Properties.Resources.createtables + findeLigne; 
            CreateDataBase += "--" + Properties.Resources.createconstraintes + findeLigne;
            Visionneuse vs = new Visionneuse(CreateDataBase);
            vs.Show();
        }
        /// <summary>
        /// Création de la base sur le serveur SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applySql_Click(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// Parcours de la table sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parcoursSQL_Click(object sender, EventArgs e)
        {
        }
        #endregion
        #region Undo-redo
        Stack<Action> actions = new Stack<Action>(50);
        Stack<Action> redo = new Stack<Action>(50);
        private void PushUndo(Action ac)
        {
            actions.Push(ac);
            annulerToolStripMenuItem.Enabled = true;
            undoButton.Enabled = true;
        }
        private void PushRedo(Action action)
        {
            redo.Push(action);
            redoButton.Enabled = true;
            rétablirToolStripMenuItem.Enabled = true;
        }
        private void annulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (actions.Count > 0)
            {
                Action action = actions.Pop();
                action.Undo();
                PushRedo(action);
                if (actions.Count == 0)
                {
                    annulerToolStripMenuItem.Enabled = false;
                    undoButton.Enabled = false;
                }
                Refresh();
            }
        }
        private void rétablirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redo.Count > 0)
            {
                Action action = redo.Pop();
                action.Redo();
                PushUndo(action);
                if (redo.Count == 0)
                {
                    redoButton.Enabled = false;
                    rétablirToolStripMenuItem.Enabled = false;
                }
            }
            Refresh();
        }
        #endregion

        private void Graphe_Load(object sender, EventArgs e)
        {

        }
    }
    /// <summary>
    /// Classe décrivant les options des différentes fenêtres
    /// </summary>
    class Options
    {
        #region Paramètres par défaut
        Size tailleParDéfaut = new Size(10, 15);
        Color couleurParDéfaut = Color.Black;
        Color couleurLienParDéfaut = Color.Black;
        int épaisseurParDéfaut = 2;
        int épaisseurLienDéfaut = 1;
        bool showAll = false;
        string langue = "Français";
        TypeSchéma type_schéma = TypeSchéma.Graphe;
        Point origineZoom;
        #endregion
        #region Propriétés
        public Size Taille_Noeud
        {
            get { return tailleParDéfaut; }
            set { tailleParDéfaut = value; }
        }
        public Color Couleur_Noeud
        {
            get { return couleurParDéfaut; }
            set { couleurParDéfaut = value; }
        }
        public int Épaisseur_Noeud
        {
            get { return épaisseurParDéfaut; }
            set { épaisseurParDéfaut = value; }
        }
        public Color Couleur_Lien
        {
            get { return couleurLienParDéfaut; }
            set { couleurLienParDéfaut = value; }
        }
        public int Épaisseur_Lien
        {
            get { return épaisseurLienDéfaut; }
            set { épaisseurLienDéfaut = value; }
        }
        public bool Show_Inherited
        {
            get { return showAll; }
            set { showAll = value; }
        }
        public TypeSchéma Type_schéma
        {
            get { return type_schéma; }
            set { type_schéma = value; }
        }
        public Point Origine_Zoom
        {
            get { return origineZoom; }
            set { origineZoom = value; }
        }
        public string Langue
        {
            get { return langue; }
            set { langue = value; }
        }
        #endregion
    }
}