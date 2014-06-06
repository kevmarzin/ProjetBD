using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DessinObjets
{
    /// <summary>
    /// Interface pour les objets pouvant être supprimés
    /// </summary>
    public interface ISupprimable
    {
        /// <summary>
        /// Méthode de suppression
        /// </summary>
        void Supprime();
        /// <summary>
        /// Méthode de restauration
        /// </summary>
        void Restaure();
        /// <summary>
        /// Restauration des paramètres
        /// </summary>
        /// <param name="obj">Données à restaurer</param>
        void RestaureParams(ISupprimable obj);
    }
    /// <summary>
    /// Classe formalisant les actions
    /// /// </summary>
    public class Action
    {
        Type_Action type_action;
        List<Object> objets;
        List<Action> actions_dépendantes;
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="type">Type d'action</param>
        /// <param name="objets">Liste de paramètres</param>
        public Action(Type_Action type, List<Object> objets)
        {
            type_action = type;
            this.objets = objets;
            actions_dépendantes = new List<Action>();
        }
        /// <summary>
        /// Ajout des sous actions dépendant de l'action principale
        /// </summary>
        /// <param name="ac"></param>
        public void AddSubAction(Action ac)
        {
            actions_dépendantes.Add(ac);
        }
        /// <summary>
        /// Méthode Undo
        /// </summary>
        public void Undo()
        {
            switch (type_action)
            {
                case Type_Action.Détruire:
                    ((ISupprimable)objets[0]).Restaure();
                    foreach (Action ac in actions_dépendantes)
                        ac.Undo();
                    break;
                case Type_Action.Créer:
                    ((ISupprimable)objets[0]).Supprime();
                    foreach (Action ac in actions_dépendantes)
                        ac.Undo();
                    break;
                case Type_Action.Déplacer:
                    ((Noeud)objets[0]).Déplace((Point)objets[1]);
                    break;
                case Type_Action.EnBloc:
                    if (objets.Count == 0)
                    {
                        foreach (Action ac in actions_dépendantes)
                            ac.Undo();
                    }
                    else
                    {
                       Point donnée = (Point)objets[1];
                        Point offset = new Point(-donnée.X, -donnée.Y);
                        ((Noeud)objets[0]).DéplaceVers(offset);
                    }
                    break;
                case Type_Action.Paramètres:
                    ((ISupprimable)objets[0]).RestaureParams((ISupprimable)objets[1]);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Méthode Redo
        /// </summary>
        public void Redo()
        {
            switch (type_action)
            {
                case Type_Action.Détruire:
                    ((ISupprimable)objets[0]).Supprime();
                    foreach (Action ac in actions_dépendantes)
                        ac.Redo();
                    break;
                case Type_Action.Créer:
                    ((ISupprimable)objets[0]).Restaure();
                    foreach (Action ac in actions_dépendantes)
                        ac.Redo();
                    break;
                case Type_Action.Déplacer:
                    ((Noeud)objets[0]).Déplace((Point)objets[2]);
                    break;
                case Type_Action.EnBloc:
                    if (objets.Count == 0)
                    {
                        foreach (Action ac in actions_dépendantes)
                            ac.Redo();
                    }
                    else
                    {
                        Point donnée = (Point)objets[1];
                        Point offset = new Point(donnée.X, donnée.Y);
                        ((Noeud)objets[0]).DéplaceVers(offset);
                    }
                    break;
                case Type_Action.Paramètres:
                    ((ISupprimable)objets[0]).RestaureParams((ISupprimable)objets[2]);
                   break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// Type d'action disponible pour le undo redo
    /// </summary>
    public enum Type_Action
    {
        /// <summary>
        /// Création d'un objet
        /// </summary>
        Créer,
        /// <summary>
        /// Suppression d'un objet
        /// </summary>
        Détruire,
        /// <summary>
        /// Déplacement d'un noeud
        /// </summary>
        Déplacer,
        /// <summary>
        /// Mouvement en bloc
        /// </summary>
        EnBloc,
        /// <summary>
        /// Modification des paramètres
        /// </summary>
        Paramètres
    }
}