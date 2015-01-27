using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sauri_Project3
{
    /// <summary>
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        MainWindow myOwner;
        Random rand = new Random();
        Monster enemy;
        BitmapImage gob = Application.Current.Resources["goblin"] as BitmapImage; 
        BitmapImage troop = Application.Current.Resources["horde"] as BitmapImage;
        BitmapImage champ = Application.Current.Resources["champ"] as BitmapImage;
        BitmapImage boss = Application.Current.Resources["boss"] as BitmapImage;


        public BattleWindow(MainWindow owner)
        {
            InitializeComponent();

            int generatemobType = rand.Next(0, 100); //Randoly choose our enemy
            string mobType;

            if (generatemobType > 94) 
            { 
                mobType = "Boss";
                enemypic.Source = boss;
            }

            else if (generatemobType > 85) 
            { 
                mobType = "Champion";
                enemypic.Source = champ;
            }

            else if (generatemobType > 65) 
            { 
                mobType = "Squad";
                enemypic.Source = troop;
            }

            else 
            { 
                mobType = "Minion";
                enemypic.Source = gob;
            }

            myOwner = owner;
            enemy = new Monster(mobType);

            enemyName.Text = enemy.Name;
            heroHP.Text = "Health: " + myOwner.player.Health;
            enemyHP.Text = "Health: " + enemy.Life;


            if (myOwner.attack2learned == true) //If you have learned the attack then you can use it
            {
                attackButton2.Visibility = Visibility.Visible;
            }
            if (myOwner.attack3learned == true)
            {
                attackButton3.Visibility = Visibility.Visible;
            }
            if (myOwner.attack4learned == true)
            {
                attackButton4.Visibility = Visibility.Visible;
            }
        }

        private int roll()
        {
            return rand.Next(1, 7);
        } //Our die

 
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myOwner.busy = false;
        }

        private void attackButton1_Click(object sender, RoutedEventArgs e)
        {
           battle(myOwner.attack1, "Your blade cuts");
        } //Click to attack, All button are pretty much the same

        private void attackButton2_Click(object sender, RoutedEventArgs e)
        {
            battle(myOwner.attack2, "Your gauntlet sends out electricity shocking");
        }

        private void attackButton3_Click(object sender, RoutedEventArgs e)
        {
            battle(myOwner.attack3, "You cast a great fire incinerating");
        }

        private void attackButton4_Click(object sender, RoutedEventArgs e)
        {
            heal(myOwner.attack4);
        } //Click to heal

        public void battle(int d, string s)
        {
            int playerRoll = 0;

            for (int i = 0; i < myOwner.player.Dice; i++)
            {
                playerRoll += roll();
            }

            int enemyRoll = roll();

            if (playerRoll > enemyRoll)
            {
                enemy.takeDamage(d);
                enemyHP.Text = "Health: " + enemy.Life;
                combatLog.Text = s + " the enemy dealing " + d + " damage.";

                if (enemy.Life <= 0)
                {
                    int loot = rand.Next(100, 500);
                    enemyHP.Text = "Dead";
                    myOwner.player.Gold += loot;
                    myOwner.goldCount.Text = ("Gold: " + myOwner.player.Gold);
                    MessageBox.Show("You have killed the enemy. You looted " + loot + " gold.");

                    Close();

                }
            }

            else if (enemyRoll > playerRoll)
            {
                enemy.pickmove();

                myOwner.player.takeDamage(enemy.Damage);

                combatLog.Text = "Your attack has missed! The enemy countered with " + enemy.Attack + " dealing " + enemy.Damage + " damage.";
                heroHP.Text = "Health: " + myOwner.player.Health;

                if (myOwner.player.Health <= 0)
                {
                    Close();
                    MessageBox.Show("You Lose! Too bad.");
                    myOwner.reset();
                }

            }
        }

        public void heal(int h)
        {
            int playerRoll = 0;

            for (int i = 0; i < myOwner.player.Dice; i++)
            {
                playerRoll += roll();
            }

            int enemyRoll = roll();

            if (playerRoll > enemyRoll)
            {
                myOwner.player.Health += h;
                heroHP.Text = "Health: " + myOwner.player.Health;
                combatLog.Text = "You managed to heal yourself for " + h + " health.";
            }

            else if (enemyRoll > playerRoll)
            {
                enemy.pickmove();

                myOwner.player.takeDamage(enemy.Damage);

                combatLog.Text = "Before you could heal our enemy attacked with " + enemy.Attack + " dealing " + enemy.Damage + " damage.";
                heroHP.Text = "Health: " + myOwner.player.Health;

                if (myOwner.player.Health <= 0)
                {
                    Close();
                    MessageBox.Show("You Lose! Too bad.");
                    myOwner.reset();
                }

            }
        }


    }
}
