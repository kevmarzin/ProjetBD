using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DessinObjets
{
    public class Relation : Noeud
    {
        
        List<Champ> champs = new List<Champ>();

        public Relation(): base()
        {}

        public Relation(Point location, Size size, Color couleurBordure, int épaisseur) : base(location, size, couleurBordure, épaisseur)
        {
            texte = "Relation";
        }

        public List<Champ> Champs
        {
            get { return champs; }
            set { champs = value; }
        }
        
        public void CalculTaille(Font police, Graphics graphics, float zoom)
        {
            //calcul de la taille du dessin
            SizeF size = graphics.MeasureString(Texte, police);
            
            int lignes=champs.Count();

            taille = new Size((int)size.Width + 3, (lignes*15)+(int)size.Height);           
        }

        public Point PositionText(float zoom, Point origin, Point origineZoom, int ligne)
        {
            Point p= new Point(rectangle.X, (ligne*15)+rectangle.Y);
            return p;
        }

        public override void Dessine(Graphics graphics, float zoom, Point origin, Point origineZoom)
        {
          /*  if (supprimé)
                return;*/
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
            graphics.DrawRectangle(p, rectAffichage);
            Brush br = new SolidBrush(couleurPolice);
            
            //if ((texte != null) && (texte != ""))
            int ligne = 0;
            graphics.DrawString(texte, police, br, PositionText(zoom, origin, origineZoom,ligne));
                
            foreach (Champ c in champs)
            {
                ligne++;                
                graphics.DrawString(c.ToString(), police, br, PositionText(zoom, origin, origineZoom, ligne));
            }
        }
    }
}
