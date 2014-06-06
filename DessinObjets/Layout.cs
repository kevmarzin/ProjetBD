using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Chung.Core;
using Microsoft.Chung.Visualization;


namespace DessinObjets
{
    /// <summary>
    /// Textes décrivant les différents algorithmes de disposition
    /// voir aussi http://graphsharp.codeplex.com/
    /// </summary>
    public enum GraphLayoutType { 
        /// <summary>
        /// Force-directed layout algorithm http://wiki.gephi.org/index.php/Fruchterman-Reingold
        /// </summary>
        Fruchterman_Reingold,
        /// <summary>
        /// The combination of attractive forces on adjacent vertices, and repulsive forces on all vertices, was first used by Eades (1984)
        /// </summary>    
        Eades,
        /// <summary>
        /// Placement aléatoire des noeuds
        /// </summary>
        Random,
        /// <summary>
        /// Placement des noeuds sur un cercle
        /// </summary>
        Circle,       
        /// <summary>
        /// Encore un "force directed layout algorithm"
        /// </summary>
        Kamada_Kawaii,
        /// <summary>
        /// Placement des noeuds sur une grille
        /// </summary>
        Grid,
        /// <summary>
        /// 
        /// </summary>
        Sugiyama
    };
    /// <summary>
    /// Classe décrivant un graphe
    /// </summary>
    public class Graph
    {
        #region attributs
        List<Noeud> noeuds;
        List<Trait> traits;
        #endregion
        /// <summary>
        /// Liste des noeuds
        /// </summary>
        #region Propriétés
        public List<Noeud> Noeuds
        {
            get { return noeuds; }
            set { noeuds = value; }
        }
        /// <summary>
        ///  Liste des arêtes
        /// </summary>
        public List<Trait> Traits
        {
            get { return traits; }
            set { traits = value; }
        }
        #endregion
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="noeuds">Noeuds</param>
        /// <param name="traits">Arêtes</param>
        public Graph(List<Noeud> noeuds, List<Trait> traits)
        { this.noeuds = noeuds; this.traits = traits; }
    }
    /// <summary>
    /// Classe utilisant la bibiliothèque Chung développée par Microsoft Reseach
    /// </summary>
    public class GraphLayout
    {
         static GraphDrawer gd = new GraphDrawer();
        /// <summary>
        /// Méthode statique de Layout
        /// </summary>
        /// <param name="graphe">Graphe entrée</param>
        /// <param name="rectangle">Zone de dessin</param>
        /// <param name="layout">Type de layout</param>
        /// <returns>Le graphe repositionné</returns>
        public static Graph LayoutGraph(Graph graphe, Rectangle rectangle, GraphLayoutType layout)
        {
            Microsoft.Chung.Core.Graph mcg = new Microsoft.Chung.Core.Graph();
            #region Copy the graph
            foreach (Noeud n in graphe.Noeuds)
            {
                if (!n.Supprimé)
                {
                    Microsoft.Chung.Core.Vertex v = new Microsoft.Chung.Core.Vertex();
                    v.SetValue("ID", n.ID);
                    v.Name = n.Texte;
                    mcg.Vertices.Add(v);
                }
            }
            foreach (Trait e in graphe.Traits)
            {
                Microsoft.Chung.Core.IVertex vs;
                Microsoft.Chung.Core.IVertex vt;
                mcg.Vertices.Find(e.Source.Texte, out vs);
                mcg.Vertices.Find(e.Destination.Texte, out  vt);
                if ((vs != null) && (vt != null))
                {
                    Microsoft.Chung.Core.Edge mce = new Microsoft.Chung.Core.Edge(vs, vt, true);
                    mcg.Edges.Add(mce);
                }
            }
            #endregion
            ILayout fr = ChooseLayout(layout);
            rectangle = new Rectangle(100, 100, rectangle.Width - 150, rectangle.Height - 150);
            LayoutContext t = new LayoutContext(rectangle, gd);
            fr.LayOutGraph(mcg, t);
            gd.Layout = fr;
            #region Update initialgraph
            foreach (Noeud n in graphe.Noeuds)
            {
                lock (graphe)
                {
                    Microsoft.Chung.Core.IVertex vs;
                    mcg.Vertices.Find(n.Texte, out vs);
                    n.Déplace(new Point((int)vs.Location.X, (int)vs.Location.Y));
                }
            }
            #endregion
            return graphe;
        }
        private static ILayout ChooseLayout(GraphLayoutType s)
        {
            EdgeDrawer ed = new EdgeDrawer();
            gd.EdgeDrawer = ed;
            ed.Color = Color.Red;
            VertexDrawer vd = new VertexDrawer();
            gd.VertexDrawer = vd;
            vd.Shape = VertexDrawer.VertexShape.Disk;
            ILayout fr = new FruchtermanReingoldLayout();
            switch (s)
            {
                case GraphLayoutType.Fruchterman_Reingold:
                    fr = new FruchtermanReingoldLayout();
                    break;
                case GraphLayoutType.Random:
                    fr = new RandomLayout();
                    break;
                case GraphLayoutType.Circle:
                    fr = new CircleLayout();
                    break;
                case GraphLayoutType.Kamada_Kawaii:
                    fr = new KamadaKawaiiLayout();
                    break;
                case GraphLayoutType.Grid:
                    fr = new GridLayout();
                    break;
                case GraphLayoutType.Sugiyama:
                    SugiyamaEdgeDrawer eds = new SugiyamaEdgeDrawer();
                    gd.EdgeDrawer = eds;
                    eds.Color = Color.Red;
                    SugiyamaVertexDrawer vds = new SugiyamaVertexDrawer();
                    gd.VertexDrawer = vds;
                    vds.Shape = VertexDrawer.VertexShape.Sphere;
                    fr = new SugiyamaLayout();
                    break;
            }
            return fr;
        }
    }
}