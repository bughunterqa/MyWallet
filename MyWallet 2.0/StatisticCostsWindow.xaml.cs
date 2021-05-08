using Microsoft.Data.Sqlite;
using MyWallet_2._0.Helpers;
using MyWallet_2._0.Models;
using NPOI.SS.Formula.Functions;
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

    public partial class StatisticCostsWindow : Window
    {
        public StatisticCostsWindow()
        {
            InitializeComponent();

        }

        private void Back_to_Costs(object sender, RoutedEventArgs e)
        {
            UserCostsWindow userCostsWindow = new UserCostsWindow();
            userCostsWindow.Show();
            Hide();
        }

        private void Go_to_StatisticIncome(object sender, RoutedEventArgs e)
        {

        }

        private void comboBoxForCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        
        {
            int getCategoryId;
            if (comboBoxForCategories.SelectedIndex > -1)
            {
                getCategoryId = Convert.ToInt32(comboBoxForCategories.SelectedItem.ToString()) ;
                using (ApplicationContext context = new ApplicationContext())
                {
                    List<UserSpend> userSpend = null;
                    userSpend = context.UserSpends.Where(b => b.CategoryId == getCategoryId).ToList();

                    historyByCategory.ItemsSource = userSpend.Take(100);

                    new Sorting().SortDesc(historyByCategory);
                }
            }
            else
                return;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<Category> categories = context.Categories.ToList();

                comboBoxForCategories.ItemsSource = categories;


                new StatisticsByDay().ByDay(historyByDate);


            }
            
            new Sorting().SortDescAmount(historyByDate);
        }

        private void Button_Click_By_Day(object sender, RoutedEventArgs e)
        {
            historyByDate.Items.Clear();
            new StatisticsByDay().ByDay(historyByDate);
            new Sorting().SortDescAmount(historyByDate);
            
        }

        private void Button_Click_By_Month(object sender, RoutedEventArgs e)
        {
            historyByDate.Items.Clear();
            new StatisticsByDay().ByMonth(historyByDate);
            new Sorting().SortDescAmount(historyByDate);



        }

        private void Button_Click_By_Year(object sender, RoutedEventArgs e)
        {
            historyByDate.Items.Clear();
            new StatisticsByDay().ByYear(historyByDate);
            new Sorting().SortDescAmount(historyByDate);
        }
    }



}
