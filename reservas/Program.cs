using static System.Net.Mime.MediaTypeNames;

class Program
{
    public static async Task Main()
    {
        Iniciar();
    }

    static void Iniciar()
    {
        //control edat
        Console.Write("Quina es l'edat del grup? ");
        string? edatConsola = Console.ReadLine();
        int edat = 0;

        if (edatConsola != null)
        {
            if (!int.TryParse(edatConsola, out edat))
            {
                Console.WriteLine("L'edat ha de ser un número sencer");
                return;
            }

            if (edat<0 || edat >120)
            {
                Console.WriteLine("L'edat ha de ser un número sencer entre 0 i 120");
                return;
            }
        }
        else
        {
            Console.WriteLine("Error desconegut");
            return;
        }

        //control quantitat
        Console.Write("Quina es la quantitat de persones? ");
        string? quantitatConsola = Console.ReadLine();
        int quantitat = 0;

        if (quantitatConsola != null)
        {
            if (!int.TryParse(quantitatConsola, out quantitat))
            {
                Console.WriteLine("La quantitat ha de ser un número sencer");
                return;
            }

            if (quantitat < 1 || quantitat > 100)
            {
                Console.WriteLine("La quantitat ha de ser un número sencer entre 1 i 100");
                return;
            }
        }
        else
        {
            Console.WriteLine("Error desconegut");
            return;
        }

        //preu per persona
        Console.Write("Quin es el preu per persona? ");
        string? preuConsola = Console.ReadLine();
        decimal preu = 0;

        if (preuConsola != null)
        {
            if (!decimal.TryParse(preuConsola, out preu))
            {
                Console.WriteLine("El preu ha de ser un número decimal");
                return;
            }

            if (preu < 1 || preu >= 10000)
            {
                Console.WriteLine("El preu ha de ser entre 1 i 10000");
                return;
            }
        }
        else
        {
            Console.WriteLine("Error desconegut");
            return;
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
        Console.WriteLine($"El preu a pagar es de : {preuFinal}");


    }

    

}
