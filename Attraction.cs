namespace TP2Prog;

public class Attraction
{
    public string _id { get; }
    public string _nom { get; }
    public int _capacite { get; }
    public TypeAttraction _typeAttraction { get; }

    public Attraction(string id, TypeAttraction typeAttraction, string nom, int capacite)
    {
        _id = id;
        _nom = nom;
        _capacite = capacite;
        _typeAttraction = typeAttraction;
    }
}
