class Program
{
    public static void Main()
    {        
        int edat = PreguntaInt("Quina es l'edat del grup?", 0, 120);
        int quantitat = PreguntaInt("Quina es la quantitat de persones?", 1, 100);
        decimal preu = DemanarPreuXPersona();
        string promoConsola = DemanarPromocio();
        decimal preuFinal = CalculPreu(edat, quantitat, preu, promoConsola);
        MostrarPreu(preuFinal);
    }

    static int PreguntaInt(string pregunta, int minim, int maxim)
    {
        int resultat = 0;

        do
        {
            Console.Write($"{pregunta} ");
            string? resposta = Console.ReadLine();
            if (!int.TryParse(resposta, out resultat))
            {
                Console.WriteLine("La resposta ha de ser un número sencer");
                continue;
            }
            else if (resultat < minim || resultat > maxim)
            {
                Console.WriteLine($"L'edat ha de ser un número sencer entre {minim} i {maxim}");
                continue;
            }

            break;

        } while (true);

        return resultat;
    }

    static decimal DemanarPreuXPersona()
    {
        decimal preu = 0;
        do
        {
            Console.Write("Quin es el preu per persona? ");
            string? preuConsola = Console.ReadLine();
            if (!decimal.TryParse(preuConsola, out preu))
            {
                Console.WriteLine("El preu ha de ser un número decimal");
                continue;
            }
            else if (preu < 0 || preu > 10000)
            {
                Console.WriteLine("El preu ha de ser un número decimal entre 0 i 10000");
                continue;
            }
            break;

        } while (true);

        return preu;
    }

    static string DemanarPromocio()
    {
        Console.Write("Si la teniu introduiu la vostra promoció: ");
        string? promoConsola = Console.ReadLine() ?? "";        

        if (promoConsola == null)
            return "";
        
        return promoConsola;
    }

    static decimal CalculPreu(int edat, int quantitat, decimal preu, string promoConsola)
    {
        
        //càlcul del preu base
        decimal preuFinal = preu * quantitat;

        //Si l'edat es menor a 12 anys s'aplica un descompte del 30%
        if (edat < 12)
            preuFinal = preuFinal - (preuFinal * 0.30m);

        //Si el grup el formen 5 o mes persones s'aplica un descompte del 10%
        if (quantitat >= 5)
            preuFinal = preuFinal - (preuFinal * 0.10m);

        //Si hi ha promo s'aplica el descompte corresponent
        int promo = promoConsola.Trim().ToUpper() switch
        {
            "VERANO" => 5,
            _ => 0
        };
        if (promo > 0)
            preuFinal = preuFinal - (preuFinal * ((decimal)promo / 100));

        return preuFinal;

    }

    static void MostrarPreu(decimal preuFinal)
    {
        Console.WriteLine($"El preu a pagar es de : {preuFinal:F2}");
    }

}
