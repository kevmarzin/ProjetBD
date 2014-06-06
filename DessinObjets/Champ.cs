using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DessinObjets
{
    public class Champ
    {
        private string nom;
        private Type type;
        private int taille;
        private bool clé_Primaire;
        private bool auto;
        private bool notNull;
        private int IndexChamp;

        public Champ(string nom_Champ, Type type_Champ, int taille_Champ, bool clé_Primaire_Champ, bool auto_Champ, bool notNull_Champ, int IndexChamp_Champ)
        {
            nom=nom_Champ;
            type=type_Champ;
            taille=taille_Champ;
            clé_Primaire=clé_Primaire_Champ;
            auto=auto_Champ;
            notNull=notNull_Champ;
            IndexChamp = IndexChamp_Champ;
        }
    }
}
