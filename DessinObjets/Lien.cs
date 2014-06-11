using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DessinObjets
{
    public class Lien : Trait
    {
        string cardinalité;
        Font police;

        public Lien() : base()
        {
            police = new Font("Arial", 12);
        }

        public Lien(Noeud sour, Noeud dest, Color c, int e) : base(sour, dest, c, e)
        {
            police = new Font("Arial", 12);
        }

        public Lien(Noeud sour, Noeud dest, Color c, int e, string card) : base(sour, dest, c, e)
        {
            cardinalité = card;
            police = new Font("Arial", 12);
        }

        public string Cardinalité
        {
            get { return cardinalité; }
            set { cardinalité = value; }
        }
        
        public override void Dessine(Graphics graphics, float zoom, Point origin, Point origineZoom)
        {
            if (supprimé)
                return;

            base.Dessine(graphics, zoom, origin, origineZoom);

            #region Polices
            Pen p = new Pen(Color.Black);
            if (IsSelected)
                p = new Pen(Color.Red);
            float fontSize = police.Size * zoom;
            if (fontSize > 36)
                fontSize = 36;
            if (fontSize < 6)
                fontSize = 6;
            police = new Font(police.FontFamily, fontSize, FontStyle.Regular);
            #endregion
            
            Brush br = new SolidBrush(Color.Black);

            graphics.DrawString(cardinalité,new Font(police.FontFamily, fontSize, FontStyle.Regular), br, new Point(Math.Abs(débutTrait.X+finTrait.X)/2, Math.Abs(débutTrait.Y+finTrait.Y)/2));

        }
    }
}
