
namespace TP2Prog;

public class Visiteur
{
    private string _nom;

    private LinkedList<string> _listeActions = new LinkedList<string>();


    public Visiteur(string nom)
    {
        this._nom = nom;
    }

    public LinkedList<string> GetListeActions()
    {
        return _listeActions;
    }


}
