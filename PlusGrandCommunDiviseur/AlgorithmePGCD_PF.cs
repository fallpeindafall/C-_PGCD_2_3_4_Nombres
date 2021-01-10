using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PlusGrandCommunDiviseur
{
    static class AlgorithmePGCD_PF
    {
     
        static public int TrouverPGCD(int a, int b, out long dureeEuclide)
        {
            // Initialiser chrono
            dureeEuclide = 0;
            Stopwatch chrono = new Stopwatch();
            chrono.Start();

            // Si le premier nombre est égal à zéro, renvoyer le second
            if (a == 0) return b;
          
           
           
            while (b != 0)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            chrono.Stop();
            dureeEuclide = chrono.ElapsedTicks;
            return a;
        }

      /*  static public int TrouverPGCD3(int a, int b,int c)
        {

            int x = TrouverPGCD(a, b);
            return TrouverPGCD(x, c);
           
        }
        static public int TrouverPGCD4(int a, int b, int c,int e)
        {

            int x = TrouverPGCD3(a, b,c);
            return TrouverPGCD(x, e);

        }

        static public int TrouverPGCD5(int a, int b, int c, int e, int f)
        {

            int x = TrouverPGCD4(a, b, c, e);
            return TrouverPGCD(x, f);

        }*/


        //TASK 3
        static public int TrouverPGCDStein(int u,int v, out long dureeStein)
        {
            // Initialiser chrono
            dureeStein = 0;
            Stopwatch chrono = new Stopwatch();
            chrono.Start();

            int k;

            // Etape 1.
            // pgcd(0, v) = v, car tout  divise zéro, 
            // et v est le plus grand nombre qui divise v. 
            // Idem, pgcd(u, 0) = u. pgcd(0, 0) n'est pas habituellement défini 
            // mais il est commode de poser pgcd(0, 0) = 0.
            if (u == 0 || v == 0)
                return u | v;

            // Etape 2.
            // Si u et v sont tous deux pairs, alors pgcd(u, v) = 2•pgcd(u/2, v/2), 
            // car 2 est un  diviseur commun. 
            for (k = 0; ((u | v) & 1) == 0; ++k)
            {
                u >>= 1;
                v >>= 1;
            }

            // Etape 3.
            // Si u est pair et v est impair, alors pgcd(u, v) = pgcd(u/2, v), 
            // car 2 n'est pas un  diviseur commun. 
            // Idem, si u est impair et v pair, 
            // alors pgcd(u, v) = pgcd(u, v/2). 
            while ((u & 1) == 0)
                u >>= 1;

            // Etape 4.
            // If u et v sont tous impairs, et u ≥ v, 
            // alors pgcd(u, v) = pgcd((u − v)/2, v). 
            // If tous sont impairs et u < v, alors pgcd(u, v) = pgcd((v − u)/2, u). 
            // Voila les combinaisons en une Etape de   
            //  l'algorithme Euclidien simple, 
            // qui utilise la soustraction à chaque Etape, et une application 
            // de l'Etape 3 ci-dessus. 
            // La division par 2 tombe sur un entier car la 
            // difference de deux nombres impairs  est paire.
            do
            {
                while ((v & 1) == 0)  // Boucle x
                    v >>= 1;

                //  u et v sont tous impairs, alors diff(u, v) est pair.
                //   Soit u = min(u, v) et v = diff(u, v)/2. 
                if (u < v)
                {
                    v -= u;
                }
                else
                {
                    int diff = u - v;
                    u = v;
                    v = diff;
                }
                v >>= 1;
                // Etape 5.
                // Répéter les Etapes 3–4 jusqu'à ce que u = v, ou (Etape supplémentaire) 
                // jusqu'à ce que u = 0.
                // Quelque soit le cas, le résultat est (2^k) * v, où k est 
                // le nombre de facteurs communs  de 2 trouvé à l'Etape 2. 
            } while (v != 0);

            u <<= k;

            chrono.Stop();
            dureeStein = chrono.ElapsedTicks;
            return u;
        }
    }

}
