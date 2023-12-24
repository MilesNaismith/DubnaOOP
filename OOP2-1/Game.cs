using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OOP2_1
{
    internal class Game
    {
        
        public string name;
      //  public string character;
      //  public Person player;
       // public Person enemy;
        public Random rnd = new Random();
        public int dist;
        public Game() 
        {
     //       this.player = new Person();
            //this.enemy = new Person();
            this.dist = 0;
        }
        new public Person start(string character)
        {
            Person player = null;
            if (character == "Warrior") {
                player = new Warrior();   
            }
            else if (character == "Archer")
            {
                player = new Archer();
            }
            else if (character == "Mage")
            {
                player = new Mage();
            }
            return player;
        }
        new public Person getEnemy()
        {
            Person enemy = null;
            int enemy_type= rnd.Next(0,1);
            string[] enemies = new string[2] { "Orc", "Skeleton" };
            string type = enemies[enemy_type];
            if (type == "Orc")
            {
                enemy = new Orc();
            }
            else if (type == "Skeleton")
            {
                enemy = new Skeleton();
            }
            return enemy;
        }

        new public string good_end()
        {
            string messageBoxText = "Вы сразили врага и очистили подземелье,\nпоздравляю с победой";
            string caption = "Победа";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            string win_text = "Вы сразили врага и очистили подземелье,\nпоздравляю с победой";
            return win_text;
        }

        new public string bad_end()
        {
            string messageBoxText = "Ваш противник был сильнее и победа \nосталась за ним, теперь в мире \nвоцарится хаос и разрушение. Ура";
            string caption = "Поражение";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            string lose_text = "Ваш противник был сильнее и победа \nосталась за ним, теперь в мире \nвоцарится хаос и разрушение. Ура";
            return lose_text;
        }
        new public int getDist()
        {
            dist = rnd.Next(1, 11);
            return dist;
        }
        new public string enemy_turn(int dist, Person enemy)
        {
            if (dist > enemy.range)
            {
                return "move";
            }
            else 
            {
                return "attack";
            };
        }
        
        //new public createField() { 
            
        
        
       // }
    }
}
