using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauri_Project3
{
    public class Monster
    {
        int life;
        string type;
        string name;
        int damage;
        Dictionary<string, int> enemyAttack = new Dictionary<string, int>();
        string[] champnames = new string[5];
        string[] bossnames = new string[3];
        Random rand = new Random();
        int attackchoose;
        string attack;

       
        public Monster(string t)
        {
            type = t;

            pickmove();

            //Minion moves:
            enemyAttack.Add("Headbutt", 5);
            enemyAttack.Add("Kick", 10);
            enemyAttack.Add("Quick Strike", 15);
            enemyAttack.Add("Slash", 25);

            //Squad moves + slash:
            enemyAttack.Add("Piercing Shot", 20);
            enemyAttack.Add("Scorch", 30);
            enemyAttack.Add("Flank", 40);

            //Champion moves:
            enemyAttack.Add("Charge", 35);
            enemyAttack.Add("Fatal Strike", 40);
            enemyAttack.Add("Impale", 50);
            enemyAttack.Add("Execute", 55);

            //Boss moves
            enemyAttack.Add("Desecrate", 65);
            enemyAttack.Add("Obliterate", 65);
            enemyAttack.Add("Conflagrate", 75);
            enemyAttack.Add("Decapitate", 80);

            if (t == "Boss") { Boss(); }

            else if (t == "Champion") { Champion(); }

            else if (t == "Squad") { Squad(); }

            else { Minion(); }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public int Damage
        {
            get { return damage; }
        }

        public string Attack
        {
            get { return attack; }
        }

        public string Type
        {
            get { return type; }
        }

        public void takeDamage(int h)
        {
            life -= h;

        }
        public string Name
        {
            get { return name; }
        }

        public void pickmove() //picks which attack the monster uses
        {
            attackchoose = rand.Next(1, 101);
        }
                     
       public void Minion() //Minion type
        {
          life = 30;
          name = "Goblin Patroller";
      
           //Attacking
          if (attackchoose > 40)
          {
              damage = enemyAttack["Headbutt"];
              attack = "Headbutt";
          }

          else if (attackchoose > 25)
          {
              damage = enemyAttack["Kick"];
              attack = "Kick";

          }

          else if (attackchoose > 10)
          {
              damage = enemyAttack["Quick Strike"];
              attack = "Quick Strike";
          }

          else
          {
              damage = enemyAttack["Slash"];
              attack = "Slash";
          }
          
        }

       public void Squad() //Squad Type 
       {
           life = 90;
           name = "Orc Raiders";

           //Attacking
           if (attackchoose > 40)
           {
               damage = enemyAttack["Piercing Shot"];
               attack = "Piercing Shot";
           }

           else if (attackchoose > 25)
           {
               damage = enemyAttack["Slash"];
               attack = "Slash";

           }

           else if (attackchoose > 10)
           {
               damage = enemyAttack["Scorch"];
               attack = "Scorch";
           }

           else
           {
               damage = enemyAttack["Flank"];
               attack = "Flank";
           }
       }

       public void Champion() //Champion type
       {
           life = 120;
           
           //Champion names:
           champnames[0] = "Rhozaq the Skullsplitter";
           champnames[1] = "Warlord Gurkosh";
           champnames[2] = "Rekkul, Champion of the Blood Guard";
           champnames[3] = "Omokk, The Gluttony";
           champnames[4] = "Harromm the Earthshatterer";

           int namepicker = rand.Next(0, champnames.Length);
           name = champnames[namepicker];

           //Attacking
           if (attackchoose > 40)
           {
               damage = enemyAttack["Charge"];
               attack = "Charge";
           }

           else if (attackchoose > 25)
           {
               damage = enemyAttack["Fatal Strike"];
               attack = "Fatal Strike";
           }

           else if (attackchoose > 10)
           {
               damage = enemyAttack["Implae"];
               attack = "Impale";
           }

           else
           {
               damage = enemyAttack["Execute"];
               attack = "Execute";
           }
       }

        public void Boss() //Boss type
        {
            life = 150;
            
            //boss names:
            bossnames[0] = "Alexei, Sword of the Nightfall";
            bossnames[1] = "The Dark Knight";
            bossnames[2] = "Lancaster, Bane of Aran";

            int namepicker = rand.Next(0, bossnames.Length);
            name = bossnames[namepicker];


            //Attacking
            if (attackchoose > 40)
            {
                damage = enemyAttack["Desecrate"];
                attack = "Desecrate";
            }

            else if (attackchoose > 25)
            {
                damage = enemyAttack["Obliterate"];
                attack = "Obliterate";
            }

            else if (attackchoose > 10)
            {
                damage = enemyAttack["Conflagrate"];
                attack = "Conflagrate";
            }

            else
            {
                damage = enemyAttack["Decapitate"];
                attack = "Decapitate";
            }
        }
    }
}
