namespace TP2Prog;

public class AffichageConsole
{
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

        foreach (var attraction in parc.getAttractions)
        {
            int visiteurs = gestionVisiteurs.getNbVisiteursParAttraction(attraction.GetId);
            Console.Write($"{attraction.GetId}   {attraction.GetType()}   {visiteurs}/{attraction.GetCapacite()}");
            Console.WriteLine();
        }
    }

    public static void AfficherHistoriqueVisiteur(Visiteur visiteur)
    {

    }
}
