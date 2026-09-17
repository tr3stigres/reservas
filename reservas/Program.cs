class Program
{
    public static void Main()
    {
        Iniciar();
    }

    static void Iniciar()
    {

        //control edat
        bool repetirPregunta = true;
        int edat = 0;
        while (repetirPregunta)
        {
            Console.Write("Quina es l'edat del grup? ");
            string? edatConsola = Console.ReadLine();
            if (!int.TryParse(edatConsola, out edat))
            {
                Console.WriteLine("L'edat ha de ser un número sencer");
            }
            else if (edat < 0 || edat > 120)
            {
                Console.WriteLine("L'edat ha de ser un número sencer entre 0 i 120");
            }
            else
            {
                repetirPregunta = false;
            }
        }

        //control quantitat
        repetirPregunta = true;
        int quantitat = 0;
        while (repetirPregunta)
        {
            Console.Write("Quina es la quantitat de persones? ");
            string? quantitatConsola = Console.ReadLine();
            if (!int.TryParse(quantitatConsola, out quantitat))
            {
                Console.WriteLine("La quantitat ha de ser un número sencer");
            }
            else if (quantitat < 1 || quantitat > 100)
            {
                Console.WriteLine("La quantitat ha de ser un número sencer entre 1 i 100");
            }
            else
            {
                repetirPregunta = false;
            }
        }

        //control preu per persona
        repetirPregunta = true;
        decimal preu = 0;
        while (repetirPregunta)
        {
            Console.Write("Quin es el preu per persona? ");
            string? preuConsola = Console.ReadLine();
            if (!decimal.TryParse(preuConsola, out preu))
            {
                Console.WriteLine("El preu ha de ser un número decimal");
            }
            else if (preu < 0 || preu > 10000)
            {
                Console.WriteLine("El preu ha de ser un número decimal entre 0 i 10000");
            }
            else
            {
                repetirPregunta = false;
            }
        }
        
        //promoció
        Console.Write("Si la teniu introduiu la vostra promoció: ");
        string? promoConsola = Console.ReadLine() ?? "";
        int? promo = null;

        if (promoConsola != null)
        {
            promo =  promoConsola.Trim().ToUpper() switch
            {
                "VERANO" => 5,
                _ => 0
            };

        }
        else
        {
            Console.WriteLine("Error desconegut");
            return;
        }

        //càlcul del preu base
        decimal preuFinal = preu * quantitat;

        //Si l'edat es menor a 12 anys s'aplica un descompte del 30%
        if (edat < 12)
            preuFinal = preuFinal - (preuFinal * 0.30m);

        //Si el grup el formen 5 o mes persones s'aplica un descompte del 10%
        if (quantitat >= 5)
            preuFinal = preuFinal - (preuFinal * 0.10m);

        //Si hi ha promo s'aplica el descompte corresponent
        if (promo > 0)
            preuFinal = preuFinal - (preuFinal * ((decimal)promo / 100));

        //mostrar preu
        Console.WriteLine($"El preu a pagar es de : {preuFinal:F2}");
    }

}
