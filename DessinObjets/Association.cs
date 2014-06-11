using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DessinObjets
{
    public class Association : Noeud
    {
        Entité entitéSource;
        Entité entitéDestination;
        Lien lienSource;
        Lien lienDestination;

        List<Champ> champs = new List<Champ>();

        public Association(): base()
        {
        }

        public Association(Point location, Size size, Color couleurBordure, int épaisseur, Entité S, Entité D)
            : base(location, size, couleurBordure, épaisseur)
        {
            texte = "Association";
            entitéSource = S;
            entitéDestination = D;
            //A calculer : Point Location
            //             Size size
        }

        public Association(Point location, Size size, Color couleurBordure, int épaisseur, Entité S, Entité D, Lien lS, Lien lD) : base(location, size, couleurBordure, épaisseur)
        {
            texte = "Association";
            entitéSource = S;
            entitéDestination = D;
            lienSource = lS;
            lienDestination = lD;
            //A calculer : Point Location
            //             Size size
        }

        public List<Champ> Champs
        {
            get { return champs; }
            set { champs = value; }
        }

        public Lien LienSource
        {
            get { return lienSource; }
            set { lienSource = value; }
        }

        public Lien LienDestination
        {
            get { return lienDestination; }
            set { lienDestination = value; }
        }

        public Champ GetCléPrimaire
        {
            get
            {
                Champ clé = null;
                foreach(Champ c in Champs)
                {
                    if (c.CléPrimaire)
                        clé = c;
                }
                return clé;
            }
        }
        
        public void CalculTaille(Font police, Graphics graphics, float zoom)
        {
            //calcul de la taille du dessin
            SizeF size = graphics.MeasureString(Texte, police);
            
            int lignes=champs.Count();
            taille = new Size((int)size.Width + 3, (lignes*18)+(int)size.Height);           
        }

        public Point PositionText(float zoom, Point origin, Point origineZoom, int ligne)
        {
            Point p= new Point(rectangle.X, (ligne*18)+rectangle.Y);
            return p;
        }

        public override void Dessine(Graphics graphics, float zoom, Point origin, Point origineZoom)
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
            CalculTaille(police,graphics,zoom);
            rectAffichage = RectangleAffichage(zoom, origin, origineZoom);
            graphics.FillRectangle(new SolidBrush(CouleurFond), rectAffichage);
            
            graphics.DrawEllipse(p, rectAffichage);
            Brush br = new SolidBrush(couleurPolice);
            
            int ligne = 0;

            graphics.DrawString(texte, police, br, PositionText(zoom, origin, origineZoom,ligne));

            if (champs.Count() > 0)
            {
                //calcul de la largeur pour pouvoir dessiner le trait
                SizeF size = graphics.MeasureString(Texte, police);

                graphics.DrawLine(p, new Point(rectangle.X, rectangle.Y + 18), new Point(rectangle.X + (int)size.Width + 3, rectangle.Y + 18));

                foreach (Champ c in champs)
                {
                    ligne++;
                    graphics.DrawString(c.ToString(), police, br, PositionText(zoom, origin, origineZoom, ligne));
                }
            }
        }
    }
}
