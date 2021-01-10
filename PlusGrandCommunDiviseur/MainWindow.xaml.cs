using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace PlusGrandCommunDiviseur
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        
        private void Calculer_PGCD_Click(object sender, RoutedEventArgs e)
        {

            if (!LireEntierPositifZoneTexte(entier1, out int premierNombre)) return;
            if (!LireEntierPositifZoneTexte(entier2, out int secondNombre)) return;
            if (!LireEntierPositifZoneTexte(entier3, out int troisiemeNombre)) return;
            if (!LireEntierPositifZoneTexte(entier4, out int quatriemeNombre)) return;
            if (!LireEntierPositifZoneTexte(entier5, out int cinquiemeNombre)) return;


            // Afficher les résultats 
            if (sender == trouverPGCD) // Euclide et Stein pour 2 entiers
            {
                // Appeler la méthode TrouverPGCD  et afficher le résultat

                this.resultatEuclide.Content = String.Format("Euclide: {0}, Durée (en ticks): {1}", AlgorithmePGCD_PF.TrouverPGCD(premierNombre, secondNombre, out long dureeEuclide), dureeEuclide);
                
                // Appeler la méthode TrouverPGCDStein et afficher le résultat
                
                this.resultatStein.Content = String.Format("Stein: {0}, Durée (en ticks): {1}", AlgorithmePGCD_PF.TrouverPGCDStein(premierNombre, secondNombre, out long dureeStein), dureeStein);

            }
            /* if (sender == trouverPGCD3) // Euclide pour 3 entiers
             {
                 // Appeler la méthode TrouverPGCD3  et afficher le résultat

                 this.resultatEuclide.Content = String.Format("Resultats: {0}", AlgorithmePGCD_PF.TrouverPGCD3(premierNombre, secondNombre, troisiemeNombre));
             }

             if (sender == trouverPGCD4) // Euclide pour 4 entiers
             {

                 // Appeler la méthode TrouverPGCD4   et afficher le résultat

                 this.resultatEuclide.Content = String.Format("Resultats: {0}", AlgorithmePGCD_PF.TrouverPGCD4(premierNombre, secondNombre, troisiemeNombre,quatriemeNombre));
             }


             if (sender == trouverPGCD5) // Euclide pour 5 entiers
             {

                 // Appeler la méthode TrouverPGCD5  et afficher le résultat

                 this.resultatEuclide.Content = String.Format("Resultats: {0}",AlgorithmePGCD_PF.TrouverPGCD5(premierNombre, secondNombre,troisiemeNombre, quatriemeNombre,cinquiemeNombre));
             }*/

        }

        /// <summary>
        /// Lire un entier postif  à partir d'une zone de texte
        /// Affiche une boite de message avec les données si le texte ne peut pas être parsé.
        /// </summary>
        /// <param name="zoneTexte">Textzone de texte à lire</param>
        /// <param name="i">entier Postif  (paramètre out)</param>
        /// <returns>True si succès, false sinon</returns>
        private bool LireEntierPositifZoneTexte(TextBox zoneTexte, out int i)
        {
            i = -1;
            if (int.TryParse(zoneTexte.Text, out i))
            {
                if (i >= 0) return true;
            }
            MessageBox.Show("entrez un nombre positif svp: " );
            return false;
        }

      
    }
}
