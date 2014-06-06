using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DessinObjets
{
    /// <summary>
    /// Casse construisant un type à partir d'une relation
    /// </summary>
    public class ConstructeurType
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="relation">Nom de la relation</param>
        /// <returns></returns>
        public static Type Construit(DataTable relation)
        {
            AppDomain domaineCourant = Thread.GetDomain();
            AssemblyName nomAssembly = new AssemblyName();
            nomAssembly.Name = relation.TableName;
            AssemblyBuilder contructeurAssembly = domaineCourant.DefineDynamicAssembly(nomAssembly, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder constructeurModule = contructeurAssembly.DefineDynamicModule(relation.TableName + "Module", relation.TableName + ".dll");
            #region Création du type, des attributs et des propriétés
            TypeBuilder constructeurDeType = constructeurModule.DefineType(relation.TableName, TypeAttributes.Public);
            FieldBuilder clé = null;
            List<FieldBuilder> constructeurDeChamps = new List<FieldBuilder>();
            foreach (DataColumn colonne in relation.Columns)
            {
                FieldBuilder champ = CréeAttributs(constructeurDeType, colonne);
                constructeurDeChamps.Add(champ);
                if (colonne.Unique)
                    clé = champ;
            }
            if (clé == null)
                clé = constructeurDeChamps[0];
            #endregion
            CréationConstructeur(constructeurDeType, clé);
            return constructeurDeType.CreateType();
        }
        private static FieldBuilder CréeAttributs(TypeBuilder constructeurDeType, DataColumn colonne)
        {
            FieldBuilder champBldr = null;
            PropertyBuilder constructeurPropriété;
            #region Création de l'attribut
            champBldr = constructeurDeType.DefineField(colonne.ColumnName.ToLower(), colonne.DataType, FieldAttributes.Private);
            #endregion
            #region Création de la Propriété associée
            constructeurPropriété = constructeurDeType.DefineProperty(colonne.ColumnName, System.Reflection.PropertyAttributes.HasDefault, colonne.DataType, null);
            // Choix des attributs
            MethodAttributes attrGetSet = MethodAttributes.Public |
               MethodAttributes.SpecialName | MethodAttributes.HideBySig;
            #region Définition du "getter".
            MethodBuilder constructeurGet = constructeurDeType.DefineMethod("get_" + colonne.ColumnName, attrGetSet, colonne.DataType, Type.EmptyTypes);
            ILGenerator champGetIL = constructeurGet.GetILGenerator();
            champGetIL.Emit(OpCodes.Ldarg_0);
            champGetIL.Emit(OpCodes.Ldfld, champBldr);
            champGetIL.Emit(OpCodes.Ret);
            #endregion
            #region Définition du "setter".
            MethodBuilder constructeurSet = constructeurDeType.DefineMethod("set_" + colonne.ColumnName, attrGetSet, null, new Type[] { colonne.DataType });
            ILGenerator champSetIL = constructeurSet.GetILGenerator();
            champSetIL.Emit(OpCodes.Ldarg_0);
            champSetIL.Emit(OpCodes.Ldarg_1);
            champSetIL.Emit(OpCodes.Stfld, champBldr);
            champSetIL.Emit(OpCodes.Ret);
            #endregion
            #region Association des accesseurs à la propriété
            constructeurPropriété.SetGetMethod(constructeurGet);
            constructeurPropriété.SetSetMethod(constructeurSet);
            #endregion
            #endregion
            return champBldr;
        }
        private static void CréationConstructeur(TypeBuilder constructeurDeType, FieldBuilder clé)
        {
            #region création d'un constructeur simple portant sur une clé (le premier champ)
            Type objType = Type.GetType("System.Object");
            Type[] ctorParams = new Type[] { typeof(int) };
            ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);
            ConstructorBuilder constructeurConstructeur = constructeurDeType.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, ctorParams);
            ILGenerator générateurIL = constructeurConstructeur.GetILGenerator();
            générateurIL.Emit(OpCodes.Ldarg_0);
            générateurIL.Emit(OpCodes.Call, objCtor);
            générateurIL.Emit(OpCodes.Ldarg_0);
            générateurIL.Emit(OpCodes.Ldarg_1);
            générateurIL.Emit(OpCodes.Stfld, clé);
            générateurIL.Emit(OpCodes.Ret);
            #endregion
        }
    }
}
