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

namespace OOP2_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person player;
        int choose_width = 100;
        int choose_height = 30;

        string[] choose_list = new string[] { "Warrior", "Archer", "Mage" };
        Button[] choose_buttons = new Button[3];
        string[] action_list = new string[] { "Приблизиться", "Атаковать", "Отсутпить" };
        Button[] action_buttons = new Button[3];
        string failed_attack_text = "Вы пытаетесь атаковать противника,\nно промахиваетесь. Противник слишком далеко.";
        string backward_text = "Выделаете шаг назад";
        string forward_text = "Вы делаете шаг вперед";
            
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_button_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel choose_panel = new WrapPanel();
            int choose_panel_width = choose_width * 3;
            int choose_panel_height = choose_height;
            choose_panel.Width = choose_panel_width;
            choose_panel.Height = choose_panel_height;
            choose_panel.VerticalAlignment = VerticalAlignment.Center;
            choose_panel.HorizontalAlignment = HorizontalAlignment.Center;
            Label choose_label = new Label();
            choose_label.Content = "Выберите класс";
            choose_label.HorizontalAlignment = HorizontalAlignment.Center;
            choose_label.VerticalAlignment = VerticalAlignment.Top;
            choose_label.FontSize = 30;
            game_panel.Children.Add(choose_label);
            game_panel.Children.Add(choose_panel);
            for (int i = 0; i < choose_list.Length; i++)
            {
                choose_buttons[i] = new Button();
                choose_buttons[i].Content = choose_list[i];
                choose_buttons[i].Name = choose_list[i];
                choose_buttons[i].Width = choose_width;
                choose_buttons[i].Height = choose_height;
                choose_panel.Children.Add(choose_buttons[i]);
            }
            start.VerticalAlignment = VerticalAlignment.Bottom;
            start.HorizontalAlignment = HorizontalAlignment.Left;
            start.Content = "Начать заново";
            start.Margin = new Thickness(5);

            foreach (Button button in choose_buttons)
            {
                button.Click += (b, eArgs) =>
                {

                    game_panel.Children.Clear();
                    //WrapPanel text_panel = new WrapPanel();
                    //text_panel.Width = 200;
                    //text_panel.Height = 200;
                    Game game = new Game();
                    player = game.start(button.Content.ToString());
                    //while (player.getHealth() > 0)
                    //{
                    TextBlock text_block = new TextBlock();
                    //text_block.Width = 200;
                    //text_block.Height = 200;
                    text_block.HorizontalAlignment = HorizontalAlignment.Center;
                    text_block.VerticalAlignment = VerticalAlignment.Top;
                    Person enemy = game.getEnemy();
                    int dist = game.getDist();
                    text_block.Text = "Вы продвигаетесь по пещере, \nвпереди вы замечаете " + enemy.name + " \nна расстоянии " + dist + " метров. \nЧто будете делать?";
                    string attack_text = "Вы мастерски используете свои умения и \nнаносите противнику " + player.damage + " урона, он явно слабеет";
                    string status_text = "\nВы на расстоянии " + dist + "\nот врага, у вас " + player.getHealth() + " очков здоровья\nУ вашего противника " + enemy.getHealth();
                    game_panel.Children.Add(text_block);
                    WrapPanel action_panel = new WrapPanel();
                    int action_panel_width = choose_width * 3;
                    int action_panel_height = choose_height;
                    action_panel.Width = choose_panel_width;
                    action_panel.Height = choose_panel_height;
                    action_panel.VerticalAlignment = VerticalAlignment.Center;
                    action_panel.HorizontalAlignment = HorizontalAlignment.Center;
                    Label action_label = new Label();
                    action_label.Content = "Выберите действие";
                    action_label.HorizontalAlignment = HorizontalAlignment.Center;
                    action_label.VerticalAlignment = VerticalAlignment.Center;
                    action_label.FontSize = 30;
                    game_panel.Children.Add(action_label);
                    game_panel.Children.Add(action_panel);
                    for (int i = 0; i < action_list.Length; i++)
                    {
                        action_buttons[i] = new Button();
                        action_buttons[i].Content = action_list[i];
                        action_buttons[i].Name = action_list[i];
                        action_buttons[i].Width = choose_width;
                        action_buttons[i].Height = choose_height;
                        action_panel.Children.Add(action_buttons[i]);
                    }
                    foreach (Button button1 in action_buttons)
                    {
                        button1.Click += (bb, eeArgs) =>
                        {
                            if (button1.Name == "Атаковать")
                            {
                                int damage = player.attack(dist);
                                if (damage > 0)
                                {
                                    enemy.health -= damage;
                                    if (enemy.isAlive())
                                    {
                                        text_block.Text = attack_text;
                                        //text_block.Text += "\nВы на расстоянии " + dist + "\nот врага, у вас " + player.getHealth() + " очков здоровья\nУ вашего противника " + enemy.getHealth();

                                    }
                                    else
                                    {
                                        text_block.Text = game.good_end();
                                        this.Close();

                                    }
                                }
                                else
                                {
                                    text_block.Text = failed_attack_text;
                                   // text_block.Text += "\nВы на расстоянии " + dist + "\nот врага, у вас " + player.getHealth() + " очков здоровья\nУ вашего противника " + enemy.getHealth();


                                }
                                string turn = game.enemy_turn(dist, enemy);
                                if (turn == "attack")
                                {
                                    player.health -= enemy.damage;
                                    text_block.Text += "\nВраг атакует, вы ранены";
                                    text_block.Text += "\nВы на расстоянии " + dist + "\nот врага, у вас " + player.getHealth() + " очков здоровья\nУ вашего противника " + enemy.getHealth();
                                    if (!player.isAlive())
                                    {
                                        game.bad_end();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    dist -= enemy.speed;
                                    text_block.Text += "\nВраг сокращает дистанцию";
                                    text_block.Text += "\nВы на расстоянии " + dist + "\nот врага, у вас " + player.getHealth() + " очков здоровья\nУ вашего противника " + enemy.getHealth();
                                }
                            }
                            else if (button1.Name == "Приблизиться")
                            {
                                dist -= player.move();
                                if (dist < 1)
                                {
                                    dist = 1;
                                }
                                text_block.Text = forward_text;
                                string turn = game.enemy_turn(dist, enemy);
                                if (turn == "attack")
                                {
                                    player.health -= enemy.damage;
                                    text_block.Text += "\nВраг атакует, вы ранены";
                                    if (!player.isAlive())
                                    {
                                        game.bad_end();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    dist -= enemy.speed;
                                    text_block.Text += "\nВраг сокращает дистанцию";
                                    // text_block.Text += "\nВы на расстоянии " + dist + "\nот врага, у вас " + player.getHealth() + " очков здоровья\nУ вашего противника " + enemy.getHealth(); ;
                                }
                            }
                                
                                
                            else if (button1.Name == "Отступить")
                            {
                                dist += player.move();
                                text_block.Text = backward_text;
                                string turn = game.enemy_turn(dist, enemy);
                                if (turn == "attack")
                                {
                                    player.health -= enemy.damage;
                                    text_block.Text += "\nВраг атакует, вы ранены";
                                    if (!player.isAlive())
                                    {
                                        game.bad_end();
                                        this.Close();

                                    }
                                }
                                else
                                {
                                    dist -= enemy.speed;
                                    text_block.Text += "\nВраг сокращает дистанцию";
                                }
                                text_block.Text += "\nВы на расстоянии " + dist + "\nот врага, у вас " + player.getHealth() + " очков здоровья\nУ вашего противника " + enemy.getHealth();
                            }

                        };
                    };
                };

            }
        }
            
    }
}
