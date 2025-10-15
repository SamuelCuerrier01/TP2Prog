namespace TP2Prog;

public class Map
{
    public readonly List<string[]> _attractionsLocation;
    public int _largeur {get ; private set;}
    public int _hauteur {get ; private set;}

    public Map(Parc parc)
    {
        _attractionsLocation = new List<string[]>();
        RecupererInfos();
    }

    public List<string[]> GetAttractionsLocation => _attractionsLocation;

    private void RecupererInfos()
    {
        string[] lignes = File.ReadAllLines("../../../Fichiers/map.txt");
        int index = 0;

        foreach (string ligne in lignes)
        {
            if (index == 0)
            {
                string[] dimensions =ligne.Split(";");
                _hauteur = int.Parse(dimensions[0]);
                _largeur = int.Parse(dimensions[1]);
            }
            string[] infosAttraction = ligne.Split("   ");
            int index2 = 0;
            foreach (string attraction in infosAttraction)
            {
                if (!attraction.Contains('-') && !attraction.Contains(';'))
                {
                    _attractionsLocation.Add(new string[] {attraction, (index - 1).ToString(), index2.ToString()});
                }
                index2++;
            }
            index++;

        }
    }
}
