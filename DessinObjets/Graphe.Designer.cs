namespace DessinObjets
{
    partial class Graphe
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graphe));
            this.vScroll = new System.Windows.Forms.VScrollBar();
            this.separatorEntité = new System.Windows.Forms.ToolStripSeparator();
            this.separatorCouper = new System.Windows.Forms.ToolStripSeparator();
            this.separatorRelation = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ouvrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.nouveauToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.enregistrerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.separatorFichier = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imprimerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imprimerToutButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewButton = new System.Windows.Forms.ToolStripButton();
            this.printScaleButton = new System.Windows.Forms.ToolStripButton();
            this.separatorImpression = new System.Windows.Forms.ToolStripSeparator();
            this.déplacement = new System.Windows.Forms.ToolStripButton();
            this.couperToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copierToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.collerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.créeRelationsBouton = new System.Windows.Forms.ToolStripButton();
            this.créeEntitéAssociationButton = new System.Windows.Forms.ToolStripButton();
            this.versSQL = new System.Windows.Forms.ToolStripButton();
            this.applySql = new System.Windows.Forms.ToolStripButton();
            this.parcoursSQL = new System.Windows.Forms.ToolStripButton();
            this.separatorLayout = new System.Windows.Forms.ToolStripSeparator();
            this.layoutComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.layoutButton = new System.Windows.Forms.ToolStripButton();
            this.homothétie = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.hScroll = new System.Windows.Forms.HScrollBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrersousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.imprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aperçuavantimpressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rétablirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.couperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.sélectionnertoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personnaliserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sommaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechercherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.àproposdeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScroll
            // 
            resources.ApplyResources(this.vScroll, "vScroll");
            this.vScroll.Maximum = 800;
            this.vScroll.Name = "vScroll";
            this.vScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScroll_Scroll);
            this.vScroll.ValueChanged += new System.EventHandler(this.vScroll_ValueChanged);
            // 
            // separatorEntité
            // 
            this.separatorEntité.Name = "separatorEntité";
            resources.ApplyResources(this.separatorEntité, "separatorEntité");
            // 
            // separatorCouper
            // 
            this.separatorCouper.Name = "separatorCouper";
            resources.ApplyResources(this.separatorCouper, "separatorCouper");
            // 
            // separatorRelation
            // 
            this.separatorRelation.Name = "separatorRelation";
            resources.ApplyResources(this.separatorRelation, "separatorRelation");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripButton,
            this.nouveauToolStripButton,
            this.enregistrerToolStripButton,
            this.separatorFichier,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator1,
            this.imprimerToolStripButton,
            this.imprimerToutButton,
            this.printPreviewButton,
            this.printScaleButton,
            this.separatorImpression,
            this.déplacement,
            this.separatorCouper,
            this.couperToolStripButton,
            this.copierToolStripButton,
            this.collerToolStripButton,
            this.separatorRelation,
            this.créeRelationsBouton,
            this.créeEntitéAssociationButton,
            this.separatorEntité,
            this.versSQL,
            this.applySql,
            this.parcoursSQL,
            this.separatorLayout,
            this.layoutComboBox,
            this.layoutButton,
            this.homothétie});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // ouvrirToolStripButton
            // 
            this.ouvrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.ouvrirToolStripButton, "ouvrirToolStripButton");
            this.ouvrirToolStripButton.Name = "ouvrirToolStripButton";
            this.ouvrirToolStripButton.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
            // 
            // nouveauToolStripButton
            // 
            this.nouveauToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.nouveauToolStripButton, "nouveauToolStripButton");
            this.nouveauToolStripButton.Name = "nouveauToolStripButton";
            this.nouveauToolStripButton.Click += new System.EventHandler(this.nouveauToolStripButton_Click);
            // 
            // enregistrerToolStripButton
            // 
            this.enregistrerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.enregistrerToolStripButton, "enregistrerToolStripButton");
            this.enregistrerToolStripButton.Name = "enregistrerToolStripButton";
            this.enregistrerToolStripButton.Click += new System.EventHandler(this.enregistrerToolStripMenuItem_Click);
            // 
            // separatorFichier
            // 
            this.separatorFichier.Name = "separatorFichier";
            resources.ApplyResources(this.separatorFichier, "separatorFichier");
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.undoButton, "undoButton");
            this.undoButton.Image = global::DessinObjets.Properties.Resources.Undo_16x;
            this.undoButton.Name = "undoButton";
            this.undoButton.Click += new System.EventHandler(this.annulerToolStripMenuItem_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.redoButton, "redoButton");
            this.redoButton.Image = global::DessinObjets.Properties.Resources.Redo_16x;
            this.redoButton.Name = "redoButton";
            this.redoButton.Click += new System.EventHandler(this.rétablirToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // imprimerToolStripButton
            // 
            this.imprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.imprimerToolStripButton, "imprimerToolStripButton");
            this.imprimerToolStripButton.Name = "imprimerToolStripButton";
            this.imprimerToolStripButton.Click += new System.EventHandler(this.imprimerToolStripButton_Click);
            // 
            // imprimerToutButton
            // 
            this.imprimerToutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimerToutButton.Image = global::DessinObjets.Properties.Resources.PrintEntireDocument;
            resources.ApplyResources(this.imprimerToutButton, "imprimerToutButton");
            this.imprimerToutButton.Name = "imprimerToutButton";
            this.imprimerToutButton.Click += new System.EventHandler(this.imprimerToutButton_Click);
            // 
            // printPreviewButton
            // 
            this.printPreviewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printPreviewButton.Image = global::DessinObjets.Properties.Resources.PrintPreviewHS;
            resources.ApplyResources(this.printPreviewButton, "printPreviewButton");
            this.printPreviewButton.Name = "printPreviewButton";
            this.printPreviewButton.Click += new System.EventHandler(this.aperçuavantimpressionToolStripMenuItem_Click);
            // 
            // printScaleButton
            // 
            this.printScaleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printScaleButton.Image = global::DessinObjets.Properties.Resources.ZoomToFit;
            resources.ApplyResources(this.printScaleButton, "printScaleButton");
            this.printScaleButton.Name = "printScaleButton";
            this.printScaleButton.Click += new System.EventHandler(this.printScaleButton_Click);
            // 
            // separatorImpression
            // 
            this.separatorImpression.Name = "separatorImpression";
            resources.ApplyResources(this.separatorImpression, "separatorImpression");
            // 
            // déplacement
            // 
            this.déplacement.CheckOnClick = true;
            this.déplacement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.déplacement.Image = global::DessinObjets.Properties.Resources.Select;
            resources.ApplyResources(this.déplacement, "déplacement");
            this.déplacement.Name = "déplacement";
            // 
            // couperToolStripButton
            // 
            this.couperToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.couperToolStripButton, "couperToolStripButton");
            this.couperToolStripButton.Name = "couperToolStripButton";
            this.couperToolStripButton.Click += new System.EventHandler(this.couperToolStripButton_Click);
            // 
            // copierToolStripButton
            // 
            this.copierToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.copierToolStripButton, "copierToolStripButton");
            this.copierToolStripButton.Name = "copierToolStripButton";
            this.copierToolStripButton.Click += new System.EventHandler(this.copierToolStripButton_Click);
            // 
            // collerToolStripButton
            // 
            this.collerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.collerToolStripButton, "collerToolStripButton");
            this.collerToolStripButton.Name = "collerToolStripButton";
            this.collerToolStripButton.Click += new System.EventHandler(this.collerToolStripButton_Click);
            // 
            // créeRelationsBouton
            // 
            this.créeRelationsBouton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.créeRelationsBouton.Image = global::DessinObjets.Properties.Resources.Table_748_32;
            resources.ApplyResources(this.créeRelationsBouton, "créeRelationsBouton");
            this.créeRelationsBouton.Name = "créeRelationsBouton";
            // 
            // créeEntitéAssociationButton
            // 
            this.créeEntitéAssociationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.créeEntitéAssociationButton.Image = global::DessinObjets.Properties.Resources.EntityDataModel_table_Mapping_16x16;
            resources.ApplyResources(this.créeEntitéAssociationButton, "créeEntitéAssociationButton");
            this.créeEntitéAssociationButton.Name = "créeEntitéAssociationButton";
            // 
            // versSQL
            // 
            this.versSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.versSQL.Image = global::DessinObjets.Properties.Resources.SQL;
            resources.ApplyResources(this.versSQL, "versSQL");
            this.versSQL.Name = "versSQL";
            this.versSQL.Click += new System.EventHandler(this.vers_SQL_Click);
            // 
            // applySql
            // 
            this.applySql.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.applySql.Image = global::DessinObjets.Properties.Resources.FillUp;
            resources.ApplyResources(this.applySql, "applySql");
            this.applySql.Name = "applySql";
            this.applySql.Click += new System.EventHandler(this.applySql_Click);
            // 
            // parcoursSQL
            // 
            this.parcoursSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.parcoursSQL.Image = global::DessinObjets.Properties.Resources.book_open;
            resources.ApplyResources(this.parcoursSQL, "parcoursSQL");
            this.parcoursSQL.Name = "parcoursSQL";
            this.parcoursSQL.Click += new System.EventHandler(this.parcoursSQL_Click);
            // 
            // separatorLayout
            // 
            this.separatorLayout.Name = "separatorLayout";
            resources.ApplyResources(this.separatorLayout, "separatorLayout");
            // 
            // layoutComboBox
            // 
            this.layoutComboBox.Name = "layoutComboBox";
            resources.ApplyResources(this.layoutComboBox, "layoutComboBox");
            // 
            // layoutButton
            // 
            this.layoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layoutButton.Image = global::DessinObjets.Properties.Resources.LayoutEditorPart_6030;
            resources.ApplyResources(this.layoutButton, "layoutButton");
            this.layoutButton.Name = "layoutButton";
            this.layoutButton.Click += new System.EventHandler(this.layoutButton_Click);
            // 
            // homothétie
            // 
            this.homothétie.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.zoom200,
            this.toolStripMenuItem3,
            this.zoom100,
            this.toolStripMenuItem5,
            this.zoom50,
            this.toolStripMenuItem4});
            resources.ApplyResources(this.homothétie, "homothétie");
            this.homothétie.Name = "homothétie";
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.zoom_Click);
            // 
            // zoom200
            // 
            resources.ApplyResources(this.zoom200, "zoom200");
            this.zoom200.Name = "zoom200";
            this.zoom200.Click += new System.EventHandler(this.zoom_Click);
            // 
            // toolStripMenuItem3
            // 
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.zoom_Click);
            // 
            // zoom100
            // 
            resources.ApplyResources(this.zoom100, "zoom100");
            this.zoom100.Name = "zoom100";
            this.zoom100.Click += new System.EventHandler(this.zoom_Click);
            // 
            // toolStripMenuItem5
            // 
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.zoom_Click);
            // 
            // zoom50
            // 
            resources.ApplyResources(this.zoom50, "zoom50");
            this.zoom50.Name = "zoom50";
            this.zoom50.Click += new System.EventHandler(this.zoom_Click);
            // 
            // toolStripMenuItem4
            // 
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.zoom_Click);
            // 
            // hScroll
            // 
            resources.ApplyResources(this.hScroll, "hScroll");
            this.hScroll.Maximum = 800;
            this.hScroll.Name = "hScroll";
            this.hScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScroll_Scroll);
            this.hScroll.ValueChanged += new System.EventHandler(this.hScroll_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.editionToolStripMenuItem,
            this.outilsToolStripMenuItem,
            this.aideToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvrirToolStripMenuItem,
            this.toolStripSeparator,
            this.enregistrerToolStripMenuItem,
            this.enregistrersousToolStripMenuItem,
            this.toolStripSeparator6,
            this.imprimerToolStripMenuItem,
            this.aperçuavantimpressionToolStripMenuItem,
            this.toolStripSeparator7});
            this.fichierToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            resources.ApplyResources(this.fichierToolStripMenuItem, "fichierToolStripMenuItem");
            // 
            // nouveauToolStripMenuItem
            // 
            resources.ApplyResources(this.nouveauToolStripMenuItem, "nouveauToolStripMenuItem");
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            // 
            // ouvrirToolStripMenuItem
            // 
            resources.ApplyResources(this.ouvrirToolStripMenuItem, "ouvrirToolStripMenuItem");
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // enregistrerToolStripMenuItem
            // 
            resources.ApplyResources(this.enregistrerToolStripMenuItem, "enregistrerToolStripMenuItem");
            this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            // 
            // enregistrersousToolStripMenuItem
            // 
            this.enregistrersousToolStripMenuItem.Name = "enregistrersousToolStripMenuItem";
            resources.ApplyResources(this.enregistrersousToolStripMenuItem, "enregistrersousToolStripMenuItem");
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // imprimerToolStripMenuItem
            // 
            resources.ApplyResources(this.imprimerToolStripMenuItem, "imprimerToolStripMenuItem");
            this.imprimerToolStripMenuItem.Name = "imprimerToolStripMenuItem";
            this.imprimerToolStripMenuItem.Click += new System.EventHandler(this.imprimerToolStripButton_Click);
            // 
            // aperçuavantimpressionToolStripMenuItem
            // 
            resources.ApplyResources(this.aperçuavantimpressionToolStripMenuItem, "aperçuavantimpressionToolStripMenuItem");
            this.aperçuavantimpressionToolStripMenuItem.Name = "aperçuavantimpressionToolStripMenuItem";
            this.aperçuavantimpressionToolStripMenuItem.Click += new System.EventHandler(this.aperçuavantimpressionToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annulerToolStripMenuItem,
            this.rétablirToolStripMenuItem,
            this.toolStripSeparator8,
            this.couperToolStripMenuItem,
            this.copierToolStripMenuItem,
            this.collerToolStripMenuItem,
            this.toolStripSeparator9,
            this.sélectionnertoutToolStripMenuItem});
            this.editionToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            resources.ApplyResources(this.editionToolStripMenuItem, "editionToolStripMenuItem");
            // 
            // annulerToolStripMenuItem
            // 
            resources.ApplyResources(this.annulerToolStripMenuItem, "annulerToolStripMenuItem");
            this.annulerToolStripMenuItem.Name = "annulerToolStripMenuItem";
            this.annulerToolStripMenuItem.Click += new System.EventHandler(this.annulerToolStripMenuItem_Click);
            // 
            // rétablirToolStripMenuItem
            // 
            resources.ApplyResources(this.rétablirToolStripMenuItem, "rétablirToolStripMenuItem");
            this.rétablirToolStripMenuItem.Name = "rétablirToolStripMenuItem";
            this.rétablirToolStripMenuItem.Click += new System.EventHandler(this.rétablirToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // couperToolStripMenuItem
            // 
            resources.ApplyResources(this.couperToolStripMenuItem, "couperToolStripMenuItem");
            this.couperToolStripMenuItem.Name = "couperToolStripMenuItem";
            this.couperToolStripMenuItem.Click += new System.EventHandler(this.couperToolStripButton_Click);
            // 
            // copierToolStripMenuItem
            // 
            resources.ApplyResources(this.copierToolStripMenuItem, "copierToolStripMenuItem");
            this.copierToolStripMenuItem.Name = "copierToolStripMenuItem";
            this.copierToolStripMenuItem.Click += new System.EventHandler(this.copierToolStripButton_Click);
            // 
            // collerToolStripMenuItem
            // 
            resources.ApplyResources(this.collerToolStripMenuItem, "collerToolStripMenuItem");
            this.collerToolStripMenuItem.Name = "collerToolStripMenuItem";
            this.collerToolStripMenuItem.Click += new System.EventHandler(this.collerToolStripButton_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // sélectionnertoutToolStripMenuItem
            // 
            this.sélectionnertoutToolStripMenuItem.Name = "sélectionnertoutToolStripMenuItem";
            resources.ApplyResources(this.sélectionnertoutToolStripMenuItem, "sélectionnertoutToolStripMenuItem");
            this.sélectionnertoutToolStripMenuItem.Click += new System.EventHandler(this.sélectionnertoutToolStripMenuItem_Click);
            // 
            // outilsToolStripMenuItem
            // 
            this.outilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personnaliserToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.outilsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            resources.ApplyResources(this.outilsToolStripMenuItem, "outilsToolStripMenuItem");
            // 
            // personnaliserToolStripMenuItem
            // 
            this.personnaliserToolStripMenuItem.Name = "personnaliserToolStripMenuItem";
            resources.ApplyResources(this.personnaliserToolStripMenuItem, "personnaliserToolStripMenuItem");
            this.personnaliserToolStripMenuItem.Click += new System.EventHandler(this.personnaliserToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sommaireToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.rechercherToolStripMenuItem,
            this.toolStripSeparator10,
            this.àproposdeToolStripMenuItem});
            this.aideToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            resources.ApplyResources(this.aideToolStripMenuItem, "aideToolStripMenuItem");
            // 
            // sommaireToolStripMenuItem
            // 
            this.sommaireToolStripMenuItem.Name = "sommaireToolStripMenuItem";
            resources.ApplyResources(this.sommaireToolStripMenuItem, "sommaireToolStripMenuItem");
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            resources.ApplyResources(this.indexToolStripMenuItem, "indexToolStripMenuItem");
            // 
            // rechercherToolStripMenuItem
            // 
            this.rechercherToolStripMenuItem.Name = "rechercherToolStripMenuItem";
            resources.ApplyResources(this.rechercherToolStripMenuItem, "rechercherToolStripMenuItem");
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // àproposdeToolStripMenuItem
            // 
            this.àproposdeToolStripMenuItem.Name = "àproposdeToolStripMenuItem";
            resources.ApplyResources(this.àproposdeToolStripMenuItem, "àproposdeToolStripMenuItem");
            // 
            // Graphe
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vScroll);
            this.Controls.Add(this.hScroll);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Graphe";
            this.Load += new System.EventHandler(this.Graphe_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DessinObjets_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DessinObjets_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DessinObjets_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DessinObjets_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DessinObjets_MouseUp);
            this.Resize += new System.EventHandler(this.DessinObjets_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScroll;
        private System.Windows.Forms.ToolStripButton nouveauToolStripButton;
        private System.Windows.Forms.ToolStripButton ouvrirToolStripButton;
        private System.Windows.Forms.ToolStripButton enregistrerToolStripButton;
        private System.Windows.Forms.ToolStripButton imprimerToolStripButton;
        private System.Windows.Forms.ToolStripSeparator separatorEntité;
        private System.Windows.Forms.ToolStripButton déplacement;
        private System.Windows.Forms.ToolStripSeparator separatorCouper;
        private System.Windows.Forms.ToolStripButton couperToolStripButton;
        private System.Windows.Forms.ToolStripButton copierToolStripButton;
        private System.Windows.Forms.ToolStripButton collerToolStripButton;
        private System.Windows.Forms.ToolStripSeparator separatorRelation;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.HScrollBar hScroll;
        private System.Windows.Forms.ToolStripButton créeRelationsBouton;
        private System.Windows.Forms.ToolStripButton versSQL;
        private System.Windows.Forms.ToolStripButton applySql;
        private System.Windows.Forms.ToolStripButton parcoursSQL;
        private System.Windows.Forms.ToolStripSeparator separatorImpression;
        private System.Windows.Forms.ToolStripButton printPreviewButton;
        private System.Windows.Forms.ToolStripButton imprimerToutButton;
        private System.Windows.Forms.ToolStripButton printScaleButton;
        private System.Windows.Forms.ToolStripSeparator separatorFichier;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrersousToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem imprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aperçuavantimpressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem annulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rétablirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem couperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem sélectionnertoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personnaliserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sommaireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechercherToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem àproposdeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton créeEntitéAssociationButton;
        private System.Windows.Forms.ToolStripSeparator separatorLayout;
        private System.Windows.Forms.ToolStripButton layoutButton;
        private System.Windows.Forms.ToolStripComboBox layoutComboBox;
        private System.Windows.Forms.ToolStripDropDownButton homothétie;
        private System.Windows.Forms.ToolStripMenuItem zoom200;
        private System.Windows.Forms.ToolStripMenuItem zoom100;
        private System.Windows.Forms.ToolStripMenuItem zoom50;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton redoButton;

    }
}

