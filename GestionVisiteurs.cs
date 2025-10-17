// <copyright file="GestionVisiteurs.cs" company="CSTJEAN">
// Samuel Cuerrier, Nicolas Savaria
// </copyright>
namespace TP2Prog;

/// <summary>
/// Classe GestionVisiteurs qui comporte les methodes qui gerent les visiteurs d'un parc.
/// </summary>
public class GestionVisiteurs
{
    private Visiteur _visiteur = new Visiteur("Visiteur test");
    private LinkedList<Visiteur> _listeVisiteurs = new LinkedList<Visiteur>();
    private Dictionary<string, int> _listeNbVisiteursParAttraction = new Dictionary<string, int>();

    /// <summary>
    /// Constructeur.
    /// </summary>
    /// <param name="parc">Le parc qu'on veut gerer.</param>
    public GestionVisiteurs(Parc parc)
    {
        foreach (var attraction in parc.GetAttractions)
        {
            _listeNbVisiteursParAttraction.Add(attraction.Id, 0);
        }
    }

    /// <summary>
    /// Renvoit la liste des visiteurs.
    /// </summary>
    public LinkedList<Visiteur> GetListeVisiteurs => _listeVisiteurs;

    /// <summary>
    /// Methode pour savoir le nb de visiteurs d'un attraction dans sa file .
    /// </summary>
    /// <param name="id">Le id de l'attraction qu'on desire.</param>
    /// <returns>Retourne le nb de visiteurs dans la file d'un attraction.</returns>
    public int GetNbVisiteursParAttraction(string id)
    {
        return _listeNbVisiteursParAttraction[id];
    }

    /// <summary>
    /// Methode pour rentrer un visiteur dans la file d'un attraction desiré.
    /// </summary>
    /// <param name="id">Le id de l'attraction qu'on desire.</param>
    /// <param name="visiteur">Le visiteur qu'on souhaite rentrer dans la file.</param>
    public void EntrerVisiteurDansFilAttente(string id, Visiteur visiteur)
    {
        _listeNbVisiteursParAttraction[id]++; // incremente ou stock le nb de visiteur (valeur) par id de l'attraction (clé)
        visiteur.SetAttractionDuVisiteur(visiteur, id); // donne le visiteur (clé) avec l'attraction qu'il visite live (valeur)
        visiteur.GetListeActions().AddLast($"Entrer dans la file d'attente de l'attraction {id}");
    }

    /// <summary>
    /// Methode pour rentrer un visiteur un attraction.
    /// </summary>
    /// <param name="id">Le id de l'attraction qu'on desire.</param>
    public void EntrerVisiteurDansAttraction(string id)
    {
        _visiteur.GetListeActions().AddLast($"Entrer dans l'attraction {id}");
    }

    /// <summary>
    /// Methode pour rentrer un visiteur le parc.
    /// </summary>
    /// <param name="visiteur">Le visiteur qu'on veut faire rentrer dans le parc.</param>
    public void EntrerVisiteurDansParc(Visiteur visiteur)
    {
        _listeVisiteurs.AddLast(visiteur);
        visiteur.GetListeActions().AddLast("Entrer dans le parc");
    }

    /// <summary>
    /// Methode pour sortir un visiteur du parc.
    /// </summary>
    /// <param name="visiteur">Le visiteur qu'on veut sortir du parc.</param>
    public void SortirVisiteurDuParc(Visiteur visiteur)
    {
        if (visiteur.GetAttractionDuVisiteur().ContainsKey(visiteur))
        {
            _listeNbVisiteursParAttraction[visiteur.GetAttractionDuVisiteur()[visiteur]]--; // si ce visiteur etais dans une file,

                                                                                            // on le remove du nb visiteur (file d'attente de cet attraction) en plus
        }

        _listeVisiteurs.Remove(visiteur);
        visiteur.GetListeActions().AddLast("Sortir du parc");
    }
}
