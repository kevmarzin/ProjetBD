﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DessinObjets
{
    public class Contrainte : Trait
    {
        string nom;
        Champ champSource = new Champ();
        Champ champDestination = new Champ();

        public Contrainte() : base()
        { }
        public Contrainte(Noeud sour, Noeud dest, Color c, int e) : base(sour, dest, c, e)
        { }

        public Contrainte(Noeud sour, Noeud dest, Color c, int e, Champ cS, Champ cD)
            : base(sour, dest, c, e)
        {
            champSource = cS;
            champDestination = cD;
        }

        public string Nom
        {
            get {return nom;}
            set {nom = value;}
        }
        public Champ ChampSource
        {
            get { return champSource; }
            set { champSource = value; }
        }
        public Champ ChampDestination
        {
            get { return champDestination; }
            set { champDestination = value; }
        }

    }
}
