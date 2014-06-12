using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DessinObjets
{
    /// <summary>
    /// Classe destinée à simplifier les accès à la base de données
    /// </summary>
    public class AccèsSQL
    {

        OleDbConnection dbCon;

        public OleDbConnection DbCon
        {
            get { return dbCon; }
            set { dbCon = value; }
        }
        DataTableCollection Collectiontables;


        DataTable foreignKeys;
        string conStr;
        #region Propriétés
        public bool IsOpen { get { return dbCon.State == ConnectionState.Open; } }
        /// <summary>
        /// Chaine de connexion à la base de données
        /// </summary>
        public string ConnexionString
        {
            get { return conStr; }
            set { conStr = value; }
        }
        /// <summary>
        /// Liste des tables
        /// </summary>
        public DataTableCollection Tables
        {
            get { return Collectiontables; }
            set { Collectiontables = value; }
        }
        /// <summary>
        /// Liste des contraintes référentielles
        /// </summary>
        public DataTable ForeignKeys
        {
            get { return foreignKeys; }
            set { foreignKeys = value; }
        }
        #endregion
        /// <summary>
        /// Création d'un accès à la base de données et obtention de la liste des tables
        /// et des contraintes référentielles
        /// </summary>
        /// <param name="catalog">Nom de la base</param>
        public AccèsSQL(string catalog)
        {
            // conStr = @"Provider=SQLOLEDB;Data Source=INFO-SIMPLET;Initial Catalog=" + catalog + ";Integrated Security=SSPI";
            conStr = @"Provider=SQLOLEDB;Data Source=INFO-SIMPLET;Initial Catalog=" + catalog + ";Uid=ETD;Pwd=ETD";
            try
            {
                dbCon = new OleDbConnection(conStr);
                dbCon.Open();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Connexion impossible");
                return;
            }
            if (dbCon.State == ConnectionState.Open)
            {
                Collectiontables = GetTables(dbCon);
                foreignKeys = GetForeignKeys(dbCon);
            }
        }
        private DataTableCollection GetTables(OleDbConnection dbCon)
        {
            List<string> Tables = new List<string>();
            DataTable tables = dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            foreach (DataRow dt in tables.Rows)
            {
                Tables.Add((string)dt["TABLE_NAME"]);
            }
            DataSet baseDeDonnees = new DataSet();
            foreach (string tableName in Tables)
            {
                string SQL = "Select * from " + tableName;
                OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, dbCon);
                adapter.FillSchema(baseDeDonnees, SchemaType.Source, tableName);
            }
            return baseDeDonnees.Tables;
        }
        private DataTable GetForeignKeys(OleDbConnection dbCon)
        {
            return dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, new object[] { null, null, null, null });
        }
        /// <summary>
        /// Retourne la liste des tables
        /// </summary>
        /// <param name="script">Chaine de connexion à la base de données</param>
        /// <returns></returns>
        public void ExecuteCommand(string script)
        {
            if (script != "")
            {
                try
                {
                    OleDbConnection dbCon = new OleDbConnection(conStr);
                    dbCon.Open();
                    OleDbCommand dcCommand = new OleDbCommand(script, dbCon);
                    int success = dcCommand.ExecuteNonQuery();
                }
                catch { }
            }
        }
        /// <summary>
        /// Renvoie un lecteur associé à la requête
        /// </summary>
        /// <param name="query">Requête</param>
        /// <returns>Un lecteur de données</returns>
        public OleDbDataReader Lecteur(string query)
        {
            OleDbCommand cmd = new OleDbCommand(query, dbCon);
            return cmd.ExecuteReader();
        }
        private static List<object> FetchRow(string constr, string query)
        {
            OleDbConnection dbCon = new OleDbConnection(constr);
            dbCon.Open();
            OleDbCommand cmd = new OleDbCommand(query, dbCon);
            OleDbDataReader lecteur = cmd.ExecuteReader();
            List<object> ob = new List<object>();
            while (lecteur.Read())
            {
                #region lecture des données
                for (int i = 0; i < lecteur.VisibleFieldCount; i++)
                {
                    if (lecteur.IsDBNull(i))
                        ob.Add(null);
                    else
                    {
                        Type t = lecteur.GetFieldType(i);
                        switch (t.Name)
                        {
                            case "Byte[]":
                                long len = lecteur.GetBytes(i, 0, null, 0, 0);
                                byte[] im = new byte[len];
                                lecteur.GetBytes(i, 0, im, 0, (int)len);
                                ob.Add(im);
                                break;
                            case "Int16":
                                ob.Add(lecteur.GetInt16(i));
                                break;
                            case "Int32":
                                ob.Add(lecteur.GetInt32(i));
                                break;
                            case "Decimal":
                                ob.Add(lecteur.GetDecimal(i));
                                break;
                            case "String":
                                ob.Add(lecteur.GetString(i));
                                break;
                            default:
                                ob.Add(null);
                                break;
                        }
                    }
                }
                #endregion
            }
            return ob;
        }
        #region Méthodes statiques
        /// <summary>
        /// Retourne les instances SQL Server disponibles sur le réseau
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSQLServerInstances()
        {
            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            List<string> nomsServeurs = new List<string>();
            foreach (DataRow dr in servers.Rows)
            {
                nomsServeurs.Add((string)dr["ServerName"]);
            }
            return nomsServeurs;
        }
        /// <summary>
        /// Retourne la liste des bases de données disponibles sur un serveur
        /// </summary>
        /// <param name="conStr"></param>
        /// <returns></returns>
        public static List<string> GetDatabases(string conStr)
        {

            try
            {
                OleDbConnection dbCon = new OleDbConnection(conStr);
                dbCon.Open();
                DataTable database = dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Catalogs, null);
                List<string> db = new List<string>();
                foreach (DataRow dtr in database.Rows)
                {
                    db.Add((string)dtr.ItemArray[0]);
                }
                dbCon.Close();
                return db;
            }
            catch { return null; }
        }
        #endregion
    }

}