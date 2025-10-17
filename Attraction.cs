// <copyright file="Attraction.cs" company="CSTJEAN">
// Samuel Cuerrier, Nicolas Savaria
// </copyright>
namespace TP2Prog;

/// <summary>
/// Classe Attraction qui comporte les informations sur un attraction du parc.
/// </summary>
public class Attraction
{
    /// <summary>
    /// Constructeur.
    /// </summary>
    /// <param name="id">Le id de l'attraction.</param>
    /// <param name="typeAttraction">Le type de l'attraction.</param>
    /// <param name="nom">Le nom de l'attraction.</param>
    /// <param name="capacite">La capacite de l'attraction.</param>
    public Attraction(string id, TypeAttraction typeAttraction, string nom, int capacite)
    {
        Id = id;
        Nom = nom;
        Capacite = capacite;
        TypeAttraction = typeAttraction;
    }

    /// <summary>
    /// Le id de l'attraction.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Le nom de l'attraction.
    /// </summary>
    public string Nom { get; }

    /// <summary>
    /// La capactie total de l'attraction.
    /// </summary>
    public int Capacite { get; }

    /// <summary>
    /// Le type de l'attraction.
    /// </summary>
    public TypeAttraction TypeAttraction { get; }
}
