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
         * et à chaque nombre pair on mettra un X pour le joueur 2 ou vegeta
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

        int tour = 1, pointJoueur1 = 0, pointJoueur2 = 0;
        //La variable pointJoueur2 sera utilisé pour Vegeta si on l'affronte

        private void Activation()// Les bouttons sont activés une fois le mode choisie
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }

        private void DesActivation()// Les bouttons sont activés une fois le mode choisie
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }




        //Dabord on choisi soit le mode 2 joueurs
        /*Il y'aura une variable booleen qui déterminera si le code duel entre humain sera éxecuter
         ou si le code contre l'IA sera executer, l'IA se nommera Vegeta pour le fun*/
        // la variable adversaire affiche le nom de l'opposant

        bool mode = true;// True pour le duel d'humain
        string adversaire = "";// Necessaire pour affecter la chaine
        // tour du joueur 2 ou tour de Vegeta
        private void duelHumains_Click(object sender, EventArgs e)
        {
            label1.Text = "Joueur 1 nombre de point: ";
            label2.Text = "Joueur 2 nombre de point: ";
            adversaire = "Joueur 2";
            // on fait apparaitre les boutons nouveau round et recommencer
            button11.Visible = true; button10.Visible = true;
            // puis on fait disparaitre les boutons de mode
            duelHumains.Visible = false; buttonIA.Visible = false;
            Activation();

        }

        //Soit le mode joueur contre Vegeta, qui est en réalité l'IA

        private void buttonIA_Click(object sender, EventArgs e)
        {
            label1.Text = "Joueur 1 nombre de point: ";
            label2.Text = "Vegeta nombre de point: ";
            adversaire = "Vegeta";
            mode = false; // False pour affronter Vegeta
            button11.Visible = true; button10.Visible = true;
            duelHumains.Visible = false; buttonIA.Visible = false;
            Activation();
        }
        // Même si le joueur 1 gagne Vegeta va quand même continuer à jouer
        // Et executer le code suivant il faut donc que l'ordinateur comprenne
        // qu'il ne doit pas éxecuter le code la méthode vérifier s'execute après
        // et ne l'arrêtera pas. Nous devons donc
        // en tant que développeur ... Arrêter Vegeta ! tel est notre devoir !
        // La variable suivante sera incrémenter à chaque appuie
        int appuie = 0;
        // Le 5 ème appui du joueur contre l'IA sera toujours le dernier

        // BOUTTON 1

        private void button1_Click(object sender, EventArgs e)
        {
            appuie += 1;
            if (mode && tour % 2 == 0)// Si c'est pair X et que le mode 
                                      // joueur 1 vs joueur 2 est activé
            {
                button1.Text = "X";
                // le joueur 2 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 1
                label3.Text = "Tour du joueur 1";
                // Vérouillage du bouton
                button1.Enabled = false;


            }

            // Ce code ne sera pas éxecuter si on affronte pas vegeta
            if ((tour % 2 != 0) || !mode) // Sinon O
                                          // Mettre mode vegeta false donc a || permet d'ignorer la condition du nombre de
                                          // tour impair obligatoire sinon on ne peut pas rentrer le pour vegeta au tour pair dans le
                                          // if imbriqué
            {
                button1.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour de " + adversaire;
                // Vérouillage du bouton
                button1.Enabled = false;
                if (!mode && appuie!=5)//après que le joueur un appuie Vegeta joue juste après
                {
                    Vegeta();
                }
            }

            Verifier();
            // il faut mettre le match aussi et conditionner le code pour vegeta après le ||
            // C'est à dire que la variable tour sera incrémenté 5 fois pour arrivé à un match nul
            // Elle n'est pas incrémenter que l'IA joue
            if (tour == 9 || (tour == 5 && !mode))// Après avoir effectué les 9 tours le round est terminé
            {
                label3.Text = "Personne ne gagne ce round";
            }

            //Ensuite on incrémentre pour mettre à jour le nombre de tour
            tour += 1;
        }

        // BOUTTON 2
        private void button2_Click(object sender, EventArgs e)
        {
            appuie += 1;
            if (mode && tour % 2 == 0)
            {
                button2.Text = "X";
                label3.Text = "Tour du joueur 1";
                button2.Enabled = false;
            }

            // Ce code ne sera pas éxecuter si on affronte pas vegeta
            if ((tour % 2 != 0) || !mode) // Sinon O
                                          // Mettre mode vegeta false donc a || permet d'ignorer la condition du nombre de
                                          // tour impair obligatoire sinon on ne peut pas rentrer le pour vegeta au tour pair dans le
                                          // if imbriqué
            {
                button2.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label2.Text = "Tour de " + adversaire;
                // Vérouillage du bouton
                button2.Enabled = false;
                if (!mode && appuie!=5)//après que le joueur un appuie Vegeta joue juste après
                {
                    Vegeta();
                }
            }

            Verifier();
            // il faut mettre le match aussi et conditionner le code pour vegeta après le ||
            if (tour == 9 || (tour == 5 && !mode))
            {
                label3.Text = "Personne ne gagne ce round";
            }

            tour += 1;

        }

        // BOUTTON 3
        private void button3_Click(object sender, EventArgs e)
        {
            appuie += 1;
            if (mode && tour % 2 == 0)
            {
                button3.Text = "X";
                label3.Text = "Tour du joueur 1"; button3.Enabled = false;
            }

            // Ce code ne sera pas éxecuter si on affronte pas vegeta
            if ((tour % 2 != 0) || !mode) // Sinon O
                                          // Mettre mode vegeta false donc a || permet d'ignorer la condition du nombre de
                                          // tour impair obligatoire sinon on ne peut pas rentrer le pour vegeta au tour pair dans le
                                          // if imbriqué
            {
                button3.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour de " + adversaire;
                // Vérouillage du bouton
                button3.Enabled = false;
                if (!mode && appuie!=5)//après que le joueur un appuie Vegeta joue juste après
                {
                    Vegeta();
                }
            }

            Verifier();
            // il faut mettre le match aussi et conditionner le code pour vegeta après le ||
            if (tour == 9 || (tour == 5 && !mode))
            {
                label3.Text = "Personne ne gagne ce round";
            }

            tour += 1;

        }


        // BOUTTON 4
        private void button4_Click(object sender, EventArgs e)
        {
            appuie += 1;
            if (mode && tour % 2 == 0)
            {
                button4.Text = "X";
                label3.Text = "Tour du joueur 1"; button4.Enabled = false;
            }

            // Ce code ne sera pas éxecuter si on affronte pas vegeta
            if ((tour % 2 != 0) || !mode) // Sinon O
                                          // Mettre mode vegeta false donc a || permet d'ignorer la condition du nombre de
                                          // tour impair obligatoire sinon on ne peut pas rentrer le pour vegeta au tour pair dans le
                                          // if imbriqué
            {
                button4.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour de " + adversaire;
                // Vérouillage du bouton
                button4.Enabled = false;
                if (!mode && appuie!=5)//après que le joueur un appuie Vegeta joue juste après
                {
                    Vegeta();
                }
            }

            Verifier();
            // il faut mettre le match aussi et conditionner le code pour vegeta après le ||
            if (tour == 9 || (tour == 5 && !mode))
            {
                label3.Text = "Personne ne gagne ce round";
            }

            tour += 1;

        }

        // BOUTTON 5
        private void button5_Click(object sender, EventArgs e)
        {
            appuie += 1;
            if (mode && tour % 2 == 0)
            {
                button5.Text = "X"; label3.Text = "Tour du joueur 1";
                button5.Enabled = false;
            }

            // Ce code ne sera pas éxecuter si on affronte pas vegeta
            if ((tour % 2 != 0) || !mode) // Sinon O
                                          // Mettre mode vegeta false donc a || permet d'ignorer la condition du nombre de
                                          // tour impair obligatoire sinon on ne peut pas rentrer le pour vegeta au tour pair dans le
                                          // if imbriqué
            {
                button5.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour de " + adversaire;
                // Vérouillage du bouton
                button5.Enabled = false;
                if (!mode && appuie!=5)//après que le joueur un appuie Vegeta joue juste après
                {
                    Vegeta();
                }
            }

            Verifier();
            // il faut mettre le match aussi et conditionner le code pour vegeta après le ||
            if (tour == 9 || (tour == 5 && !mode))
            {
                label3.Text = "Personne ne gagne ce round";
            }


            tour += 1;
        }


        // BOUTTON 6
        private void button6_Click(object sender, EventArgs e)
        {
            appuie += 1;
            if (mode && tour % 2 == 0)
            {
                button6.Text = "X"; label3.Text = "Tour du joueur 1";
                button6.Enabled = false;
            }

            // Ce code ne sera pas éxecuter si on affronte pas vegeta
            if ((tour % 2 != 0) || !mode) // Sinon O
                                          // Mettre mode vegeta false donc a || permet d'ignorer la condition du nombre de
                                          // tour impair obligatoire sinon on ne peut pas rentrer le pour vegeta au tour pair dans le
                                          // if imbriqué
            {
                button6.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour de " + adversaire;
                // Vérouillage du bouton
                button6.Enabled = false;
                if (!mode && appuie!=5)//après que le joueur un appuie Vegeta joue juste après
                {
                    Vegeta();
                }
            }

            Verifier();
            // il faut mettre le match aussi et conditionner le code pour vegeta après le ||
            if (tour == 9 || (tour == 5 && !mode))
            {
                label3.Text = "Personne ne gagne ce round";
            }


            tour += 1;
        }

        // BOUTTON 7
        private void button7_Click(object sender, EventArgs e)
        {
            appuie += 1;
            if (mode && tour % 2 == 0)
            {
                button7.Text = "X"; label3.Text = "Tour du joueur 1";
                button7.Enabled = false;
            }

            // Ce code ne sera pas éxecuter si on affronte pas vegeta
            if ((tour % 2 != 0) || !mode) // Sinon O
                                          // Mettre mode vegeta false donc a || permet d'ignorer la condition du nombre de
                                          // tour impair obligatoire sinon on ne peut pas rentrer le pour vegeta au tour pair dans le
                                          // if imbriqué
            {
                button7.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour de " + adversaire;
                // Vérouillage du bouton
                button7.Enabled = false;
                if (!mode && appuie!=5)//après que le joueur un appuie Vegeta joue juste après
                {
                    Vegeta();
                }
            }

            Verifier();
            // il faut mettre le match aussi et conditionner le code pour vegeta après le ||
            if (tour == 9 || (tour == 5 && !mode))
            {
                label3.Text = "Personne ne gagne ce round";
            }

            tour += 1;
        }


        // BOUTTON 8
        private void button8_Click(object sender, EventArgs e)
        {
            appuie += 1;
            if (mode && tour % 2 == 0)
            {
                button8.Text = "X"; label3.Text = "Tour du joueur 1";
                button8.Enabled = false;
            }

            // Ce code ne sera pas éxecuter si on affronte pas vegeta
            if ((tour % 2 != 0) || !mode) // Sinon O
                                          // Mettre mode vegeta false donc a || permet d'ignorer la condition du nombre de
                                          // tour impair obligatoire sinon on ne peut pas rentrer le pour vegeta au tour pair dans le
                                          // if imbriqué
            {
                button8.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour de " + adversaire;
                // Vérouillage du bouton
                button8.Enabled = false;
                if (!mode && appuie!=5)//après que le joueur un appuie Vegeta joue juste après
                {
                    Vegeta();
                }
            }

            Verifier();
            // il faut mettre le match aussi et conditionner le code pour vegeta après le ||
            if (tour == 9 || (tour == 5 && !mode))
            {
                label3.Text = "Personne ne gagne ce round";
            }




            tour += 1;
        }

        // BOUTTON 9
        private void button9_Click(object sender, EventArgs e)
        {
            appuie += 1;
            if (mode && tour % 2 == 0)
            {
                button9.Text = "X"; label3.Text = "Tour du joueur 1";
                button9.Enabled = false;
            }

            // Ce code ne sera pas éxecuter si on affronte pas vegeta
            if ((tour % 2 != 0) || !mode) // Sinon O
                                          // Mettre mode vegeta false donc a || permet d'ignorer la condition du nombre de
                                          // tour impair obligatoire sinon on ne peut pas rentrer le pour vegeta au tour pair dans le
                                          // if imbriqué
            {
                button9.Text = "O";
                // le joueur 1 vient d'effectuer son tour, le label 3 indiquera le tour du joueur 2
                label3.Text = "Tour de " + adversaire;
                // Vérouillage du bouton
                button9.Enabled = false;
                if (!mode && appuie!=5)//après que le joueur un appuie Vegeta joue juste après
                {
                    Vegeta();
                }
            }

            Verifier();
            // il faut mettre le match aussi et conditionner le code pour vegeta après le ||
            if (tour == 9 || (tour == 5 && !mode))
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

            for (int i = 0; i < 8; i++)
            {
                //a chaque tour on test un allignement
                // En vérifiant la correspondance des boutons posséder par chaque tableau

                if (tab9[i][0].Text == "O" && tab9[i][1].Text == "O" && tab9[i][2].Text == "O")
                //Si le joueur 1 gagne
                {
                    label3.Text = "Le joueur 1 a gagner ce round ";
                    pointJoueur1 += 1;
                    labelPoint1.Text = pointJoueur1.ToString();
                    victoire = true;
                    appuie = 0; // On réintialise ou cas ou on affronte Vegeta
                }

                if (tab9[i][0].Text == "X" && tab9[i][1].Text == "X" && tab9[i][2].Text == "X")
                //Si le joueur 2 gagne ou Vegeta
                {

                    label3.Text = adversaire + " a gagner ce round ";
                    pointJoueur2 += 1;
                    labelPoint2.Text = pointJoueur2.ToString();
                    victoire = true;
                }
            }

            if (victoire)
            {
                for (int i = 0; i < 3; i++)
                {
                    // A chaque tour on vérouille 3 bouton d'une ligne
                    tab9[i][0].Enabled = false;
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

            button1.Enabled = false;
            button1.Text = "";

            button2.Enabled = false;
            button2.Text = "";

            button3.Enabled = false;
            button3.Text = "";

            button4.Enabled = false;
            button4.Text = "";

            button5.Enabled = false;
            button5.Text = "";

            button6.Enabled = false;
            button6.Text = "";

            button7.Enabled = false;
            button7.Text = "";

            button8.Enabled = false;
            button8.Text = "";

            button9.Enabled = false;
            button9.Text = "";

            pointJoueur1 = 0; labelPoint1.Text = "";

            pointJoueur2 = 0; labelPoint2.Text = "";

            button11.Visible = false; button10.Visible = false;
            buttonIA.Visible = true; duelHumains.Visible = true;
            mode = true;
        }
        private Button[][] tabPourVegeta;
        Random aleatoire = new Random();// L'IA remplira de manière aléatoire
        // Oui elle est faible en stratégie pour l'instant :D
        int pos1 = 0, pos2;
        private void Vegeta()
        {

            // Même si le joueur 1 gagne Vegeta va quand même continuer à jouer
            // Et executer le code suivant il faut donc que l'ordinateur comprenne
            // qu'il ne doit pas éxecuter le code la méthode vérifier s'execute après
            // et ne l'arrêtera pas. Nous devons donc
            // en tant que développeur ... Arrêter Vegeta ! tel est notre devoir !


            //Lignes
            Button[] tab1 = { button1, button2, button3 };
            Button[] tab2 = { button4, button5, button6 };
            Button[] tab3 = { button7, button8, button9 };

            // Colonnes
            Button[] tab4 = { button1, button4, button7 };
            Button[] tab5 = { button2, button5, button8 };
            Button[] tab6 = { button3, button6, button9 };

            //Diagonales
            Button[] tab7 = { button1, button5, button9 };
            Button[] tab8 = { button7, button5, button3 };

            Button[][] tab = { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8 };
            tabPourVegeta = tab;

            /*
            pos1 = aleatoire.Next(0, 7); // Choix du tableau
            pos2 = aleatoire.Next(0, 2); // Choix de la case


            if (tabPourVegeta[pos1][pos2].Text == "")
            {
                tabPourVegeta[pos1][pos2].Text = "X";
                tabPourVegeta[pos1][pos2].Enabled = false;// désactiver la case

                label3.Text = "Tour du joueur 1";
            }
            else// Si on tombe sur O ou X on recherche une autre postion libre
            {
                Vegeta();// Un peu comme une boucle mais de manière récursive
            }
            */

            /*
             * La stratégie que Vegeta emploira pourra battre le joueur 1 est la suivante
             * Comme il commence toujours après il va toujours mettre une croix prêt du J1, diminutif joueur1,
             * pour directement bloquer une possibilité d'alignement
             * 
             * condition A Bloqueur
             * Une boucle parcourera tout les tableaux et s'arrêtera dès que la position du J1 est trouvé
             * une croix sera affecté alors à côté 
             * 
             * 
             * condition B Bloqueur
             * Avant cela il faudra mettre la condition disant que si Vegeta voit deux O il doit bloquer l'alignement
             * sinon le J1 pourra mettre 3 O alors que Vegeta va chercher à bloquer un O
             * si il va dans la condition,qu'elle est vrai donc et qu'on la mets en première il ne pourra pas tester la B
             * car une condition égale 1 tour
             * 
             * Condition C Takedown 
             * qui sera testé en première, si Vegeta voit 2 deux croix alignés,  et un champ vide 
             * a la  suite ou entre elles
             * permettant de mettre une troisième il le fait.
             * 
             * On se servira de l'instruction goto pour sortir complètement du foreac het s'assurer qu'un seul
             * par vegeta est joué
             * 
             * un foreach pour chaque Condition
             * 
             */

            foreach (Button[] tableau in tabPourVegeta)// On vérifie un alignement par tour
            {
                // Si il voit une opportunité de faire 3 crois alignés 
                // Takedown C
                if (tableau[0].Text == "X" && tableau[1].Text == "X" && tableau[2].Text == ""
                    || tableau[0].Text == "X" && tableau[1].Text == "" && tableau[2].Text == "X"
                    || tableau[0].Text == "" && tableau[1].Text == "X" && tableau[2].Text == "X")
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (tableau[i].Text == "")
                        {
                            tableau[i].Text = "X"; label3.Text = "Tour du joueur 1";
                            tableau[i].Enabled = false;
                            goto Tourfini;
                        }
                    }


                }
            }

            // Si il voit un potentiel alignement du J1 il le bloque dans le champ vide
            //Bloqueur B

            foreach (Button[] tableau in tabPourVegeta)// On vérifie un alignement par tour
            {
               
                if (tableau[0].Text == "O" && tableau[1].Text == "O" && tableau[2].Text == ""
                    || tableau[0].Text == "O" && tableau[1].Text == "" && tableau[2].Text == "O"
                    || tableau[0].Text == "" && tableau[1].Text == "O" && tableau[2].Text == "O")
                {
                    for (int i = 0; i < 3; i++)// il parcours le tableau en cours et met une croix dans le champ vide
                    {
                        if (tableau[i].Text == "")
                        {
                            tableau[i].Text = "X"; label3.Text = "Tour du joueur 1";
                            tableau[i].Enabled = false;
                            goto Tourfini;
                        }
                    }


                }
            }



            //Il place sa croix à côté pour bloquer une possibilité
            //Bloqueur A
            foreach (Button[] tableau in tabPourVegeta)// On vérifie un alignement par tour
            {
                
            if (tableau[0].Text == "O" && tableau[1].Text == "" && tableau[2].Text == "")
                {
                    tableau[1].Text = "X";
                    label3.Text = "Tour du joueur 1";
                    tableau[1].Enabled = false;
                    goto Tourfini;
                }
                //Bloqueur A
                if (tableau[0].Text == "" && tableau[1].Text == "O" && tableau[2].Text == "")
                {
                    tableau[0].Text = "X";
                    label3.Text = "Tour du joueur 1";
                    tableau[0].Enabled = false;
                    goto Tourfini;
                }
                //Bloqueur A
                if (tableau[0].Text == "" && tableau[1].Text == "" && tableau[2].Text == "O")
                {
                    tableau[1].Text = "X";
                    label3.Text = "Tour du joueur 1";
                    tableau[1].Enabled = false;
                    goto Tourfini;
                }

            }

            Tourfini:;
        }

    }

    

}
