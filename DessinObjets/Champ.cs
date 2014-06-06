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
        private int indexChamp;

        public Champ()
        { }

        public Champ(string nom_Champ, Type type_Champ, int taille_Champ, bool clé_Primaire_Champ, bool auto_Champ, bool notNull_Champ, int indexChamp_Champ)
        {
            nom=nom_Champ;
            type=type_Champ;
            taille=taille_Champ;
            clé_Primaire=clé_Primaire_Champ;
            auto=auto_Champ;
            notNull=notNull_Champ;
            indexChamp = indexChamp_Champ;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public Type Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Taille
        {
            get { return taille; }
            set { taille = value; }
        }
        public bool CléPrimaire
        {
            get { return clé_Primaire; }
            set { clé_Primaire = value; }
        }
        public bool Auto
        {
            get { return auto; }
            set { auto = value; }
        }
        public bool NotNull
        {
            get { return notNull; }
            set { notNull = value; }
        }
        public int IndexChamp
        {
            get { return indexChamp; }
            set { indexChamp = value; }
        }
        /*
         * INUTILE FOR THE MOMENT
        public string TypetoString()
        {
            string s="";

           if(type== typeof(Byte))
               s="Byte";

           if(type== typeof(Byte[]))
               s="Byte[]";

           if(type== typeof(Decimal))
               s ="Decimal";

           if(type== typeof(DateTime))
               s = "Date Time";
           if(type== typeof(Int16))
               s ="Int16";
           if(type== typeof(Int32))
               s = "Int32";
           if(type== typeof(Single))
               s= "Single";
           if(type== typeof(String))
               s = "String";
            
            return s;
        }*/

        public string ToString()
        {
            string s="";
            s+=  nom;// +TypetoString();
            return s;
        }
    }
}
