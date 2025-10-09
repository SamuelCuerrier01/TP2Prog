namespace TP2Prog;

public class Visiteur
{
    private string _nom;

    private LinkedList<string> _listeActions = new LinkedList<string>();

    private Dictionary<Visiteur, string> _attractionDuVisiteur = new Dictionary<Visiteur, string>();

    public Visiteur(string nom)
    {
        this._nom = nom;
    }

    public LinkedList<string> GetListeActions()
    {
        return _listeActions;
    }

    public Dictionary<Visiteur, string> GetAttractionDuVisiteur()
    {
        return _attractionDuVisiteur;
    }

    public void SetAttractionDuVisiteur(Visiteur visiteur, string id)
    {
        _attractionDuVisiteur.Add(visiteur, id);
    }
}
