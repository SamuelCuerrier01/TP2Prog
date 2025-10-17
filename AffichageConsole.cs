// <copyright file="AffichageConsole.cs" company="CSTJEAN">
// Samuel Cuerrier, Nicolas Savaria
// </copyright>
namespace TP2Prog;

/// <summary>
/// Classe AfficherConsole qui comporte les methodes qui gèrent l'affichage de la map et l'historique des visiteurs.
/// </summary>
public class AffichageConsole
{
    /// <summary>
    /// Methode qui affiche la map et les attractions de celle-ci.
    /// </summary>
    /// <param name="parc">Le parc.</param>
    /// <param name="map">La map du parc.</param>
    /// <param name="gestionVisiteurs">La gestion des visiteurs.</param>
    public static void Afficher(Parc parc, Map map, GestionVisiteurs gestionVisiteurs) // Notation O(n3)
    {
        var attractionID = new Dictionary<string, Attraction>();

        foreach (var attraction in parc.GetAttractions)
        {
            attractionID[attraction.Id] = attraction;
        }

        for (int i = 0; i < map.Hauteur; i++)
        {
            for (int j = 0; j < map.Largeur; j++)
            {
                bool trouve = false;
                foreach (var attraction in map.GetAttractionsLocation)
                {
                    if (int.Parse(attraction[1]) == i && int.Parse(attraction[2]) == j)
                    {
                        if (attractionID.ContainsKey(attraction[0]))
                        {
                            var attract = attractionID[attraction[0]];
                            ChangerCouleur(gestionVisiteurs, attract);
                            Console.Write(attraction[0] + "   ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

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

        Console.WriteLine($"\n{gestionVisiteurs.GetListeVisiteurs.Count} visiteur(s) présent(s) dans le parc.\n");
        foreach (var attr in parc.GetAttractions)
        {
            int visiteurs = gestionVisiteurs.GetNbVisiteursParAttraction(attr.Id);
            ChangerCouleur(gestionVisiteurs, attr);
            Console.Write("0");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"   {attr.Id}{attr.Nom,+15} ({attr.TypeAttraction}){visiteurs,+10}/{attr.Capacite}");
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Methode qui affiche l'historique d'un visiteur.
    /// </summary>
    /// <param name="visiteur">Le visiteur qu'on cherche à voir l'historique.</param>
    public static void AfficherHistoriqueVisiteur(Visiteur visiteur)
    {
        Console.WriteLine($"\n### {visiteur.GetNom} ###");
        foreach (var action in visiteur.GetListeActions())
        {
            Console.WriteLine($"- {action}");
        }
    }

    private static void ChangerCouleur(GestionVisiteurs gestionVisiteurs, Attraction attr)
    {
        int visiteurs = gestionVisiteurs.GetNbVisiteursParAttraction(attr.Id);
        if (visiteurs / attr.Capacite == 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        else if (double.Parse(visiteurs.ToString()) / attr.Capacite >= 0.75)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}
