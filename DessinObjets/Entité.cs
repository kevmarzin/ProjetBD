using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DessinObjets
{
    public class Entité : Noeud
    {       

        List<Champ> champs = new List<Champ>();

        public Entité(): base()
        {
            texte = "Entité";
            Champ ID = new Champ("ID", typeof(Int16), 0, true, false, true, 1);
            champs.Add(ID);
        }

        public Entité(Point location, Size size, Color couleurBordure, int épaisseur) : base(location, size, couleurBordure, épaisseur)
        {
            texte = "Entité";
            Champ ID = new Champ("ID", typeof(Int16), 0, true, false, true, 1);
            champs.Add(ID);
        }

        public List<Champ> Champs
        {
            get { return champs; }
            set { champs = value; }
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
            Font policeID = new Font(police.FontFamily, fontSize, FontStyle.Underline);
            #endregion
            CalculTaille(police,graphics,zoom);
            rectAffichage = RectangleAffichage(zoom, origin, origineZoom);
            graphics.FillRectangle(new SolidBrush(CouleurFond), rectAffichage);
            graphics.DrawRectangle(p, rectAffichage);
            Brush br = new SolidBrush(couleurPolice);
            
            //if ((texte != null) && (texte != ""))
            int ligne = 0;
            graphics.DrawString(texte, police, br, PositionText(zoom, origin, origineZoom,ligne));

            //calcul de la largeur pour pouvoir dessiner le trait
            SizeF size = graphics.MeasureString(Texte, police);




            graphics.DrawLine(p, new Point(rectangle.X, rectangle.Y + 18), new Point(rectangle.X + (int)size.Width + 3, rectangle.Y + 18));

            foreach (Champ c in champs)
            {
                ligne++;
                if (c.CléPrimaire)
                    graphics.DrawString(c.ToString(), policeID, br, PositionText(zoom, origin, origineZoom, ligne));
                else
                    graphics.DrawString(c.ToString(), police, br, PositionText(zoom, origin, origineZoom, ligne));
            }
        }
    }
}
