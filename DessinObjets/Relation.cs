using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace DessinObjets
{
    public class Relation : Noeud
    {
        
        List<Champ> champs = new List<Champ>();
        Font policeChamp;

        public Relation(): base()
        {
            Champ ID = new Champ("ID", typeof(Int16), 0, true, false, true, 1);
            champs.Add(ID);
            policeChamp = new Font("Arial", 10);
        }

        public Relation(Point location, Size size, Color couleurBordure, int épaisseur) : base(location, size, couleurBordure, épaisseur)
        {
            Champ ID = new Champ("ID", typeof(Int16), 0, true, false, true, 1);
            champs.Add(ID);
            texte = "Relation";
            policeChamp = new Font("Arial", 10);
        }

        public Relation(Point location, Size size, Color couleurBordure, int épaisseur, DataTable table)
            : base(location, size, couleurBordure, épaisseur)
        {
            texte = table.TableName;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Champs.Add(new Champ(table.Columns[i].ColumnName, table.Columns[i].DataType, table.Columns[i].MaxLength, table.Columns[i].Unique, table.Columns[i].AutoIncrement, table.Columns[i].AllowDBNull, 0));
            }
            policeChamp = new Font("Arial", 10);
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
            SizeF nouvTaille;
            foreach (Champ c in champs)
            {
                nouvTaille = graphics.MeasureString(c.Nom, police);
                if (size.Width < nouvTaille.Width)
                    size.Width = nouvTaille.Width;
            }

            int lignes = champs.Count();

            taille = new Size((int)size.Width + 3, (lignes * 15) + (int)size.Height);
        }

        public Point PositionText(float zoom, Point origin, Point origineZoom, int ligne)
        {
            Point p = new Point(rectangle.X+origin.X, (ligne*15)+rectangle.Y+origin.Y);
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
            police = new Font(police.FontFamily, fontSize, FontStyle.Bold);

            float fontSizeChamp = policeChamp.Size * zoom;
            if (fontSizeChamp > 36)
                fontSizeChamp = 36;
            if (fontSizeChamp < 6)
                fontSizeChamp = 6;
            policeChamp = new Font(police.FontFamily, fontSizeChamp, FontStyle.Regular);

            Font policeID = new Font(police.FontFamily, fontSizeChamp, FontStyle.Underline);
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
                if (c.CléPrimaire)
                    graphics.DrawString(c.ToString(), policeID, br, PositionText(zoom, origin, origineZoom, ligne));                
                else
                    graphics.DrawString(c.ToString(), policeChamp, br, PositionText(zoom, origin, origineZoom, ligne));
                
            }
        }
    }
}
