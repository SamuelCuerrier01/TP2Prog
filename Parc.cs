// <copyright file="Parc.cs" company="CSTJEAN">
// Samuel Cuerrier, Nicolas Savaria
// </copyright>
namespace TP2Prog;

/// <summary>
/// Classe Parc qui comporte les informations sur un parc.
/// </summary>
public class Parc
{
    /// <summary>
    /// Constructeur.
    /// </summary>
    public Parc()
    {
        File.ReadAllText("Fichiers/attractions.txt");
        foreach (var line in File.ReadAllLines("Fichiers/attractions.txt"))
        {
            string[] infosAttraction = line.Split(';');
            ListeAttraction.Add(new Attraction(infosAttraction[0],
                (TypeAttraction)Enum.Parse(typeof(TypeAttraction), infosAttraction[1]),
                infosAttraction[2],
                int.Parse(infosAttraction[3])));
        }
    }

    /// <summary>
    /// Retourne la liste des attractions dans le parc.
    /// </summary>
    public List<Attraction> GetAttractions => ListeAttraction;

    private List<Attraction> ListeAttraction { get; } = [];

    /// <summary>
    /// Constructeur.
    /// </summary>
    /// <param name="id">Le id de l'attraction qu'on veut recuperer.</param>
    /// <returns>Retourne l'attraction qu'on souhaite recuperer.</returns>
    public Attraction RecupererAttraction(string id) => ListeAttraction.First(a => a.Id == id);
}
