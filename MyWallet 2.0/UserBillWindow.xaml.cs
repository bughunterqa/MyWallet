using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;

namespace MyWallet_2._0
{

    public partial class UserBillWindow : Window
    {
        public UserBillWindow()
        {
            InitializeComponent();
        }





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<Total> total = context.Totals.ToList();
                listOfBill.ItemsSource = total;
            }
        }

        private void Create_Bill(object sender, RoutedEventArgs e)
        {
            string nameBill;
            if (textBoxForName.Text != "")
            {
                nameBill = textBoxForName.Text.Trim();
            }
            else
            {
                MessageBox.Show("Введите Название!");
                return;
            }


            double amount;
            if (textBoxForAmount.Text != "")
            {
                amount = Convert.ToDouble(textBoxForAmount.Text.Trim());
            }
            else
            {
                MessageBox.Show("Выберите сумму!");
                return;
            }

            if(testNew.Content.ToString() == "Создать счёт")
            {
                Total totals = new Total(amount, nameBill);

                using (ApplicationContext context = new ApplicationContext())
                {
                    context.Totals.Add(totals);
                    context.SaveChanges();

                    List<Total> total = context.Totals.ToList();
                    listOfBill.ItemsSource = total;
                }

                textBoxForName.Clear();
                textBoxForAmount.Clear();
            }
            else
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    string getBill = listOfBill.SelectedItems[0].ToString();

                    DB db = new DB();

                    SQLiteCommand command = new SQLiteCommand("UPDATE Totals SET totalMoney = @amount  WHERE billName = @locator ", db.getConnection());
                    command.Parameters.Add("@amount", DbType.Double).Value = amount;
                    command.Parameters.Add("@name", DbType.String).Value = nameBill;
                    command.Parameters.Add("@locator", DbType.String).Value = getBill;

                    db.openConnection();

                    command.ExecuteNonQuery();

                    List<Total> total = context.Totals.ToList();
                    listOfBill.ItemsSource = total;
                }
            }



           

        }

        private void Go_To_Transfers(object sender, RoutedEventArgs e)
        {
            UserTransfersWindow userTransfersWindow = new UserTransfersWindow();
            userTransfersWindow.Show();
            Hide();
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string getBill;
            if (listOfBill.SelectedIndex > -1)
            {
                getBill = listOfBill.SelectedItems[0].ToString();
            }
            else
            {
                MessageBox.Show("Сперва кликните на Счёт которые хотите изменить, а после - на значёк редактирования");
                return;
            }

            testNew.Content = "Изменить";
            testNew.Background = Brushes.LightSeaGreen;

            gridBill.Visibility = Visibility.Visible;
            backBtn.Visibility = Visibility.Hidden;
            createBtn.Visibility = Visibility.Visible;




        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            createBtn.Visibility = Visibility.Hidden;
            backBtn.Visibility = Visibility.Visible;
            backBtn.Background = Brushes.LightCoral;

            testNew.Content = "Создать счёт";
            testNew.Background = Brushes.LightSeaGreen;
            gridBill.Visibility = Visibility.Visible;

        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            backBtn.Visibility = Visibility.Hidden;
            createBtn.Visibility = Visibility.Visible;
            gridBill.Visibility = Visibility.Collapsed;
            
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string name;
            if (textBoxForName.Text != "")
            {
                name = textBoxForName.Text.Trim();
            }
            else
            {

                name = listOfBill.SelectedItem.ToString();
            }


            string amount;
            if (textBoxForAmount.Text != "")
            {
                amount = textBoxForAmount.Text.Trim();
            }
            else
            {
                MessageBox.Show("Введите сумму!");
                return;
            }



            using (ApplicationContext context = new ApplicationContext())
            {
                DB db = new DB();

                SQLiteCommand command = new SQLiteCommand("UPDATE Totals SET totalMoney = @amount AND billName = @name WHERE  ", db.getConnection());
                command.Parameters.Add("@amount", DbType.Int32).Value = amount;
                command.Parameters.Add("@name", DbType.String).Value = name;


                List<Total> total = context.Totals.ToList();
                listOfBill.ItemsSource = total;
            }



        }

    }
}