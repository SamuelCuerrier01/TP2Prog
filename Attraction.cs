namespace TP2Prog;

public class Attraction
{
    private string _id;
    private string _nom;
    private int _capacite;
    private TypeAttraction _typeAttraction;

    public Attraction(string id, TypeAttraction typeAttraction, string nom, int capacite)
    {
        this._id = id;
        this._nom = nom;
        this._capacite = capacite;
        this._typeAttraction = typeAttraction;
    }

    public string GetId()
    {
        return _id;
    }

    public string GetNom()
    {
        return _nom;
    }

    public int GetCapacite()
    {
        return _capacite;
    }
}
