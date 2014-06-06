using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Xml;

namespace DessinObjets
{
    /// <summary>
    /// La classe Trait représente un trait reliant deux noeuds (par leurs bords), sa source et sa destination.
    /// Le trait a une épaisseur et une couleur
    /// </summary>
    [Serializable]
    public class Trait : ISupprimable
    {
        #region Propriétés
        /// <summary>
        /// Source du trait
        /// </summary>
        public Noeud Source
        {
            get { return source; }
            set { source = value; }
        }
        /// <summary>
        /// Destination du trait
        /// </summary>
        public Noeud Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        /// <summary>
        /// Couleur du trait
        /// </summary>
        public Color Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }
        /// <summary>
        /// Epaisseur
        /// </summary>
        public int Epaisseur
        {
            get { return épaisseur; }
            set { épaisseur = value; }
        }
        /// <summary>
        /// Vrai si le noeud est sélectionn"
        /// </summary>
        protected bool IsSelected { get { return isSelected; } }
        #endregion
        #region Membre privés
        /// <summary>
        /// 
        /// </summary>
        protected bool supprimé;
        private Noeud source;
        private Noeud destination;
        private Color couleur;
        private int épaisseur;
        /// <summary>
        /// 
        /// </summary>
        protected Point débutTrait;
        /// <summary>
        /// 
        /// </summary>
        protected Point finTrait;
        private bool isSelected;
        #endregion
        #region Constructeurs
        /// <summary>
        /// Constructeur générique
        /// </summary>
        public Trait() { }
        /// <summary>
        /// Création d'un trait de couleur c, d'épaisseur e, reliant
        /// les rectangles source et destination
        /// </summary>
        /// <param name="sour">Rect source</param>
        /// <param name="dest">Rect destination</param>
        /// <param name="c">couleur initiale</param>
        /// <param name="e">epaisseur initiale</param>
        public Trait(Noeud sour, Noeud dest, Color c, int e)
        {
            source = sour;
            destination = dest;
            couleur = c;
            épaisseur = e;
        }
        #endregion
        #region Implémentation de l'interface
        /// <summary>
        /// Suppression du trait
        /// </summary>
        public void Supprime()
        { supprimé = true; }
        /// <summary>
        /// Restauration du trait
        /// </summary>
        public void Restaure()
        { supprimé = false; }
        #endregion
        #region Dessine
        /// <summary>
        /// Dessine le trait
        /// </summary>
        /// <param name="graphics">zone d'affichage</param>
        /// <param name="zoom">Facteur de zoom</param>
        /// <param name="origin">Origine du dessin</param>
        /// <param name="origineZoom">Centre d'homothétie</param>
        public virtual void Dessine(Graphics graphics, float zoom, Point origin, Point origineZoom)
        {
            if (supprimé)
                return;
            #region Prise en compte de la position relative des noeuds
            if (Source.Left.X > Destination.Right.X)
            {
                débutTrait = Destination.Right;
                finTrait = Source.Left;

            }
            else if (Source.Left.X < Destination.Right.X)
            {
                débutTrait = Source.Right;
                finTrait = Destination.Left;
            }
            if (Math.Abs(Source.Left.X - Destination.Right.X) < 10)
            {
                if (Source.Top.Y < Destination.Bottom.Y)
                {
                    débutTrait = Source.Bottom;
                    finTrait = Destination.Top;

                }
                else if (Source.Bottom.Y > Destination.Top.Y)
                {
                    débutTrait = Source.Top;
                    finTrait = Destination.Bottom;
                }

            }
            #endregion
            Pen p = new Pen(couleur, épaisseur);
            if (isSelected)
                p = new Pen(Color.Red, épaisseur);
            graphics.DrawLine(p, débutTrait, finTrait);
        }
        /// <summary>
        /// Désection du trait
        /// </summary>
        public void Deselect()
        {
            isSelected = false;
        }
        /// <summary>
        /// Teste si le point est sur le trait
        /// </summary>
        /// <param name="point">Point à tester</param>
        /// <returns>Vrai si le point est sur le trai</returns>
        public bool Contient(Point point)
        {
            // IsSelected = false;
            Point beg = débutTrait;
            Point end = finTrait;
            if (beg.X > end.X)
            {
                Point exch = end;
                end = beg;
                beg = exch;
            }
            if (beg.X == end.X)
            {
                int deb = Math.Min(end.Y, beg.Y);
                int fin = Math.Max(end.Y, beg.Y);
                for (int y = deb; y <= fin; y++)
                {
                    Point current = new Point(beg.X, y);
                    Rectangle e = new Rectangle(current.X - 3, current.Y - 3, 6, 6);
                    if (e.Contains(point))
                    {
                        isSelected = true;
                        return true;
                    }
                }
            }
            else
            {
                for (int x = beg.X; x <= end.X; x++)
                {
                    Point current = new Point(x, beg.Y + ((x - beg.X) * (end.Y - beg.Y)) / (end.X - beg.X));
                    Rectangle e = new Rectangle(current.X - 3, current.Y - 3, 6, 6);
                    if (e.Contains(point))
                    {
                        isSelected = true;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Crée un clone du trait courant
        /// </summary>
        /// <returns></returns>
        public Trait Clone()
        {
            ConstructorInfo[] cix = this.GetType().GetConstructors();
            #region Recherche d'un constructeur sans paramètres
            ConstructorInfo ciNull = null;
            foreach (ConstructorInfo ci in cix)
            {
                if (ci.GetParameters().Length == 0)
                {
                    ciNull = ci;
                    break;
                }
            }
            #endregion
            if (ciNull == null)
                return null;
            object copie = ciNull.Invoke(null);
            PropertyInfo[] pix = this.GetType().GetProperties();
            foreach (PropertyInfo pi in pix)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(copie, pi.GetValue(this));
                }
            }
            return (Trait)copie;
        }
        /// <summary>
        /// Méthode générique de restauration des paramètres de l'objet
        /// </summary>
        /// <param name="ancien">Anciennes valeurs</param>
        public void RestaureParams(ISupprimable ancien)
        {
            PropertyInfo[] pix = this.GetType().GetProperties();
            foreach (PropertyInfo pi in pix)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(this, pi.GetValue(ancien));
                }
            }
        }

