using System;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Xml;

namespace DessinObjets
{
    /// <summary>
    /// La classe Noeud encapsule un rectangle avec son épaisseur et la couleur de son bord
    /// </summary>
    [Serializable]
    public partial class Noeud : ISupprimable, IDisposable
    {
        #region Propriétés
        #region Propriétés de base
        /// <summary>
        /// Identificateur
        /// </summary>
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        /// <summary>
        /// Localisation
        /// </summary>
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
        /// <summary>
        /// Dimensions
        /// </summary>
        public Size Taille
        {
            get { return taille; }
            set { taille = value; }
        }
        /// <summary>
        /// Epaisseur du bord
        /// </summary>
        public int Epaisseur
        {
            get { return épaisseur; }
            set { épaisseur = value; }
        }
        /// <summary>
        /// Couleur du bord
        /// </summary>
        public Color CouleurBord
        {
            get { return couleurBordure; }
            set { couleurBordure = value; }
        }
        /// <summary>
        /// Couleur du fond
        /// </summary>
        public Color CouleurFond
        {
            get { return couleurFond; }
            set { couleurFond = value; }
        }
        #endregion
        #region Texte
        /// <summary>
        /// Texte
        /// </summary>
        public string Texte
        {
            get { return texte; }
            set { texte = value; }
        }
        /// <summary>
        /// Police
        /// </summary>
        public Font Police
        {
            get { return police; }
            set { police = value; }
        }
        /// <summary>
        /// Couleur de la police
        /// </summary>
        public Color CouleurPolice
        {
            get { return couleurPolice; }
            set { couleurPolice = value; }
        }
        #endregion
        #region Coordonnées de dessin
        /// <summary>
        /// 
        /// </summary>
        public Point Left { get { return new Point(rectAffichage.Left, rectAffichage.Top + rectAffichage.Height / 2); } }
        /// <summary>
        /// 
        /// </summary>
        public Point Right { get { return new Point(rectAffichage.Right, rectAffichage.Top + rectAffichage.Height / 2); } }
        /// <summary>
        /// 
        /// </summary>
        public Point Top { get { return new Point(rectAffichage.Left + rectAffichage.Width / 2, rectAffichage.Top); } }
        /// <summary>
        /// 
        /// </summary>
        public Point Bottom { get { return new Point(rectAffichage.Left + rectAffichage.Width / 2, rectAffichage.Bottom); } }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public Point Centre { get { return new Point(position.X, position.Y); } }
        #endregion
        #region Implémentation de l'interface
        /// <summary>
        /// 
        /// </summary>
        protected bool supprimé = false;
        /// <summary>
        /// Vrai si l'objet est supprimé
        /// </summary>
        public bool Supprimé
        {
            get { return supprimé; }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Supprime()
        { supprimé = true; }
        /// <summary>
        /// 
        /// </summary>
        public void Restaure()
        { supprimé = false; }
        #endregion
        #region Membres privés
        /// <summary>
        /// 
        /// </summary>
        protected Rectangle rectangle
        {
            get { return new Rectangle(new Point(position.X - taille.Width / 2, position.Y - taille.Height / 2), taille); }
            set { new Rectangle(new Point(position.X - taille.Width / 2, position.Y - taille.Height / 2), taille); }
        }
        /// <summary>
        /// 
        /// </summary>
        protected static int compteur;
        /// <summary>
        /// 
        /// </summary>
        protected int iD;
        /// <summary>
        /// 
        /// </summary>
        protected Point position;
        /// <summary>
        /// 
        /// </summary>
        protected Size taille;
        /// <summary>
        /// 
        /// </summary>
        protected Color couleurBordure;
        /// <summary>
        /// 
        /// </summary>
        protected Color couleurFond;
        /// <summary>
        /// 
        /// </summary>
        protected int épaisseur;
        /// <summary>
        /// 
        /// </summary>
        protected string texte;
        /// <summary>
        /// 
        /// </summary>
        protected Font police;
        /// <summary>
        /// 
        /// </summary>
        protected Color couleurPolice = Color.Black;
        /// <summary>
        /// 
        /// </summary>
        public bool IsSelected;
        /// <summary>
        /// 
        /// </summary>
        protected Rectangle rectAffichage;


        #endregion
        #region Constructeur
        /// <summary>
        /// Constructeur vide, nécessaire pour la déserialisation
        /// </summary>
        public Noeud() { }
        /// <summary>
        /// Construit un Noeud
        /// </summary>
        /// <param name="location">Centre</param>
        /// <param name="size">Taille</param>
        /// <param name="couleurBordure">couleur initiale</param>
        /// <param name="épaisseur">épaisseur initiale</param>
        public Noeud(Point location, Size size, Color couleurBordure, int épaisseur)
        {
            iD = compteur;
            texte = ID.ToString();
            compteur++;
            //   p.Offset(-s.Width / 2, -s.Height / 2);
            this.position = location;
            this.taille = size;
            this.couleurBordure = couleurBordure;
            this.épaisseur = épaisseur;
            police = new Font("Arial", 12);

        }
        #endregion
        #region Méthodes
        /// <summary>
        /// Crée un clone du noeud courant
        /// </summary>
        /// <returns></returns>
        public Noeud Clone()
        {
            ConstructorInfo[] cix = this.GetType().GetConstructors();
            #region Recherche d'un constructeur sans paramètres
            ConstructorInfo ciNull = null;
            foreach(ConstructorInfo ci in cix)
            {
                if( ci.GetParameters().Length==0)
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
            foreach(PropertyInfo pi in pix)
            {
                if(pi.CanWrite)
                {
                    pi.SetValue(copie, pi.GetValue(this));
                }
            }
            return (Noeud)copie;
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
        /// <summary>
        /// Méthode de dessin
        /// </summary>
        /// <param name="graphics">zone d'affichage</param>
        /// <param name="zoom">Facteur de zoom</param>
        /// <param name="origin">Origine du dessin</param>
        /// <param name="origineZoom">Centre d'homothétie</param>
        public virtual void Dessine(Graphics graphics, float zoom, Point origin, Point origineZoom)
        {
            if (supprimé)
                return;
            #region Polices
            Pen p = new Pen(couleurBordure, épaisseur);
            if (IsSelected)
                p = new Pen(Color.Red, épaisseur);
            float fontSize = police.Size * zoom;
            if (fontSize > 36)
                fontSize = 36;
            if (fontSize < 6)
                fontSize = 6;
            police = new Font(police.FontFamily, fontSize, FontStyle.Regular);
            #endregion
            rectAffichage = RectangleAffichage(zoom, origin, origineZoom);
            graphics.FillRectangle(new SolidBrush(CouleurFond), rectAffichage);
            graphics.DrawRectangle(p, rectAffichage);
            Brush br = new SolidBrush(couleurPolice);
            if ((texte != null) && (texte != ""))
                graphics.DrawString(texte, police, br, CentreDessin(zoom, origin, origineZoom));
            else
                graphics.DrawString(iD.ToString(), police, br, CentreDessin(zoom, origin, origineZoom));

        }
        /// <summary>
        /// Zone d'affichage du noeud
        /// </summary>
        /// <param name="zoom">Facteur de zoom à partir de l'origine</param>
        /// <param name="origin">Origine du dessin</param>
        /// <param name="origineZoom">Centre d'homothétie</param>
        /// <returns></returns>
       public Rectangle RectangleAffichage(float zoom, Point origin, Point origineZoom)
        {
            int x = position.X - taille.Width / 2; int y = position.Y - taille.Height / 2;
            int x0 = origineZoom.X; int y0 = origineZoom.Y;
            
            Rectangle r = new Rectangle((int)((x - x0 ) * zoom) + x0 + origin.X, (int)((y - y0) * zoom) + y0 + origin.Y,
                (int)(taille.Width * zoom), (int)(taille.Height * zoom));
            return r;
        }
        /// <summary>
        /// Centre du noeud à l'affichage
        /// </summary>
        /// <param name="zoom">Facteur de zoom</param>
        /// <param name="origin">Origine du dessin</param>
       /// <param name="origineZoom">Centre d'homothétie</param>
       /// <returns></returns>
        public Point CentreDessin(float zoom, Point origin, Point origineZoom)
        {
            return new Point((int)((Centre.X - origineZoom.X) * zoom) + origineZoom.X + origin.X, (int)((Centre.Y - origineZoom.Y) * zoom) + origineZoom.Y + origin.Y);
        }
        /// <summary>
        /// Teste la présence d'un point
        /// </summary>
        /// <param name="pt">Point à tester</param>
        /// <returns>true si la forme contient le point</returns>
        public virtual bool Contains(Point pt)
        {
            IsSelected = rectangle.Contains(pt);
            return IsSelected;
        }
        /// <summary>
        /// Déplace le rectangle
        /// </summary>
        /// <param name="p">Nouvel emplacement</param>
        public void Déplace(Point p)
        {
            position.X = p.X;// -rectangle.Width / 2;
            position.Y = p.Y;// -rectangle.Height / 2;
        }
        /// <summary>
        /// Déplacement relatif du noeud
        /// </summary>
        /// <param name="Vecteur">Vecteur de déplacement</param>
        public void DéplaceVers(Point Vecteur)
        {
            position.X += Vecteur.X;
            position.Y += Vecteur.Y;
        }
        /// <summary>
        /// Sélectionne le noeud
        /// </summary>
        public void Select()
        {
            IsSelected = true;
        }
        /// <summary>
        ///  Déselectionne le noeud
        /// </summary>
        public void UnSelect()
        {
            IsSelected = false;
        }
        #endregion
        #region Sauvegarde
        #region Sauvegarde ToXML
        /// <summary>
        /// Génération XML
        /// </summary>
        /// <returns></returns>
        public string ToXML()
        {
            string text = "<NOEUD>";
            text += "   <ID>";
            text += "     " + iD.ToString();
            text += "   </ID>";
            text += "   <POSITION>";
            text += "     " + position.ToString();
            text += "   </POSITION>";
            text += "   <TAILLE>";
            text += "     " + taille.ToString();
            text += "   </TAILLE>";
            text += "   <EPAISSEUR>";
            text += "     " + épaisseur.ToString();
            text += "   </EPAISSEUR>";
            text += "   <COULEUR>";
            text += "     " + couleurBordure.ToArgb().ToString();
            text += "   </COULEUR>";
            text += "</NOEUD >";
            return text;
        }
        /// <summary>
        /// Création d'un noeud à partir d'une structure XML
        /// </summary>
        /// <param name="xNN"></param>
        public Noeud(XmlNode xNN)
        {
            iD++;
            foreach (XmlNode xNNN in xNN.ChildNodes)
            {
                switch (xNNN.Name.ToUpper())
                {
                    case "ID":
                        iD = int.Parse(xNNN.InnerText);
                        break;
                    case "POSITION":
                        string[] data = xNNN.InnerText.Split(',');
                        int x = int.Parse(xNNN.ChildNodes[0].InnerText);
                        int y = int.Parse(xNNN.ChildNodes[1].InnerText);
                        position = new Point(x, y);
                        break;
                    case "TAILLE":
                        data = xNNN.InnerText.Split(',');
                        int w = int.Parse(xNNN.ChildNodes[0].InnerText);
                        int h = int.Parse(xNNN.ChildNodes[1].InnerText);
                        taille = new Size(w, h);
                        break;
                    case "EPAISSEUR":
                        épaisseur = int.Parse(xNNN.InnerText);
                        break;
                    case "COULEURBORD":
                        int c = int.Parse(xNNN.InnerText);
                        couleurBordure = Color.FromArgb(c);
                        break;
                    case "COULEURFOND":
                        c = int.Parse(xNNN.InnerText);
                        couleurFond = Color.FromArgb(c);
                        break;
                    case "TEXTE":
                        Texte = xNNN.InnerText;
                        break;
                    case "POLICE":
                        int s = int.Parse(xNNN.ChildNodes[10].InnerText);
                        police = new Font(xNNN.ChildNodes[5].InnerText, s);
                        break;
                }
            }
        }
        #endregion
        #endregion
        public void Dispose()
        {
            Dispose(true);
        }
        private void Dispose(bool disp)
        {
            police.Dispose(); ;
        }
    }
}
