using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class Sorteio
{
    static Random _random = new Random();//Modudo do random, configurado para misturar os times

    public static void Shuffle<T>(T[] Array)
    {
        var random = _random;
        for(int i = Array.Length; i > 1; i--)
        {
            int j = random.Next(i);
            T tmp = Array[j];
            Array[j] = Array[i - 1];
            Array[i - 1] = tmp;
        }
    }
    public static void Main()
    {
        string[] jogadores = new string[10];
        
        Console.Write("\n\nGerador de Times:\n");
        Console.Write("--------------------------------------\n");
        Console.Write("Insira os nomes dos jogadores a seguir:\n");
        for (int i=0;i<10;i++)
        {
            Console.Write("Jogador {0} : ", i);
            jogadores[i] = Convert.ToString(Console.ReadLine());
        }
        Console.Write("\nJogadores registrados : ");
        for(int i=0; i < 10; i++)
        {
            Console.Write("{0} ", jogadores[i]);
        }
        Console.Write("\n");
        Shuffle(jogadores);

        string[] items = Enumerable.Range(1, 10).Select(i => "Time" + i).ToArray();

        string[][] chunks = jogadores
                            .Select((s, i) => new { Value = s, Index = i })
                            .GroupBy(x => x.Index / 5)
                            .Select(grp => grp.Select(x => x.Value).ToArray())
                            .ToArray();



        for (int i = 0; i < chunks.Length; i++)
        {
            foreach (var item in chunks[i])
                Console.WriteLine("Time: {0} {1}", i, item);
        }





        Console.ReadLine();
    }
    
    
}
