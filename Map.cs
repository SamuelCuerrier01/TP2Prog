namespace TP2Prog;

public class Map
{
    private Parc _parc;

    public Map(Parc parc)
    {
        _parc = parc;
    }

    public void afficherParc()
    {
        Console.WriteLine(_parc);
    }
}