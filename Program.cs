//TD10 d'algorithmique
//Nathan Choukroun
//Esilv A1S2
//TD N2

using System;

namespace TD10
{
    class Program
    {


        static int[,] initialisation_damier(int M, int N)
        {
            //initialise les cellules aléatoirement
            int[,] damier = null;

            if (M > 0 && N > 0)
            {
                damier = new int[M, N];

                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        int random = new Random().Next(0, 2);
                        damier[i, j] = random;
                    }
                }
            }

            return damier;
        }

        static void affiche_damier(int[,] damier)
        {
            // Affiche le damier
            if (damier != null && damier.Length != 0)
            {

                for (int i = 0; i < damier.GetLength(0); i++)
                {
                    for (int j = 0; j < damier.GetLength(1); j++)
                    {
                        if (damier[i, j] == 0)
                        {
                            Console.Write("–  ");
                        }
                        else
                        {
                            Console.Write("*  ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        static int nombre_voisins(int[,] damier, int i0, int j0)
        {
            //Renvoie le nombre de voisins vivant de la cellule (i0,j0)
            int nbVoisins = 0;
            /*
            if(i0==0 || j0 == 0)
            {
                if ((i0 == 0 && j0 == 0) || (i0 == 0 && j0 == damier.GetLength(1) - 1) || (i0 == damier.GetLength(0) - 1 && j0 == 0) || (i0 == damier.GetLength(0) - 1 && j0 == damier.GetLength(1) - 1))
                {
                    
                }
                else
                {

                }
            }*/
            
            //Valeur du bord haut sans les coins
            if(i0==0 && j0!=damier.GetLength(1)-1 && j0!=0)
            {
                if (damier[i0, j0-1] == 1)
                {
                    nbVoisins++;
                }
                if (damier[i0, j0+1] == 1)
                {
                    nbVoisins++;
                }

                for (int j = j0 - 1; j <= j0 + 1; j++)
                {
                    if (damier[j, i0 + 1] == 1)
                    {
                        nbVoisins++;
                    }
                }
            }
            //Valeur du bord bas sans les coins
            if (i0 == damier.GetLength(0)- 1 && j0 != damier.GetLength(1)-1 && j0 != 0)
            {
                if (damier[i0, j0 - 1] == 1)
                {
                    nbVoisins++;
                }
                if (damier[i0, j0 + 1] == 1)
                {
                    nbVoisins++;
                }

                for (int j = j0 - 1; j <= j0 + 1; j++)
                {
                    if (damier[j, i0 - 1] == 1)
                    {
                        nbVoisins++;
                    }
                }
            }
            




            //Valeur pour toutes les cases sauf les bords
            if (i0>0 && j0>0 && i0<damier.GetLength(0)-1 && j0 < damier.GetLength(1)-1)
            {

                if (damier[i0 - 1, j0] == 1)
                {
                    nbVoisins++;
                }
                if (damier[i0 + 1, j0] == 1)
                {
                    nbVoisins++;
                }

                for (int i=i0-1; i<=i0+1; i++)
                {
                    if (damier[i, j0 - 1] == 1)
                    {
                        nbVoisins++;
                    }
                    if (damier[i, j0 + 1] == 1)
                    {
                        nbVoisins++;
                    }
                }
            }


            return nbVoisins;
        }

        static int[,] generation_suivant(int[,] damier)
        {
            //retourne un nouveau tableau de la generation suivante
            int[,] gen = null;

            if (damier != null && damier.Length != 0)
            {
                gen = new int[damier.GetLength(0), damier.GetLength(1)];

                for (int i = 0; i < damier.GetLength(0); i++)
                {
                    for (int j = 0; j < damier.GetLength(1); j++)
                    {
                        gen[i, j] = damier[i, j];
                        if(damier[i, j]==1 && (nombre_voisins(damier,i,j)==2 || nombre_voisins(damier, i, j) == 3) )
                        {
                            gen[i, j] = 1;
                        }
                        if(damier[i,j]==1 && nombre_voisins(damier, i, j) < 2)
                        {
                            gen[i, j] = 0;
                        }
                        if(damier[i,j]==1 && nombre_voisins(damier, i, j) > 3)
                        {
                            gen[i, j] = 0;
                        }
                        if(damier[i,j]==0 && nombre_voisins(damier, i, j) == 3)
                        {
                            gen[i, j] = 1;
                        }

                    }
                }
            }


            return gen;
        }

        static void copie_damier(int[,] damier_cible, int[,] damier_source)
        {
            //Copie les cellule de demier_source vers damier_cible
            if (damier_cible != null && damier_cible.Length != 0 && damier_cible != null && damier_cible.Length != 0)
            {
                if (damier_cible.GetLength(0)==damier_source.GetLength(0) && damier_cible.GetLength(1) == damier_source.GetLength(1)) {
                    for (int i = 0; i < damier_cible.GetLength(0); i++)
                    {
                        for (int j = 0; j < damier_cible.GetLength(1); j++)
                        {
                            damier_cible[i, j] = damier_source[i, j];
                        }
                    } 
                }
            }
        }


        static void Main(string[] args)
        {

            int i = 0;
            int nbCycles = 0;

            //Saisir nb ligne
            Console.Write("Nombre de lignes : ");
            int ligne = -1;
            do
            {
                ligne = Convert.ToInt32(Console.ReadLine());
            } while (ligne <= 0);//if string =null


            // saisir nb colonne
            Console.Write("Nombre de colonnes : ");
            int colonne = -1;
            do
            {
                colonne = Convert.ToInt32(Console.ReadLine());
            } while (colonne <= 0);

            //déclarer la matrice

            //int[,] damier = initialisation_damier(ligne, colonne);

            //declarer nouvelle matrice

            //saisir le nombre de cycle
            Console.Write("Nombre de cycles : ");
            do
            {
                nbCycles = Convert.ToInt32(Console.ReadLine());
            } while (nbCycles <= 0);


            //initialisation du damier
            int[,] damier = initialisation_damier(ligne, colonne);


            while (i < nbCycles)
            {
                Console.Clear();

                //affichage du damier
                affiche_damier(damier);

                Console.WriteLine();
                //calcule de la generation suivante
                int[,] generation = generation_suivant(damier);

                //affiche_damier(generation);

                copie_damier(damier, generation);

                Console.ReadKey();
                
                i++;

            }




            //Console.ReadKey();
        }
    }
}