        #endregion
        #region Sauvegarde
        #region XML
        /// <summary>
        /// Sauvegarde un trait au format Xml
        /// </summary>
        /// <returns>Chaîne Xml</returns>
        public string ToXML()
        {
            string text = "<TRAIT>";
            text += "   <SOURCE>";
            text += "      " + source.ID.ToString();
            text += "   </SOURCE>";
            text += "   <DESTINATION>";
            text += "      " + destination.ID.ToString();
            text += "   </DESTINATION>";
            text += "   <EPAISSEUR>";
            text += "     " + épaisseur.ToString();
            text += "   </EPAISSEUR>";
            text += "   <COULEUR>";
            text += "      " + couleur.ToArgb().ToString();
            text += "   </COULEUR>";
            text += "</TRAIT>";
            return text;
        }
        /// <summary>
        /// Lit depuis XML
        /// </summary>
        /// <param name="Xnode">Donnée au format XML</param>
        /// <param name="noeuds">Liste des noeuds</param>
        public Trait(XmlNode Xnode, List<Noeud> noeuds)
        {
            foreach (XmlNode xN in Xnode.ChildNodes)
            {
                switch (xN.Name.ToUpper())
                {
                    case "SOURCE":
                        int i = int.Parse(xN.ChildNodes[0].InnerText);
                        foreach (Noeud nd in noeuds)
                        {
                            if (nd.ID == i)
                            {
                                source = nd;
                                break;
                            }
                        }
                        break;
                    case "DESTINATION":
                        int j = int.Parse(xN.ChildNodes[0].InnerText);
                        foreach (Noeud nd in noeuds)
                        {
                            if (nd.ID == j)
                            {
                                destination = nd;
                                break;
                            }
                        }
                        break;
                    case "EPAISSEUR":
                        épaisseur = int.Parse(xN.InnerText);
                        break;
                    case "COULEUR":
                        int c = int.Parse(xN.InnerText);
                        couleur = Color.FromArgb(c);
                        break;
                }
            }
        }
        #endregion
        #endregion
    }
}
