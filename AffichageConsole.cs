namespace TP2Prog;

public class AffichageConsole
{
    //Trouver une facon de réduire la Notation Grand O de la méthode afficher pcq j'ai abuser
    public static void Afficher(Parc parc, Map map, GestionVisiteurs gestionVisiteurs)
    {
        for (int i = 0; i < map._hauteur; i++)
        {
            for (int j = 0; j < map._largeur; j++)
            {
                bool trouve = false;
                foreach (var attraction in map.GetAttractionsLocation)
                {
                    if (int.Parse(attraction[1]) == i && int.Parse(attraction[2]) == j)
                    {
                        foreach (var attr in parc.getAttractions)
                        {
                            if (attr._id == attraction[0])
                            {
                                ChangerCouleur(gestionVisiteurs, attr);
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
        Console.WriteLine($"\n{gestionVisiteurs.getListeVisiteurs.Count} visiteur(s) présent(s) dans le parc.\n");
        foreach (var attr in parc.getAttractions)
        {
            int visiteurs = gestionVisiteurs.getNbVisiteursParAttraction(attr._id);
            ChangerCouleur(gestionVisiteurs, attr);
            Console.Write("0");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"   {attr._id}{attr._nom, +15} ({attr._typeAttraction}){visiteurs, +10}/{attr._capacite}");
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

    private static void ChangerCouleur(GestionVisiteurs gestionVisiteurs, Attraction attr)
    {
        int visiteurs = gestionVisiteurs.getNbVisiteursParAttraction(attr._id);
        if (visiteurs / attr._capacite == 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        } else if (double.Parse(visiteurs.ToString()) / attr._capacite >= 0.75)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}
