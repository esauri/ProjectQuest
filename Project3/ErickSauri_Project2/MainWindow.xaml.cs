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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Sauri_Project3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int size = 16; //Size of Game board
        Random rand = new Random(); 
        Tile[,] grid;
        public Player player;
        Tile finishLine;
        BattleWindow battle;
        InstructionWindow guide;
        public Boolean busy = false;


        public Boolean attack2learned; //Have you learned the attacks?
        public Boolean attack3learned;
        public Boolean attack4learned;

        public int attack1 = 20; //Attack Damage
        public int attack2 = 35;
        public int attack3 = 50;
        public int attack4 = 10;

        int x1;
        int x2;
        string type;

        public MainWindow()
        {
            InitializeComponent();

            clearBoard();
        }

        public void reset()
        {

            clearBoard();
            createWalls();
            printGrid();

        }

        public void clearBoard()
        {
            grid = new Tile[size, size];
            Tile.TileColors["player"] = (Color)ColorConverter.ConvertFromString("#FF75A3");  //This is the player's tile
            Tile.TileColors["wall"] = (Color)ColorConverter.ConvertFromString("#afaca7");  //This is a wall tile
            Tile.TileColors["water"] = (Color)ColorConverter.ConvertFromString("#0047B2"); //Water Tile
            Tile.TileColors["magma"] = (Color)ColorConverter.ConvertFromString("#990000"); //Magma Tile
            Tile.TileColors["endZone"] = (Color)ColorConverter.ConvertFromString("#A37ACC"); //Finish Line

            buildGameBoard(size, size);

            player = new Player(0, 0);
            myGrid.Children.Add(player);

            finishLine = new Tile(15, 15, "endZone");
            myGrid.Children.Add(finishLine);

            goldCount.Text = ("Gold: " + player.Gold);
        }


        private void buildGameBoard(int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Rectangle r = new Rectangle();
                    r.Width = Tile.SIZE;
                    r.Height = Tile.SIZE;
                    r.Fill = new SolidColorBrush(Colors.LightGray);
                   // r.RadiusX = r.RadiusY = 5;
                    myGrid.Children.Add(r);

                    r.HorizontalAlignment = HorizontalAlignment.Left;
                    r.VerticalAlignment = VerticalAlignment.Top;

                    Thickness theMargin = new Thickness(
                        Tile.START + x * (Tile.SIZE + Tile.SPACING),
                        Tile.START + y * (Tile.SIZE + Tile.SPACING), 0, 0);
                    r.Margin = theMargin;
                }
            }


        } //Making the Game Board

        private void createWalls()
        {
            for (int i = 0; i < 80; i++)
            {
              makeWalls();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Boolean moved = false;
            if (!busy)
            {
                if (e.Key == Key.Up)
                {
                   moved = moveUp();
                }

                else if (e.Key == Key.Down)
                {
                    moved = moveDown();
                    
                }

                else if (e.Key == Key.Left)
                {
                    moved = moveLeft();
                }
                else if (e.Key == Key.Right)
                {
                 moved = moveRight();
                }

                if (moved)
                {
                    if (player.Column == finishLine.Column && player.Row == finishLine.Row)
                    {
                        win();
                    }
                    else
                    {
                        ambush();
                        find();
                    }
                }
                
                
            }
        } //Key Pressing

        private Boolean moveDown()
        {

            if (player.Row == (size - 1) || (grid[player.Column, player.Row + 1] != null)) //If the Player is in the final row do not do anything
            {
                return false;
            }
            else
            {
             player.MoveTo(player.Column, player.Row + 1);
             return true;
            }
                
                         
          } //Movement in the Up direction

        private Boolean moveUp()
        {
            
            if (player.Row == 0 || grid[player.Column, player.Row - 1] != null) //If the Player is in the final row do not do anything
            {
                return false;
            }

            else
            {
                player.MoveTo(player.Column, player.Row - 1);
                return true;
            }
        } //Movement in the up direction

        private Boolean moveLeft()
        {
            if (player.Column == 0 || grid[player.Column - 1, player.Row] != null) //If the Player is in the final row do not do anything
            {
                return false;
            }

            else
            {
                player.MoveTo(player.Column - 1, player.Row);
                return true;
            }
            
        } //Movement in the Left direction

        private Boolean moveRight()
        {

            if (player.Column == (size - 1) || grid[player.Column + 1, player.Row] != null) //If the Player is in the final row do not do anything
            {
                return false;
            }

            else
            {

                player.MoveTo(player.Column + 1, player.Row);
                return true;
            }
           
        } //Movement in the Right direction

        private void makeWalls()
        {
            List<int[]> empties = blankSpots();

            int index = rand.Next(1, empties.Count - 2);

            int[] coordinates = empties[index];

            /*int generateType = rand.Next(0, 100); Makes random tiles of either wall, magma or water but it looks ugly

            string solidtype = "";

            if (generateType > 70)
            {
                solidtype = "water";
            }

            else if (generateType > 50)
            {
                solidtype = "magma";
            }

            else
            {
                solidtype = "wall";
            } */

            Tile tilenew;
            tilenew = new Tile(coordinates[0], coordinates[1], "wall");
            myGrid.Children.Add(tilenew);
            grid[coordinates[0], coordinates[1]] = tilenew;

        } //Spawn many walls

        private void ambush()
        {
            int chanceofAttack = rand.Next(0, 100);

            if (chanceofAttack > 70)
            {
                busy = true;
                battle = new BattleWindow(this);
                battle.Show();

            }

        } // Rolls the die. If the die is greater than a certain number, danger is set to true

        private List<int[]> blankSpots()
        {
            List<int[]> empties = new List<int[]>();

            // loop through r values
            for (int r = 0; r < size; r++)
            {
                // loop through c values
                for (int c = 0; c < size; c++)
                {
                    // if tiles[c,r] is null
                    if (grid[c, r] == null)
                    {
                        // make an int[2] named position
                        int[] position = new int[2];

                        // position[0] will hold the x value
                        position[0] = c;
                        // position[1] will hold the y value
                        position[1] = r;
                        // add position to empties

                        empties.Add(position);
                    }


                }
            }

            return empties;

        } //Checks for empty spaces

        private void printGrid()
        {
            Console.WriteLine("-------------------------");
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (grid[c, r] != null)
                    {
                        // print the square's value
                        string output = grid[c, r].Value.ToString();
                        Console.Write(output.PadLeft(4) + ",");
                    }
                    else
                    {
                        // print a blank space
                        Console.Write("    ,");
                    }
                }
                Console.WriteLine();
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            reset();

        } //Click to reset

        private void win()
        {
                MessageBox.Show("You have reached the finish line! Total gold found was " + player.Gold + ". But our princess is in another castle!");
                reset();
        } //If player reaches finish line he wins

        private void find()
        {
            if (!busy)
            {
                int findtreasure = rand.Next(0, 101);

                if (findtreasure > 95)
                {
                    if (player.Dice < 4)
                        player.Dice++;
                    MessageBox.Show("The gods have heeded your prayers!" + "\n" + "Your accuracy has greatly increased.");
                }
                else if (findtreasure > 80)
                {
                    player.Health += 10;
                    MessageBox.Show("You feel replenished." + "\n" + "Your health has been increased.");

                }
                else if (findtreasure > 60)
                {
                    learn();
                }

                else if (findtreasure > 50)
                {
                    int goldfound = rand.Next(100, 1000);
                    player.Gold += goldfound;
                    goldCount.Text = ("Gold: " + player.Gold);
                    MessageBox.Show("You have found " + goldfound + " gold!");
                }
            }
           
        } //find items

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //set the save-file dialog
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "message";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            //here we actually show the dialog
            Nullable<bool> result = dialog.ShowDialog();

            // Process save file dialog box results 
            if (result == true)
            {
                //get the file name 
                string filename = dialog.FileName;


                using (StreamWriter writer = new StreamWriter(filename))
                {
                    for (int c = 0; c < size; c++)
                    {
                        for (int r = 0; r < size; r++)
                        {
                            if (grid[c, r] != null)
                            {
                                writer.Write(grid[c, r].Value + "," + grid[c, r].Column + "," + grid[c, r].Row + "\n"); //Write indexes seperated by commas
                            }
                        }
                    }

                }
            }
        } //Save map

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "message"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension 

            //attempt to show the dialog
            Nullable<bool> result = dialog.ShowDialog();

            //if the dialog box ran successfully and user chose a file, do this stuff
            if (result == true)
            {


                //obtain the file name that the user chose
                string filename = dialog.FileName;


                using (StreamReader reader = new StreamReader(filename))
                {
                                       
                    string line = null;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] info = line.Split(','); //Split Text

                        type = info[0]; //Set first columm to first number
                        x1 = Int32.Parse(info[1]); //Set second column to second number
                        x2 = Int32.Parse(info[2]); //Set third column to third number

                        Tile tilenew;
                        tilenew = new Tile(x1, x2, type);
                        myGrid.Children.Add(tilenew);
                        grid[x1, x2] = tilenew;
                       
                       
                    }
                }
            }
        } //Load map
                     
        public void learn() //Learning attacks
        {
            if (attack2learned == false) //This boolean is useful for the button in Battle Window
            {
                attack2learned = true; //If you haven't learned this attack learn it
                MessageBox.Show("As you are walking, your step on something strange. You pick it up and realize it is an old gauntlet that has the power to electrocute. Since it still looks charged you put it on in case enemies attack.");
            }

            else if (attack3learned == false)
            {
                attack3learned = true;
                MessageBox.Show("You find an old tome with several torn pages on the floor. As you open it you realize it is a spell incantation for summoning a great fire. Perhaps if you find the rest of the pages your magical ability can increase.");
            }

            else if (attack4learned == false)
            {
                attack4learned = true;
                MessageBox.Show("You come across a strange statue. The orcs must have stolen it from an abbey. Etched on the statue are prayers the Clerics once had. Will the gods heed your call in times of need?");
            }

            else //If you know all attacks then next time their power increases
            {
                int increasewhich = rand.Next(1, 5);

                if (increasewhich > 4)
                {
                    attack1 += 10;
                    MessageBox.Show("After battling many enemies your mastery over swords has increased!");
                }

                else if (increasewhich > 3)
                {
                    attack2 += 10;
                    MessageBox.Show("You find a small orb filled with electrical energy. Better absorb it to increase your gauntlet's charge.");
                }

                else if (increasewhich > 2)
                {
                    attack3 += 5;
                    MessageBox.Show("You find a torn page with etchings of what looks like a great fire.");
                }

                else
                {
                    attack4 += 5;
                    MessageBox.Show("You have come across another sacred statue. You quickly memorize the prayer in hopes that the gods will listen.");
                }

                //if all four are know then increase their "damage"
            }
        }

        private void cleartButton_Click(object sender, RoutedEventArgs e)
        {
            clearBoard();
        }

    }
}
