namespace TP2Prog;

public class Map
{
    private Parc _parc;
    private List<string[]> attractionsLocation;
    private int largeur;
    private int hauteur;

    public Map(Parc parc)
    {
        _parc = parc;
        attractionsLocation = new List<string[]>();
        recupererInfos();
    }

    public void recupererInfos()
    {
        var lignes = File.ReadAllLines("../../../Fichiers/map.txt");
        int index = 0;

        foreach (var ligne in lignes)
        {
            if (index == 0)
            {
                string[] dimensions =ligne.Split(";");
                hauteur = int.Parse(dimensions[0]);
                largeur = int.Parse(dimensions[1]);
            }
            string[] infosAttraction = ligne.Split("   ");
            int index2 = 0;
            foreach (var attraction in infosAttraction)
            {
                if (!attraction.Contains('-') && !attraction.Contains(';'))
                {
                    attractionsLocation.Add(new string[] {attraction, (index - 1).ToString(), index2.ToString()});
                }
                index2++;
            }
            index++;

        }
    }

    public void chargerCarte()
    {
        for (int i = 0; i < hauteur; i++)
        {
            for (int j = 0; j < largeur; j++)
            {
                bool trouve = false;
                foreach (var attraction in attractionsLocation)
                {

                    if (int.Parse(attraction[1]) == i && int.Parse(attraction[2]) == j)
                    {
                        Console.Write(attraction[0] + "   ");
                        trouve = true;
                        break;
                    }
                }

                if (!trouve)
                {
                    Console.Write("-----   ");
                }
            }
            Console.WriteLine();
        }
    }
}
