using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morpion
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        /* Avant tout, il faut définir une variable qui va compter les tours
         * Par défaut le joueur 1 sera celui qui commencera le tour
         * ce qui signifie qu'a chaque nombre impair des tour on mettre un O
         * et à chaque nombre pair on mettra un X pour le joueur 2
         * 
         * le label 3 servira à afficher quel tour appartient à quel joueur
         * 
         * il faudra donc toujours tester le nombre de tour dans chaque bouton 
         * pour mettre le bon symbole.
         * 
         * A chaque tour il faut verifier si un allignement de 3 symboles
         * a été fait. Il n'y a que 8 allignements à vérifier
         * 
         * les 3 lignes horizontales, les 3 lignes verticales
         * et les deux diagonales, tout cela à l'interieur d'une fonction
         * que j'appelerai Verifier, elle attribura les points gagnés
         * 
         * Il faudra aussi verouiller un bouton après qu'il est été sélectionné
        */

        int tour = 1, pointJoueur1=0, pointJoueur2=0;

        // BOUTTON 1
        private void button1_Click(object sender, EventArgs e)
        {
            if(tour%2==0)// Si c'est pair X
            {
                button1.Text = "X";
                // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                label3.Text = "Tour du joueur 1";
                // Vérouillage du bouton
                button1.Enabled = false;
            }

            else // Sinon O
            {
                button1.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour du joueur 2";
                // Vérouillage du bouton
                button1.Enabled = false;
            }

            Verifier();
            if (tour == 9)// Après avoir effectué les 9 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
        }

        // BOUTTON 2
        private void button2_Click(object sender, EventArgs e)
        {
            if (tour % 2 == 0)
            {
                button2.Text = "X";
                label3.Text = "Tour du joueur 1";
                button2.Enabled = false;
            }

            else 
            {
                button2.Text = "O";
                label3.Text = "Tour du joueur 2"; button2.Enabled = false;
            }

            Verifier();
            //Si on a un gagnant le label3 ne prendra pas la chaîne de string suivante comme valeure

            if (tour == 9)
            {
                label3.Text = "Personne ne gagne ce round";
            }


            tour += 1;
        }

        // BOUTTON 3
        private void button3_Click(object sender, EventArgs e)
        {
            if (tour % 2 == 0)
            {
                button3.Text = "X";
                label3.Text = "Tour du joueur 1"; button3.Enabled = false;
            }

            else 
            {
                button3.Text = "O";
                label3.Text = "Tour du joueur 2";
                button3.Enabled = false;
            }

            Verifier();
            if (tour == 9)
            {
                label3.Text = "Personne ne gagne ce round";
            }


            tour += 1;
        }


        // BOUTTON 4
        private void button4_Click(object sender, EventArgs e)
        {
            if (tour % 2 == 0)
            {
                button4.Text = "X";
                label3.Text = "Tour du joueur 1"; button4.Enabled = false;
            }

            else 
            {
                button4.Text = "O"; label3.Text = "Tour du joueur 2";
                button4.Enabled = false;
            }
            Verifier();
            if (tour == 9)
            {
                label3.Text = "Personne ne gagne ce round";
            }


            tour += 1;
        }

        // BOUTTON 5
        private void button5_Click(object sender, EventArgs e)
        {
            if (tour % 2 == 0)
            {
                button5.Text = "X"; label3.Text = "Tour du joueur 1";
                button5.Enabled = false;
            }

            else 
            {
                button5.Text = "O"; label3.Text = "Tour du joueur 2";
                button5.Enabled = false;
            }

            Verifier();
            if (tour == 9)
            {
                label3.Text = "Personne ne gagne ce round";
            }


            tour += 1;
        }


        // BOUTTON 6
        private void button6_Click(object sender, EventArgs e)
        {
            if (tour % 2 == 0)
            {
                button6.Text = "X"; label3.Text = "Tour du joueur 1";
                button6.Enabled = false;
            }

            else 
            {
                button6.Text = "O"; label3.Text = "Tour du joueur 2";
                button6.Enabled = false;
            }

            Verifier();
            if (tour == 9)
            {
                label3.Text = "Personne ne gagne ce round";
            }


            tour += 1;
        }

        // BOUTTON 7
        private void button7_Click(object sender, EventArgs e)
        {
            if (tour % 2 == 0)
            {
                button7.Text = "X"; label3.Text = "Tour du joueur 1";
                button7.Enabled = false;
            }

            else 
            {
                button7.Text = "O"; label3.Text = "Tour du joueur 2";
                button7.Enabled = false;
            }


            Verifier();
            if (tour == 9)
            {
                label3.Text = "Personne ne gagne ce round";
            }

            tour += 1;
        }


        // BOUTTON 8
        private void button8_Click(object sender, EventArgs e)
        {
            if (tour % 2 == 0)
            {
                button8.Text = "X"; label3.Text = "Tour du joueur 1";
                button8.Enabled = false;
            }

            else 
            {
                button8.Text = "O"; label3.Text = "Tour du joueur 2";
                button8.Enabled = false;
            }

            Verifier();
            if (tour == 9)
            {
                label3.Text = "Personne ne gagne ce round";
            }




            tour += 1;
        }

        // BOUTTON 9
        private void button9_Click(object sender, EventArgs e)
        {
            if (tour % 2 == 0)
            {
                button9.Text = "X"; label3.Text = "Tour du joueur 1";
                button9.Enabled = false;
            }

            else 
            {
                button9.Text = "O"; label3.Text = "Tour du joueur 2";
                button9.Enabled = false;
            }

            Verifier();
            if (tour == 9)
            {
                label3.Text = "Personne ne gagne ce round";
            }

            tour += 1;

            
        }


        private void Verifier()
        {
            /* On utilisera 8 tableaux donc chacun contiendra un allignement
             * a L'interieur de la boucle on vérifiera à la fois si le premier
             * allignement trouvé correspond a des X ou des O.
            */

            // Test des lignes
            Button[] tab1 = { button1, button2, button3 };
            Button[] tab2 = { button4, button5, button6 };
            Button[] tab3 = { button7, button8, button9 };

            //Test des colonnes
            Button[] tab4 = { button1, button4, button7 };
            Button[] tab5 = { button2, button5, button8 };
            Button[] tab6 = { button3, button6, button9 };

            //Test des diagonales
            Button[] tab7 = { button1, button5, button9 };
            Button[] tab8 = { button7, button5, button3 };


            // et maintenant un tableau.... de tableaux XD LOL MDR PTDR
            Button[][] tab9 = { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8 };

            // On va pouvoir tester dans la boucle dorénavant
            // Il faudra un boolean pour dire si il y'a une victoire
            // Cela permettra de réinitaliser les variables nécessaires
            // Et le jeu sera vérouillé jusqu'a réinitialisation du round ou totalement

            bool victoire = false;

            for(int i=0; i<8; i++)
            {
                //a chaque tour on test un allignement
                // En vérifiant la correspondance des boutons posséder par chaque tableau

                if(tab9[i][0].Text == "O" && tab9[i][1].Text=="O" && tab9[i][2].Text=="O")
                    //Si le joueur 1 gagne
                {
                    label3.Text = "Le joueur 1 a gagner ce round ";
                    pointJoueur1 += 1;
                    labelPoint1.Text = pointJoueur1.ToString();
                    victoire = true;
                }

                if (tab9[i][0].Text == "X" && tab9[i][1].Text == "X" && tab9[i][2].Text == "X")
                    //Si le joueur 2 gagne
                {
                    label3.Text = "Le joueur 2 a gagner ce round ";
                    pointJoueur2 += 1;
                    labelPoint2.Text = pointJoueur2.ToString();
                    victoire = true;
                }
            }

            if(victoire)
            {
                for(int i=0; i<3; i++)
                {
                    // A chaque tour on vérouille 3 bouton d'une ligne
                    tab9[i][0].Enabled= false;
                    tab9[i][1].Enabled = false;
                    tab9[i][2].Enabled = false;
                }
                tour = 1;// on remet le nombre de tour pour le premier joueur
            }


        }


        // LE BOUTON NOUVEAU ROUND 
        /* LEs variables nécessaires au nouveau round sont réinitialisées */

        private void button10_Click(object sender, EventArgs e)
        {
            label3.Text = "Tour joueur 1";
            tour = 1;

            button1.Enabled = true;
            button1.Text = "";

            button2.Enabled = true;
            button2.Text = "";

            button3.Enabled = true;
            button3.Text = "";

            button4.Enabled = true;
            button4.Text = "";

            button5.Enabled = true;
            button5.Text = "";

            button6.Enabled = true;
            button6.Text = "";

            button7.Enabled = true;
            button7.Text = "";

            button8.Enabled = true;
            button8.Text = "";

            button9.Enabled = true;
            button9.Text = "";
        }

        // Recommencer le jeu totalement
        private void button11_Click(object sender, EventArgs e)
        {
            label3.Text = "Tour joueur 1";
            tour = 1;

            button1.Enabled = true;
            button1.Text = "";

            button2.Enabled = true;
            button2.Text = "";

            button3.Enabled = true;
            button3.Text = "";

            button4.Enabled = true;
            button4.Text = "";

            button5.Enabled = true;
            button5.Text = "";

            button6.Enabled = true;
            button6.Text = "";

            button7.Enabled = true;
            button7.Text = "";

            button8.Enabled = true;
            button8.Text = "";

            button9.Enabled = true;
            button9.Text = "";

            pointJoueur1 = 0; labelPoint1.Text = "";
            
            pointJoueur2 = 0; labelPoint2.Text = "";
        }
    }
}
