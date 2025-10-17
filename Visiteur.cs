// <copyright file="Visiteur.cs" company="CSTJEAN">
// Samuel Cuerrier, Nicolas Savaria
// </copyright>
namespace TP2Prog;

/// <summary>
/// Classe qui contient les informations sur un visiteur.
/// </summary>
public class Visiteur
{
    private string _nom;

    private LinkedList<string> _listeActions = new LinkedList<string>();

    private Dictionary<Visiteur, string> _attractionDuVisiteur = new Dictionary<Visiteur, string>();

    /// <summary>
    /// Constructeur.
    /// </summary>
    /// <param name="nom">Le nom du visiteur.</param>
    public Visiteur(string nom)
    {
        this._nom = nom;
    }

    /// <summary>
    /// Retourne le nom du visiteur.
    /// </summary>
    public string GetNom => _nom;

    /// <summary>
    /// Recuperer la liste des actions d'un visiteur.
    /// </summary>
    /// <returns>Retorune la liste des actions d'un visiteur.</returns>
    public LinkedList<string> GetListeActions()
    {
        return _listeActions;
    }

    /// <summary>
    /// Recuperer l'attraction auquel le visiteur visite au moment.
    /// </summary>
    /// <returns>Retorune l'attraction auquel le visiteur visite au moment.</returns>
    public Dictionary<Visiteur, string> GetAttractionDuVisiteur()
    {
        return _attractionDuVisiteur;
    }

    /// <summary>
    /// Assigner l'attraction au visiteur auqel il visite au moment.
    /// </summary>
    /// <param name="visiteur">Le visiteur qu'on veut assigner.</param>
    /// <param name="id">Le id de l'attraction qu'on veut lui assigner.</param>
    public void SetAttractionDuVisiteur(Visiteur visiteur, string id)
    {
        _attractionDuVisiteur.Add(visiteur, id);
    }
}
