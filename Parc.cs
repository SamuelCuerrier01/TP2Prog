namespace TP2Prog;

public class Parc
{
    private List<Attraction> _listeAttraction { get; } = [];

    public Parc()
    {
        File.ReadAllText("Fichiers/attractions.txt");
        foreach (var line in File.ReadAllLines("Fichiers/attractions.txt"))
        {
            string[] infosAttraction = line.Split(';');
            _listeAttraction.Add(new Attraction(infosAttraction[0],
                (TypeAttraction)Enum.Parse(typeof(TypeAttraction), infosAttraction[1]),
                infosAttraction[2],
                int.Parse(infosAttraction[3])));
        }
    }

    public Attraction RecupererAttraction(string id) =>
        _listeAttraction.First(a => a._id == id);
    public List<Attraction> getAttractions => _listeAttraction;
}
