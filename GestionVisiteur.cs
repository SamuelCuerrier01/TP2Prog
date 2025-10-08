namespace TP2Prog;

public class GestionVisiteur
{
    private Parc parc;
    private Visiteur visiteur;

    public void EntrerVisiteurDansFileAttente(string id, Visiteur visiteur)
    {

        visiteur.GetListeActions().AddFirst($"Entrer dans la file d'attente de l'attraction {parc.RecupererAttraction(id).GetId()}");
    }

    public void EntrerVisiteurDansAttraction(string id)
    {

        visiteur.GetListeActions().AddFirst($"Entrer dans l'attraction {parc.RecupererAttraction(id).GetId()}");
    }

    public void EntrerVisiteurDansParc(Visiteur visiteur)
    {
        visiteur.GetListeActions().AddFirst("Entrer dans le parc");
    }
    public void SortirVisiteurDansParc(Visiteur visiteur)
    {
        visiteur.GetListeActions().AddFirst("Sortir du parc");
    }

}
