namespace TP2Prog;

public class GestionVisiteurs
{
    private Parc _parc;
    private Visiteur _visiteur = new Visiteur("Visiteur test");
    private LinkedList<Visiteur> _listeVisiteurs = new LinkedList<Visiteur>();
    private Dictionary<string, int> _listeNbVisiteursParAttraction = new Dictionary<string, int>();

    public GestionVisiteurs(Parc parc)
    {
        _parc = parc;
        foreach (var attraction in _parc.getAttractions)
        {
            _listeNbVisiteursParAttraction.Add(attraction.GetId, 0);
        }
    }

    public LinkedList<Visiteur>  getListeVisiteurs => _listeVisiteurs;
    public int getNbVisiteursParAttraction(string id)
    {
        return _listeNbVisiteursParAttraction[id];
    }

    public void EntrerVisiteurDansFilAttente(string id, Visiteur visiteur)
    {
        _listeNbVisiteursParAttraction[id]++; // incremente ou stock le nb de visiteur (valeur) par id de l'attraction (clé)
        visiteur.SetAttractionDuVisiteur(visiteur, id); // donne le visiteur (clé) avec l'attraction qu'il visite live (valeur)
        visiteur.GetListeActions().AddLast($"Entrer dans la file d'attente de l'attraction {id}");
    }

    public void EntrerVisiteurDansAttraction(string id)
    {
        _visiteur.GetListeActions().AddLast($"Entrer dans l'attraction {id}");
    }

    public void EntrerVisiteurDansParc(Visiteur visiteur)
    {
        _listeVisiteurs.AddLast(visiteur);
        visiteur.GetListeActions().AddLast("Entrer dans le parc");
    }

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
