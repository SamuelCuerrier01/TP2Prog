namespace TP2Prog;

public class AffichageConsole
{
    //Trouver une facon de réduire la Notation Grand O de la méthode afficher pcq j'ai abuser
    public static void Afficher(Parc parc, Map map, GestionVisiteurs gestionVisiteurs)
    {
        for (int i = 0; i < map.getHauteur; i++)
        {
            for (int j = 0; j < map.getLargeur; j++)
            {
                bool trouve = false;
                foreach (var attraction in map.getAttractionsLocation)
                {
                    if (int.Parse(attraction[1]) == i && int.Parse(attraction[2]) == j)
                    {
                        foreach (var attr in parc.getAttractions)
                        {
                            if (attr.GetId == attraction[0])
                            {
                                changerCouleur(gestionVisiteurs, attr);
                                Console.Write(attraction[0] + "   ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
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

        int nbAttraction = 1;
        int nbToilette = 1;
        int nbMagasin = 1;
        int nbRestaurant = 1;
        Console.WriteLine($"\n{gestionVisiteurs.getListeVisiteurs.Count} visiteur(s) présent(s) dans le parc.\n");
        foreach (var attr in parc.getAttractions)
        {
            int visiteurs = gestionVisiteurs.getNbVisiteursParAttraction(attr.GetId);
            changerCouleur(gestionVisiteurs, attr);
            string nomAttraction = "";
            switch (attr.GetTypeAttraction)
            {
                case TypeAttraction.S:
                    nomAttraction = $"Manège {nbAttraction}";
                    nbAttraction++;
                    break;
                case TypeAttraction.I:
                    nomAttraction = $"Manège {nbAttraction}";
                    nbAttraction++;
                    break;
                case TypeAttraction.F:
                    nomAttraction = $"Manège {nbAttraction}";
                    nbAttraction++;
                    break;
                case TypeAttraction.T:
                    nomAttraction = $"Manège {nbToilette}";
                    nbToilette++;
                    break;
                case TypeAttraction.M:
                    nomAttraction = $"Magasin {nbMagasin}";
                    nbMagasin++;
                    break;
                case TypeAttraction.R:
                    nomAttraction = $"Restaurant {nbRestaurant}";
                    nbRestaurant++;
                    break;
            }
            Console.Write("0");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"   {attr.GetId}{nomAttraction, +15} ({attr.GetTypeAttraction}){visiteurs, +10}/{attr.GetCapacite}");
            Console.WriteLine();
        }
    }

    public static void AfficherHistoriqueVisiteur(Visiteur visiteur)
    {
        Console.WriteLine($"\n### {visiteur.getNom} ###");
        foreach (var action in visiteur.GetListeActions())
        {
            Console.WriteLine($"- {action}");
        }
    }

    private static void changerCouleur(GestionVisiteurs gestionVisiteurs, Attraction attr)
    {
        int visiteurs = gestionVisiteurs.getNbVisiteursParAttraction(attr.GetId);
        if (visiteurs / attr.GetCapacite == 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        } else if (double.Parse(visiteurs.ToString()) / attr.GetCapacite >= 0.75)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}
