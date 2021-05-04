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
using System.Windows.Media.Animation;

namespace MyWallet_2._0
{ 

    public partial class MainWindow : Window
    {
        ApplicationContext db;


        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(5);
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation);

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.ToLower().Trim();

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле заполнено некоректно";
                textBoxLogin.BorderBrush = Brushes.DarkRed;
            }

            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле заполнено некоректно";
                passBox.BorderBrush = Brushes.DarkRed;
            }

            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Это поле заполнено некоректно";
                passBox_2.BorderBrush = Brushes.DarkRed;
            }

            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле заполнено некоректно";
                textBoxEmail.BorderBrush = Brushes.DarkRed;
            }

            else
            {
                textBoxLogin.ToolTip = null;
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = null;
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = null;
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = null;
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Пользователь успешно зарегистрирован!");
                User user = new User(login, email, pass);


                db.Users.Add(user);
                db.SaveChanges();


                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}






/*
public MainWindow()
{
    InitializeComponent();

    db = new ApplicationContext();

    List<User> users = db.Users.ToList();
    string str = "";
    foreach (User user in users)
        str += "Login: " + user.Login + " | ";

    example.Text = str;
}*/


               /* < TextBlock x: Name = "example" FontWeight = "Bold" Margin = "0 0 0 20" />*/