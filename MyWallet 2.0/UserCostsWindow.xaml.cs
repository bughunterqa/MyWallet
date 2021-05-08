using Microsoft.Data.Sqlite;
using MyWallet_2._0.Helpers;
using MyWallet_2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Globalization;
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

namespace MyWallet_2._0
{

    public partial class UserCostsWindow : Window
    {
        public UserCostsWindow()
        {
            InitializeComponent();


        }


        private void Button_Send(object sender, RoutedEventArgs e)
        {
            double amountSpent;
            if (textBoxForSpent.Text != "")
            {
                amountSpent = Convert.ToDouble(textBoxForSpent.Text.Trim());
            }
            else
            {
                MessageBox.Show("Введите сумму!");
                return;
            }


            string getCategoryId;
            if (listOfCategories.SelectedIndex > -1)
            {
                getCategoryId = listOfCategories.SelectedItems[0].ToString();
            }
            else
            {
                MessageBox.Show("Выберите категорию!");
                return;
            }


            string getComment = textBoxForComments.Text.Trim();
            string getBill = listOfUsers.Text.ToString();

            UserSpend userSpend = new UserSpend(amountSpent, Convert.ToInt32(getCategoryId), getComment);

            

            using (ApplicationContext context = new ApplicationContext())
            {
                DB db = new DB();


                SQLiteCommand command = new SQLiteCommand("UPDATE Totals SET totalMoney = totalMoney - @amountSpent WHERE billName = @billName", db.getConnection());
                command.Parameters.Add("@amountSpent", DbType.Double).Value = amountSpent;
                command.Parameters.Add("@billName", DbType.String).Value = getBill;

                db.openConnection();

                command.ExecuteNonQuery();

                int index = listOfUsers.SelectedIndex;
                List<Total> total = context.Totals.ToList();
                listOfUsers.ItemsSource = total;
                listOfUsers.SelectedIndex = index;


                context.UserSpends.Add(userSpend);
                context.SaveChanges();

                textBoxForSpent.Clear();
                listOfCategories.UnselectAll();
                textBoxForComments.Clear();
            }


            using (ApplicationContext context = new ApplicationContext())
            {
                List<UserSpend> userSpends = context.UserSpends
                   .Include(c => c.Category)
                   .ToList();

                historySpend.ItemsSource = userSpends;



                new Sorting().SortDesc(historySpend);

               
            }
               




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<Total> total = context.Totals.ToList();
                listOfUsers.ItemsSource = total;


                List<Category> categories = context.Categories.ToList();
                listOfCategories.ItemsSource = categories.Take(10);

                List<UserSpend> userSpends = context.UserSpends
               .Include(c => c.Category)
               .ToList();
                historySpend.ItemsSource = userSpends;
             
                new Sorting().SortDesc(historySpend);


            }
        }

        private void Button_All_Categories(object sender, RoutedEventArgs e)
        {

        }



        private void textBoxForSpent_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!textBoxForSpent.Text.Contains(".")
               && textBoxForSpent.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void textBoxForSpent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBoxForSpent.Clear();
        }

        private void btnIncome_Click(object sender, RoutedEventArgs e)
        {
            UserIncomeWindow userIncomeWindow = new UserIncomeWindow();
            userIncomeWindow.Show();
            this.Hide();

        }

        private void Go_To_Transfers(object sender, RoutedEventArgs e)
        {
            UserTransfersWindow userTransfersWindow = new UserTransfersWindow();
            userTransfersWindow.Show();
            Hide();
        }

        private void Go_to_Statistics(object sender, RoutedEventArgs e)
        {
            StatisticCostsWindow statisticCostsWindow = new StatisticCostsWindow();
            statisticCostsWindow.Show();
            this.Hide();
        }
    }
}
