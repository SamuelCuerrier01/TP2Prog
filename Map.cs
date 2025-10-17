// <copyright file="Map.cs" company="CSTJEAN">
// Samuel Cuerrier, Nicolas Savaria
// </copyright>
namespace TP2Prog;

/// <summary>
/// Classe Map qui comporte les informations sur la map d'un parc.
/// </summary>
public class Map
{
    private readonly List<string[]> _attractionsLocation;

    /// <summary>
    /// Constructeur.
    /// </summary>
    /// <param name="parc">Le parc qu'on veut afficher.</param>
    public Map(Parc parc)
    {
        _attractionsLocation = new List<string[]>();
        RecupererInfos();
    }

    /// <summary>
    /// Renvoit la largeur de la map.
    /// </summary>
    public int Largeur { get; private set; }

    /// <summary>
    /// Renvoit la hauteur de la map.
    /// </summary>
    public int Hauteur { get; private set; }

    /// <summary>
    /// Renvoit la liste des locations des attractions.
    /// </summary>
    public List<string[]> GetAttractionsLocation => _attractionsLocation;

    private void RecupererInfos()
    {
        string[] lignes = File.ReadAllLines("../../../Fichiers/map.txt");
        int index = 0;

        foreach (string ligne in lignes)
        {
            if (index == 0)
            {
                string[] dimensions = ligne.Split(";");
                Hauteur = int.Parse(dimensions[0]);
                Largeur = int.Parse(dimensions[1]);
            }

            string[] infosAttraction = ligne.Split("   ");
            int index2 = 0;
            foreach (string attraction in infosAttraction)
            {
                if (!attraction.Contains('-') && !attraction.Contains(';'))
                {
                    _attractionsLocation.Add([attraction, (index - 1).ToString(), index2.ToString()]);
                }

                index2++;
            }

            index++;
        }
    }
}
