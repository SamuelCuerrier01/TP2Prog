namespace TP2Prog;

public class Parc
{
    private List<Attraction> _listeAttraction;

    public Parc()
    {
        _listeAttraction = new List<Attraction>();
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

    public Attraction RecupererAttraction(string id)
    {
        foreach (var attraction in _listeAttraction)
        {
            if (attraction.GetId() == id)
            {
                return attraction;
            }
        }
        return null;
    }

    public void getAttractions()
    {
        foreach (var attraction in _listeAttraction)
        {
            Console.WriteLine($"{attraction.GetId()} {attraction.GetCapacite()} {attraction.GetNom()}");
        }
    }
}
